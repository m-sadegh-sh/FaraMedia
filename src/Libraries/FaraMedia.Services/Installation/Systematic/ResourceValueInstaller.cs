namespace FaraMedia.Services.Installation.Systematic {
    using FaraMedia.Data.Schemas.Systematic;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class ResourceValueInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(ResourceValueConstants.Fields.Value.Label, "کلید");

                NewResource(ResourceValueConstants.Fields.Key.Label, "کلید");

                transaction.Commit();
            }
        }
    }
}