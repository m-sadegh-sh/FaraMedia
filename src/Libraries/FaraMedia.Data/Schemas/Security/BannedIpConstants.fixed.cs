namespace FaraMedia.Data.Schemas.Security {
	using FaraMedia.Core.Domain.Security;

	public sealed class BannedIpConstants : EntityConstantsBase<BannedIp> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(bi => bi.Id);
			public static readonly string ByIpAddress = Helpers.CacheKey(bi => bi.IpAdrress);
		}

		public new sealed class Fields : EntityConstantsBase<BannedIp>.Fields {
			public sealed class IpAdrress {
				public const int Length = Constants.IpAddressLength;

				public static readonly string Label = Helpers.Label<IpAdrress>();
			}

			public sealed class Reason {
				public const int Length = 1000;

				public static readonly string Label = Helpers.Label<Reason>();
			}

			public sealed class StartDateUtc {
				public static readonly string Label = Helpers.Label<StartDateUtc>();
			}

			public sealed class ExpireDateUtc {
				public static readonly string Label = Helpers.Label<ExpireDateUtc>();
			}
		}
	}
}