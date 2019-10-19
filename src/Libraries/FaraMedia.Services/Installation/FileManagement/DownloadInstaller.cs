namespace FaraMedia.Services.Installation.FileManagement {
    using FaraMedia.Data.Schemas.FileManagement;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class DownloadInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(DownloadConstants.Fields.UseDownloadUrl.Label, "استفاده از آدرس");

                NewResource(DownloadConstants.Fields.ContentType.Label, "نوع محتوی");
                NewResource(DownloadConstants.Fields.FileName.Label, "نام سند");

                NewResource(DownloadConstants.Fields.DownloadUrl.Label, "آدرس");

                transaction.Commit();
            }
        }
    }
}