namespace FaraMedia.Data.Schemas.Billing {
	using FaraMedia.Core.Domain.Billing;
	using FaraMedia.Data.Schemas.Shared;

	public sealed class OrderStatusConstants : AttributeConstantsBase<OrderStatus> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(os => os.Id);
		}

		public new sealed class Fields : EntityConstantsBase<OrderStatus>.Fields {
			public sealed class Orders {
				public static readonly string Label = Helpers.Label<Orders>();
			}
		}
	}
}