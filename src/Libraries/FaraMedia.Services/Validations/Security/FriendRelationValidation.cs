namespace FaraMedia.Services.Validations.Security {
    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Data.Schemas.Security;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class FriendRequestValidation : EntityValidationBase<FriendRequest> {
        public FriendRequestValidation() {
            Define(fr => fr.From)
                .NotNullable()
                .WithRequired(FriendRequestConstants.Fields.From.Label);

            Define(fr => fr.To)
                .NotNullable()
                .WithRequired(FriendRequestConstants.Fields.To.Label);

            Define(fr => fr.SentDateUtc);

            Define(fr => fr.Accepted);

            Define(fr => fr.AcceptanceDateUtc);

            Define(fr => fr.BlockSubsequentRequests);
        }
    }
}