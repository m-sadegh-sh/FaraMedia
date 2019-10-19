namespace FaraMedia.Web.Framework.Mvc.Attributes.Adapters {
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class ResourceMaxAttributeAdapter : DataAnnotationsModelValidator<ResourceMaxAttribute> {
        public ResourceMaxAttributeAdapter(ModelMetadata modelMetadata, ControllerContext controllerContext, ResourceMaxAttribute resourceMaxAttribute) : base(modelMetadata, controllerContext, resourceMaxAttribute) {}

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules() {
            yield return new ModelClientValidationRule {
                ValidationType = "max",
                ErrorMessage = ErrorMessage
            };
        }
    }
}