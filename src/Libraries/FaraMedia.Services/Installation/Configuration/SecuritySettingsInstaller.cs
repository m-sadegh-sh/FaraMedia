namespace FaraMedia.Services.Installation.Configuration {
    using FaraMedia.Core.Domain.Configuration;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Data.Schemas.Configuration;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class SecuritySettingsInstaller : SettingsInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(SecuritySettingsConstants.Fields.EncryptionKey.Label, "کلید رمزنگاری");
                NewResource(SecuritySettingsConstants.Fields.AdminAreaAllowedIpAddress.Label, "آدرس آی پی مجاز");
                NewResource(SecuritySettingsConstants.Fields.HideLinksBasedOnPermissions.Label, "آدرس آی پی مجاز");
                NewResource(SecuritySettingsConstants.Fields.UseSsl.Label, "از اس اس ال استفاده شود.");

                NewResource(SecuritySettingsConstants.Fields.MaxumimMinutesToDeleteGuestUsers.Label, "کاربران برخط");
                NewResource(SecuritySettingsConstants.Fields.OnlineUserMinutes.Label, "کاربران برخط");

                NewResource(SecuritySettingsConstants.Fields.RegistrationType.Label, "نوع ثبت نام");
                NewResource(SecuritySettingsConstants.Fields.RegistrationType.Standard, "استاندارد");
                NewResource(SecuritySettingsConstants.Fields.RegistrationType.EmailValidation, "اعتبارسنجی از طریق ایمیل");
                NewResource(SecuritySettingsConstants.Fields.RegistrationType.AdminApproval, "تایید توسط مدیر");
                NewResource(SecuritySettingsConstants.Fields.RegistrationType.Disabled, "غیرفعال");

                NewResource(SecuritySettingsConstants.Fields.UserNamesEnabled.Label, "نام کاربری فعال باشد");
                NewResource(SecuritySettingsConstants.Fields.IllegalUserNameChars.Label, "نام کاربری فعال باشد");
                NewResource(SecuritySettingsConstants.Fields.ScreenNameFormat.Label, "قالب نام کاربر");
                NewResource(SecuritySettingsConstants.Fields.ScreenNameFormat.Email, "ایمیل");
                NewResource(SecuritySettingsConstants.Fields.ScreenNameFormat.UserName, "نام کاربری");
                NewResource(SecuritySettingsConstants.Fields.ScreenNameFormat.FullName, "نام کامل");

                NewResource(SecuritySettingsConstants.Fields.PasswordMinLength.Label, "حداقل طول گذرواژه");
                NewResource(SecuritySettingsConstants.Fields.RequiredPasswordChars.Label, "حداقل طول گذرواژه");
                NewResource(SecuritySettingsConstants.Fields.HashAlgorithm.Label, "قالب گذرواژه");
                NewResource(SecuritySettingsConstants.Fields.HashAlgorithm.Sha1, "اس اچ ای 1 (SHA1)");
                NewResource(SecuritySettingsConstants.Fields.HashAlgorithm.Md5, "ام دی 5 (MD5)");

                NewResource(SecuritySettingsConstants.Fields.ShowUserJoinDate.Label, "تاریخ عضویت کاربر نمایش داده شود.");
                NewResource(SecuritySettingsConstants.Fields.AllowViewingProfiles.Label, "امکان نمایش پروفایل وجود داشته باشد.");
                NewResource(SecuritySettingsConstants.Fields.GenderEnabled.Label, "جنسیت فعال باشد.");
                NewResource(SecuritySettingsConstants.Fields.DateOfBirthEnabled.Label, "تاریخ تولد فعال باشد.");
                NewResource(SecuritySettingsConstants.Fields.CityEnabled.Label, "شهر فعال باشد.");
                NewResource(SecuritySettingsConstants.Fields.CountryEnabled.Label, "کشور فعال باشد.");
                NewResource(SecuritySettingsConstants.Fields.NewsletterEnabled.Label, "کشور فعال باشد.");

                NewResource(SecuritySettingsConstants.Fields.NotifyForNewUserRegistration.Label, "کاربر به محض درخواست آدرس، بدون وفقه به آن منتقل شود.");
                NewResource(SecuritySettingsConstants.Fields.NotifyForNewComments.Label, "کاربر به محض درخواست آدرس، بدون وفقه به آن منتقل شود.");

                transaction.Commit();
            }
        }

        public override void InstallSettings() {
            EngineContext.Current.Resolve<IDbSettingsService<SecuritySettings>>().Save(new SecuritySettings {
                EncryptionKey = "273ece6f97dd844d",
                AdminAreaAllowedIpAddress = "",
                HideLinksBasedOnPermissions = true,
                UseSsl = true,
                OnlineUserMinutes = 20,
                RegistrationType = UserRegistrationType.Standard,
                UserNamesEnabled = true,
                IllegalUserNameChars = "",
                ScreenNameFormat = DisplayScreenNameFormat.FullName,
                PasswordMinLength = 6,
                RequiredPasswordChars = "",
                HashAlgorithm = HashedPasswordAlgorithm.Sha1,
                ShowUserJoinDate = false,
                AllowViewingProfiles = true,
                GenderEnabled = true,
                DateOfBirthEnabled = true,
                CountryEnabled = true,
                CityEnabled = true,
                NewsletterEnabled = true,
                NotifyForNewUserRegistration = true,
                NotifyForNewComments = true,
            });
        }
    }
}