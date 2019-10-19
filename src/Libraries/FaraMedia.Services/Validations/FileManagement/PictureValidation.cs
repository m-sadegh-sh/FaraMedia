namespace FaraMedia.Services.Validations.FileManagement {
    using FaraMedia.Core.Domain.FileManagement;
    using FaraMedia.Data.Schemas.FileManagement;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class PictureValidation : EntityValidationBase<Picture> {
        public PictureValidation() {
            Define(p => p.MimeType)
                .NotNullableAndNotEmpty()
                .WithRequired(PictureConstants.Fields.MimeType.Label)
                .And
                .MaxLength(PictureConstants.Fields.MimeType.Length)
                .WithInvalidLength(PictureConstants.Fields.MimeType.Label,
                                   PictureConstants.Fields.MimeType.Length);

            Define(p => p.FileName)
                .NotNullableAndNotEmpty()
                .WithRequired(PictureConstants.Fields.FileName.Label)
                .And
                .MaxLength(PictureConstants.Fields.FileName.Length)
                .WithInvalidLength(PictureConstants.Fields.FileName.Label,
                                   PictureConstants.Fields.FileName.Length);
        }
    }
}