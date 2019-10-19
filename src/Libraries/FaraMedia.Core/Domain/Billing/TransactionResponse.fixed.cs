namespace FaraMedia.Core.Domain.Billing {
	using System;

	public class TransactionResponse : EntityBase {
		public virtual TransactionRequest Request { get; set; }
		public virtual DateTime VerifyDateUtc { get; set; }
		public virtual string Code { get; set; }
		public virtual string SubCode { get; set; }
		public virtual string ReasonCode { get; set; }
		public virtual string ReasonDescription { get; set; }
		public virtual TransactionResponseResult Result { get; set; }
	}
}