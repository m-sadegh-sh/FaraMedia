namespace FaraMedia.Core.Domain.ContentManagement {
	using FaraMedia.Core.Domain.Components;

	using Iesi.Collections.Generic;

	public class Group : EntityBase,
	                     IHasMetadata {
		private MetadataComponent _metadata;
		private ISet<Group> _children;
		private ISet<Page> _pages;

		public virtual string Title { get; set; }
		public virtual string Description { get; set; }

		public virtual MetadataComponent Metadata {
			get { return _metadata ?? (_metadata = new MetadataComponent()); }
			set { _metadata = value; }
		}

		public void OverrideMetadata() {
			Metadata.SecondaryCandidateSlug(Title);
		}

		public virtual Group Parent { get; set; }

		public virtual ISet<Group> Children {
			get { return _children ?? (_children = new HashedSet<Group>()); }
			protected set { _children = value; }
		}

		public virtual ISet<Page> Pages {
			get { return _pages ?? (_pages = new HashedSet<Page>()); }
			protected set { _pages = value; }
		}
	}
}