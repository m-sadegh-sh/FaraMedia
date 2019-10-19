namespace FaraMedia.Services.Extensions.Billing {
	using FaraMedia.Core;
	using FaraMedia.Core.Domain.Billing;
	using FaraMedia.Services.Querying.Billing;

	public static class TransactionRequestServiceExtensions {
		public static TransactionRequest GetByComputedHash(this IDbService<TransactionRequest, TransactionRequestQuery> service,
		                                                   string computedHash) {
			if (Neutrals.Is(computedHash))
				return null;

			var transactionRequest = service.Get(trq => trq.WithComputedHash(computedHash));

			return transactionRequest;
		}
	}
}