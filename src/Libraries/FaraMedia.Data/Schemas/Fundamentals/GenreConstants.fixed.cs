namespace FaraMedia.Data.Schemas.Fundamentals {
	using FaraMedia.Core.Domain.Fundamentals;

	public sealed class GenreConstants : UIElementConstantsBase<Genre> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(g => g.Id);
		}

		public new sealed class Fields : UIElementConstantsBase<Genre>.Fields {
			public sealed class Title {
				public const int Length = 50;

				public static readonly string Label = Helpers.Label<Title>();
			}

			public sealed class Description {
				public static readonly string Label = Helpers.Label<Description>();
			}

			public sealed class Tracks {
				public static readonly string Label = Helpers.Label<Tracks>();
			}
		}
	}
}