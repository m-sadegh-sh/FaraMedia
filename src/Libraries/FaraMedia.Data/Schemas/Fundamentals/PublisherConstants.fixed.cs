namespace FaraMedia.Data.Schemas.Fundamentals {
	using FaraMedia.Core.Domain.Fundamentals;

	public sealed class PublisherConstants : UIElementConstantsBase<Publisher> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(p => p.Id);
		}

		public new sealed class Fields : UIElementConstantsBase<Publisher>.Fields {
			public sealed class Name {
				public const int Length = 100;

				public static readonly string Label = Helpers.Label<Name>();
			}

			public sealed class Ceo {
				public const int Length = 100;

				public static readonly string Label = Helpers.Label<Ceo>();
			}

			public sealed class RegisterationNumber {
				public const int Length = 50;

				public static readonly string Label = Helpers.Label<RegisterationNumber>();
			}

			public sealed class Email {
				public const int Length = Constants.EmailLength;

				public static readonly string Label = Helpers.Label<Email>();
			}

			public sealed class BriefHistory {
				public static readonly string Label = Helpers.Label<BriefHistory>();
			}

			public sealed class Website {
				public const int Length = Constants.UrlLength;

				public static readonly string Label = Helpers.Label<Website>();
			}

			public sealed class Logo {
				public static readonly string Label = Helpers.Label<Logo>();
			}

			public sealed class Tracks {
				public static readonly string Label = Helpers.Label<Tracks>();
			}
		}
	}
}