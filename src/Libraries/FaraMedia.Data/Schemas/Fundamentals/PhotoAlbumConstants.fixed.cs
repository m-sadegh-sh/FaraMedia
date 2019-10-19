namespace FaraMedia.Data.Schemas.Fundamentals {
	using FaraMedia.Core.Domain.Fundamentals;

	public sealed class PhotoAlbumConstants : UIElementConstantsBase<PhotoAlbum> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(pa => pa.Id);
		}

		public new sealed class Fields : UIElementConstantsBase<PhotoAlbum>.Fields {
			public sealed class Title {
				public const int Length = 200;

				public static readonly string Label = Helpers.Label<Title>();
			}

			public sealed class Description {
				public static readonly string Label = Helpers.Label<Description>();
			}

			public sealed class Artist {
				public static readonly string Label = Helpers.Label<Artist>();
			}

			public sealed class Photos {
				public static readonly string Label = Helpers.Label<Photos>();
			}
		}
	}
}