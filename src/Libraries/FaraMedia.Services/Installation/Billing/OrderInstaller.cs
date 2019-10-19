namespace FaraMedia.Services.Installation.Billing {
    using FaraMedia.Data.Schemas.Billing;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class OrderInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(OrderConstants.Fields.Guid.Label, "تاریخ پرداخت");

                NewResource(OrderConstants.Fields.PlaceDateUtc.Label, "تاریخ پرداخت");

                NewResource(OrderConstants.Fields.Buyer.Label, "سفارش دهنده");
                NewResource(OrderConstants.Fields.BuyerIp.Label, "سفارش دهنده");

                NewResource(OrderConstants.Fields.Status.Label, "وضعیت");

                NewResource(OrderConstants.Fields.Lines.Label, "اقلام");

                NewResource(OrderConstants.Fields.Notes.Label, "یادداشت ها");

                NewResource(OrderConstants.Fields.Requests.Label, "اقلام");

                transaction.Commit();
            }
        }
    }
}