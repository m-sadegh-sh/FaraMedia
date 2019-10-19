namespace FaraMedia.Data.Schemas.Configuration {
	using FaraMedia.Core.Domain.Configuration;

	public sealed class SettingConstants : EntityConstantsBase<Setting> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(s => s.Id);
			public static readonly string ByKey = Helpers.CacheKey(s => s.Key);
		}

		public new sealed class Fields : EntityConstantsBase<Setting>.Fields {
			public sealed class Key {
				public const int Length = Constants.SystemNameLength;

				public static readonly string Label = Helpers.Label<Key>();
			}

			public sealed class Value {
				public static readonly string Label = Helpers.Label<Value>();
			}
		}
	}
}