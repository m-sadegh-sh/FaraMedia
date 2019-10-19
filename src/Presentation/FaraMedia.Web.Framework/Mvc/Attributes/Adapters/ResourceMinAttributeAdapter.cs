namespace FaraMedia.Web.Framework.Mvc.Attributes.Adapters {
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class ResourceMinAttributeAdapter : DataAnnotationsModelValidator<ResourceMinAttribute> {
        public ResourceMinAttributeAdapter(ModelMetadata modelMetadata, ControllerContext controllerContext, ResourceMinAttribute resourceMinAttribute) : base(modelMetadata, controllerContext, resourceMinAttribute) {}

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules() {
            yield return new ModelClientValidationRule {
                ValidationType = "min",
                ErrorMessage = ErrorMessage
            };
        }
    }
}