namespace FaraMedia.Services.Infrastructure {
    using System.Linq;

    using NHibernate.Validator.Engine;
    using NHibernate.Validator.Exceptions;

    public static class ServiceOperationResultExtensions {
        public static void InjectExceptionMessages(this ServiceOperationResult serviceOperationResult, InvalidStateException invalidStateException) {
            InjectInvalidValues(serviceOperationResult, invalidStateException.GetInvalidValues());
        }

        public static void InjectInvalidValues(this ServiceOperationResult serviceOperationResult, InvalidValue[] invalidValues) {
            foreach (var invalidValue in invalidValues.Where(iv => !string.IsNullOrEmpty(iv.PropertyName)))
                serviceOperationResult.AddPropertyError(invalidValue.PropertyName, invalidValue.Message);
        }
    }
}