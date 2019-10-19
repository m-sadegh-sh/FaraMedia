namespace FaraMedia.Data.Schemas.Systematic {
	using FaraMedia.Core.Domain.Systematic;
	using FaraMedia.Data.Schemas.Shared;

	public sealed class MessageTemplateConstants : AttributeConstantsBase<MessageTemplate> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(mt => mt.Id);
			public static readonly string BySystemName = Helpers.CacheKey(mt => mt.SystemName);
		}

		public new sealed class Fields : AttributeConstantsBase<MessageTemplate>.Fields {
			public sealed class BccEmailAddresses {
				public static readonly string Label = Helpers.Label<BccEmailAddresses>();
			}

			public sealed class Subject {
				public const int Length = 200;

				public static readonly string Label = Helpers.Label<Subject>();
			}

			public sealed class Body {
				public static readonly string Label = Helpers.Label<Body>();
			}

			public sealed class Account {
				public static readonly string Label = Helpers.Label<Account>();
			}
		}
	}
}