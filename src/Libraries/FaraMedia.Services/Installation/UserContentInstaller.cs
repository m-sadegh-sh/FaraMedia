namespace FaraMedia.Services.Installation {
    using FaraMedia.Core.Domain;
    using FaraMedia.Data.Schemas;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class UserContentInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(UserContentConstantsBase<UserContentBase>.Fields.CreationHistory.Label, "آدرس آی پی");
                NewResource(UserContentConstantsBase<UserContentBase>.Fields.ModificationHistory.Label, "آدرس آی پی");
                NewResource(UserContentConstantsBase<UserContentBase>.Fields.VisibilityHistory.Label, "آدرس آی پی");

                transaction.Commit();
            }
        }
    }
}