namespace FaraMedia.Core.Domain.Security {
	using System;

	public class FriendRequest : EntityBase {
		public virtual User From { get; set; }
		public virtual User To { get; set; }
		public virtual DateTime SentDateUtc { get; set; }
		public virtual bool Accepted { get; set; }
		public virtual DateTime AcceptanceDateUtc { get; set; }
		public virtual bool BlockSubsequentRequests { get; set; }
	}
}