namespace FaraMedia.Core.Domain.ContentManagement {
	public class Page : UIElementBase {
		public override void OverrideMetadata() {
			Metadata.SecondaryCandidateSlug(Title);
		}

		public virtual string Title { get; set; }
		public virtual string Body { get; set; }
		public virtual Group Group { get; set; }
	}
}