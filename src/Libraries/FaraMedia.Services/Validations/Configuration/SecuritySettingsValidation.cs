namespace FaraMedia.Services.Validations.Configuration {
    using FaraMedia.Core.Domain.Configuration;
    using FaraMedia.Data.Schemas.Configuration;
    using FaraMedia.Services.Validations.Extensions;

    using NHibernate.Validator.Cfg.Loquacious;

    public sealed class SecuritySettingsValidation : ValidationDef<SecuritySettings> {
        public SecuritySettingsValidation() {
            Define(ss => ss.EncryptionKey)
                .MaxLength(SecuritySettingsConstants.Fields.EncryptionKey.Length)
                .WithInvalidLength(SecuritySettingsConstants.Fields.EncryptionKey.Label,
                                   SecuritySettingsConstants.Fields.EncryptionKey.Length);

            Define(ss => ss.AdminAreaAllowedIpAddress)
                .MaxLength(SecuritySettingsConstants.Fields.AdminAreaAllowedIpAddress.Length)
                .WithInvalidLength(SecuritySettingsConstants.Fields.AdminAreaAllowedIpAddress.Label,
                                   SecuritySettingsConstants.Fields.AdminAreaAllowedIpAddress.Length)
                .And
                .IsIp()
                .WithInvalidFormat(SecuritySettingsConstants.Fields.AdminAreaAllowedIpAddress.Label);

            Define(ss => ss.HideLinksBasedOnPermissions);

            Define(ss => ss.UseSsl);

            Define(ss => ss.MaxumimMinutesToDeleteGuestUsers)
                .GreaterThanOrEqualTo(SecuritySettingsConstants.Fields.MaxumimMinutesToDeleteGuestUsers.MinValue)
                .WithInvalidMinValue(SecuritySettingsConstants.Fields.MaxumimMinutesToDeleteGuestUsers.Label,
                                     SecuritySettingsConstants.Fields.MaxumimMinutesToDeleteGuestUsers.MinValue);

            Define(ss => ss.OnlineUserMinutes)
                .GreaterThanOrEqualTo(SecuritySettingsConstants.Fields.OnlineUserMinutes.MinValue)
                .WithInvalidMinValue(SecuritySettingsConstants.Fields.OnlineUserMinutes.Label,
                                     SecuritySettingsConstants.Fields.OnlineUserMinutes.MinValue);

            Define(ss => ss.RegistrationType);

            Define(ss => ss.UserNamesEnabled);

            Define(ss => ss.IllegalUserNameChars)
                .MaxLength();

            Define(ss => ss.ScreenNameFormat);

            Define(ss => ss.PasswordMinLength)
                .GreaterThanOrEqualTo(SecuritySettingsConstants.Fields.PasswordMinLength.MinValue)
                .WithInvalidMinValue(SecuritySettingsConstants.Fields.PasswordMinLength.Label,
                                     SecuritySettingsConstants.Fields.PasswordMinLength.MinValue);

            Define(ss => ss.RequiredPasswordChars)
                .MaxLength();

            Define(ss => ss.HashAlgorithm);

            Define(ss => ss.ShowUserJoinDate);

            Define(ss => ss.AllowViewingProfiles);

            Define(ss => ss.GenderEnabled);

            Define(ss => ss.DateOfBirthEnabled);

            Define(ss => ss.CountryEnabled);

            Define(ss => ss.CityEnabled);

            Define(ss => ss.NewsletterEnabled);

            Define(ss => ss.NotifyForNewUserRegistration);

            Define(ss => ss.NotifyForNewComments);
        }
    }
}