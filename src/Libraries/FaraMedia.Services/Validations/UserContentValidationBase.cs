namespace FaraMedia.Services.Validations {
    using FaraMedia.Core.Domain;
    using FaraMedia.Data.Schemas;
    using FaraMedia.Services.Validations.Extensions;

    public abstract class UserContentValidationBase<T> : EntityValidationBase<T> where T : UserContentBase {
        protected UserContentValidationBase() {
            Define(uc => uc.CreationHistory)
                .NotNullable()
                .WithRequired(UserContentConstantsBase<T>.Fields.CreationHistory.Label);
        }
    }
}