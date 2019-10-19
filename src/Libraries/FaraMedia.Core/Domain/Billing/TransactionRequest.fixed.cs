namespace FaraMedia.Core.Domain.Billing {
	using System;

	using Iesi.Collections.Generic;

	public class TransactionRequest : EntityBase {
		private ISet<TransactionResponse> _responses;

		public virtual Order Order { get; set; }
		public virtual DateTime RequestDateUtc { get; set; }
		public virtual string MerchantId { get; set; }
		public virtual string TransactionKey { get; set; }
		public virtual string ComputedHash { get; set; }
		public virtual TransactionRequestStatus Status { get; set; }

		public virtual ISet<TransactionResponse> Responses {
			get { return _responses ?? (_responses = new HashedSet<TransactionResponse>()); }
			protected set { _responses = value; }
		}
	}
}