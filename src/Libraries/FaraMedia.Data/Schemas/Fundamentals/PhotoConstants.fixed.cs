namespace FaraMedia.Data.Schemas.Fundamentals {
	using FaraMedia.Core.Domain.Fundamentals;

	public sealed class PhotoConstants : UIElementConstantsBase<Photo> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(p => p.Id);
		}

		public new sealed class Fields : UIElementConstantsBase<Photo>.Fields {
			public sealed class Title {
				public const int Length = 200;

				public static readonly string Label = Helpers.Label<Title>();
			}

			public sealed class Description {
				public static readonly string Label = Helpers.Label<Description>();
			}

			public sealed class Album {
				public static readonly string Label = Helpers.Label<Album>();
			}

			public sealed class Picture {
				public static readonly string Label = Helpers.Label<Picture>();
			}
		}
	}
}