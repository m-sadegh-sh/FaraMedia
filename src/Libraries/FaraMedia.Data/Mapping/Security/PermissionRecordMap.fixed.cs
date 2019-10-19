namespace FaraMedia.Data.Mapping.Security {
	using FaraMedia.Core.Domain.Security;
	using FaraMedia.Data.Mapping.Shared;

	public sealed class PermissionRecordMap : AttributeMapBase<PermissionRecord> {
		public PermissionRecordMap() {
			Property(pr => pr.Category);
			SetController(pc => pc.Roles);
		}
	}
}