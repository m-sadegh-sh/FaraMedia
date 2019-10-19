namespace FaraMedia.Services.Installation {
    using FaraMedia.Core.Domain;
    using FaraMedia.Data.Schemas;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class SecurableInstaller : ResourceInstallerBase
    {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(SecurableConstantsBase<SecurableBase>.Fields.IsSecured.Label, "آدرس آی پی");
               
                transaction.Commit();
            }
        }
    }
}