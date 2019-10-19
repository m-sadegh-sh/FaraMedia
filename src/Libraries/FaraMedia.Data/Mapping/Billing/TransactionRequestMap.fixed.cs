namespace FaraMedia.Data.Mapping.Billing {
	using FaraMedia.Core.Domain.Billing;

	public sealed class TransactionRequestMap : EntityMapBase<TransactionRequest> {
		public TransactionRequestMap() {
			ManyToOne(tr => tr.Order);
			Property(tr => tr.RequestDateUtc);
			Property(tr => tr.MerchantId);
			Property(tr => tr.TransactionKey);
			Property(tr => tr.ComputedHash,
			         pm => pm.Unique(true));
			Property(tr => tr.Status);
			Set(tr => tr.Responses);
		}
	}
}