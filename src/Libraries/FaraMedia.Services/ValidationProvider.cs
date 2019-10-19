namespace FaraMedia.Services {
	using System.Linq;

	using NHibernate.Validator.Engine;

	public class ValidationProvider<T> {
		private readonly ValidatorEngine _validatorEngine;

		public ValidationProvider(ValidatorEngine validatorEngine) {
			_validatorEngine = validatorEngine;
		}

		public bool Validate(T entity,
		                     ServiceOperationResult result) {
			var invalidValues = _validatorEngine.Validate(entity).
			                                     ToList();

			var hasInvalidError = invalidValues.Count > 0;

			if (hasInvalidError) {
				invalidValues.ForEach(iv => result.AddPropertyError(iv.PropertyName,
				                                                    iv.Message));
			}

			return hasInvalidError;
		}
	}
}