namespace FaraMedia.Web.Framework.Mvc.Validators {
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class ClientNumericModelValidatorProvider : ModelValidatorProvider {
        private static readonly HashSet<Type> _numericTypes = new HashSet<Type>(new[] {typeof (byte), typeof (sbyte), typeof (short), typeof (ushort), typeof (int), typeof (uint), typeof (long), typeof (ulong), typeof (float), typeof (double), typeof (decimal)});

        public override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context) {
            if (metadata == null)
                throw new ArgumentNullException("metadata");

            if (context == null)
                throw new ArgumentNullException("context");

            return GetValidatorsImpl(metadata, context);
        }

        private static IEnumerable<ModelValidator> GetValidatorsImpl(ModelMetadata metadata, ControllerContext context) {
            var type = metadata.ModelType;

            if (IsNumericType(type))
                yield return new NumericModelValidator(metadata, context);
        }

        private static bool IsNumericType(Type type) {
            var underlyingType = Nullable.GetUnderlyingType(type);

            return _numericTypes.Contains(underlyingType ?? type);
        }
    }
}