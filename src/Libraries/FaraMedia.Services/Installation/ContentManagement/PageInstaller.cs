namespace FaraMedia.Services.Installation.ContentManagement {
    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class PageInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(PageConstants.Fields.Title.Label, "عنوان");
                NewResource(PageConstants.Fields.Body.Label, "بدنه");

                NewResource(PageConstants.Fields.Group.Label, "گروه");

                transaction.Commit();
            }
        }
    }
}