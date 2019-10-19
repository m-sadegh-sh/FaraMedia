namespace FaraMedia.Services.Installation.FileManagement {
    using FaraMedia.Data.Schemas.FileManagement;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class PictureInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(PictureConstants.Fields.MimeType.Label, "قالب");
                NewResource(PictureConstants.Fields.FileName.Label, "نام سند");

                transaction.Commit();
            }
        }
    }
}