namespace FaraMedia.Web.Framework.Mvc.Validators {
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class ClientDateTimeModelValidatorProvider : ModelValidatorProvider {
        public override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context) {
            if (metadata == null)
                throw new ArgumentNullException("metadata");

            if (context == null)
                throw new ArgumentNullException("context");

            return GetValidatorsImpl(metadata, context);
        }

        private static IEnumerable<ModelValidator> GetValidatorsImpl(ModelMetadata metadata, ControllerContext context) {
            var type = metadata.ModelType;

            if (IsDateType(type))
                yield return new DateTimeModelValidator(metadata, context);
        }

        private static bool IsDateType(Type type) {
            var underlyingType = Nullable.GetUnderlyingType(type);

            return typeof (DateTime) == (underlyingType ?? type);
        }
    }
}