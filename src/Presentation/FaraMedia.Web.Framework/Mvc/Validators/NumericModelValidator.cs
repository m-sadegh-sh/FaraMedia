namespace FaraMedia.Web.Framework.Mvc.Validators {
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using FaraMedia.Services.Installation.Installers;

    public sealed class NumericModelValidator : ModelValidator {
        public NumericModelValidator(ModelMetadata metadata, ControllerContext controllerContext) : base(metadata, controllerContext) {}

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules() {
            yield return new ModelClientValidationRule {
                ValidationType = "number",
                ErrorMessage = MakeErrorString(Metadata.GetDisplayName())
            };
        }

        private static string MakeErrorString(string displayName) {
            return ValidationMessageFormatter.InvalidFormatName(displayName);
        }

        public override IEnumerable<ModelValidationResult> Validate(object container) {
            return Enumerable.Empty<ModelValidationResult>();
        }
    }
}