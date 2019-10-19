namespace FaraMedia.Data.Schemas.Systematic {
	using FaraMedia.Core.Domain;
	using FaraMedia.Core.Domain.Systematic;
	using FaraMedia.Core.Infrastructure.Extensions;

	public sealed class QueuedEmailConstants : EntityConstantsBase<QueuedEmail> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(qe => qe.Id);
		}

		public new sealed class Fields : EntityConstantsBase<QueuedEmail>.Fields {
			public sealed class From {
				public const int Length = Constants.EmailLength;

				public static readonly string Label = Helpers.Label<From>();
			}

			public sealed class FromName {
				public const int Length = 100;

				public static readonly string Label = Helpers.Label<FromName>();
			}

			public sealed class To {
				public const int Length = Constants.EmailLength;

				public static readonly string Label = Helpers.Label<To>();
			}

			public sealed class ToName {
				public const int Length = 100;

				public static readonly string Label = Helpers.Label<ToName>();
			}

			public sealed class Cc {
				public static readonly string Label = Helpers.Label<Cc>();
			}

			public sealed class Bcc {
				public static readonly string Label = Helpers.Label<Bcc>();
			}

			public sealed class Subject {
				public const int Length = 100;

				public static readonly string Label = Helpers.Label<Subject>();
			}

			public sealed class Body {
				public static readonly string Label = Helpers.Label<Body>();
			}

			public sealed class SendPriority {
				public static int MinValue = EnumExtensions.GetLowerBound<Priority>();
				public static int MaxValue = EnumExtensions.GetUpperBound<Priority>();

				public static readonly string Label = Helpers.Label<SendPriority>();

				public static readonly string Low = Helpers.Enum<SendPriority, Priority>(Priority.Low);
				public static readonly string Normal = Helpers.Enum<SendPriority, Priority>(Priority.Medium);
				public static readonly string High = Helpers.Enum<SendPriority, Priority>(Priority.High);
				public static readonly string Critical = Helpers.Enum<SendPriority, Priority>(Priority.Critical);
			}

			public sealed class SendingTries {
				public static readonly string Label = Helpers.Label<SendingTries>();
			}

			public sealed class SentDateUtc {
				public static readonly string Label = Helpers.Label<SentDateUtc>();
			}

			public sealed class Account {
				public static readonly string Label = Helpers.Label<Account>();
			}
		}
	}
}