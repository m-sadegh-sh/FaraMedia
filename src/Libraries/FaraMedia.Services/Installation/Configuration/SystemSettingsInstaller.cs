namespace FaraMedia.Services.Installation.Configuration {
    using System;
    using System.Linq;

    using FaraMedia.Core.Domain.Configuration;
    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Data.Schemas.Configuration;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;
    using NHibernate.Linq;

    public sealed class SystemSettingsInstaller : SettingsInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(SystemSettingsConstants.Fields.IsClosed.Label, "سایت بسته شود.");
                NewResource(SystemSettingsConstants.Fields.MobileDevicesSupported.Label, "از موبایل پشتیبانی می شود.");
                NewResource(SystemSettingsConstants.Fields.EnableHttpCompression.Label, "برای کاهش ترافیک سرور، فشرده سازی انجام شود.");
                NewResource(SystemSettingsConstants.Fields.LoadAllLocaleRecordsOnStartup.Label, "بارگذاری تمام منابع.");
                NewResource(SystemSettingsConstants.Fields.ShowHeaderRssUrl.Label, "آدرس فید در سربرگ نمایش داده شود؟");
                NewResource(SystemSettingsConstants.Fields.CaseInvariantReplacement.Label, "چشم پوشی از حساسیت به حروف هنگام جایگذاری نشانه ها در بدنه قالب پیام.");
                NewResource(SystemSettingsConstants.Fields.ConvertNonWesternChars.Label, "کاراکترهای غیر. ISO تبدیل شوند");
                NewResource(SystemSettingsConstants.Fields.AllowUnicodeCharsInUrls.Label, "وجود کاراکترهای یونیکد در آدرس مجاز است.");
                NewResource(SystemSettingsConstants.Fields.CanonicalUrlsEnabled.Label, "آدرس استاندارد ایجاد شود.");

                NewResource(SystemSettingsConstants.Fields.GridPageSize.Label, "عنوان صفحات");
                NewResource(SystemSettingsConstants.Fields.MainPageSize.Label, "تعداد پست ها (صفحه اصلی)");
                NewResource(SystemSettingsConstants.Fields.ArchivePageSize.Label, "تعداد پست ها (آرشیو)");

                NewResource(SystemSettingsConstants.Fields.Name.Label, "نام");
                NewResource(SystemSettingsConstants.Fields.Url.Label, "آدرس");

                NewResource(SystemSettingsConstants.Fields.DefaultTitle.Label, "عنوان صفحات");
                NewResource(SystemSettingsConstants.Fields.DefaultMetaKeywords.Label, "کلمات کلیدی صفحات");
                NewResource(SystemSettingsConstants.Fields.DefaultMetaDescription.Label, "توضیحات صفحات");

                NewResource(SystemSettingsConstants.Fields.TitleSeparator.Label, "جداکننده عنوان صفحات");
                NewResource(SystemSettingsConstants.Fields.BreadcrumbSeparator.Label, "جداکننده مسیر کاربر");

                NewResource(SystemSettingsConstants.Fields.Color1.Label, "رنگ شماره 1");
                NewResource(SystemSettingsConstants.Fields.Color2.Label, "رنگ شماره 2");
                NewResource(SystemSettingsConstants.Fields.Color3.Label, "رنگ شماره 3");

                NewResource(SystemSettingsConstants.Fields.DefaultEmailAccountId.Label, "حساب ایمیل پیشفرض");
                NewResource(SystemSettingsConstants.Fields.AllowUsersToSetTimeZone.Label, "به کاربر اجازه تغییر منطقه زمانی داده شود.");
                NewResource(SystemSettingsConstants.Fields.DefaultTimeZoneId.Label, "حساب ایمیل پیشفرض");
                NewResource(SystemSettingsConstants.Fields.AllowUsersToSetLanguage.Label, "به کاربر اجازه تغییر منطقه زمانی داده شود.");
                NewResource(SystemSettingsConstants.Fields.DefaultLanguageId.Label, "حساب ایمیل پیشفرض");

                NewResource(SystemSettingsConstants.Fields.ImmediatelyRedirection.Label, "کاربر به محض درخواست آدرس، بدون وفقه به آن منتقل شود.");
                NewResource(SystemSettingsConstants.Fields.RedirectionDelay.Label, "تاخیر زمانی");

                transaction.Commit();
            }
        }

        public override void InstallSettings() {
            var emailAccount = EngineContext.Current.Resolve<IStatelessSession>().Query<EmailAccount>().Take(1).ToList().FirstOrDefault();

            if (emailAccount == null)
                throw new InvalidOperationException("No EmailAccount can be found.");

            var language = EngineContext.Current.Resolve<IStatelessSession>().Query<Language>().Take(1).ToList().FirstOrDefault();

            if (language == null)
                throw new InvalidOperationException("No Language can be found.");

            EngineContext.Current.Resolve<IDbSettingsService<SystemSettings>>().Save(new SystemSettings {
                IsClosed = false,
                MobileDevicesSupported = false,
                EnableHttpCompression = true,
                LoadAllLocaleRecordsOnStartup = true,
                ShowHeaderRssUrl = true,
                CaseInvariantReplacement = false,
                ConvertNonWesternChars = false,
                AllowUnicodeCharsInUrls = true,
                CanonicalUrlsEnabled = true,
                GridPageSize = 10,
                MainPageSize = 3,
                ArchivePageSize = 10,
                Name = "فرامدیا",
                Url = "http://www.faramedia.com/",
                DefaultTitle = "فرامدیا",
                DefaultMetaKeywords = "خرید، موزیک، آنلاین",
                DefaultMetaDescription = "اولین فروشگاه خرید آنلاین موزیک",
                TitleSeparator = " - ",
                BreadcrumbSeparator = "/",
                Color1 = "#b9babe",
                Color2 = "#ebecee",
                Color3 = "#dde2e6",
                DefaultEmailAccountId = emailAccount.Id,
                AllowUsersToSetTimeZone = true,
                DefaultTimeZoneId = "Iran Standard Time",
                AllowUsersToSetLanguage = true,
                DefaultLanguageId = language.Id,
                ImmediatelyRedirection = false,
                RedirectionDelay = 10
            });
        }
    }
}