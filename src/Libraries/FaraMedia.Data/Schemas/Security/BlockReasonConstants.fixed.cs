namespace FaraMedia.Data.Schemas.Security {
	using FaraMedia.Core.Domain.Security;
	using FaraMedia.Data.Schemas.Shared;

	public sealed class BlockReasonConstants : AttributeConstantsBase<BlockReason> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(r => r.Id);
			public static readonly string BySystemName = Helpers.CacheKey(r => r.SystemName);
		}

		public new sealed class Fields : AttributeConstantsBase<BlockReason>.Fields {
			public class Users {
				public static readonly string Label = Helpers.Label<Users>();
			}
		}
	}
}