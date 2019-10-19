namespace FaraMedia.Services.Installation.Security {
    using FaraMedia.Data.Schemas.Security;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class BannedIpInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(BannedIpConstants.Fields.IpAdrress.Label, "آدرس آی پی");
                NewResource(BannedIpConstants.Fields.Reason.Label, "دلیل مسدود شدن");

                NewResource(BannedIpConstants.Fields.StartDateUtc.Label, "تاریخ انقضا");
                NewResource(BannedIpConstants.Fields.ExpireDateUtc.Label, "تاریخ انقضا");

                transaction.Commit();
            }
        }
    }
}