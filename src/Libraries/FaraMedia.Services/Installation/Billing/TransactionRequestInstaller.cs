namespace FaraMedia.Services.Installation.Billing {
    using FaraMedia.Data.Schemas.Billing;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class TransactionRequestInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(TransactionRequestConstants.Fields.Order.Label, "وضعیت (بانک)");

                NewResource(TransactionRequestConstants.Fields.RequestDateUtc.Label, "شناسه خودگردان");

                NewResource(TransactionRequestConstants.Fields.MerchantId.Label, "وضعیت");
                NewResource(TransactionRequestConstants.Fields.TransactionKey.Label, "وضعیت");

                NewResource(TransactionRequestConstants.Fields.ComputedHash.Label, "سفارش");

                NewResource(TransactionRequestConstants.Fields.IsPending.Label, "سفارش");
                NewResource(TransactionRequestConstants.Fields.IsVerified.Label, "سفارش");

                NewResource(TransactionRequestConstants.Fields.Responses.Label, "سفارش");

                transaction.Commit();
            }
        }
    }
}