namespace FaraMedia.Data.Schemas.Security {
	using FaraMedia.Core.Domain.Security;
	using FaraMedia.Data.Schemas.Shared;

	public sealed class PermissionRecordConstants : AttributeConstantsBase<PermissionRecord> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(pr => pr.Id);
			public static readonly string BySystemName = Helpers.CacheKey(pr => pr.SystemName);
		}

		public new sealed class Fields : AttributeConstantsBase<PermissionRecord>.Fields {
			public sealed class Category {
				public const int Length = 50;

				public static readonly string Label = Helpers.Label<Category>();
			}

			public sealed class Roles {
				public static readonly string Label = Helpers.Label<Roles>();
			}
		}
	}
}