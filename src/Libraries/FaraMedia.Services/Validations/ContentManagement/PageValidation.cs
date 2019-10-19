namespace FaraMedia.Services.Validations.ContentManagement {
    using FaraMedia.Core.Domain.ContentManagement;
    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class PageValidation : EntityValidationBase<Page> {
        public PageValidation() {
            Define(p => p.Title)
                .NotNullableAndNotEmpty()
                .WithRequired(PageConstants.Fields.Title.Label)
                .And
                .MaxLength(PageConstants.Fields.Title.Length)
                .WithInvalidLength(PageConstants.Fields.Title.Label,
                PageConstants.Fields.Title.Length);

            Define(p => p.Body)
                .MaxLength();

            Define(p => p.Group)
                .NotNullable()
                .WithRequired(PageConstants.Fields.Group.Label);
        }
    }
}