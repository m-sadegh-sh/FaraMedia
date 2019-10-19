namespace FaraMedia.Services.Installation.Fundamentals {
    using FaraMedia.Data.Schemas.Fundamentals;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class PhotoInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(PhotoConstants.Fields.Title.Label, "عنوان");
                NewResource(PhotoConstants.Fields.Description.Label, "توضیحات");

                NewResource(PhotoConstants.Fields.Album.Label, "عکس");
                NewResource(PhotoConstants.Fields.Picture.Label, "عکس");

                transaction.Commit();
            }
        }
    }
}