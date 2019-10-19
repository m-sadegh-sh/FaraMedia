namespace FaraMedia.Services.Installation.Configuration {
    using FaraMedia.Data.Schemas.Configuration;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class SettingInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            using (var transaction = session.BeginTransaction()) {
                NewResource(SettingConstants.Fields.Key.Label, "کلید");
                NewResource(SettingConstants.Fields.Value.Label, "مقدار");

                transaction.Commit();
            }
        }
    }
}