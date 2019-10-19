namespace FaraMedia.Services.Installation.Fundamentals {
    using FaraMedia.Data.Schemas.Fundamentals;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class AlbumInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(AlbumConstants.Fields.Title.Label, "عنوان آلبوم");
                NewResource(AlbumConstants.Fields.Description.Label, "توضیحات");

                NewResource(AlbumConstants.Fields.ReleaseDateUtc.Label, "تاریخ انتشار");

                NewResource(AlbumConstants.Fields.Tracks.Label, "ناشر");

                transaction.Commit();
            }
        }
    }
}