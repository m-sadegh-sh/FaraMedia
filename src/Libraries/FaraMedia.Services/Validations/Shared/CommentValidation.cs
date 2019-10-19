namespace FaraMedia.Services.Validations.Shared {
    using FaraMedia.Core.Domain.Shared;
    using FaraMedia.Data.Schemas.Shared;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class CommentValidation : UserContentValidationBase<Comment> {
        public CommentValidation() {
            Define(c => c.OwnerId)
                .GreaterThanOrEqualTo(CommentConstants.Fields.OwnerId.MinValue)
                .WithInvalidMinValue(CommentConstants.Fields.OwnerId.Label,
                                     CommentConstants.Fields.OwnerId.MinValue);

            Define(c => c.Email)
                .NotNullableAndNotEmpty()
                .WithRequired(CommentConstants.Fields.Email.Label)
                .And
                .MaxLength(CommentConstants.Fields.Email.Length)
                .WithInvalidLength(CommentConstants.Fields.Email.Label,
                                   CommentConstants.Fields.Email.Length)
                .And
                .IsEmail()
                .WithInvalidFormat(CommentConstants.Fields.Email.Label);

            Define(c => c.Title)
                .NotNullableAndNotEmpty()
                .WithRequired(CommentConstants.Fields.Title.Label)
                .And
                .MaxLength(CommentConstants.Fields.Title.Length)
                .WithInvalidLength(CommentConstants.Fields.Title.Label,
                                   CommentConstants.Fields.Title.Length);

            Define(c => c.Body)
                .NotNullableAndNotEmpty()
                .WithRequired(CommentConstants.Fields.Body.Label)
                .And
                .MaxLength();

            Define(c => c.InReplyTo);

            Define(c => c.Replies);
        }
    }
}