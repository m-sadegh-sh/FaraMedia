namespace FaraMedia.Services.Installation.ContentManagement {
    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class NewsInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(NewsConstants.Fields.Title.Label, "عنوان");
                NewResource(NewsConstants.Fields.Short.Label, "خلاصه");
                NewResource(NewsConstants.Fields.Full.Label, "متن کامل");

                NewResource(NewsConstants.Fields.Category.Label, "دسته (گروه)");

                transaction.Commit();
            }
        }
    }
}