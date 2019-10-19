namespace FaraMedia.Data.Schemas.Billing {
	using FaraMedia.Core.Domain.Billing;
	using FaraMedia.Core.Infrastructure.Extensions;

	public sealed class OrderLineConstants : EntityConstantsBase<OrderLine> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(ol => ol.Id);
		}

		public new sealed class Fields : EntityConstantsBase<OrderLine>.Fields {
			public sealed class Type {
				public static int MinValue = EnumExtensions.GetLowerBound<ItemType>();
				public static int MaxValue = EnumExtensions.GetUpperBound<ItemType>();

				public static readonly string Label = Helpers.Label<Type>();

				public static readonly string Album = Helpers.Enum<Type, ItemType>(ItemType.Album);
				public static readonly string Track = Helpers.Enum<Type, ItemType>(ItemType.Track);
			}

			public sealed class ItemId {
				public const int MinValue = Constants.ZeroAllowedDigits;

				public static readonly string Label = Helpers.Label<ItemId>();
			}

			public sealed class ItemTitle {
				public const int Length = 200;

				public static readonly string Label = Helpers.Label<ItemTitle>();
			}

			public sealed class Quantity {
				public const int MinValue = Constants.PositiveDigits;

				public static readonly string Label = Helpers.Label<Quantity>();
			}

			public sealed class Discount {
				public const int MinValue = Constants.ZeroAllowedDigits;

				public static readonly string Label = Helpers.Label<Discount>();
			}

			public sealed class Price {
				public const int MinValue = Constants.ZeroAllowedDigits;

				public static readonly string Label = Helpers.Label<Price>();
			}

			public sealed class Order {
				public static readonly string Label = Helpers.Label<Order>();
			}

			public sealed class Download {
				public static readonly string Label = Helpers.Label<Download>();
			}

			public sealed class AccessTries {
				public const int MinValue = Constants.ZeroAllowedDigits;

				public static readonly string Label = Helpers.Label<AccessTries>();
			}
		}
	}
}