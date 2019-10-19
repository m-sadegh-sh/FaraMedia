namespace FaraMedia.Data.Knowns.Billing {
	using FaraMedia.Data.Schemas;

	public sealed class OrderStatusNames : ConstantsBase {
		public static readonly string Pending = Helpers.Key<OrderStatusNames, string>(osn => Pending);
		public static readonly string Processing = Helpers.Key<OrderStatusNames, string>(osn => Processing);
		public static readonly string Completed = Helpers.Key<OrderStatusNames, string>(osn => Completed);
		public static readonly string Cancelled = Helpers.Key<OrderStatusNames, string>(osn => Cancelled);
		public static readonly string Fraud = Helpers.Key<OrderStatusNames, string>(osn => Fraud);
	}
}