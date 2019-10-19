namespace FaraMedia.Core.Domain.ContentManagement {
	using Iesi.Collections.Generic;

	public class Post : UIElementBase {
		private ISet<Tag> _tags;

		public override void OverrideMetadata() {
			Metadata.SecondaryCandidateSlug(Title);
		}

		public virtual string Title { get; set; }
		public virtual string Body { get; set; }
		public virtual Blog Blog { get; set; }

		public virtual ISet<Tag> Tags {
			get { return _tags ?? (_tags = new HashedSet<Tag>()); }
			protected set { _tags = value; }
		}
	}
}