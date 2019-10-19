namespace FaraMedia.Data.Schemas.Configuration {
	using FaraMedia.Core.Domain.Configuration;

	public sealed class FileManagementSettingsConstants : ConstantsBase<FileManagementSettings> {
		public sealed class Fields {
			public sealed class DefaultPictureZoomEnabled {
				public static readonly string Label = Helpers.Label<DefaultPictureZoomEnabled>();
			}

			public sealed class MaximumImageSize {
				public const int MinValue = Constants.PositiveDigits;

				public static readonly string Label = Helpers.Label<MaximumImageSize>();
			}

			public sealed class AvatarPictureSize {
				public const int MinValue = Constants.PositiveDigits;

				public static readonly string Label = Helpers.Label<AvatarPictureSize>();
			}

			public sealed class ThumbPictureSize {
				public const int MinValue = Constants.PositiveDigits;

				public static readonly string Label = Helpers.Label<ThumbPictureSize>();
			}

			public sealed class DetailsPictureSize {
				public const int MinValue = Constants.PositiveDigits;

				public static readonly string Label = Helpers.Label<DetailsPictureSize>();
			}

			public sealed class ImageQuality {
				public const int MinValue = Constants.PositiveDigits;
				public const int MaxValue = 100;

				public static readonly string Label = Helpers.Label<ImageQuality>();
			}

			public sealed class DefaultAvatarImageName {
				public const int Length = 100;

				public static readonly string Label = Helpers.Label<DefaultAvatarImageName>();
			}

			public sealed class DefaultEntityImageName {
				public const int Length = 100;

				public static readonly string Label = Helpers.Label<DefaultEntityImageName>();
			}

			public sealed class CdnUrl {
				public const int Length = Constants.UrlLength;

				public static readonly string Label = Helpers.Label<CdnUrl>();
			}

			public sealed class ImagesPath {
				public const int Length = Constants.PathLength;

				public static readonly string Label = Helpers.Label<ImagesPath>();
			}

			public sealed class StylesPath {
				public const int Length = Constants.PathLength;

				public static readonly string Label = Helpers.Label<StylesPath>();
			}

			public sealed class ScriptsPath {
				public const int Length = Constants.PathLength;

				public static readonly string Label = Helpers.Label<ScriptsPath>();
			}

			public sealed class DownloadsPath {
				public const int Length = Constants.PathLength;

				public static readonly string Label = Helpers.Label<DownloadsPath>();
			}
		}
	}
}