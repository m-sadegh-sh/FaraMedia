namespace FaraMedia.Data.Mapping.Shared {
	using FaraMedia.Core.Domain.Shared;

	public sealed class CommentMap : UserContentMapBase<Comment> {
		public CommentMap() {
			Property(c => c.OwnerId);
			Property(c => c.Email);
			Property(c => c.Title);
			Property(c => c.Body);
			ManyToOne(c => c.InReplyTo);
			Set(c => c.Replies);
		}
	}
}