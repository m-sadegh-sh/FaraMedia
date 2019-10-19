namespace FaraMedia.Services.Installation.Fundamentals {
    using FaraMedia.Data.Schemas.Fundamentals;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class GenreInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(GenreConstants.Fields.Title.Label, "عنوان");
                NewResource(GenreConstants.Fields.Description.Label, "توضیحات");

                NewResource(GenreConstants.Fields.Tracks.Label, "توضیحات");

                transaction.Commit();
            }
        }
    }
}