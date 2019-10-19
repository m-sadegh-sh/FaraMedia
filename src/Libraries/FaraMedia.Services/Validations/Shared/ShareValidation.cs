namespace FaraMedia.Services.Validations.Shared {
    using FaraMedia.Core.Domain.Shared;
    using FaraMedia.Data.Schemas.Shared;
    using FaraMedia.Services.Validations.Extensions;

    public class ShareValidation : OwnableValidationBase<Share> {
        public ShareValidation() {
            Define(s => s.Sharer)
                .NotNullable()
                .WithRequired(ShareConstants.Fields.Sharer.Label);

            Define(s => s.ShareDateUtc);
        }
    }
}