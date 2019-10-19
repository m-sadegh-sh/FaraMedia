namespace FaraMedia.Services.Validations.ContentManagement {
    using FaraMedia.Core.Domain.ContentManagement;
    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class CategoryValidation : EntityValidationBase<Category> {
        public CategoryValidation() {
            Define(c => c.Title)
                .NotNullableAndNotEmpty()
                .WithRequired(CategoryConstants.Fields.Title.Label)
                .And
                .MaxLength(CategoryConstants.Fields.Title.Length)
                .WithInvalidLength(CategoryConstants.Fields.Title.Label,
                CategoryConstants.Fields.Title.Length);

            Define(c => c.Description)
                .MaxLength();

            Define(c => c.Parent);

            Define(c => c.Children);

            Define(c => c.News);
        }
    }
}