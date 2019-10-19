namespace FaraMedia.Data.Mapping.Fundamentals {
	using FaraMedia.Core.Domain.Fundamentals;

	public sealed class PublisherMap : UIElementMapBase<Publisher> {
		public PublisherMap() {
			Property(p => p.Name);
			Property(p => p.Ceo);
			Property(p => p.RegisterationNumber);
			Property(p => p.Email);
			Property(p => p.BriefHistory);
			ManyToOne(p => p.Website);
			ManyToOne(p => p.Logo);
			Set(o => o.Tracks);
		}
	}
}