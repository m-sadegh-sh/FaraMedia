namespace FaraMedia.Services.Installation.Billing {
    using FaraMedia.Data.Schemas.Billing;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class OrderLineInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(OrderLineConstants.Fields.ItemId.Label, "نام");
                NewResource(OrderLineConstants.Fields.ItemTitle.Label, "نام");

                NewResource(OrderLineConstants.Fields.Quantity.Label, "تعداد");
                NewResource(OrderLineConstants.Fields.Discount.Label, "قیمت");
                NewResource(OrderLineConstants.Fields.Price.Label, "قیمت");

                NewResource(OrderLineConstants.Fields.Type.Label, "مربوط به");

                NewResource(OrderLineConstants.Fields.Order.Label, "مربوط به");

                NewResource(OrderLineConstants.Fields.Download.Label, "بارگذاری");
                NewResource(OrderLineConstants.Fields.AccessTries.Label, "تعداد دسترسی ها");

                transaction.Commit();
            }
        }
    }
}