namespace FaraMedia.Data.Schemas.Systematic {
	using FaraMedia.Core.Domain.Systematic;

	public sealed class NewsletterSubscriptionConstants : EntityConstantsBase<NewsletterSubscription> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(ns => ns.Id);
			public static readonly string ByGuid = Helpers.CacheKey(ns => ns.Guid);
			public static readonly string ByEmail = Helpers.CacheKey(ns => ns.Email);
		}

		public new sealed class Fields : EntityConstantsBase<NewsletterSubscription>.Fields {
			public sealed class Email {
				public const int Length = Constants.EmailLength;

				public static readonly string Label = Helpers.Label<Email>();
			}

			public sealed class Guid {
				public static readonly string Label = Helpers.Label<Guid>();
			}
		}
	}
}