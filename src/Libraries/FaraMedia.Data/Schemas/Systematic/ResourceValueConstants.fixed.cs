namespace FaraMedia.Data.Schemas.Systematic {
	using FaraMedia.Core.Domain.Systematic;

	public sealed class ResourceValueConstants : EntityConstantsBase<ResourceValue> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(rv => rv.Id);

			public static readonly string ByLanguageIdAndResourceSystemNamey = Helpers.CacheKey(rv => rv.Language.Id,
			                                                                                    rv => rv.Key.Key);
		}

		public new sealed class Fields : EntityConstantsBase<ResourceKey>.Fields {
			public sealed class Language {
				public static readonly string Label = Helpers.Label<Language>();
			}

			public sealed class Key {
				public static readonly string Label = Helpers.Label<Key>();
			}

			public sealed class Value {
				public static readonly string Label = Helpers.Label<Value>();
			}
		}
	}
}