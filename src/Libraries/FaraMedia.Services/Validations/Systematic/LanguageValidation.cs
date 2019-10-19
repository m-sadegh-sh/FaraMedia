namespace FaraMedia.Services.Validations.Systematic {
    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Data.Schemas.Systematic;
    using FaraMedia.Services.Extensions.Systematic;
    using FaraMedia.Services.Querying.Systematic;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class LanguageValidation : EntityValidationBase<Language> {
        public LanguageValidation() {
            Define(l => l.SystemName)
                .NotNullableAndNotEmpty()
                .WithRequired(LanguageConstants.Fields.SystemName.Label)
                .And
                .MaxLength(LanguageConstants.Fields.SystemName.Length)
                .WithInvalidLength(LanguageConstants.Fields.SystemName.Label,
                                   LanguageConstants.Fields.SystemName.Length);

            Define(l => l.DisplayName)
                .NotNullableAndNotEmpty()
                .WithRequired(LanguageConstants.Fields.DisplayName.Label)
                .And
                .MaxLength(LanguageConstants.Fields.DisplayName.Length)
                .WithInvalidLength(LanguageConstants.Fields.DisplayName.Label,
                                   LanguageConstants.Fields.DisplayName.Length);

            Define(l => l.NativeName)
                .NotNullableAndNotEmpty()
                .WithRequired(LanguageConstants.Fields.NativeName.Label)
                .And
                .MaxLength(LanguageConstants.Fields.NativeName.Length)
                .WithInvalidLength(LanguageConstants.Fields.NativeName.Label,
                                   LanguageConstants.Fields.NativeName.Length);

            Define(l => l.Description)
                .MaxLength();

            Define(l => l.CultureCode)
                .NotNullableAndNotEmpty()
                .WithRequired(LanguageConstants.Fields.CultureCode.Label)
                .And
                .MaxLength(LanguageConstants.Fields.CultureCode.Length)
                .WithInvalidLength(LanguageConstants.Fields.CultureCode.Label,
                                   LanguageConstants.Fields.CultureCode.Length);

            ValidateInstance.SafeBy((language, context) => {
                                        var isValid = true;

                                        var service = EngineContext.Current.Resolve<IDbService<Language, LanguageQuery>>();

                                        if (service.GetBySystemName(language.SystemName).IsDuplicate(language)) {
                                            context.AddDuplicate<Language, string>(LanguageConstants.Fields.SystemName.Label,
                                                                                   l => l.SystemName);

                                            isValid = false;
                                        }

                                        if (service.GetByCultureCode(language.CultureCode).IsDuplicate(language)) {
                                            context.AddDuplicate<Language, string>(LanguageConstants.Fields.CultureCode.Label,
                                                                                   l => l.CultureCode);

                                            isValid = false;
                                        }

                                        return isValid;
                                    });
        }
    }
}