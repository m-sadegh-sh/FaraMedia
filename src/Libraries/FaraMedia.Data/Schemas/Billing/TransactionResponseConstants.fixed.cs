namespace FaraMedia.Data.Schemas.Billing {
	using FaraMedia.Core.Domain.Billing;
	using FaraMedia.Core.Infrastructure.Extensions;

	public sealed class TransactionResponseConstants : EntityConstantsBase<TransactionResponse> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(tr => tr.Id);
		}

		public new sealed class Fields : EntityConstantsBase<TransactionResponse>.Fields {
			public sealed class Request {
				public static readonly string Label = Helpers.Label<Request>();
			}

			public sealed class VerifyDateUtc {
				public static readonly string Label = Helpers.Label<VerifyDateUtc>();
			}

			public sealed class Code {
				public static readonly string Label = Helpers.Label<Code>();
			}

			public sealed class SubCode {
				public static readonly string Label = Helpers.Label<SubCode>();
			}

			public sealed class ReasonCode {
				public static readonly string Label = Helpers.Label<ReasonCode>();
			}

			public sealed class ReasonDescription {
				public static readonly string Label = Helpers.Label<ReasonDescription>();
			}

			public sealed class Result {
				public static int MinValue = EnumExtensions.GetLowerBound<TransactionResponseResult>();
				public static int MaxValue = EnumExtensions.GetUpperBound<TransactionResponseResult>();

				public static readonly string Label = Helpers.Label<Result>();

				public static readonly string Waiting = Helpers.Enum<Result, TransactionResponseResult>(TransactionResponseResult.Waiting);
				public static readonly string Verified = Helpers.Enum<Result, TransactionResponseResult>(TransactionResponseResult.Verified);
				public static readonly string Cancelled = Helpers.Enum<Result, TransactionResponseResult>(TransactionResponseResult.Cancelled);
				public static readonly string Invalid = Helpers.Enum<Result, TransactionResponseResult>(TransactionResponseResult.Invalid);
			}
		}
	}
}