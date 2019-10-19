namespace FaraMedia.Services.Validations.ContentManagement {
    using FaraMedia.Core.Domain.ContentManagement;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.Services.Querying.ContentManagement;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class BlogValidation : UIElementValidationBase<Blog> {
        public BlogValidation() {
            Define(b => b.Title)
                .NotNullableAndNotEmpty()
                .WithRequired(BlogConstants.Fields.Title.Label)
                .And
                .MaxLength(BlogConstants.Fields.Title.Length)
                .WithInvalidLength(BlogConstants.Fields.Title.Label,
                                   BlogConstants.Fields.Title.Length);

            Define(b => b.Description)
                .MaxLength();

            Define(b => b.Author)
                .NotNullable()
                .WithRequired(BlogConstants.Fields.Author.Label);

            Define(b => b.Tags);

            Define(b => b.Posts);
        }
    }
}