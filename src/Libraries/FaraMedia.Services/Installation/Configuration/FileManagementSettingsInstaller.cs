namespace FaraMedia.Services.Installation.Configuration {
    using FaraMedia.Core.Domain.Configuration;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Data.Schemas.Configuration;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class FileManagementSettingsInstaller : SettingsInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(FileManagementSettingsConstants.Fields.DefaultPictureZoomEnabled.Label, "بزرگنمایی فعال باشد.");
         
                NewResource(FileManagementSettingsConstants.Fields.MaximumImageSize.Label, "اندازه عکس");
                NewResource(FileManagementSettingsConstants.Fields.AvatarPictureSize.Label, "اندازه آواتار");
                NewResource(FileManagementSettingsConstants.Fields.ThumbPictureSize.Label, "اندازه عکس (بندانگشتی)");
                NewResource(FileManagementSettingsConstants.Fields.DetailsPictureSize.Label, "اندازه عکس (جزئیات)");
              
                NewResource(FileManagementSettingsConstants.Fields.ImageQuality.Label, "کیفیت عکس");
             
                NewResource(FileManagementSettingsConstants.Fields.DefaultAvatarImageName.Label, "نام عکس آواتار");
                NewResource(FileManagementSettingsConstants.Fields.DefaultEntityImageName.Label, "نام عکس موجودیت");
               
                NewResource(FileManagementSettingsConstants.Fields.CdnUrl.Label, "آدرس سی دی ان");
                NewResource(FileManagementSettingsConstants.Fields.ImagesPath.Label, "مسیر عکس ها");
                NewResource(FileManagementSettingsConstants.Fields.StylesPath.Label, "مسیر استایل ها");
                NewResource(FileManagementSettingsConstants.Fields.ScriptsPath.Label, "مسیر اسکریپت ها");
                NewResource(FileManagementSettingsConstants.Fields.DownloadsPath.Label, "مسیر دانلود ها");

                transaction.Commit();
            }
        }

        public override void InstallSettings() {
            EngineContext.Current.Resolve<IDbSettingsService<FileManagementSettings>>().Save(new FileManagementSettings
            {
                DefaultPictureZoomEnabled = false,
                MaximumImageSize = 1280,
                AvatarPictureSize = 85,
                ThumbPictureSize = 125,
                DetailsPictureSize = 300,
                ImageQuality = 70,
                DefaultAvatarImageName = "default-avatar.jpg",
                DefaultEntityImageName = "default-entity.jpg",
                CdnUrl = "http://www.cdn-faramedia.net/",
                ImagesPath = "images/",
                StylesPath = "styles/",
                ScriptsPath = "scripts/",
                DownloadsPath = "downloads/"
            });
        }
    }
}