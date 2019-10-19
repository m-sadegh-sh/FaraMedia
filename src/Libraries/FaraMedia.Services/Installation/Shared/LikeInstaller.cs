namespace FaraMedia.Services.Installation.Shared {
    using FaraMedia.Data.Schemas.Shared;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class LikeInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            using (var transaction = session.BeginTransaction()) {
                NewResource(LikeConstants.Fields.Liker.Label, "توسط");

                NewResource(LikeConstants.Fields.LikeDateUtc.Label, "تاریخ لایک");

                transaction.Commit();
            }
        }
    }
}