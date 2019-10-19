namespace FaraMedia.Services.Validations {
    using FaraMedia.Core.Domain;
    using FaraMedia.Data.Schemas;
    using FaraMedia.Services.Validations.Extensions;

    public abstract class OwnableValidationBase<T> : EntityValidationBase<T> where T : OwnableBase {
        protected OwnableValidationBase() {
            Define(o => o.OwnerId)
                .GreaterThanOrEqualTo(OwnableConstantsBase<OwnableBase>.Fields.OwnerId.MinValue)
                .WithInvalidMinValue(OwnableConstantsBase<OwnableBase>.Fields.OwnerId.Label,
                                     OwnableConstantsBase<OwnableBase>.Fields.OwnerId.MinValue);
        }
    }
}