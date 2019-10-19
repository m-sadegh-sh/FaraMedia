namespace FaraMedia.Data.Mapping.ContentManagement {
	using FaraMedia.Core.Domain.ContentManagement;

	public sealed class NewsMap : UIElementMapBase<News> {
		public NewsMap() {
			Property(n => n.Title);
			Property(n => n.Short);
			Property(n => n.Full);
			ManyToOne(n => n.Category);
		}
	}
}