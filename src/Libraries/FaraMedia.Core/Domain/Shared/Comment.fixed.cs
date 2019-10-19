namespace FaraMedia.Core.Domain.Shared {
	using Iesi.Collections.Generic;

	public class Comment : UserContentBase,
	                       IOwnable {
		private ISet<Comment> _replies;

		public virtual long OwnerId { get; set; }
		public virtual string Email { get; set; }
		public virtual string Title { get; set; }
		public virtual string Body { get; set; }
		public virtual Comment InReplyTo { get; set; }

		public virtual ISet<Comment> Replies {
			get { return _replies ?? (_replies = new HashedSet<Comment>()); }
			protected set { _replies = value; }
		}
	}
}