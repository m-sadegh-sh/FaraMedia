namespace FaraMedia.Web.Framework.Mvc.Attributes.Adapters {
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class ResourceUrlAttributeAdapter : DataAnnotationsModelValidator<ResourceUrlAttribute> {
        public ResourceUrlAttributeAdapter(ModelMetadata modelMetadata, ControllerContext controllerContext, ResourceUrlAttribute resourceUrlAttribute) : base(modelMetadata, controllerContext, resourceUrlAttribute) {}

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules() {
            yield return new ModelClientValidationRule {
                ValidationType = "url",
                ErrorMessage = ErrorMessage
            };
        }
    }
}