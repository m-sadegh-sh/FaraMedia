namespace FaraMedia.Data.Mapping.Billing {
	using FaraMedia.Core.Domain.Billing;

	public sealed class TransactionResponseMap : EntityMapBase<TransactionResponse> {
		public TransactionResponseMap() {
			ManyToOne(tr => tr.Request);
			Property(tr => tr.VerifyDateUtc);
			Property(tr => tr.Code);
			Property(tr => tr.SubCode);
			Property(tr => tr.ReasonCode);
			Property(tr => tr.ReasonDescription);
			Property(tr => tr.Result);
		}
	}
}