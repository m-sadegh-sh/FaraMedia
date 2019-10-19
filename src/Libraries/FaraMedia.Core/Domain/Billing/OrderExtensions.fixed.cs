namespace FaraMedia.Core.Domain.Billing {
	using System.Linq;

	public static class OrderExtensions {
		public static int TotalAmount(this Order order) {
			var totalAmount = order.Lines.Sum(ol => (ol.Price*ol.Quantity) - ol.Discount);

			return totalAmount.GetValueOrDefault(0);
		}
	}
}