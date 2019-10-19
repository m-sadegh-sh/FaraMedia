namespace FaraMedia.Data.Schemas.Systematic {
	using FaraMedia.Core.Domain;
	using FaraMedia.Core.Domain.Systematic;
	using FaraMedia.Core.Infrastructure.Extensions;
	using FaraMedia.Data.Schemas.Shared;

	public sealed class ScheduleTaskConstants : AttributeConstantsBase<ScheduleTask> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(st => st.Id);
		}

		public new sealed class Fields : AttributeConstantsBase<ScheduleTask>.Fields {
			public sealed class TypeName {
				public const int Length = 500;

				public static readonly string Label = Helpers.Label<TypeName>();
			}

			public sealed class IsActive {
				public static readonly string Label = Helpers.Label<IsActive>();
			}

			public sealed class ExecutionPriority {
				public static int MinValue = EnumExtensions.GetLowerBound<Priority>();
				public static int MaxValue = EnumExtensions.GetUpperBound<Priority>();

				public static readonly string Label = Helpers.Label<ExecutionPriority>();

				public static readonly string Low = Helpers.Enum<ExecutionPriority, Priority>(Priority.Low);
				public static readonly string Normal = Helpers.Enum<ExecutionPriority, Priority>(Priority.Medium);
				public static readonly string High = Helpers.Enum<ExecutionPriority, Priority>(Priority.High);
				public static readonly string Critical = Helpers.Enum<ExecutionPriority, Priority>(Priority.Critical);
			}

			public sealed class StopOnError {
				public static readonly string Label = Helpers.Label<StopOnError>();
			}

			public sealed class MaximumRunningSeconds {
				public const int MinValue = Constants.ZeroAllowedDigits;

				public static readonly string Label = Helpers.Label<MaximumRunningSeconds>();
			}
		}
	}
}