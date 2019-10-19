namespace FaraMedia.Services.Installation.Fundamentals {
    using FaraMedia.Data.Schemas.Fundamentals;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class PhotoAlbumInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(PhotoAlbumConstants.Fields.Title.Label, "عنوان");
                NewResource(PhotoAlbumConstants.Fields.Description.Label, "توضیحات");

                NewResource(PhotoAlbumConstants.Fields.Artist.Label, "مربوط به");
                
                NewResource(PhotoAlbumConstants.Fields.Photos.Label, "مربوط به");

                transaction.Commit();
            }
        }
    }
}