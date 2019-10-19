namespace FaraMedia.Services.Validations.Configuration {
    using FaraMedia.Core.Domain.Configuration;
    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Data.Schemas.Configuration;
    using FaraMedia.Services.Querying.Systematic;
    using FaraMedia.Services.Validations.Extensions;

    using NHibernate.Validator.Cfg.Loquacious;

    public sealed class SystemSettingsValidation : ValidationDef<SystemSettings> {
        public SystemSettingsValidation() {
            Define(ss => ss.IsClosed);

            Define(ss => ss.MobileDevicesSupported);

            Define(ss => ss.EnableHttpCompression);

            Define(ss => ss.LoadAllLocaleRecordsOnStartup);

            Define(ss => ss.ShowHeaderRssUrl);

            Define(ss => ss.CaseInvariantReplacement);

            Define(ss => ss.ConvertNonWesternChars);

            Define(ss => ss.AllowUnicodeCharsInUrls);

            Define(ss => ss.CanonicalUrlsEnabled);

            Define(ss => ss.GridPageSize)
                .GreaterThanOrEqualTo(SystemSettingsConstants.Fields.GridPageSize.MinValue)
                .WithInvalidMinValue(SystemSettingsConstants.Fields.GridPageSize.Label,
                                     SystemSettingsConstants.Fields.GridPageSize.MinValue);

            Define(ss => ss.MainPageSize)
                .GreaterThanOrEqualTo(SystemSettingsConstants.Fields.MainPageSize.MinValue)
                .WithInvalidMinValue(SystemSettingsConstants.Fields.MainPageSize.Label,
                                     SystemSettingsConstants.Fields.MainPageSize.MinValue);

            Define(ss => ss.ArchivePageSize)
                .GreaterThanOrEqualTo(SystemSettingsConstants.Fields.ArchivePageSize.MinValue)
                .WithInvalidMinValue(SystemSettingsConstants.Fields.ArchivePageSize.Label,
                                     SystemSettingsConstants.Fields.ArchivePageSize.MinValue);

            Define(ss => ss.Name)
                .NotNullableAndNotEmpty()
                .WithRequired(SystemSettingsConstants.Fields.Name.Label)
                .And.MaxLength(SystemSettingsConstants.Fields.Name.Length)
                .WithInvalidLength(SystemSettingsConstants.Fields.Name.Label,
                                   SystemSettingsConstants.Fields.Name.Length);

            Define(ss => ss.Url)
                .NotNullableAndNotEmpty()
                .WithRequired(SystemSettingsConstants.Fields.Url.Label)
                .And
                .MaxLength(SystemSettingsConstants.Fields.Url.Length)
                .WithInvalidLength(SystemSettingsConstants.Fields.Url.Label,
                                   SystemSettingsConstants.Fields.Url.Length)
                .And
                .IsUrl()
                .WithInvalidFormat(SystemSettingsConstants.Fields.Url.Label);

            Define(ss => ss.DefaultTitle)
                .MaxLength(SystemSettingsConstants.Fields.DefaultTitle.Length)
                .WithInvalidLength(SystemSettingsConstants.Fields.DefaultTitle.Label,
                                   SystemSettingsConstants.Fields.DefaultTitle.Length);

            Define(ss => ss.DefaultMetaKeywords)
                .MaxLength(SystemSettingsConstants.Fields.DefaultMetaKeywords.Length)
                .WithInvalidLength(SystemSettingsConstants.Fields.DefaultMetaKeywords.Label,
                                   SystemSettingsConstants.Fields.DefaultMetaKeywords.Length);

            Define(ss => ss.DefaultMetaDescription)
                .MaxLength(SystemSettingsConstants.Fields.DefaultMetaDescription.Length)
                .WithInvalidLength(SystemSettingsConstants.Fields.DefaultMetaDescription.Label,
                                   SystemSettingsConstants.Fields.DefaultMetaDescription.Length);

            Define(ss => ss.TitleSeparator)
                .MaxLength(SystemSettingsConstants.Fields.TitleSeparator.Length)
                .WithInvalidLength(SystemSettingsConstants.Fields.TitleSeparator.Label,
                                   SystemSettingsConstants.Fields.TitleSeparator.Length);

            Define(ss => ss.BreadcrumbSeparator)
                .MaxLength(SystemSettingsConstants.Fields.BreadcrumbSeparator.Length)
                .WithInvalidLength(SystemSettingsConstants.Fields.BreadcrumbSeparator.Label,
                                   SystemSettingsConstants.Fields.BreadcrumbSeparator.Length);

            Define(ss => ss.Color1)
                .MaxLength(SystemSettingsConstants.Fields.Color1.Length)
                .WithInvalidLength(SystemSettingsConstants.Fields.Color1.Label,
                                   SystemSettingsConstants.Fields.Color1.Length);

            Define(ss => ss.Color2)
                .MaxLength(SystemSettingsConstants.Fields.Color2.Length)
                .WithInvalidLength(SystemSettingsConstants.Fields.Color2.Label,
                                   SystemSettingsConstants.Fields.Color2.Length);

            Define(ss => ss.Color3)
                .MaxLength(SystemSettingsConstants.Fields.Color3.Length)
                .WithInvalidLength(SystemSettingsConstants.Fields.Color3.Label,
                                   SystemSettingsConstants.Fields.Color3.Length);
            
            Define(ss => ss.DefaultEmailAccountId)
                .GreaterThanOrEqualTo(SystemSettingsConstants.Fields.DefaultEmailAccountId.MinValue)
                .WithInvalidMinValue(SystemSettingsConstants.Fields.DefaultEmailAccountId.Label,
                                     SystemSettingsConstants.Fields.DefaultEmailAccountId.MinValue);

            Define(ss => ss.AllowUsersToSetTimeZone);

            Define(ss => ss.DefaultTimeZoneId)
                .IsDateTimeZoneId()
                .WithInvalidFormat(SystemSettingsConstants.Fields.DefaultTimeZoneId.Label);

            Define(ss => ss.AllowUsersToSetLanguage);

            Define(ss => ss.DefaultLanguageId)
                .GreaterThanOrEqualTo(SystemSettingsConstants.Fields.DefaultLanguageId.MinValue)
                .WithInvalidMinValue(SystemSettingsConstants.Fields.DefaultLanguageId.Label,
                                     SystemSettingsConstants.Fields.DefaultLanguageId.MinValue);

            Define(ss => ss.ImmediatelyRedirection);

            Define(ss => ss.RedirectionDelay)
                .GreaterThanOrEqualTo(SystemSettingsConstants.Fields.RedirectionDelay.MinValue)
                .WithInvalidMinValue(SystemSettingsConstants.Fields.RedirectionDelay.Label,
                SystemSettingsConstants.Fields.RedirectionDelay.MinValue);

            ValidateInstance.SafeBy((systemSettings, context) =>
            {
                var isValid = true;

                var emailAccountService = EngineContext.Current.Resolve<IDbService<EmailAccount, EmailAccountQuery>>();

                if (emailAccountService.GetById(systemSettings.DefaultEmailAccountId) == null)
                {
                    context.AddInvalidValue<SystemSettings, long>(SystemSettingsConstants.Fields.DefaultEmailAccountId.Label,
                                                                       ss => ss.DefaultEmailAccountId);

                    isValid = false;
                }

                var languageService = EngineContext.Current.Resolve<IDbService<Language, LanguageQuery>>();

                if (languageService.GetById(systemSettings.DefaultLanguageId) == null)
                {
                    context.AddInvalidValue<SystemSettings, long>(SystemSettingsConstants.Fields.DefaultLanguageId.Label,
                                                                       ss => ss.DefaultLanguageId);

                    isValid = false;
                }

                return isValid;
            });
        }
    }
}