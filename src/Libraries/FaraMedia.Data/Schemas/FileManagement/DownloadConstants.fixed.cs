namespace FaraMedia.Data.Schemas.FileManagement {
	using FaraMedia.Core.Domain.FileManagement;

	public sealed class DownloadConstants : UserContentConstantsBase<Download> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(d => d.Id);
		}

		public new sealed class Fields : UserContentConstantsBase<Download>.Fields {
			public sealed class UseDownloadUrl {
				public static readonly string Label = Helpers.Label<UseDownloadUrl>();
			}

			public sealed class FileName {
				public const int Length = 100;

				public static readonly string Label = Helpers.Label<FileName>();
			}

			public sealed class ContentType {
				public const int Length = 100;

				public static readonly string Label = Helpers.Label<ContentType>();
			}

			public sealed class ContentLength {
				public const int Length = Constants.ZeroAllowedDigits;

				public static readonly string Label = Helpers.Label<ContentLength>();
			}

			public sealed class Checksum {
				public const int Length = 160;

				public static readonly string Label = Helpers.Label<Checksum>();
			}

			public sealed class BinaryContent {
				public static readonly string Label = Helpers.Label<BinaryContent>();
			}

			public sealed class DownloadUrl {
				public const int Length = Constants.UrlLength;

				public static readonly string Label = Helpers.Label<DownloadUrl>();
			}
		}
	}
}