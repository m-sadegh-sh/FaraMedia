namespace FaraMedia.Core.Domain.Fundamentals {
	using Iesi.Collections.Generic;

	public class PhotoAlbum : UIElementBase {
		private ISet<Photo> _photos;

		public override void OverrideMetadata() {
			Metadata.SecondaryCandidateSlug(Title);
		}

		public virtual string Title { get; set; }
		public virtual string Description { get; set; }
		public virtual Artist Artist { get; set; }

		public virtual ISet<Photo> Photos {
			get { return _photos ?? (_photos = new HashedSet<Photo>()); }
			protected set { _photos = value; }
		}
	}
}