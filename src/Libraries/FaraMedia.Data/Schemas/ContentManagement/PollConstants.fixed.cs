namespace FaraMedia.Data.Schemas.ContentManagement {
	using FaraMedia.Core.Domain.ContentManagement;

	public sealed class PollConstants : UIElementConstantsBase<Poll> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(p => p.Id);
		}

		public new sealed class Fields : UIElementConstantsBase<Poll>.Fields {
			public sealed class PlaceholderKey {
				public const int Length = Constants.SystemNameLength;

				public static readonly string Label = Helpers.Label<PlaceholderKey>();
			}

			public sealed class Title {
				public const int Length = 200;

				public static readonly string Label = Helpers.Label<Title>();
			}

			public sealed class Description {
				public static readonly string Label = Helpers.Label<Description>();
			}

			public sealed class StartDateUtc {
				public static readonly string Label = Helpers.Label<StartDateUtc>();
			}

			public sealed class EndDateUtc {
				public static readonly string Label = Helpers.Label<EndDateUtc>();
			}

			public sealed class AuthenticationRequired {
				public static readonly string Label = Helpers.Label<AuthenticationRequired>();
			}

			public sealed class ShowOnHomePage {
				public static readonly string Label = Helpers.Label<ShowOnHomePage>();
			}

			public sealed class Choices {
				public static readonly string Label = Helpers.Label<Choices>();
			}
		}
	}
}