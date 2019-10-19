namespace FaraMedia.Core.Domain.Security {
	using FaraMedia.Core.Domain.Shared;

	using Iesi.Collections.Generic;

	public class PermissionRecord : AttributeBase {
		private ISet<Role> _roles;

		public virtual string Category { get; set; }

		public virtual ISet<Role> Roles {
			get { return _roles ?? (_roles = new HashedSet<Role>()); }
			protected set { _roles = value; }
		}
	}
}