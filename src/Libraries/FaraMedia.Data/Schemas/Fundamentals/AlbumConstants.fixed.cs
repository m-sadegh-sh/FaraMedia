namespace FaraMedia.Data.Schemas.Fundamentals {
	using FaraMedia.Core.Domain.Fundamentals;

	public sealed class AlbumConstants : UIElementConstantsBase<Album> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(a => a.Id);
		}

		public new sealed class Fields : UIElementConstantsBase<Album>.Fields {
			public sealed class Title {
				public const int Length = 200;

				public static readonly string Label = Helpers.Label<Title>();
			}

			public sealed class Description {
				public static readonly string Label = Helpers.Label<Description>();
			}

			public sealed class ReleaseDateUtc {
				public static readonly string Label = Helpers.Label<ReleaseDateUtc>();
			}

			public sealed class Tracks {
				public static readonly string Label = Helpers.Label<Tracks>();
			}
		}
	}
}