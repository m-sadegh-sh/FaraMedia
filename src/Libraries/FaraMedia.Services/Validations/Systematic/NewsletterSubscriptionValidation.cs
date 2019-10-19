namespace FaraMedia.Services.Validations.Systematic {
    using System;

    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Data.Schemas.Systematic;
    using FaraMedia.Services.Extensions.Systematic;
    using FaraMedia.Services.Querying.Systematic;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class NewsletterSubscriptionValidation : EntityValidationBase<NewsletterSubscription> {
        public NewsletterSubscriptionValidation() {
            Define(ns => ns.Email)
                .NotNullableAndNotEmpty()
                .WithRequired(NewsletterSubscriptionConstants.Fields.Email.Label)
                .And
                .MaxLength(NewsletterSubscriptionConstants.Fields.Email.Length)
                .WithInvalidLength(NewsletterSubscriptionConstants.Fields.Email.Label,
                                   NewsletterSubscriptionConstants.Fields.Email.Length)
                .And
                .IsEmail()
                .WithInvalidFormat(NewsletterSubscriptionConstants.Fields.Email.Label);

            Define(ns => ns.Guid)
                .NotEmpty()
                .WithInvalidValue(NewsletterSubscriptionConstants.Fields.Guid.Label);

            ValidateInstance.SafeBy((newsletterSubscription, context) => {
                                        var isValid = true;

                                        var service = EngineContext.Current.Resolve<IDbService<NewsletterSubscription, NewsletterSubscriptionQuery>>();

                                        if (service.GetByEmail(newsletterSubscription.Email).IsDuplicate(newsletterSubscription)) {
                                            context.AddDuplicate<NewsletterSubscription, string>(NewsletterSubscriptionConstants.Fields.Email.Label,
                                                                                                 ns => ns.Email);

                                            isValid = false;
                                        }

                                        if (service.GetByGuid(newsletterSubscription.Guid).IsDuplicate(newsletterSubscription)) {
                                            context.AddDuplicate<NewsletterSubscription, Guid>(NewsletterSubscriptionConstants.Fields.Guid.Label,
                                                                                               ns => ns.Guid);

                                            isValid = false;
                                        }

                                        return isValid;
                                    });
        }
    }
}