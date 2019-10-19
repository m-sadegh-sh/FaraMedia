namespace FaraMedia.Data.Schemas.Fundamentals {
	using FaraMedia.Core.Domain.Fundamentals;

	public sealed class ArtistConstants : UIElementConstantsBase<Artist> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(a => a.Id);
		}

		public new sealed class Fields : UIElementConstantsBase<Artist>.Fields {
			public sealed class FullName {
				public const int Length = 100;

				public static readonly string Label = Helpers.Label<FullName>();
			}

			public sealed class AlternativeName {
				public const int Length = 100;

				public static readonly string Label = Helpers.Label<AlternativeName>();
			}

			public sealed class HomeTown {
				public const int Length = 50;

				public static readonly string Label = Helpers.Label<HomeTown>();
			}

			public sealed class Biography {
				public static readonly string Label = Helpers.Label<Biography>();
			}

			public sealed class BirthDateUtc {
				public static readonly string Label = Helpers.Label<BirthDateUtc>();
			}

			public sealed class Facebook {
				public const int Length = Constants.UrlLength;

				public static readonly string Label = Helpers.Label<Facebook>();
			}

			public sealed class Avatar {
				public static readonly string Label = Helpers.Label<Avatar>();
			}

			public sealed class PhotoAlbums {
				public static readonly string Label = Helpers.Label<PhotoAlbums>();
			}

			public sealed class SingedTracks {
				public static readonly string Label = Helpers.Label<SingedTracks>();
			}

			public sealed class ComposedTracks {
				public static readonly string Label = Helpers.Label<ComposedTracks>();
			}

			public sealed class ArrangedTracks {
				public static readonly string Label = Helpers.Label<ArrangedTracks>();
			}

			public sealed class SongwrittenTracks {
				public static readonly string Label = Helpers.Label<SongwrittenTracks>();
			}
		}
	}
}