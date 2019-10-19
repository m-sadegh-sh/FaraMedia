namespace FaraMedia.Services.Installation.Shared {
    using FaraMedia.Data.Schemas.Shared;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class ShareInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            using (var transaction = session.BeginTransaction()) {
                NewResource(ShareConstants.Fields.Sharer.Label, "توسط");

                NewResource(ShareConstants.Fields.ShareDateUtc.Label, "تاریخ به اشتراک گذاری");

                transaction.Commit();
            }
        }
    }
}