namespace FaraMedia.Data.Mapping.Billing {
	using FaraMedia.Core.Domain.Billing;

	public sealed class OrderMap : EntityMapBase<Order> {
		public OrderMap() {
			Property(o => o.Guid,
			         pm => pm.Unique(true));
			Property(o => o.PlaceDateUtc);
			ManyToOne(o => o.Buyer);
			Property(o => o.BuyerIp);
			ManyToOne(o => o.Status);
			Set(o => o.Lines);
			Set(o => o.Notes);
			Set(o => o.Requests);
		}
	}
}