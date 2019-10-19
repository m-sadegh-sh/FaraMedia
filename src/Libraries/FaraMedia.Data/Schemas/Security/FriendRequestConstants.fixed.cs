namespace FaraMedia.Data.Schemas.Security {
	using FaraMedia.Core.Domain.Security;

	public sealed class FriendRequestConstants : EntityConstantsBase<FriendRequest> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
		}

		public new sealed class Fields : EntityConstantsBase<FriendRequest>.Fields {
			public sealed class From {
				public static readonly string Label = Helpers.Label<From>();
			}

			public sealed class To {
				public static readonly string Label = Helpers.Label<To>();
			}

			public sealed class SentDateUtc {
				public static readonly string Label = Helpers.Label<SentDateUtc>();
			}

			public sealed class Accepted {
				public static readonly string Label = Helpers.Label<Accepted>();
			}

			public sealed class AcceptanceDateUtc {
				public static readonly string Label = Helpers.Label<AcceptanceDateUtc>();
			}

			public sealed class BlockSubsequentRequests {
				public static readonly string Label = Helpers.Label<BlockSubsequentRequests>();
			}
		}
	}
}