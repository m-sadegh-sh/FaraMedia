namespace FaraMedia.Data.Mapping.ContentManagement {
	using FaraMedia.Core.Domain.ContentManagement;

	public sealed class GroupMap : EntityMapBase<Group> {
		public GroupMap() {
			Property(g => g.Title);
			Property(g => g.Description);
			Component(g => g.Metadata);
			ManyToOne(g => g.Parent);
			Set(g => g.Children);
			Set(g => g.Pages);
		}
	}
}