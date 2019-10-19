namespace FaraMedia.Services.Validations.ContentManagement {
    using FaraMedia.Core.Domain.ContentManagement;
    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class TagValidation : EntityValidationBase<Tag> {
        public TagValidation() {
            Define(t => t.Title)
                .NotNullableAndNotEmpty()
                .WithRequired(TagConstants.Fields.Title.Label)
                .And
                .MaxLength(TagConstants.Fields.Title.Length)
                .WithInvalidLength(TagConstants.Fields.Title.Label,
                                   TagConstants.Fields.Title.Length);

            Define(t => t.Description)
                .MaxLength();

            Define(t => t.Blog)
                .NotNullable()
                .WithRequired(TagConstants.Fields.Blog.Label);

            Define(t => t.Posts);
        }
    }
}