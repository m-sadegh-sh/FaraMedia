namespace FaraMedia.Services.Validations.ContentManagement {
    using FaraMedia.Core.Domain.ContentManagement;
    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class PostValidation : UIElementValidationBase<Post> {
        public PostValidation() {
            Define(p => p.Title)
                .NotNullableAndNotEmpty()
                .WithRequired(PostConstants.Fields.Title.Label)
                .And
                .MaxLength(PostConstants.Fields.Title.Length)
                .WithInvalidLength(PostConstants.Fields.Title.Label,
                PostConstants.Fields.Title.Length);

            Define(p => p.Body)
                .NotNullableAndNotEmpty()
                .WithRequired(PostConstants.Fields.Body.Label)
                .And
                .MaxLength();

            Define(p => p.Blog)
                .NotNullable()
                .WithRequired(PostConstants.Fields.Blog.Label);

            Define(p => p.Tags);
        }
    }
}