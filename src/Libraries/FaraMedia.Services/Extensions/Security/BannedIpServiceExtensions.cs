namespace FaraMedia.Services.Extensions.Security {
	using System;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.Security;
	using FaraMedia.Services.Querying.Security;

	public static class BannedIpServiceExtensions {
		public static bool IsBanned(this IDbService<BannedIp, BannedIpQuery> service,
		                            string ipAddress) {
			if (Neutrals.Is(ipAddress))
				return false;

			var bannedIp = service.Get(biq => biq.WithIpAddress(ipAddress));

			if (bannedIp == null)
				return false;

			if (bannedIp.ExpireDateUtc < DateTime.UtcNow)
				return false;

			return true;
		}
	}
}