namespace FaraMedia.Data.Mapping.ContentManagement {
	using FaraMedia.Core.Domain.ContentManagement;

	public sealed class BlogMap : UIElementMapBase<Blog> {
		public BlogMap() {
			Property(b => b.Title);
			Property(b => b.Description);
			Set(b => b.Authors);
			Set(b => b.Tags);
			Set(b => b.Posts);
		}
	}
}