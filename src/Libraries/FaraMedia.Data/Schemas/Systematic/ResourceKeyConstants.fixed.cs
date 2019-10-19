namespace FaraMedia.Data.Schemas.Systematic {
	using FaraMedia.Core.Domain.Systematic;

	public sealed class ResourceKeyConstants : EntityConstantsBase<ResourceKey> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(rk => rk.Id);
			public static readonly string BySystemName = Helpers.CacheKey(rk => rk.Key);
		}

		public new sealed class Fields : EntityConstantsBase<ResourceKey>.Fields {
			public sealed class Key {
				public const int Length = Constants.SystemNameLength;

				public static readonly string Label = Helpers.Label<Key>();
			}

			public sealed class DisplayName {
				public const int Length = 100;

				public static readonly string Label = Helpers.Label<DisplayName>();
			}

			public sealed class Description {
				public static readonly string Label = Helpers.Label<Description>();
			}

			public sealed class Values {
				public static readonly string Label = Helpers.Label<Values>();
			}
		}
	}
}