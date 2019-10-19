namespace FaraMedia.Services.Installation.Billing {
    using FaraMedia.Data.Schemas.Billing;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class OrderStatusInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var osansaction = session.BeginTransaction()) {
                NewResource(OrderStatusConstants.Fields.SystemName.Label, "وضعیت (بانک)");
                NewResource(OrderStatusConstants.Fields.DisplayName.Label, "وضعیت (بانک)");
                NewResource(OrderStatusConstants.Fields.Description.Label, "شناسه خودگردان");

                NewResource(OrderStatusConstants.Fields.Orders.Label, "شناسه خودگردان");

                osansaction.Commit();
            }
        }
    }
}