namespace FaraMedia.Services.Infrastructure {
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using FaraMedia.Core.Infrastructure.Extensions;
    using FaraMedia.Services.Installation.Abstraction;

    using Utilities.DataTypes.ExtensionMethods;
    using Utilities.Reflection.ExtensionMethods;

	public class ServiceOperationResult {
        public ServiceOperationResult() {
            Errors = new Dictionary<string, string>();
        }

        public IDictionary<string, string> Errors { get; set; }

        public bool Success {
            get { return Errors.Count == 0; }
        }

        public void AddError(string error) {
            Errors.Add(string.Empty, error);
        }

        public void AddResourceError(string key, params object[] args) {
            var resourceValue = ValidationMessageFormatter.WithKey(key, args);

            Errors.Add(string.Empty, resourceValue);
        }

        public void AddPropertyError(string propertyName, string errorMessage) {
            Errors.Add(propertyName, errorMessage);
        }

        public void AddPropertyResourceError<T>(Expression<Func<T, object>> property, string key, params object[] args) where T : class {
            var propertyName = property.GetPropertyName();

            var resourceValue = ValidationMessageFormatter.WithKey(key, args);

            Errors.Add(propertyName, resourceValue);
        }

        public void CopyFrom(ServiceOperationResult serviceOperationResult) {
            serviceOperationResult.Errors.ForEach(Errors.Add);
        }
    }
}