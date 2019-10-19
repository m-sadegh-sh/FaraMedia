namespace FaraMedia.Core.Domain.Billing {
	public enum TransactionRequestStatus : byte {
		Unknown = 1,
		Pending = 2,
		Requested = 4,
		Completed = 8
	}
}