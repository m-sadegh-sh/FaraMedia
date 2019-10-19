namespace FaraMedia.Services.Installation.FileManagement {
    using FaraMedia.Data.Schemas.FileManagement;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class FileManagementSectionInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(FileManagementSectionConstants.Metadata.Title, "بخش مدیا");
                NewResource(FileManagementSectionConstants.Metadata.Description, ResourceTemplates.SectionDescription("دانلود ها و تصاویر"));

                NewResource(FileManagementSectionConstants.DownloadsController.List.Metadata.Title, "دانلود ها");
                NewResource(FileManagementSectionConstants.DownloadsController.List.Metadata.Description, ResourceTemplates.ListDescription("دانلود ها", "دانلود"));
                NewResource(FileManagementSectionConstants.DownloadsController.New.Metadata.Title, ResourceTemplates.NewTitle("دانلود"));
                NewResource(FileManagementSectionConstants.DownloadsController.New.Metadata.Description, ResourceTemplates.NewDescription("دانلود"));
                NewResource(FileManagementSectionConstants.DownloadsController.Edit.Metadata.Title, ResourceTemplates.EditTitle("دانلود"));
                NewResource(FileManagementSectionConstants.DownloadsController.Edit.Metadata.Description, ResourceTemplates.EditDescription("دانلود"));

                NewResource(FileManagementSectionConstants.PicturesController.List.Metadata.Title, "تصاویر");
                NewResource(FileManagementSectionConstants.PicturesController.List.Metadata.Description, ResourceTemplates.ListDescription("تصاویر", "تصویر"));
                NewResource(FileManagementSectionConstants.PicturesController.New.Metadata.Title, ResourceTemplates.NewTitle("تصویر"));
                NewResource(FileManagementSectionConstants.PicturesController.New.Metadata.Description, ResourceTemplates.NewDescription("تصویر"));
                NewResource(FileManagementSectionConstants.PicturesController.Edit.Metadata.Title, ResourceTemplates.EditTitle("تصویر"));
                NewResource(FileManagementSectionConstants.PicturesController.Edit.Metadata.Description, ResourceTemplates.EditDescription("تصویر"));

                transaction.Commit();
            }
        }
    }
}