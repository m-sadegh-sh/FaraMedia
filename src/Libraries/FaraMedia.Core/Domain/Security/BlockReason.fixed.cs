namespace FaraMedia.Core.Domain.Security {
	using FaraMedia.Core.Domain.Shared;

	using Iesi.Collections.Generic;

	public class BlockReason : AttributeBase {
		private ISet<User> _users;

		public virtual ISet<User> Users {
			get { return _users ?? (_users = new HashedSet<User>()); }
			protected set { _users = value; }
		}
	}
}