namespace FaraMedia.Core.Domain.Security {
	using FaraMedia.Core.Domain.Shared;

	using Iesi.Collections.Generic;

	public class Role : AttributeBase {
		private ISet<PermissionRecord> _records;
		private ISet<User> _users;

		public virtual bool IsActive { get; set; }

		public virtual ISet<PermissionRecord> Records {
			get { return _records ?? (_records = new HashedSet<PermissionRecord>()); }
			protected set { _records = value; }
		}

		public virtual ISet<User> Users {
			get { return _users ?? (_users = new HashedSet<User>()); }
			protected set { _users = value; }
		}
	}
}