namespace FaraMedia.Data.Mapping.Billing {
	using FaraMedia.Core.Domain.Billing;
	using FaraMedia.Data.Mapping.Shared;

	public sealed class OrderStatusMap : AttributeMapBase<OrderStatus> {
		public OrderStatusMap() {
			Set(os => os.Orders);
		}
	}
}