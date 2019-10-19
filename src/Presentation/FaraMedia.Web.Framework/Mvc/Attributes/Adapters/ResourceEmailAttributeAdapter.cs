namespace FaraMedia.Web.Framework.Mvc.Attributes.Adapters {
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class ResourceEmailAttributeAdapter : DataAnnotationsModelValidator<ResourceEmailAttribute> {
        public ResourceEmailAttributeAdapter(ModelMetadata modelMetadata, ControllerContext controllerContext, ResourceEmailAttribute resourceEmailAttribute) : base(modelMetadata, controllerContext, resourceEmailAttribute) {}

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules() {
            yield return new ModelClientValidationRule {
                ValidationType = "email",
                ErrorMessage = ErrorMessage
            };
        }
    }
}