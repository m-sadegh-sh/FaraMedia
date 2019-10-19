namespace FaraMedia.Data.Mapping.ContentManagement {
	using FaraMedia.Core.Domain.ContentManagement;

	public sealed class CategoryMap : EntityMapBase<Category> {
		public CategoryMap() {
			Property(c => c.Title);
			Property(c => c.Description);
			Component(c => c.Metadata);
			ManyToOne(c => c.Parent);
			Set(c => c.Children);
			Set(c => c.News);
		}
	}
}