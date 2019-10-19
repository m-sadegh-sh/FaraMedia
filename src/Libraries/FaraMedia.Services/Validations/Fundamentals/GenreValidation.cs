namespace FaraMedia.Services.Validations.Fundamentals {
    using FaraMedia.Core.Domain.Fundamentals;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Data.Schemas.Fundamentals;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class GenreValidation : UIElementValidationBase<Genre> {
        public GenreValidation() {
            Define(g => g.Title)
                .NotNullableAndNotEmpty()
                .WithRequired(GenreConstants.Fields.Title.Label)
                .And
                .MaxLength(GenreConstants.Fields.Title.Length)
                .WithInvalidLength(GenreConstants.Fields.Title.Label,
                GenreConstants.Fields.Title.Length);

            Define(g => g.Description)
                .MaxLength();

            Define(g => g.Tracks);
        }
    }
}