namespace FaraMedia.Services.Validations {
    using FaraMedia.Core.Domain;

    public abstract class SecurableValidationBase<T> : EntityValidationBase<T> where T : SecurableBase {
        protected SecurableValidationBase() {
            Define(s => s.IsSecured);
        }
    }
}