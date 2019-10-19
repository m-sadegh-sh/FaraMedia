namespace FaraMedia.Core.Domain.ContentManagement {
	using FaraMedia.Core.Domain.Components;

	using Iesi.Collections.Generic;

	public class Category : EntityBase,
	                        IHasMetadata {
		private MetadataComponent _metadata;
		private ISet<Category> _children;
		private ISet<News> _news;

		public virtual string Title { get; set; }
		public virtual string Description { get; set; }

		public virtual MetadataComponent Metadata {
			get { return _metadata ?? (_metadata = new MetadataComponent()); }
			set { _metadata = value; }
		}

		public void OverrideMetadata() {
			Metadata.SecondaryCandidateSlug(Title);
		}

		public virtual Category Parent { get; set; }

		public virtual ISet<Category> Children {
			get { return _children ?? (_children = new HashedSet<Category>()); }
			protected set { _children = value; }
		}

		public virtual ISet<News> News {
			get { return _news ?? (_news = new HashedSet<News>()); }
			protected set { _news = value; }
		}
	}
}