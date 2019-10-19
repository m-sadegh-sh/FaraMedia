namespace FaraMedia.Data.Schemas.Systematic {
	using FaraMedia.Core.Domain.Systematic;
	using FaraMedia.Core.Infrastructure.Extensions;

	public sealed class LogConstants : EntityConstantsBase<Log> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(l => l.Id);
		}

		public new sealed class Fields : EntityConstantsBase<Log>.Fields {
			public sealed class ShortMessage {
				public const int Length = 500;

				public static readonly string Label = Helpers.Label<ShortMessage>();
			}

			public sealed class FullMessage {
				public static readonly string Label = Helpers.Label<FullMessage>();
			}

			public sealed class RequestedUrl {
				public const int Length = Constants.UrlLength;

				public static readonly string Label = Helpers.Label<RequestedUrl>();
			}

			public sealed class ReferrerUrl {
				public const int Length = Constants.UrlLength;

				public static readonly string Label = Helpers.Label<ReferrerUrl>();
			}

			public sealed class Level {
				public static int MinValue = EnumExtensions.GetLowerBound<LogLevel>();
				public static int MaxValue = EnumExtensions.GetUpperBound<LogLevel>();

				public static readonly string Label = Helpers.Label<Level>();

				public static readonly string Debug = Helpers.Enum<Level, LogLevel>(LogLevel.Debug);
				public static readonly string Information = Helpers.Enum<Level, LogLevel>(LogLevel.Information);
				public static readonly string Warning = Helpers.Enum<Level, LogLevel>(LogLevel.Warning);
				public static readonly string Error = Helpers.Enum<Level, LogLevel>(LogLevel.Error);
				public static readonly string Fatal = Helpers.Enum<Level, LogLevel>(LogLevel.Fatal);
			}

			public sealed class LogDateUtc {
				public static readonly string Label = Helpers.Label<LogDateUtc>();
			}

			public sealed class Invoker {
				public static readonly string Label = Helpers.Label<Invoker>();
			}

			public sealed class InvokerIp {
				public const int Length = Constants.IpAddressLength;

				public static readonly string Label = Helpers.Label<InvokerIp>();
			}
		}
	}
}