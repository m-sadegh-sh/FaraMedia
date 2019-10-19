namespace FaraMedia.Data.Mapping.Billing {
	using FaraMedia.Core.Domain.Billing;

	public sealed class OrderLineMap : EntityMapBase<OrderLine> {
		public OrderLineMap() {
			Property(ol => ol.Type);
			Property(ol => ol.ItemId);
			Property(ol => ol.ItemTitle);
			Property(ol => ol.Quantity);
			Property(ol => ol.Discount);
			Property(ol => ol.Price);
			ManyToOne(ol => ol.Order);
			ManyToOne(ol => ol.Download);
			Property(ol => ol.AccessTries);
		}
	}
}