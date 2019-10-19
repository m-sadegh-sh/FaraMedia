namespace FaraMedia.Core.Domain.Security {
	using System;

	public class BannedIp : EntityBase {
		public virtual string IpAdrress { get; set; }
		public virtual string Reason { get; set; }
		public virtual DateTime StartDateUtc { get; set; }
		public virtual DateTime? ExpireDateUtc { get; set; }
	}
}