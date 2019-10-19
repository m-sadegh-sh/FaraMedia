namespace FaraMedia.Services.Installation.Components {
    using FaraMedia.Data.Schemas.Components;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class DeletionHistoryComponentInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(DeletionHistoryComponentConstants.Fields.IsDeleted.Label, "عنوان");

                NewResource(DeletionHistoryComponentConstants.Fields.Deleter.Label, "عنوان");
                NewResource(DeletionHistoryComponentConstants.Fields.DeleterIp.Label, "عنوان");

                NewResource(DeletionHistoryComponentConstants.Fields.DeleteDateUtc.Label, "عنوان");

                transaction.Commit();
            }
        }
    }
}