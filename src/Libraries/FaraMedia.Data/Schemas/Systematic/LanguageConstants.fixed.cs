namespace FaraMedia.Data.Schemas.Systematic {
	using FaraMedia.Core.Domain.Systematic;
	using FaraMedia.Data.Schemas.Shared;

	public sealed class LanguageConstants : AttributeConstantsBase<Language> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.Label<Language>();
			public static readonly string ById = Helpers.CacheKey(l => l.Id);
		}

		public new sealed class Fields : AttributeConstantsBase<Language>.Fields {
			public sealed class NativeName {
				public const int Length = 100;

				public static readonly string Label = Helpers.Label<NativeName>();
			}

			public sealed class CultureCode {
				public const int Length = 2;

				public static readonly string Label = Helpers.Label<CultureCode>();
			}

			public sealed class Values {
				public static readonly string Label = Helpers.Label<Values>();
			}
		}
	}
}