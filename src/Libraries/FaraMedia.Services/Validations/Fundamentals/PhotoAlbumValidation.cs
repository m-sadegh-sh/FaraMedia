namespace FaraMedia.Services.Validations.Fundamentals {
    using FaraMedia.Core.Domain.Fundamentals;
    using FaraMedia.Data.Schemas.Fundamentals;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class PhotoAlbumValidation : UIElementValidationBase<PhotoAlbum> {
        public PhotoAlbumValidation() {
            Define(pa => pa.Title)
                .NotNullableAndNotEmpty()
                .WithRequired(PhotoAlbumConstants.Fields.Title.Label)
                .And
                .MaxLength(PhotoAlbumConstants.Fields.Title.Length)
                .WithInvalidLength(PhotoAlbumConstants.Fields.Title.Label, 
                PhotoAlbumConstants.Fields.Title.Length);
         
            Define(pa => pa.Description)
                .MaxLength();

            Define(pa => pa.Artist)
                .NotNullable()
                .WithRequired(PhotoAlbumConstants.Fields.Owner.Label);

            Define(pa => pa.Photos);
        }
    }
}