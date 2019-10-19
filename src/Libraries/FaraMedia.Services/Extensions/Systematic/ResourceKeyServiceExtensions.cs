namespace FaraMedia.Services.Extensions.Systematic {
    using System.Linq;

    using FaraMedia.Core;
    using FaraMedia.Core.Comparison;
    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Core.SafeCode;
    using FaraMedia.Services.Querying.Abstraction;
    using FaraMedia.Services.Querying.Systematic;

    public static class ResourceKeyServiceExtensions {
        public static ResourceKey GetByKey(this IDbService<ResourceKey, ResourceKeyQuery> service, string key) {
			if (Neutrals.Is(key))
                return null;

            var resourceKey = service.Get(rkq=>rkq.WithKey(key));

            return resourceKey;
        }
    }
}