namespace FaraMedia.Services.Extensions.Systematic {
    using System;
    using System.Linq;

    using FaraMedia.Core;
    using FaraMedia.Core.Comparison;
    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Core.SafeCode;
    using FaraMedia.Services.Querying.Abstraction;
    using FaraMedia.Services.Querying.Systematic;

    public static class NewsletterSubscriptionServiceExtensions {
        public static NewsletterSubscription GetByEmail(this IDbService<NewsletterSubscription, NewsletterSubscriptionQuery> service, string email) {
			if (Neutrals.Is(email))
                return null;

            var newsletterSubscription = service.Get(nsq=>nsq.WithEmail(email));

            return newsletterSubscription;
        }

        public static NewsletterSubscription GetByGuid(this IDbService<NewsletterSubscription, NewsletterSubscriptionQuery> service, Guid guid) {
			if (Neutrals.Is(guid))
                return null;

            var newsletterSubscription = service.Get(nsq=>nsq.WithGuid(guid));

            return newsletterSubscription;
        }
    }
}