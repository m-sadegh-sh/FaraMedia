namespace FaraMedia.Data.Schemas.Misc {
	using FaraMedia.Core.Domain;
	using FaraMedia.Core.Domain.Misc;
	using FaraMedia.Core.Infrastructure.Extensions;

	public sealed class TicketConstants : EntityConstantsBase<Ticket> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(t => t.Id);
		}

		public new sealed class Fields : EntityConstantsBase<Ticket>.Fields {
			public sealed class Opener {
				public static readonly string Label = Helpers.Label<Opener>();
			}

			public sealed class OpenDateUtc {
				public static readonly string Label = Helpers.Label<OpenDateUtc>();
			}

			public sealed class Subject {
				public const int Length = 200;

				public static readonly string Label = Helpers.Label<Subject>();
			}

			public sealed class Body {
				public static readonly string Label = Helpers.Label<Body>();
			}

			public sealed class Department {
				public static readonly string Label = Helpers.Label<Department>();
			}

			public sealed class CheckPriority {
				public static int MinValue = EnumExtensions.GetLowerBound<Priority>();
				public static int MaxValue = EnumExtensions.GetUpperBound<Priority>();

				public static readonly string Label = Helpers.Label<CheckPriority>();

				public static readonly string Low = Helpers.Enum<CheckPriority, Priority>(Priority.Low);
				public static readonly string Medium = Helpers.Enum<CheckPriority, Priority>(Priority.Medium);
				public static readonly string High = Helpers.Enum<CheckPriority, Priority>(Priority.High);
				public static readonly string Critical = Helpers.Enum<CheckPriority, Priority>(Priority.Critical);
			}

			public sealed class Status {
				public static readonly string Label = Helpers.Label<Status>();
			}

			public sealed class Responses {
				public static readonly string Label = Helpers.Label<Responses>();
			}
		}
	}
}