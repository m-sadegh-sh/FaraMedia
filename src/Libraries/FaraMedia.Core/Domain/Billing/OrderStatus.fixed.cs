namespace FaraMedia.Core.Domain.Billing {
	using FaraMedia.Core.Domain.Shared;

	using Iesi.Collections.Generic;

	public class OrderStatus : AttributeBase {
		private ISet<Order> _orders;

		public virtual ISet<Order> Orders {
			get { return _orders ?? (_orders = new HashedSet<Order>()); }
			protected set { _orders = value; }
		}
	}
}