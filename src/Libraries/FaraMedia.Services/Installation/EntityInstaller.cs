namespace FaraMedia.Services.Installation {
    using FaraMedia.Core.Domain;
    using FaraMedia.Data.Schemas;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class EntityInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(EntityConstantsBase<EntityBase>.Fields.Id.Label, "شناسه");

                transaction.Commit();
            }
        }
    }
}