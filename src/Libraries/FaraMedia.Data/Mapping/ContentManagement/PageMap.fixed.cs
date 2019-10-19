namespace FaraMedia.Data.Mapping.ContentManagement {
	using FaraMedia.Core.Domain.ContentManagement;

	public sealed class PageMap : UIElementMapBase<Page> {
		public PageMap() {
			Property(p => p.Title);
			Property(p => p.Body);
			ManyToOne(p => p.Group);
		}
	}
}