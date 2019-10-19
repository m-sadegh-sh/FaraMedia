namespace FaraMedia.Services.Validations.Shared {
    using FaraMedia.Core.Domain.Shared;
    using FaraMedia.Data.Schemas.Shared;
    using FaraMedia.Services.Validations.Extensions;

    public class LikeValidation : OwnableValidationBase<Like> {
        public LikeValidation() {
            Define(l => l.Liker)
                .NotNullable()
                .WithRequired(LikeConstants.Fields.Liker.Label);

            Define(l => l.LikeDateUtc);
        }
    }
}