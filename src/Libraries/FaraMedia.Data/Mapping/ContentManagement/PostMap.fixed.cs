namespace FaraMedia.Data.Mapping.ContentManagement {
	using FaraMedia.Core.Domain.ContentManagement;

	public sealed class PostMap : UIElementMapBase<Post> {
		public PostMap() {
			Property(p => p.Title);
			Property(p => p.Body);
			ManyToOne(p => p.Blog);
			SetController(p => p.Tags);
		}
	}
}