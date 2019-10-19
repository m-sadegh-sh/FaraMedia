namespace FaraMedia.Core.Domain.Configuration {
	public class BillingSettings : ISettings {
		public decimal PricePerTrack { get; set; }
		public decimal PublisherPercentagePerTrack { get; set; }
		public decimal PricePerAlbum { get; set; }
		public decimal PublisherPercentagePerAlbum { get; set; }
		public decimal MaximumAccessTries { get; set; }
		public TaxPayType TaxPayer { get; set; }
		public string MerchantId { get; set; }
		public string TransactionKey { get; set; }
	}
}