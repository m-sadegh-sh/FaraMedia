namespace FaraMedia.Data.Mapping.ContentManagement {
	using FaraMedia.Core.Domain.ContentManagement;

	public sealed class TagMap : EntityMapBase<Tag> {
		public TagMap() {
			Property(t => t.Title);
			Property(t => t.Description);
			Component(t => t.Metadata);
			ManyToOne(t => t.Blog);
			SetInverse(t => t.Posts,
			           p => p.Tags);
		}
	}
}