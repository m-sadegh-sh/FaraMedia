namespace FaraMedia.Data.Mapping.Systematic {
	using FaraMedia.Core.Domain.Systematic;

	public sealed class NewsletterSubscriptionMap : EntityMapBase<NewsletterSubscription> {
		public NewsletterSubscriptionMap() {
			Property(ns => ns.Email);
			Property(ns => ns.Guid,
			         pm => pm.Unique(true));
		}
	}
}