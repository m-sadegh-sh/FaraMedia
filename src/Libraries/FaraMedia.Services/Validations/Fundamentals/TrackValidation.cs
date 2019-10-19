namespace FaraMedia.Services.Validations.Fundamentals {
    using FaraMedia.Core.Domain.Fundamentals;
    using FaraMedia.Data.Schemas.Fundamentals;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class TrackValidation : UIElementValidationBase<Track> {
        public TrackValidation() {
            Define(t => t.Title)
                .NotNullableAndNotEmpty()
                .WithRequired(TrackConstants.Fields.Title.Label)
                .And
                .MaxLength(TrackConstants.Fields.Title.Length)
                .WithInvalidLength(TrackConstants.Fields.Title.Label,
                                   TrackConstants.Fields.Title.Length);

            Define(t => t.Description)
                .MaxLength();

            Define(t => t.IsVideo);
            Define(t => t.TrackNumber);
            Define(t => t.ReleaseDateUtc);

            Define(t => t.Genre)
                .NotNullable()
                .WithRequired(TrackConstants.Fields.Genre.Label);

            Define(t => t.Album);

            Define(t => t.Publisher);

            Define(t => t.Covers);

            Define(t => t.Downloads);

            Define(t => t.Singers);

            Define(t => t.Composers);

            Define(t => t.Arrangementers);

            Define(t => t.Songwriters);
        }
    }
}