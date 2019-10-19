namespace FaraMedia.Services.Validations.Fundamentals {
    using FaraMedia.Core;
    using FaraMedia.Core.Domain.Fundamentals;
    using FaraMedia.Core.Domain.Misc;
    using FaraMedia.Data.Schemas.Fundamentals;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class ArtistValidation : UIElementValidationBase<Artist> {
        public ArtistValidation() {
            Define(a => a.FullName)
                .NotNullableAndNotEmpty()
                .WithRequired(ArtistConstants.Fields.FullName.Label)
                .And
                .MaxLength(ArtistConstants.Fields.FullName.Length)
                .WithInvalidLength(ArtistConstants.Fields.FullName.Label,
                                   ArtistConstants.Fields.FullName.Length);

            Define(a => a.AlternativeName)
                .MaxLength(ArtistConstants.Fields.AlternativeName.Length)
                .WithInvalidLength(ArtistConstants.Fields.AlternativeName.Label,
                                   ArtistConstants.Fields.AlternativeName.Length);

            Define(a => a.HomeTown)
                .MaxLength(ArtistConstants.Fields.HomeTown.Length)
                .WithInvalidLength(ArtistConstants.Fields.HomeTown.Label,
                                   ArtistConstants.Fields.HomeTown.Length);

            Define(a => a.Biography)
                .MaxLength();

            ValidateInstance.SafeBy((artist, context) => {
                                        var isValid = true;

                                        if (artist.Facebook != null && !string.IsNullOrEmpty(artist.Facebook.TargetUrl)) {
                                            if (artist.Facebook.TargetUrl.Length > ArtistConstants.Fields.Facebook.Length) {
                                                context.AddInvalidLength<Artist, Redirector>(ArtistConstants.Fields.Facebook.Label,
                                                                                             ArtistConstants.Fields.Facebook.Length,
                                                                                             a => a.Facebook);

                                                isValid = false;
                                            } else if (!CommonHelper.IsValidUrl(artist.Facebook.TargetUrl)) {
                                                context.AddInvalidFormat<Artist, Redirector>(ArtistConstants.Fields.Facebook.Label,
                                                                                             a => a.Facebook);

                                                isValid = false;
                                            }
                                        }

                                        return isValid;
                                    });
        }
    }
}