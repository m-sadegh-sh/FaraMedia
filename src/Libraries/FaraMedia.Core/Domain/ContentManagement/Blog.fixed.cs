namespace FaraMedia.Core.Domain.ContentManagement {
	using FaraMedia.Core.Domain.Security;

	using Iesi.Collections.Generic;

	public class Blog : UIElementBase {
		private ISet<User> _authors;
		private ISet<Tag> _tags;
		private ISet<Post> _posts;

		public override void OverrideMetadata() {
			Metadata.SecondaryCandidateSlug(Title);
		}

		public virtual string Title { get; set; }
		public virtual string Description { get; set; }

		public virtual ISet<User> Authors {
			get { return _authors ?? (_authors = new HashedSet<User>()); }
			protected set { _authors = value; }
		}

		public virtual ISet<Tag> Tags {
			get { return _tags ?? (_tags = new HashedSet<Tag>()); }
			protected set { _tags = value; }
		}

		public virtual ISet<Post> Posts {
			get { return _posts ?? (_posts = new HashedSet<Post>()); }
			protected set { _posts = value; }
		}
	}
}