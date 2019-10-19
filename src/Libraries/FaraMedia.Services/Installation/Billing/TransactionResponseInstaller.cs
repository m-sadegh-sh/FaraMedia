namespace FaraMedia.Services.Installation.Billing {
    using FaraMedia.Data.Schemas.Billing;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class TransactionResponseInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(TransactionResponseConstants.Fields.Request.Label, "شناسه خودگردان");

                NewResource(TransactionResponseConstants.Fields.VerifyDateUtc.Label, "شناسه خودگردان");

                NewResource(TransactionResponseConstants.Fields.Code.Label, "وضعیت");
                NewResource(TransactionResponseConstants.Fields.SubCode.Label, "وضعیت");
                NewResource(TransactionResponseConstants.Fields.ReasonCode.Label, "وضعیت");
                NewResource(TransactionResponseConstants.Fields.ReasonDescription.Label, "وضعیت");

                transaction.Commit();
            }
        }
    }
}