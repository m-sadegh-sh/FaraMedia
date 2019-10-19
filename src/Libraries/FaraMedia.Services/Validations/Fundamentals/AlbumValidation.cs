namespace FaraMedia.Services.Validations.Fundamentals {
    using FaraMedia.Core.Domain.Fundamentals;
    using FaraMedia.Data.Schemas.Fundamentals;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class AlbumValidation : UIElementValidationBase<Album> {
        public AlbumValidation() {
            Define(a => a.Title)
                .NotNullableAndNotEmpty()
                .WithRequired(AlbumConstants.Fields.Title.Label)
                .And
                .MaxLength(AlbumConstants.Fields.Title.Length)
                .WithInvalidLength(AlbumConstants.Fields.Title.Label,
                                   AlbumConstants.Fields.Title.Length);

            Define(a => a.Description)
                .MaxLength();

            Define(a => a.ReleaseDateUtc);

            Define(a => a.Tracks);
        }
    }
}