namespace FaraMedia.Services.Extensions.Systematic {
    using System.Linq;

    using FaraMedia.Core;
    using FaraMedia.Core.Comparison;
    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Core.SafeCode;
    using FaraMedia.Services.Querying.Abstraction;
    using FaraMedia.Services.Querying.Systematic;

    public static class LanguageServiceExtensions {
       public static Language GetByCultureCode(this IDbService<Language, LanguageQuery> service, string cultureCode) {
		   if (Neutrals.Is(cultureCode))
                return null;

            var language = service.Get(lq=>lq.WithCultureCode(cultureCode));

            return language;
        }
    }
}