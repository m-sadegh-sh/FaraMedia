namespace FaraMedia.Core.Domain.Security {
	using System.Collections.Generic;

	public class DefaultPermissionRecord {
		public DefaultPermissionRecord() {
			Records = new List<PermissionRecord>();
		}

		public string RoleSystemName { get; set; }

		public IEnumerable<PermissionRecord> Records { get; set; }
	}
}