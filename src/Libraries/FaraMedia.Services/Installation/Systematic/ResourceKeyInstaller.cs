namespace FaraMedia.Services.Installation.Systematic {
    using FaraMedia.Data.Schemas.Systematic;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class ResourceKeyInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(ResourceKeyConstants.Fields.Key.Label, "کلید");
                NewResource(ResourceKeyConstants.Fields.DisplayName.Label, "کلید");
                NewResource(ResourceKeyConstants.Fields.Description.Label, "کلید");

                NewResource(ResourceKeyConstants.Fields.Values.Label, "کلید");

                transaction.Commit();
            }
        }
    }
}