namespace FaraMedia.Services.Extensions.Misc {
	using FaraMedia.Core;
	using FaraMedia.Core.Domain.Misc;
	using FaraMedia.Services.Querying.Misc;

	public static class RedirectorServiceExtensions {
		public static Redirector GetByTargetUrl(this IDbService<Redirector, RedirectorQuery> service,
		                                        string targetUrl) {
			if (Neutrals.Is(targetUrl))
				return null;

			var redirector = service.Get(rq => rq.WithTargetUrl(targetUrl));

			return redirector;
		}

		public static Redirector GetByShortHash(this IDbService<Redirector, RedirectorQuery> service,
		                                        string shortHash) {
			if (Neutrals.Is(shortHash))
				return null;

			var redirector = service.Get(rq => rq.WithShortHash(shortHash));

			return redirector;
		}
	}
}