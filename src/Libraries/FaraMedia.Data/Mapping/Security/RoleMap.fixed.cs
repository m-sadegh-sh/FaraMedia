namespace FaraMedia.Data.Mapping.Security {
	using FaraMedia.Core.Domain.Security;
	using FaraMedia.Data.Mapping.Shared;

	public sealed class RoleMap : AttributeMapBase<Role> {
		public RoleMap() {
			Property(r => r.IsActive);
			SetInverse(r => r.Records,
			           pr => pr.Roles);
			SetInverse(r => r.Users,
			           u => u.Roles);
		}
	}
}