namespace FaraMedia.Services.Validations {
    using FaraMedia.Core.Domain;
    using FaraMedia.Data.Schemas;
    using FaraMedia.Services.Validations.Extensions;

    public abstract class UIElementValidationBase<T> : UserContentValidationBase<T> where T : UIElementBase {
        protected UIElementValidationBase() {
            Define(uie => uie.Owner)
                .NotNullable()
                .WithRequired(UIElementConstantsBase<T>.Fields.Owner.Label);
        }
    }
}