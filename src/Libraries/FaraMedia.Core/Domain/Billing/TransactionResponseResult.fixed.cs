namespace FaraMedia.Core.Domain.Billing {
	public enum TransactionResponseResult : byte {
		Waiting = 1,
		Verified = 2,
		Cancelled = 4,
		Invalid = 8
	}
}