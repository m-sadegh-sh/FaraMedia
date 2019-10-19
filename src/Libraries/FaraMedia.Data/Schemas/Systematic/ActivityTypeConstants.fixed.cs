namespace FaraMedia.Data.Schemas.Systematic {
	using FaraMedia.Core.Domain.Systematic;
	using FaraMedia.Data.Schemas.Shared;

	public sealed class ActivityTypeConstants : AttributeConstantsBase<ActivityType> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(at => at.Id);
			public static readonly string BySystemName = Helpers.CacheKey(at => at.SystemName);
		}

		public new class Fields : AttributeConstantsBase<ActivityType>.Fields {
			public sealed class Activities {
				public static readonly string Label = Helpers.Label<Activities>();
			}
		}
	}
}