namespace FaraMedia.Data.Schemas.Systematic {
	using FaraMedia.Core.Domain.Systematic;

	public sealed class ActivityConstants : EntityConstantsBase<Activity> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(a => a.Id);
		}

		public new sealed class Fields : EntityConstantsBase<Activity>.Fields {
			public sealed class Activator {
				public static readonly string Label = Helpers.Label<Activator>();
			}

			public sealed class Type {
				public static readonly string Label = Helpers.Label<Type>();
			}

			public sealed class Comment {
				public static readonly string Label = Helpers.Label<Comment>();
			}

			public sealed class ActivationDateUtc {
				public static readonly string Label = Helpers.Label<ActivationDateUtc>();
			}
		}
	}
}