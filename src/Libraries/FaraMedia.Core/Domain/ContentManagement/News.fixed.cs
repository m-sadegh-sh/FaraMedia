namespace FaraMedia.Core.Domain.ContentManagement {
	public class News : UIElementBase {
		public override void OverrideMetadata() {
			Metadata.SecondaryCandidateSlug(Title);
		}

		public virtual string Title { get; set; }
		public virtual string Short { get; set; }
		public virtual string Full { get; set; }
		public virtual Category Category { get; set; }
	}
}