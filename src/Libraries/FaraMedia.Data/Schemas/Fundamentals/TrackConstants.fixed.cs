namespace FaraMedia.Data.Schemas.Fundamentals {
	using FaraMedia.Core.Domain.Fundamentals;

	public sealed class TrackConstants : UIElementConstantsBase<Track> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(t => t.Id);
		}

		public new sealed class Fields : UIElementConstantsBase<Track>.Fields {
			public sealed class Title {
				public const int Length = 200;

				public static readonly string Label = Helpers.Label<Title>();
			}

			public sealed class Description {
				public static readonly string Label = Helpers.Label<Description>();
			}

			public sealed class IsVideo {
				public static readonly string Label = Helpers.Label<IsVideo>();
			}

			public sealed class TrackNumber {
				public const int MinValue = Constants.PositiveDigits;

				public static readonly string Label = Helpers.Label<TrackNumber>();
			}

			public sealed class ReleaseDateUtc {
				public static readonly string Label = Helpers.Label<ReleaseDateUtc>();
			}

			public sealed class Genre {
				public static readonly string Label = Helpers.Label<Genre>();
			}

			public sealed class Album {
				public static readonly string Label = Helpers.Label<Album>();
			}

			public sealed class Publisher {
				public static readonly string Label = Helpers.Label<Publisher>();
			}

			public sealed class Covers {
				public static readonly string Label = Helpers.Label<Covers>();
			}

			public sealed class Downloads {
				public static readonly string Label = Helpers.Label<Downloads>();
			}

			public sealed class Singers {
				public static readonly string Label = Helpers.Label<Singers>();
			}

			public sealed class Composers {
				public static readonly string Label = Helpers.Label<Composers>();
			}

			public sealed class Arrangementers {
				public static readonly string Label = Helpers.Label<Arrangementers>();
			}

			public sealed class Songwriters {
				public static readonly string Label = Helpers.Label<Songwriters>();
			}
		}
	}
}