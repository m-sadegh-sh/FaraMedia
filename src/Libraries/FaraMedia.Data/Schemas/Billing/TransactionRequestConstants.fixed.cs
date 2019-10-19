namespace FaraMedia.Data.Schemas.Billing {
	using FaraMedia.Core.Domain.Billing;
	using FaraMedia.Core.Infrastructure.Extensions;

	public sealed class TransactionRequestConstants : EntityConstantsBase<TransactionRequest> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(tr => tr.Id);
			public static readonly string ByComputedCode = Helpers.CacheKey(tr => tr.ComputedHash);
		}

		public new sealed class Fields : EntityConstantsBase<TransactionRequest>.Fields {
			public sealed class Order {
				public static readonly string Label = Helpers.Label<Order>();
			}

			public sealed class RequestDateUtc {
				public static readonly string Label = Helpers.Label<RequestDateUtc>();
			}

			public sealed class MerchantId {
				public static readonly string Label = Helpers.Label<MerchantId>();
			}

			public sealed class TransactionKey {
				public static readonly string Label = Helpers.Label<TransactionKey>();
			}

			public sealed class ComputedHash {
				public static readonly string Label = Helpers.Label<ComputedHash>();
			}

			public sealed class Status {
				public static int MinValue = EnumExtensions.GetLowerBound<TransactionRequestStatus>();
				public static int MaxValue = EnumExtensions.GetUpperBound<TransactionRequestStatus>();

				public static readonly string Label = Helpers.Label<Status>();

				public static readonly string Unknown = Helpers.Enum<Status, TransactionRequestStatus>(TransactionRequestStatus.Unknown);
				public static readonly string Pending = Helpers.Enum<Status, TransactionRequestStatus>(TransactionRequestStatus.Pending);
				public static readonly string Requested = Helpers.Enum<Status, TransactionRequestStatus>(TransactionRequestStatus.Requested);
				public static readonly string Completed = Helpers.Enum<Status, TransactionRequestStatus>(TransactionRequestStatus.Completed);
			}

			public sealed class Responses {
				public static readonly string Label = Helpers.Label<Responses>();
			}
		}
	}
}