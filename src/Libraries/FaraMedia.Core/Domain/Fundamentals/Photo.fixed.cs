namespace FaraMedia.Core.Domain.Fundamentals {
	using FaraMedia.Core.Domain.FileManagement;

	public class Photo : UIElementBase {
		public override void OverrideMetadata() {
			Metadata.SecondaryCandidateSlug(Title);
		}

		public virtual string Title { get; set; }
		public virtual string Description { get; set; }
		public virtual PhotoAlbum Album { get; set; }
		public virtual Picture Picture { get; set; }
	}
}