namespace FaraMedia.Web.Framework.Mvc {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Web.Mvc;

    using FaraMedia.Core.Sanitization;
    using FaraMedia.Web.Framework.Mvc.Models;

    public sealed class FaraModelBinder : DefaultModelBinder {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {
            var model = base.BindModel(controllerContext, bindingContext);

            var modelBase = model as ModelBase;

            if (modelBase != null)
                modelBase.BindModel(controllerContext, bindingContext);

            return model;
        }

        protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor) {
            var fullPropertyKey = CreateSubPropertyName( propertyDescriptor.Name);

            if (!bindingContext.ValueProvider.ContainsPrefix(fullPropertyKey))
                return;

            var propertyBinder = Binders.GetBinder(propertyDescriptor.PropertyType);
            var originalPropertyValue = propertyDescriptor.GetValue(bindingContext.Model);
            var propertyMetadata = bindingContext.PropertyMetadata[propertyDescriptor.Name];
            propertyMetadata.Model = originalPropertyValue;

            var innerBindingContext = new ModelBindingContext {
                ModelMetadata = propertyMetadata,
                ModelName = fullPropertyKey,
                ModelState = bindingContext.ModelState,
                ValueProvider = bindingContext.ValueProvider
            };

            var newPropertyValue = GetPropertyValue(controllerContext, innerBindingContext, propertyDescriptor, propertyBinder);
            propertyMetadata.Model = newPropertyValue;

            var modelState = bindingContext.ModelState[fullPropertyKey];
            if (modelState == null || modelState.Errors.Count == 0) {
                if (OnPropertyValidating(controllerContext, bindingContext, propertyDescriptor, newPropertyValue)) {
                    SetProperty(controllerContext, bindingContext, propertyDescriptor, newPropertyValue);
                    OnPropertyValidated(controllerContext, bindingContext, propertyDescriptor, newPropertyValue);
                }
            } else {
                SetProperty(controllerContext, bindingContext, propertyDescriptor, newPropertyValue);

                foreach (var modelError in modelState.Errors.Where(me => string.IsNullOrEmpty(me.ErrorMessage) && me.Exception != null).ToList()) {
                    for (var exception = modelError.Exception; exception != null; exception = exception.InnerException) {
                        if (exception is FormatException) {
                            var displayName = propertyMetadata.GetDisplayName();
                            var errorMessageTemplate = GetValueInvalidResource(controllerContext);
                            var errorMessage = String.Format(CultureInfo.CurrentCulture, errorMessageTemplate, modelState.Value.AttemptedValue, displayName);
                            modelState.Errors.Remove(modelError);
                            modelState.Errors.Add(errorMessage);
                            break;
                        }
                    }
                }
            }
        }

        protected override void OnModelUpdated(ControllerContext controllerContext, ModelBindingContext bindingContext) {
            var startedValid = new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase);

            foreach (var validationResult in ModelValidator.GetModelValidator(bindingContext.ModelMetadata, controllerContext).Validate(null)) {
                var subPropertyName = CreateSubPropertyName(bindingContext.ModelType.Name, validationResult.MemberName);

                if (!startedValid.ContainsKey(subPropertyName))
                    startedValid[subPropertyName] = bindingContext.ModelState.IsValidField(subPropertyName);

                if (startedValid[subPropertyName])
                    bindingContext.ModelState.AddModelError(subPropertyName, validationResult.Message);
            }
        }

        protected override void SetProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor, object value) {
            var propertyMetadata = bindingContext.PropertyMetadata[propertyDescriptor.Name];
            propertyMetadata.Model = value;
            var modelStateKey = CreateSubPropertyName(bindingContext.ModelType.Name, propertyMetadata.PropertyName);

            if (value == null && bindingContext.ModelState.IsValidField(modelStateKey)) {
                var requiredValidator = ModelValidatorProviders.Providers.GetValidators(propertyMetadata, controllerContext).FirstOrDefault(v => v.IsRequired);
                if (requiredValidator != null) {
                    foreach (var validationResult in requiredValidator.Validate(bindingContext.Model))
                        bindingContext.ModelState.AddModelError(modelStateKey, validationResult.Message);
                }
            }

            var isNullValueOnNonNullableType = value == null && !TypeAllowsNullValue(propertyDescriptor.PropertyType);

            if (!propertyDescriptor.IsReadOnly && !isNullValueOnNonNullableType) {
                try {
                    propertyDescriptor.SetValue(bindingContext.Model, value);
                } catch (Exception exception) {
                    if (bindingContext.ModelState.IsValidField(modelStateKey))
                        bindingContext.ModelState.AddModelError(modelStateKey, exception);
                }
            }

            if (isNullValueOnNonNullableType && bindingContext.ModelState.IsValidField(modelStateKey))
                bindingContext.ModelState.AddModelError(modelStateKey, GetValueRequiredResource(controllerContext));
        }

        protected override PropertyDescriptorCollection GetModelProperties(ControllerContext controllerContext, ModelBindingContext bindingContext) {
            bindingContext.PropertyFilter = pf => true;

            var modelProperties = base.GetModelProperties(controllerContext, bindingContext);

            return modelProperties;
        }

        private static string CreateSubPropertyName(string propertyName) {
            propertyName = Sanitizer.Slug(propertyName);
            
            return propertyName;
        }

        private static string GetUserResourceString(ControllerContext controllerContext, string resourceName) {
            string result = null;

            if (!string.IsNullOrEmpty(ResourceClassKey) && (controllerContext != null) && (controllerContext.HttpContext != null))
                result = controllerContext.HttpContext.GetGlobalResourceObject(ResourceClassKey, resourceName, CultureInfo.CurrentUICulture) as string;

            return result;
        }

        private static bool TypeAllowsNullValue(Type type) {
            return (!type.IsValueType || IsNullableValueType(type));
        }

        private static bool IsNullableValueType(Type type) {
            return Nullable.GetUnderlyingType(type) != null;
        }

        private static string GetValueInvalidResource(ControllerContext controllerContext) {
            return GetUserResourceString(controllerContext, "PropertyValueInvalid");
        }

        private static string GetValueRequiredResource(ControllerContext controllerContext) {
            return GetUserResourceString(controllerContext, "PropertyValueRequired");
        }
    }
}