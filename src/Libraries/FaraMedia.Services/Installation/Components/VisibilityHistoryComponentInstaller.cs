namespace FaraMedia.Services.Installation.Components {
    using FaraMedia.Data.Schemas.Components;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class VisibilityHistoryComponentInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(VisibilityHistoryComponentConstants.Fields.IsVisible.Label, "عنوان");

                NewResource(VisibilityHistoryComponentConstants.Fields.Visibler.Label, "عنوان");
                NewResource(VisibilityHistoryComponentConstants.Fields.VisibilerIp.Label, "عنوان");

                NewResource(VisibilityHistoryComponentConstants.Fields.VisibleDateUtc.Label, "عنوان");

                transaction.Commit();
            }
        }
    }
}