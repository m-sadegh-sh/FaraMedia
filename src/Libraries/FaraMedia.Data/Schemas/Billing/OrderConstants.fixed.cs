namespace FaraMedia.Data.Schemas.Billing {
	using FaraMedia.Core.Domain.Billing;

	public sealed class OrderConstants : EntityConstantsBase<Order> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(o => o.Id);
		}

		public new sealed class Fields : EntityConstantsBase<Order>.Fields {
			public sealed class Guid {
				public static readonly string Label = Helpers.Label<Guid>();
			}

			public sealed class PlaceDateUtc {
				public static readonly string Label = Helpers.Label<PlaceDateUtc>();
			}

			public sealed class Buyer {
				public static readonly string Label = Helpers.Label<Buyer>();
			}

			public sealed class BuyerIp {
				public const int Length = Constants.IpAddressLength;

				public static readonly string Label = Helpers.Label<BuyerIp>();
			}

			public sealed class Status {
				public static readonly string Label = Helpers.Label<Status>();
			}

			public sealed class Lines {
				public static readonly string Label = Helpers.Label<Lines>();
			}

			public sealed class Notes {
				public static readonly string Label = Helpers.Label<Notes>();
			}

			public sealed class Requests {
				public static readonly string Label = Helpers.Label<Requests>();
			}
		}
	}
}