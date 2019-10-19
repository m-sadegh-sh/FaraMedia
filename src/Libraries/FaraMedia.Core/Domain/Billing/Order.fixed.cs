namespace FaraMedia.Core.Domain.Billing {
	using System;

	using FaraMedia.Core.Domain.Security;

	using Iesi.Collections.Generic;

	public class Order : EntityBase {
		private ISet<OrderLine> _lines;
		private ISet<OrderNote> _notes;
		private ISet<TransactionRequest> _requests;

		public virtual Guid Guid { get; set; }
		public virtual DateTime PlaceDateUtc { get; set; }
		public virtual User Buyer { get; set; }
		public virtual string BuyerIp { get; set; }
		public virtual OrderStatus Status { get; set; }

		public virtual ISet<OrderLine> Lines {
			get { return _lines ?? (_lines = new HashedSet<OrderLine>()); }
			protected set { _lines = value; }
		}

		public virtual ISet<OrderNote> Notes {
			get { return _notes ?? (_notes = new HashedSet<OrderNote>()); }
			protected set { _notes = value; }
		}

		public virtual ISet<TransactionRequest> Requests {
			get { return _requests ?? (_requests = new HashedSet<TransactionRequest>()); }
			protected set { _requests = value; }
		}
	}
}