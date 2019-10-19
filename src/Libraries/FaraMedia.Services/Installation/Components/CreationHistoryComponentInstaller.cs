namespace FaraMedia.Services.Installation.Components {
    using FaraMedia.Data.Schemas.Components;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class CreationHistoryComponentInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(CreationHistoryComponentConstants.Fields.Creator.Label, "عنوان");
                NewResource(CreationHistoryComponentConstants.Fields.CreatorIp.Label, "عنوان");

                NewResource(CreationHistoryComponentConstants.Fields.CreateDateUtc.Label, "عنوان");

                transaction.Commit();
            }
        }
    }
}