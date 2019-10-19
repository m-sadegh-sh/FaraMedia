namespace FaraMedia.Web.Framework.Mvc.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Linq;
    using System.Globalization;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    using System.Web.Routing;

    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Core.Routing;
    using FaraMedia.Core.Sanitization;
    using FaraMedia.Services.Helpers;
    using FaraMedia.Services.Systematic;
    using FaraMedia.Web.Framework.Mvc.Attributes;

    public sealed class GenericCustomHelper<TModel> : CustomHelper {
        private readonly HtmlHelper<TModel> _htmlHelper;

        public GenericCustomHelper(HtmlHelper<TModel> htmlHelper) : base(htmlHelper) {
            _htmlHelper = htmlHelper;
        }

        public MvcHtmlString EditorFor<TProperty>(Expression<Func<TModel, TProperty>> expression, string expressionTypeName = null) {
            if (expression == null)
                throw new ArgumentNullException("expression");

            if (string.IsNullOrEmpty(expressionTypeName))
                expressionTypeName = GetExpressionTypeName(expression);

            return _htmlHelper.EditorFor(expression, new {
                expressionTypeName
            });
        }

        public MvcHtmlString DropDownListFor<TProperty>(Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel = null, object htmlAttributes = null, string expressionTypeName = null) {
            if (expression == null)
                throw new ArgumentNullException("expression");

            var modelMetadata = ModelMetadata.FromLambdaExpression(expression, _htmlHelper.ViewData);
            var expressionText = GetExpressionText(expression);

            if (string.IsNullOrEmpty(expressionTypeName))
                expressionTypeName = GetExpressionTypeName(expression);

            Func<MvcHtmlString> dropDownGenerator = () => DropDownListHelper(modelMetadata, expressionText, selectList, optionLabel, htmlAttributes, expressionTypeName);

            return ControlHelper(expression, dropDownGenerator, expressionTypeName);
        }

        private MvcHtmlString DropDownListHelper(ModelMetadata modelMetadata, string expression, IEnumerable<SelectListItem> selectList, string optionLabel, object htmlAttributes, string expressionTypeName = null) {
            return SelectInternal(modelMetadata, optionLabel, expression, selectList, false, htmlAttributes, expressionTypeName);
        }

        public MvcHtmlString ListBoxFor<TProperty>(Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes = null, string expressionTypeName = null) {
            if (expression == null)
                throw new ArgumentNullException("expression");

            var modelMetadata = ModelMetadata.FromLambdaExpression(expression, _htmlHelper.ViewData);
            var expressionText = GetExpressionText(expression);

            if (string.IsNullOrEmpty(expressionTypeName))
                expressionTypeName = GetExpressionTypeName(expression);

            Func<MvcHtmlString> listBoxGenerator = () => ListBoxHelper(modelMetadata, expressionText, selectList, htmlAttributes, expressionTypeName);

            return ControlHelper(expression, listBoxGenerator, expressionTypeName);
        }

        private MvcHtmlString ListBoxHelper(ModelMetadata modelMetadata, string expression, IEnumerable<SelectListItem> selectList, object htmlAttributes, string expressionTypeName = null) {
            return SelectInternal(modelMetadata, null, expression, selectList, true, htmlAttributes, expressionTypeName);
        }

        public MvcHtmlString CheckBoxFor<TProperty>(Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null, string expressionTypeName = null) {
            var modelMetadata = ModelMetadata.FromLambdaExpression(expression, _htmlHelper.ViewData);
            var expressionText = GetExpressionText(expression);

            if (string.IsNullOrEmpty(expressionTypeName))
                expressionTypeName = GetExpressionTypeName(expression);

            bool? isChecked = null;
            if (modelMetadata.Model != null) {
                bool modelChecked;
                if (Boolean.TryParse(modelMetadata.Model.ToString(), out modelChecked))
                    isChecked = modelChecked;
            }

            Func<MvcHtmlString> checkBoxGenerator = () => CheckBoxHelper(modelMetadata, expressionText, isChecked, htmlAttributes, expressionTypeName);

            return CheckBoxHelper(expression, checkBoxGenerator, expressionTypeName);
        }

        private MvcHtmlString CheckBoxHelper(ModelMetadata modelMetadata, string name, bool? isChecked, object htmlAttributes, string expressionTypeName = null) {
            var attributes = RouteValueDictionaryExtensions.Convert(htmlAttributes);

            var explicitValue = isChecked.HasValue;
            if (explicitValue)
                attributes.Remove("checked");

            return InputHelper(InputType.CheckBox, modelMetadata, name, "true", !explicitValue, isChecked ?? false, true, false, htmlAttributes, expressionTypeName);
        }

        public MvcHtmlString HiddenFor<TProperty>(Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null, string expressionTypeName = null) {
            var modelMetadata = ModelMetadata.FromLambdaExpression(expression, _htmlHelper.ViewData);
            var expressionText = GetExpressionText(expression);

            if (string.IsNullOrEmpty(expressionTypeName))
                expressionTypeName = GetExpressionTypeName(expression);

            return HiddenHelper(modelMetadata, modelMetadata.Model, false, expressionText, htmlAttributes, expressionTypeName);
        }

        private MvcHtmlString HiddenHelper(ModelMetadata modelMetadata, object value, bool useViewData, string expression, object htmlAttributes, string expressionTypeName = null) {
            var binaryValue = value as Binary;
            if (binaryValue != null)
                value = binaryValue.ToArray();

            var byteArrayValue = value as byte[];
            if (byteArrayValue != null)
                value = Convert.ToBase64String(byteArrayValue);

            return InputHelper(InputType.Hidden, modelMetadata, expression, value, useViewData, false, true, true, htmlAttributes, expressionTypeName);
        }

        public MvcHtmlString PasswordFor<TProperty>(Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null, string expressionTypeName = null) {
            if (expression == null)
                throw new ArgumentNullException("expression");

            var modelMetadata = ModelMetadata.FromLambdaExpression(expression, _htmlHelper.ViewData);
            var expressionText = GetExpressionText(expression);

            if (string.IsNullOrEmpty(expressionTypeName))
                expressionTypeName = GetExpressionTypeName(expression);

            var placeholder = HintsText(modelMetadata);
            var attributes = RouteValueDictionaryExtensions.Convert(htmlAttributes);
            attributes.Add("placeholder", placeholder);

            Func<MvcHtmlString> passwordGenerator = () => PasswordHelper(modelMetadata, expressionText, null, attributes, expressionTypeName);

            return ControlHelper(expression, passwordGenerator, expressionTypeName);
        }

        private MvcHtmlString PasswordHelper(ModelMetadata modelMetadata, string name, object value, object htmlAttributes, string expressionTypeName = null) {
            return InputHelper(InputType.Password, modelMetadata, name, value, false, false, true, true, htmlAttributes, expressionTypeName);
        }

        public MvcHtmlString RadioButtonFor<TProperty>(Expression<Func<TModel, TProperty>> expression, object value, object htmlAttributes = null, string expressionTypeName = null) {
            var modelMetadata = ModelMetadata.FromLambdaExpression(expression, _htmlHelper.ViewData);
            var expressionText = GetExpressionText(expression);

            if (string.IsNullOrEmpty(expressionTypeName))
                expressionTypeName = GetExpressionTypeName(expression);

            Func<MvcHtmlString> radioButtonGenerator = () => RadioButtonHelper(modelMetadata, modelMetadata.Model, expressionText, value, null, htmlAttributes, expressionTypeName);

            return ControlHelper(expression, radioButtonGenerator, expressionTypeName);
        }

        private MvcHtmlString RadioButtonHelper(ModelMetadata modelMetadata, object model, string name, object value, bool? isChecked, object htmlAttributes, string expressionTypeName = null) {
            if (value == null)
                throw new ArgumentNullException("value");

            var attributes = RouteValueDictionaryExtensions.Convert(htmlAttributes);

            var explicitValue = isChecked.HasValue;
            if (explicitValue)
                attributes.Remove("checked");
            else {
                var valueString = Convert.ToString(value, CultureInfo.CurrentCulture);
                isChecked = model != null && !string.IsNullOrEmpty(name) && string.Equals(model.ToString(), valueString, StringComparison.OrdinalIgnoreCase);
            }

            return InputHelper(InputType.Radio, modelMetadata, name, value, false, isChecked ?? false, true, true, htmlAttributes, expressionTypeName);
        }

        public MvcHtmlString DatePickerFor<TDayProperty, TMonthProperty, TYearProperty>(Expression<Func<TModel, TDayProperty>> dayExpression, Expression<Func<TModel, TMonthProperty>> monthExpression, Expression<Func<TModel, TYearProperty>> yearExpression, int? beginYearOffset = null, int? endYearOffset = null, int? selectedDay = null, int? selectedMonth = null, int? selectedYear = null, string dayExpressionTypeName = null, string monthExpressionTypeName = null, string yearExpressionTypeName = null) {
            if (dayExpression == null)
                throw new ArgumentNullException("dayExpression");

            if (monthExpression == null)
                throw new ArgumentNullException("monthExpression");

            if (yearExpression == null)
                throw new ArgumentNullException("yearExpression");

            var dayModelMetadata = ModelMetadata.FromLambdaExpression(dayExpression, _htmlHelper.ViewData);
            var dayExpressionText = GetExpressionText(dayExpression);

            var monthModelMetadata = ModelMetadata.FromLambdaExpression(monthExpression, _htmlHelper.ViewData);
            var monthExpressionText = GetExpressionText(monthExpression);

            var yearModelMetadata = ModelMetadata.FromLambdaExpression(yearExpression, _htmlHelper.ViewData);
            var yearExpressionText = GetExpressionText(yearExpression);

            if (string.IsNullOrEmpty(dayExpressionTypeName))
                dayExpressionTypeName = GetExpressionTypeName(dayExpression);

            if (string.IsNullOrEmpty(monthExpressionTypeName))
                dayExpressionTypeName = GetExpressionTypeName(monthExpression);

            if (string.IsNullOrEmpty(yearExpressionTypeName))
                dayExpressionTypeName = GetExpressionTypeName(yearExpression);

            var dateTimeHelper = EngineContext.Current.Resolve<IDateTimeHelper>();

            int beginYear;
            int endYear;

            dateTimeHelper.FormatizeToPersian(ref beginYearOffset, ref endYearOffset, ref selectedYear, ref selectedMonth, ref selectedDay, out beginYear, out endYear);

            var days = new List<SelectListItem>();
            for (var i = 1; i <= 31; i++) {
                days.Add(new SelectListItem {
                    Text = i.ToString(),
                    Value = i.ToString(),
                    Selected = i == selectedDay
                });
            }

            var months = new List<SelectListItem>();
            for (var i = 1; i <= 12; i++) {
                months.Add(new SelectListItem {
                    Text = i.ToString(),
                    Value = i.ToString(),
                    Selected = i == selectedMonth
                });
            }

            var years = new List<SelectListItem>();
            for (var i = beginYear; i <= endYear; i++) {
                years.Add(new SelectListItem {
                    Text = i.ToString(),
                    Value = i.ToString(),
                    Selected = i == selectedYear
                });
            }

            Func<MvcHtmlString> datePickerDropDownListGenerator = () => MvcHtmlString.Create(DropDownListHelper(dayModelMetadata, dayExpressionText, days, HintsText(dayModelMetadata), null, dayExpressionTypeName).ToHtmlString() + DropDownListHelper(monthModelMetadata, monthExpressionText, months, HintsText(monthModelMetadata), null, monthExpressionTypeName).ToHtmlString() + DropDownListHelper(yearModelMetadata, yearExpressionText, years, HintsText(yearModelMetadata), null, yearExpressionTypeName).ToHtmlString());

            return ControlHelper(dayExpression, datePickerDropDownListGenerator, dayExpressionTypeName);
        }

        public MvcHtmlString TextBoxFor<TProperty>(Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null, string expressionTypeName = null) {
            if (expression == null)
                throw new ArgumentNullException("expression");

            var modelMetadata = ModelMetadata.FromLambdaExpression(expression, _htmlHelper.ViewData);
            var expressionText = GetExpressionText(expression);

            if (string.IsNullOrEmpty(expressionTypeName))
                expressionTypeName = GetExpressionTypeName(expression);

            var placeholder = HintsText(modelMetadata);
            var attributes = RouteValueDictionaryExtensions.Convert(htmlAttributes);
            attributes.Add("placeholder", placeholder);

            Func<MvcHtmlString> textBoxGenerator = () => TextBoxHelper(modelMetadata, modelMetadata.Model, expressionText, attributes, expressionTypeName);

            return ControlHelper(expression, textBoxGenerator, expressionTypeName);
        }

        private MvcHtmlString TextBoxHelper(ModelMetadata modelMetadata, object model, string expression, object htmlAttributes, string expressionTypeName = null) {
            return InputHelper(InputType.Text, modelMetadata, expression, model, false, false, true, true, htmlAttributes, expressionTypeName);
        }

        public MvcHtmlString TextAreaFor<TProperty>(Expression<Func<TModel, TProperty>> expression, int rows = 2, int columns = 20, object htmlAttributes = null, string expressionTypeName = null) {
            if (expression == null)
                throw new ArgumentNullException("expression");

            var modelMetadata = ModelMetadata.FromLambdaExpression(expression, _htmlHelper.ViewData);
            var expressionText = GetExpressionText(expression);

            if (string.IsNullOrEmpty(expressionTypeName))
                expressionTypeName = GetExpressionTypeName(expression);

            var placeholder = HintsText(modelMetadata);
            var attributes = RouteValueDictionaryExtensions.Convert(htmlAttributes);
            attributes.Add("placeholder", placeholder);

            Func<MvcHtmlString> textAreaGenerator = () => TextAreaHelper(modelMetadata, expressionText, GetRowsAndColumnsDictionary(rows, columns), attributes, expressionTypeName);

            return ControlHelper(expression, textAreaGenerator, expressionTypeName);
        }

        private MvcHtmlString TextAreaHelper(ModelMetadata modelMetadata, string name, IDictionary<string, object> rowsAndColumns, object htmlAttributes, string expressionTypeName = null) {
            var templateInfo = _htmlHelper.ViewContext.ViewData.TemplateInfo;

            if (!string.IsNullOrEmpty(expressionTypeName))
                templateInfo.HtmlFieldPrefix = expressionTypeName;

            var fullName = templateInfo.GetFullHtmlFieldName(name);

            var textAreaTag = new TagBuilder("textarea");
            textAreaTag.MergeAttribute("id", Sanitizer.Slug(fullName));
            textAreaTag.MergeAttributes(RouteValueDictionaryExtensions.Convert(htmlAttributes), true);
            textAreaTag.MergeAttributes(rowsAndColumns, rowsAndColumns != null);
            textAreaTag.MergeAttribute("name", fullName, true);

            ModelState modelState;

            _htmlHelper.ViewData.ModelState.TryGetValue(fullName, out modelState);

            var unobtrusiveValidationAttributes = _htmlHelper.GetUnobtrusiveValidationAttributes(name);
            textAreaTag.MergeAttributes(unobtrusiveValidationAttributes);

            string value;
            if (modelState != null && modelState.Value != null)
                value = modelState.Value.AttemptedValue;
            else if (modelMetadata.Model != null)
                value = modelMetadata.Model.ToString();
            else
                value = string.Empty;

            textAreaTag.SetInnerText(value);

            return textAreaTag.ToMvcHtmlString(TagRenderMode.Normal);
        }

        private MvcHtmlString SelectInternal(ModelMetadata modelMetadata, string optionLabel, string name, IEnumerable<SelectListItem> selectList, bool allowMultiple, object htmlAttributes, string expressionTypeName = null) {
            var templateInfo = _htmlHelper.ViewContext.ViewData.TemplateInfo;

            if (!string.IsNullOrEmpty(expressionTypeName))
                templateInfo.HtmlFieldPrefix = expressionTypeName;

            var fullName = templateInfo.GetFullHtmlFieldName(name);

            var usedViewData = false;

            if (selectList == null) {
                selectList = GetSelectData(fullName);
                usedViewData = true;
            }

            var defaultValue = allowMultiple ? GetModelStateValue(fullName, typeof (string[])) : GetModelStateValue(fullName, typeof (string));

            if (!usedViewData) {
                if (defaultValue == null)
                    defaultValue = _htmlHelper.ViewData.Eval(fullName);
            }

            if (defaultValue != null) {
                var defaultValues = allowMultiple ? defaultValue as IEnumerable : new[] {defaultValue};
                var values = from object value in defaultValues
                             select Convert.ToString(value, CultureInfo.CurrentCulture);

                var selectedValues = new HashSet<string>(values, StringComparer.OrdinalIgnoreCase);
                var newSelectList = new List<SelectListItem>();

                if (selectList != null) {
                    foreach (var selectListItem in selectList) {
                        selectListItem.Selected = selectListItem.Value != null ? selectedValues.Contains(selectListItem.Value) : selectedValues.Contains(selectListItem.Text);
                        newSelectList.Add(selectListItem);
                    }
                }

                selectList = newSelectList;
            }

            var listItemBuilder = new StringBuilder();

            if (optionLabel != null) {
                listItemBuilder.AppendLine(ListItemToOption(new SelectListItem {
                    Text = optionLabel,
                    Value = string.Empty,
                    Selected = false
                }));
            }

            if (selectList != null) {
                foreach (var item in selectList)
                    listItemBuilder.AppendLine(ListItemToOption(item));
            }

            var tagBuilder = new TagBuilder("select") {
                InnerHtml = listItemBuilder.ToString()
            };

            tagBuilder.MergeAttributes(RouteValueDictionaryExtensions.Convert(htmlAttributes));
            tagBuilder.MergeAttribute("name", fullName, true);
            tagBuilder.MergeAttribute("id", Sanitizer.Slug(fullName));
            if (allowMultiple)
                tagBuilder.MergeAttribute("multiple", "multiple");

            ModelState modelState;

            _htmlHelper.ViewData.ModelState.TryGetValue(fullName, out modelState);

            var unobtrusiveValidationAttributes = _htmlHelper.GetUnobtrusiveValidationAttributes(name, modelMetadata);
            tagBuilder.MergeAttributes(unobtrusiveValidationAttributes);

            return tagBuilder.ToMvcHtmlString(TagRenderMode.Normal);
        }

        private IEnumerable<SelectListItem> GetSelectData(string name) {
            object o = null;

            if (_htmlHelper.ViewData != null)
                o = _htmlHelper.ViewData.Eval(name);

            var selectList = o as IEnumerable<SelectListItem>;

            return selectList;
        }

        private static string ListItemToOption(SelectListItem item) {
            var builder = new TagBuilder("option") {
                InnerHtml = HttpUtility.HtmlEncode(item.Text)
            };

            if (item.Value != null)
                builder.Attributes["value"] = item.Value;

            if (item.Selected)
                builder.Attributes["selected"] = "selected";

            return builder.ToString(TagRenderMode.Normal);
        }

        private MvcHtmlString InputHelper(InputType inputType, ModelMetadata modelMetadata, string name, object value, bool useViewData, bool isChecked, bool setId, bool isExplicitValue, object htmlAttributes, string expressionTypeName = null) {
            var templateInfo = _htmlHelper.ViewContext.ViewData.TemplateInfo;

            if (!string.IsNullOrEmpty(expressionTypeName))
                templateInfo.HtmlFieldPrefix = expressionTypeName;

            var fullName = templateInfo.GetFullHtmlFieldName(name);

            var tagBuilder = new TagBuilder("input");
            tagBuilder.MergeAttributes(RouteValueDictionaryExtensions.Convert(htmlAttributes));
            tagBuilder.MergeAttribute("type", HtmlHelper.GetInputTypeString(inputType));
            tagBuilder.MergeAttribute("name", fullName, true);

            var valueParameter = Convert.ToString(value, CultureInfo.CurrentCulture);
            var usedModelState = false;

            switch (inputType) {
                case InputType.CheckBox:
                    var modelStateWasChecked = GetModelStateValue(fullName, typeof (bool)) as bool?;
                    if (modelStateWasChecked.HasValue) {
                        isChecked = modelStateWasChecked.Value;
                        usedModelState = true;
                    }
                    goto case InputType.Radio;
                case InputType.Radio:
                    if (!usedModelState) {
                        var modelStateValue = GetModelStateValue(fullName, typeof (string)) as string;
                        if (modelStateValue != null) {
                            isChecked = string.Equals(modelStateValue, valueParameter, StringComparison.Ordinal);
                            usedModelState = true;
                        }
                    }
                    if (!usedModelState && useViewData)
                        isChecked = EvalBoolean(fullName);
                    if (isChecked)
                        tagBuilder.MergeAttribute("checked", "checked");
                    tagBuilder.MergeAttribute("value", valueParameter, isExplicitValue);
                    break;
                case InputType.Password:
                    if (value != null)
                        tagBuilder.MergeAttribute("value", valueParameter, isExplicitValue);
                    break;
                default:
                    var attemptedValue = (string) GetModelStateValue(fullName, typeof (string));
                    tagBuilder.MergeAttribute("value", attemptedValue ?? ((useViewData) ? EvalString(fullName) : valueParameter), isExplicitValue);
                    break;
            }

            if (setId)
                tagBuilder.MergeAttribute("id", Sanitizer.Slug(fullName));

            ModelState modelState;

            _htmlHelper.ViewData.ModelState.TryGetValue(fullName, out modelState);

            var unobtrusiveValidationAttributes = _htmlHelper.GetUnobtrusiveValidationAttributes(name, modelMetadata);
            tagBuilder.MergeAttributes(unobtrusiveValidationAttributes);

            if (inputType == InputType.CheckBox) {
                var inputItemBuilder = new StringBuilder();
                inputItemBuilder.Append(tagBuilder.ToString(TagRenderMode.SelfClosing));

                var hiddenInput = new TagBuilder("input");
                hiddenInput.MergeAttribute("type", HtmlHelper.GetInputTypeString(InputType.Hidden));
                hiddenInput.MergeAttribute("name", fullName);
                hiddenInput.MergeAttribute("value", "false");
                inputItemBuilder.Append(hiddenInput.ToString(TagRenderMode.SelfClosing));
                return MvcHtmlString.Create(inputItemBuilder.ToString());
            }

            return tagBuilder.ToMvcHtmlString(TagRenderMode.SelfClosing);
        }

        private MvcHtmlString LabelFor<TValue>(Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, string expressionTypeName = null) {
            var modelMetadata = ModelMetadata.FromLambdaExpression(expression, _htmlHelper.ViewData);
            var expressionText = GetExpressionText(expression);
            var labelText = LabelText(modelMetadata, expressionText);

            if (string.IsNullOrEmpty(labelText))
                return MvcHtmlString.Empty;

            if (string.IsNullOrEmpty(expressionTypeName))
                expressionTypeName = GetExpressionTypeName(expression);

            var templateInfo = _htmlHelper.ViewContext.ViewData.TemplateInfo;

            if (!string.IsNullOrEmpty(expressionTypeName))
                templateInfo.HtmlFieldPrefix = expressionTypeName;

            var @for = templateInfo.GetFullHtmlFieldId(expressionText);

            var labelTag = new TagBuilder("label");
            labelTag.MergeAttributes(RouteValueDictionaryExtensions.Convert(htmlAttributes));
            labelTag.Attributes.Add("for", Sanitizer.Slug(@for));
            labelTag.SetInnerText(labelText);

            return MvcHtmlString.Create(labelTag.ToString(TagRenderMode.Normal));
        }

        private static string LabelText(ModelMetadata modelMetadata, string expressionText) {
            var labelText = modelMetadata.DisplayName ?? modelMetadata.PropertyName ?? expressionText.Split('.').Last();

            return labelText;
        }

        private static string HintsText(ModelMetadata modelMetadata) {
            object value;

            if (modelMetadata.AdditionalValues.TryGetValue(typeof (ResourceDisplayNameAttribute).Name, out value)) {
                var resourceDisplayName = value as ResourceDisplayNameAttribute;
                if (resourceDisplayName != null) {
                    var hintsKey = string.Concat(resourceDisplayName.Key, ".Hints");
                    hintsKey = hintsKey.Replace(".Label", "");

                    var stringResourceService = EngineContext.Current.Resolve<IStringResourceService>();

                    var hintsText = stringResourceService.GetResourceValue(hintsKey);

                    return hintsText;
                }
            }

            return null;
        }

        private MvcHtmlString ValidationMessageHelper(ModelMetadata modelMetadata, string expression, string validationMessage, IDictionary<string, object> htmlAttributes, out bool hasError, string expressionTypeName = null) {
            hasError = false;

            var formContext = _htmlHelper.ViewContext.FormContext;
            var templateInfo = _htmlHelper.ViewContext.ViewData.TemplateInfo;

            if (!string.IsNullOrEmpty(expressionTypeName))
                templateInfo.HtmlFieldPrefix = expressionTypeName;

            var fullName = templateInfo.GetFullHtmlFieldName(expression);

            if (!_htmlHelper.ViewData.ModelState.ContainsKey(fullName) && formContext == null)
                return null;

            var modelState = _htmlHelper.ViewData.ModelState[fullName];
            var modelErrors = (modelState == null) ? null : modelState.Errors;
            var modelError = (((modelErrors == null) || (modelErrors.Count == 0)) ? null : modelErrors.FirstOrDefault(me => !string.IsNullOrEmpty(me.ErrorMessage)) ?? modelErrors[0]);

            if (modelError == null && formContext == null)
                return null;

            var builder = new TagBuilder("span");
            builder.AddCssClass("help-inline");
            builder.MergeAttributes(htmlAttributes);

            if (!string.IsNullOrEmpty(validationMessage)) {
                builder.SetInnerText(validationMessage);
                hasError = true;
            } else if (modelError != null) {
                builder.SetInnerText(GetUserErrorMessageOrDefault(_htmlHelper.ViewContext.HttpContext, modelError, modelState));
                hasError = true;
            }

            if (formContext != null) {
                var replaceValidationMessageContents = string.IsNullOrEmpty(validationMessage);

                if (_htmlHelper.ViewContext.UnobtrusiveJavaScriptEnabled) {
                    builder.MergeAttribute("data-valmsg-for", fullName);
                    builder.MergeAttribute("data-valmsg-replace", replaceValidationMessageContents.ToString().ToLowerInvariant());
                } else {
                    var fieldMetadata = ApplyFieldValidationMetadata(_htmlHelper, modelMetadata, fullName);

                    fieldMetadata.ReplaceValidationMessageContents = replaceValidationMessageContents;

                    builder.MergeAttribute("id", Sanitizer.Slug(fullName + "ValidationMessage"));
                    fieldMetadata.ValidationMessageId = builder.Attributes["id"];
                }
            }

            return builder.ToMvcHtmlString(TagRenderMode.Normal);
        }

        private MvcHtmlString ControlHelper<TProperty>(Expression<Func<TModel, TProperty>> expression, Func<MvcHtmlString> controlGenerator, string expressionTypeName = null) {
            var divClearfixTag = new TagBuilder("div");
            divClearfixTag.AddCssClass("clearfix");

            var label = LabelFor(expression);
            divClearfixTag.InnerHtml = label.ToString();

            var divInputTag = new TagBuilder("div");
            divInputTag.AddCssClass("input");

            var control = controlGenerator();

            divInputTag.InnerHtml = control.ToString();

            bool hasError;

            var modelMetadata = ModelMetadata.FromLambdaExpression(expression, _htmlHelper.ViewData);
            var expressionText = GetExpressionText(expression);

            var validationMessage = ValidationMessageHelper(modelMetadata, expressionText, null, new RouteValueDictionary(), out hasError, expressionTypeName);

            divInputTag.InnerHtml += validationMessage;

            divClearfixTag.InnerHtml += divInputTag.ToString(TagRenderMode.Normal);

            if (hasError)
                divClearfixTag.AddCssClass("error");

            return new MvcHtmlString(divClearfixTag.ToString(TagRenderMode.Normal));
        }

        private MvcHtmlString CheckBoxHelper<TProperty>(Expression<Func<TModel, TProperty>> expression, Func<MvcHtmlString> controlGenerator, string expressionTypeName = null) {
            var modelMetadata = ModelMetadata.FromLambdaExpression(expression, _htmlHelper.ViewData);
            var expressionText = GetExpressionText(expression);

            var divClearfixTag = new TagBuilder("div");
            divClearfixTag.AddCssClass("clearfix");

            var spanTag = new TagBuilder("span") {
                InnerHtml = LabelText(modelMetadata, expressionText)
            };

            var divInputTag = new TagBuilder("div");
            divInputTag.AddCssClass("input");

            var control = controlGenerator();

            divInputTag.InnerHtml = string.Concat("<ul class=\"inputs-list\"><li><label>", control.ToString(), spanTag.ToString(TagRenderMode.Normal), "</label></li></ul>");

            bool hasError;

            var validationMessage = ValidationMessageHelper(modelMetadata, expressionText, null, new RouteValueDictionary(), out hasError, expressionTypeName);

            divInputTag.InnerHtml += validationMessage;

            divClearfixTag.InnerHtml += divInputTag.ToString(TagRenderMode.Normal);

            if (hasError)
                divClearfixTag.AddCssClass("error");

            return new MvcHtmlString(divClearfixTag.ToString(TagRenderMode.Normal));
        }

        private static Dictionary<string, object> GetRowsAndColumnsDictionary(int rows, int columns) {
            if (rows < 0)
                rows = 2;
            if (columns < 0)
                columns = 20;

            var result = new Dictionary<string, object> {
                {"rows", rows.ToString(CultureInfo.InvariantCulture)},
                {"cols", columns.ToString(CultureInfo.InvariantCulture)}
            };

            return result;
        }

        private static FieldValidationMetadata ApplyFieldValidationMetadata(HtmlHelper htmlHelper, ModelMetadata modelMetadata, string modelName) {
            var formContext = htmlHelper.ViewContext.FormContext;
            var fieldValidationMetadata = formContext.GetValidationMetadataForField(modelName, true);

            var validators = ModelValidatorProviders.Providers.GetValidators(modelMetadata, htmlHelper.ViewContext);

            foreach (var modelClientValidationRule in validators.SelectMany(mv => mv.GetClientValidationRules()))
                fieldValidationMetadata.ValidationRules.Add(modelClientValidationRule);

            return fieldValidationMetadata;
        }

        private static string GetExpressionTypeName<TProperty>(Expression<Func<TModel, TProperty>> expression) {
            string expressionText = null;
            var returnType = expression.ReturnType;

            if (returnType != typeof (string) && !returnType.IsValueType&& !returnType.IsArray)
                expressionText = GetExpressionText(expression);

            return expressionText;
        }

        private object GetModelStateValue(string key, Type destinationType) {
            ModelState modelState;

            if (_htmlHelper.ViewData.ModelState.TryGetValue(key, out modelState)) {
                if (modelState.Value != null)
                    return modelState.Value.ConvertTo(destinationType, null);
            }

            return null;
        }

        private string EvalString(string key) {
            return Convert.ToString(_htmlHelper.ViewData.Eval(key), CultureInfo.CurrentCulture);
        }

        private bool EvalBoolean(string key) {
            return Convert.ToBoolean(_htmlHelper.ViewData.Eval(key), CultureInfo.InvariantCulture);
        }
    }
}