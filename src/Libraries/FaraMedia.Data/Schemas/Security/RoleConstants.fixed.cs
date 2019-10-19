namespace FaraMedia.Data.Schemas.Security {
	using FaraMedia.Core.Domain.Security;
	using FaraMedia.Data.Schemas.Shared;

	public sealed class RoleConstants : AttributeConstantsBase<Role> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(r => r.Id);
			public static readonly string BySystemName = Helpers.CacheKey(r => r.SystemName);
		}

		public sealed class Messages {
			public static readonly string SystemRole = Helpers.Key<Messages, string>(m => SystemRole);
			public static readonly string GuestsRoleNotFound = Helpers.Key<Messages, string>(m => GuestsRoleNotFound);
			public static readonly string RegistetedRoleNotFound = Helpers.Key<Messages, string>(m => RegistetedRoleNotFound);
		}

		public new sealed class Fields : AttributeConstantsBase<Role>.Fields {
			public sealed class IsActive {
				public static readonly string Label = Helpers.Label<Description>();
			}

			public sealed class Records {
				public static readonly string Label = Helpers.Label<Records>();
			}

			public sealed class Users {
				public static readonly string Label = Helpers.Label<Users>();
			}
		}
	}
}