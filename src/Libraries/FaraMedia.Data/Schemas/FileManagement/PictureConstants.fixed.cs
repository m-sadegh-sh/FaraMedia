namespace FaraMedia.Data.Schemas.FileManagement {
	using FaraMedia.Core.Domain.FileManagement;

	public sealed class PictureConstants : UserContentConstantsBase<Picture> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(p => p.Id);
		}

		public new sealed class Fields : UserContentConstantsBase<Picture> {
			public sealed class FileName {
				public const int Length = 100;

				public static readonly string Label = Helpers.Label<FileName>();
			}

			public sealed class MimeType {
				public const int Length = 100;

				public static readonly string Label = Helpers.Label<MimeType>();
			}
		}
	}
}