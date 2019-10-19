namespace FaraMedia.Services.Validations.Misc {
    using FaraMedia.Core.Domain.Misc;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Data.Schemas.Misc;
    using FaraMedia.Services.Extensions.Misc;
    using FaraMedia.Services.Querying.Misc;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class RedirectorValidation : EntityValidationBase<Redirector> {
        public RedirectorValidation() {
            Define(r => r.TargetUrl)
                .NotNullableAndNotEmpty()
                .WithRequired(RedirectorConstants.Fields.TargetUrl.Label)
                .And
                .MaxLength(RedirectorConstants.Fields.TargetUrl.Length)
                .WithInvalidLength(RedirectorConstants.Fields.TargetUrl.Label,
                                   RedirectorConstants.Fields.TargetUrl.Length)
                .And
                .IsUrl()
                .WithInvalidFormat(RedirectorConstants.Fields.TargetUrl.Label);

            Define(r => r.ShortHash)
                .MaxLength(RedirectorConstants.Fields.ShortHash.Length)
                .WithInvalidLength(RedirectorConstants.Fields.ShortHash.Label,
                                   RedirectorConstants.Fields.ShortHash.Length);

            Define(r => r.UrlName)
                .MaxLength(RedirectorConstants.Fields.UrlName.Length)
                .WithInvalidLength(RedirectorConstants.Fields.UrlName.Label,
                                   RedirectorConstants.Fields.UrlName.Length)
                .And
                .IsSlug()
                .WithInvalidFormat(RedirectorConstants.Fields.UrlName.Label);

            Define(r => r.Description)
                .MaxLength();

            Define(r => r.UsageTimes);

            Define(r => r.Downloads);

            Define(r => r.Artists);

            Define(r => r.Publishers);

            ValidateInstance.SafeBy((redirector, context) => {
                                        var isValid = true;

                                        var service = EngineContext.Current.Resolve<IDbService<Redirector, RedirectorQuery>>();

                                        if (service.GetByTargetUrl(redirector.TargetUrl).IsDuplicate(redirector)) {
                                            context.AddDuplicate<Redirector, string>(RedirectorConstants.Fields.TargetUrl.Label,
                                                                                     r => r.TargetUrl);

                                            isValid = false;
                                        }

                if (service.GetByShortHash(redirector.ShortHash).IsDuplicate(redirector)) {
                                            context.AddDuplicate<Redirector, string>(RedirectorConstants.Fields.ShortHash.Label,
                                                                                     r => r.ShortHash);

                                            isValid = false;
                                        }

                                        return isValid;
                                    });
        }
    }
}