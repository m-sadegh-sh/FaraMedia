namespace FaraMedia.Data.Schemas.Configuration {
	using FaraMedia.Core.Domain.Configuration;

	public sealed class SystemSettingsConstants : ConstantsBase<SystemSettings> {
		public sealed class Fields {
			public sealed class IsClosed {
				public static readonly string Label = Helpers.Label<IsClosed>();
			}

			public sealed class CloseReason {
				public static readonly string Label = Helpers.Label<IsClosed>();
			}

			public sealed class MobileDevicesSupported {
				public static readonly string Label = Helpers.Label<MobileDevicesSupported>();
			}

			public sealed class EnableHttpCompression {
				public static readonly string Label = Helpers.Label<EnableHttpCompression>();
			}

			public sealed class LoadAllLocaleRecordsOnStartup {
				public static readonly string Label = Helpers.Label<LoadAllLocaleRecordsOnStartup>();
			}

			public sealed class ShowHeaderRssUrl {
				public static readonly string Label = Helpers.Label<ShowHeaderRssUrl>();
			}

			public sealed class CaseInvariantReplacement {
				public static readonly string Label = Helpers.Label<CaseInvariantReplacement>();
			}

			public sealed class ConvertNonWesternChars {
				public static readonly string Label = Helpers.Label<ConvertNonWesternChars>();
			}

			public sealed class AllowUnicodeCharsInUrls {
				public static readonly string Label = Helpers.Label<AllowUnicodeCharsInUrls>();
			}

			public sealed class CanonicalUrlsEnabled {
				public static readonly string Label = Helpers.Label<CanonicalUrlsEnabled>();
			}

			public sealed class DashboardPageSize {
				public const int MinValue = Constants.PositiveDigits;

				public static readonly string Label = Helpers.Label<DashboardPageSize>();
			}

			public sealed class MainPageSize {
				public const int MinValue = Constants.PositiveDigits;

				public static readonly string Label = Helpers.Label<MainPageSize>();
			}

			public sealed class ArchivePageSize {
				public const int MinValue = Constants.PositiveDigits;

				public static readonly string Label = Helpers.Label<ArchivePageSize>();
			}

			public sealed class Name {
				public const int Length = 100;

				public static readonly string Label = Helpers.Label<Name>();
			}

			public sealed class Url {
				public const int Length = Constants.UrlLength;

				public static readonly string Label = Helpers.Label<Url>();
			}

			public sealed class DefaultTitle {
				public const int Length = 200;

				public static readonly string Label = Helpers.Label<DefaultTitle>();
			}

			public sealed class DefaultMetaKeywords {
				public const int Length = 500;

				public static readonly string Label = Helpers.Label<DefaultMetaKeywords>();
			}

			public sealed class DefaultMetaDescription {
				public const int Length = 1000;

				public static readonly string Label = Helpers.Label<DefaultMetaDescription>();
			}

			public sealed class TitleSeparator {
				public const int Length = 20;

				public static readonly string Label = Helpers.Label<TitleSeparator>();
			}

			public sealed class BreadcrumbSeparator {
				public const int Length = 20;

				public static readonly string Label = Helpers.Label<BreadcrumbSeparator>();
			}

			public sealed class DefaultEmailAccountId {
				public const int MinValue = Constants.PositiveDigits;

				public static readonly string Label = Helpers.Label<DefaultEmailAccountId>();
			}

			public sealed class AllowUsersToSetTimeZone {
				public static readonly string Label = Helpers.Label<AllowUsersToSetTimeZone>();
			}

			public sealed class DefaultTimeZoneId {
				public static readonly string Label = Helpers.Label<DefaultTimeZoneId>();
			}

			public sealed class AllowUsersToSetLanguage {
				public static readonly string Label = Helpers.Label<AllowUsersToSetLanguage>();
			}

			public sealed class DefaultLanguageId {
				public const int MinValue = Constants.PositiveDigits;

				public static readonly string Label = Helpers.Label<DefaultLanguageId>();
			}

			public sealed class ImmediatelyRedirection {
				public static readonly string Label = Helpers.Label<ImmediatelyRedirection>();
			}

			public sealed class RedirectionDelay {
				public const int MinValue = Constants.PositiveDigits;

				public static readonly string Label = Helpers.Label<RedirectionDelay>();
			}
		}
	}
}