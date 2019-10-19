namespace FaraMedia.Data.Mapping.ContentManagement {
	using FaraMedia.Core.Domain.ContentManagement;

	public sealed class PollMap : UIElementMapBase<Poll> {
		public PollMap() {
			Property(p => p.PlaceholderKey,
			         pm => pm.Unique(true));
			Property(p => p.Title);
			Property(p => p.Description);
			Property(p => p.StartDateUtc);
			Property(p => p.EndDateUtc);
			Property(p => p.AuthenticationRequired);
			Property(p => p.ShowOnHomePage);
			Set(p => p.Choices);
		}
	}
}