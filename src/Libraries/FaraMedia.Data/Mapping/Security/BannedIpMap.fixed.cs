namespace FaraMedia.Data.Mapping.Security {
	using FaraMedia.Core.Domain.Security;

	public sealed class BannedIpMap : EntityMapBase<BannedIp> {
		public BannedIpMap() {
			Property(bi => bi.IpAdrress);
			Property(bi => bi.Reason);
			Property(bi => bi.StartDateUtc);
			Property(bi => bi.ExpireDateUtc);
		}
	}
}