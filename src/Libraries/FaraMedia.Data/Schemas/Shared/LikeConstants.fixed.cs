namespace FaraMedia.Data.Schemas.Shared {
	using FaraMedia.Core.Domain.Shared;

	public sealed class LikeConstants : OwnableConstantsBase<Like> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(l => l.Id);
		}

		public new sealed class Fields : OwnableConstantsBase<Like>.Fields {
			public sealed class Liker {
				public static readonly string Label = Helpers.Label<Liker>();
			}

			public sealed class LikeDateUtc {
				public static readonly string Label = Helpers.Label<LikeDateUtc>();
			}
		}
	}
}