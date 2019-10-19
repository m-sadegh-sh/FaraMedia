namespace FaraMedia.Data.Schemas.Shared {
	using FaraMedia.Core.Domain.Shared;

	public sealed class ShareConstants : OwnableConstantsBase<Share> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(s => s.Id);
		}

		public new sealed class Fields : OwnableConstantsBase<Share>.Fields {
			public sealed class Sharer {
				public static readonly string Label = Helpers.Label<Sharer>();
			}

			public sealed class ShareDateUtc {
				public static readonly string Label = Helpers.Label<ShareDateUtc>();
			}
		}
	}
}