namespace FaraMedia.Services.Validations.Fundamentals {
    using FaraMedia.Core.Domain.Fundamentals;
    using FaraMedia.Data.Schemas.Fundamentals;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class PhotoValidation : UIElementValidationBase<Photo> {
        public PhotoValidation() {
            Define(p => p.Title)
                .NotNullableAndNotEmpty()
                .WithRequired(PhotoConstants.Fields.Title.Label)
                .And
                .MaxLength(PhotoConstants.Fields.Title.Length)
                .WithInvalidLength(PhotoConstants.Fields.Title.Label,
                                   PhotoConstants.Fields.Title.Length);

            Define(p => p.Description)
                .MaxLength();

            Define(p => p.Album)
                .NotNullable()
                .WithRequired(PhotoConstants.Fields.Owner.Label);

            Define(p => p.Picture)
                .NotNullable()
                .WithRequired(PhotoConstants.Fields.Picture.Label);
        }
    }
}