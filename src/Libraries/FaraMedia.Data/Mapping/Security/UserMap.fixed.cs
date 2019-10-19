namespace FaraMedia.Data.Mapping.Security {
	using FaraMedia.Core.Domain.Security;

	public sealed class UserMap : MapBase<User> {
		public UserMap() {
			Property(u => u.SystemName,
			         pm => pm.Unique(true));
			Property(u => u.UserName,
			         pm => pm.Unique(true));
			Property(u => u.Email,
			         pm => pm.Unique(true));
			Property(u => u.Password);
			Property(u => u.PasswordSalt);
			Property(u => u.PasswordFormat);
			Property(u => u.LastLoginDateUtc);
			Property(u => u.LastActivityDateUtc);
			Property(u => u.LastIpAddress);
			Property(u => u.AdminComment);
			Property(u => u.CurrentBlockReason);
			SetController(u => u.Roles);
			Set(u => u.Activities);
			Set(u => u.Logs);
			Set(u => u.ToDos);
			Set(u => u.Tickets);
			Set(u => u.Responses);
			Set(u => u.IncomingFriendRequests);
			Set(u => u.OutgoingFriendRequests);
			Set(u => u.Blogs);
			Set(u => u.Orders);
			Set(u => u.Likes);
			Set(u => u.Shares);
			Set(u => u.VotingRecords);
		}
	}
}