namespace FaraMedia.Services.Validations.ContentManagement {
    using FaraMedia.Core.Domain.ContentManagement;
    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class NewsValidation : UIElementValidationBase<News> {
        public NewsValidation() {
            Define(n => n.Title)
                .NotNullableAndNotEmpty()
                .WithRequired(NewsConstants.Fields.Title.Label)
                .And
                .MaxLength(NewsConstants.Fields.Title.Length)
                .WithInvalidLength(NewsConstants.Fields.Title.Label, 
                NewsConstants.Fields.Title.Length);

            Define(n => n.Short)
                .NotNullableAndNotEmpty()
                .WithRequired(NewsConstants.Fields.Short.Label)
                .And
                .MaxLength(NewsConstants.Fields.Short.Length)
                .WithInvalidLength(NewsConstants.Fields.Short.Label,
                NewsConstants.Fields.Short.Length);

            Define(n => n.Full)
                .NotNullableAndNotEmpty()
                .WithRequired(NewsConstants.Fields.Full.Label)
                .And
                .MaxLength();

            Define(n => n.Category)
                .NotNullable()
                .WithRequired(NewsConstants.Fields.Category.Label);
        }
    }
}