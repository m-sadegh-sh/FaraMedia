namespace FaraMedia.Data.Mapping.Security {
	using FaraMedia.Core.Domain.Security;

	public sealed class FriendRequestMap : EntityMapBase<FriendRequest> {
		public FriendRequestMap() {
			ManyToOne(fr => fr.From);
			ManyToOne(fr => fr.To);
			Property(fr => fr.SentDateUtc);
			Property(fr => fr.Accepted);
			Property(fr => fr.AcceptanceDateUtc);
			Property(fr => fr.BlockSubsequentRequests);
		}
	}
}