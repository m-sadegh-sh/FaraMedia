namespace FaraMedia.Core.Domain.ContentManagement {
	using FaraMedia.Core.Domain.Components;

	using Iesi.Collections.Generic;

	public class Tag : EntityBase,
	                   IHasMetadata {
		private MetadataComponent _metadata;
		private ISet<Post> _posts;

		public virtual string Title { get; set; }
		public virtual string Description { get; set; }

		public virtual MetadataComponent Metadata {
			get { return _metadata ?? (_metadata = new MetadataComponent()); }
			set { _metadata = value; }
		}

		public void OverrideMetadata() {
			Metadata.SecondaryCandidateSlug(Title);
		}

		public virtual Blog Blog { get; set; }

		public virtual ISet<Post> Posts {
			get { return _posts ?? (_posts = new HashedSet<Post>()); }
			protected set { _posts = value; }
		}
	}
}