namespace FaraMedia.Data.Schemas.Misc {
	using FaraMedia.Core.Domain.Misc;

	public sealed class RedirectorConstants : EntityConstantsBase<Redirector> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(r => r.Id);
			public static readonly string ByTargetUrl = Helpers.CacheKey(r => r.TargetUrl);
		}

		public new sealed class Fields : EntityConstantsBase<Redirector>.Fields {
			public sealed class TargetUrl {
				public const int Length = Constants.UrlLength;

				public static readonly string Label = Helpers.Label<TargetUrl>();
			}

			public sealed class ShortHash {
				public const int Length = 32;

				public static readonly string Label = Helpers.Label<ShortHash>();
			}

			public sealed class UrlName {
				public const int Length = 200;

				public static readonly string Label = Helpers.Label<UrlName>();
			}

			public sealed class Description {
				public static readonly string Label = Helpers.Label<Description>();
			}

			public sealed class UsageTimes {
				public const int MinValue = Constants.ZeroAllowedDigits;

				public static readonly string Label = Helpers.Label<UsageTimes>();
			}

			public sealed class Downloads {
				public static readonly string Label = Helpers.Label<Downloads>();
			}

			public sealed class Artists {
				public static readonly string Label = Helpers.Label<Artists>();
			}

			public sealed class Publishers {
				public static readonly string Label = Helpers.Label<Publishers>();
			}
		}
	}
}