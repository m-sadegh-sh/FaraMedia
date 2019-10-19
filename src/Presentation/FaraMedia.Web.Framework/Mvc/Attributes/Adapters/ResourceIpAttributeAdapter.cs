namespace FaraMedia.Web.Framework.Mvc.Attributes.Adapters {
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class ResourceIpAttributeAdapter : DataAnnotationsModelValidator<ResourceIpAttribute> {
        public ResourceIpAttributeAdapter(ModelMetadata modelMetadata, ControllerContext controllerContext, ResourceIpAttribute resourceIpAttribute) : base(modelMetadata, controllerContext, resourceIpAttribute) {}

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules() {
            yield return new ModelClientValidationRule {
                ValidationType = "ip",
                ErrorMessage = ErrorMessage
            };
        }
    }
}