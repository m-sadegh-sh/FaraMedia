namespace FaraMedia.Data.Schemas.Systematic {
	using FaraMedia.Core.Domain.Systematic;
	using FaraMedia.Data.Schemas.Shared;

	public sealed class EmailAccountConstants : AttributeConstantsBase<EmailAccount> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.Label<EmailAccount>();
			public static readonly string ById = Helpers.CacheKey(ea => ea.Id);
		}

		public sealed class Messages {
			public static readonly string AtLeastOneEmailAccountRequired = Helpers.Key<Messages, string>(m => AtLeastOneEmailAccountRequired);
		}

		public new sealed class Fields : AttributeConstantsBase<EmailAccount>.Fields {
			public sealed class Email {
				public const int Length = Constants.EmailLength;

				public static readonly string Label = Helpers.Label<Email>();
			}

			public sealed class UserName {
				public const int Length = 32;

				public static readonly string Label = Helpers.Label<UserName>();
			}

			public sealed class Password {
				public const int Length = 32;

				public static readonly string Label = Helpers.Label<Password>();
			}

			public sealed class Host {
				public const int Length = 100;

				public static readonly string Label = Helpers.Label<Host>();
			}

			public sealed class Port {
				public const int MinValue = Constants.ZeroAllowedDigits;

				public static readonly string Label = Helpers.Label<Port>();
			}

			public sealed class SslEnabled {
				public static readonly string Label = Helpers.Label<SslEnabled>();
			}

			public sealed class UseDefaultCredentials {
				public static readonly string Label = Helpers.Label<UseDefaultCredentials>();
			}

			public sealed class Templates {
				public static readonly string Label = Helpers.Label<Templates>();
			}

			public sealed class Emails {
				public static readonly string Label = Helpers.Label<Emails>();
			}
		}
	}
}