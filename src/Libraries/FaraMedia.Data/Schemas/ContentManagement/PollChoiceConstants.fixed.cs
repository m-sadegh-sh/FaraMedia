namespace FaraMedia.Data.Schemas.ContentManagement {
	using FaraMedia.Core.Domain.ContentManagement;

	public sealed class PollChoiceConstants : EntityConstantsBase<PollChoice> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(pc => pc.Id);
		}

		public new sealed class Fields : EntityConstantsBase<PollChoice>.Fields {
			public sealed class Title {
				public const int Length = 500;

				public static readonly string Label = Helpers.Label<Title>();
			}

			public sealed class Description {
				public static readonly string Label = Helpers.Label<Description>();
			}

			public sealed class IsMultiSelection {
				public static readonly string Label = Helpers.Label<IsMultiSelection>();
			}

			public sealed class Poll {
				public static readonly string Label = Helpers.Label<Poll>();
			}

			public sealed class Items {
				public static readonly string Label = Helpers.Label<Items>();
			}
		}
	}
}