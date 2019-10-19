namespace FaraMedia.Services.Installation.ContentManagement {
    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class GroupInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(GroupConstants.Fields.Title.Label, "عنوان");
                NewResource(GroupConstants.Fields.Description.Label, "والد");

                NewResource(GroupConstants.Fields.Parent.Label, "عنوان");

                NewResource(GroupConstants.Fields.Children.Label, "والد");
                NewResource(GroupConstants.Fields.Pages.Label, "عنوان");

                transaction.Commit();
            }
        }
    }
}