namespace FaraMedia.Services.Validations.Fundamentals {
    using FaraMedia.Core;
    using FaraMedia.Core.Domain.Fundamentals;
    using FaraMedia.Core.Domain.Misc;
    using FaraMedia.Data.Schemas.Fundamentals;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class PublisherValidation : UIElementValidationBase<Publisher> {
        public PublisherValidation() {
            Define(p => p.Name)
                .NotNullableAndNotEmpty()
                .WithRequired(PublisherConstants.Fields.Name.Label)
                .And
                .MaxLength(PublisherConstants.Fields.Name.Length)
                .WithInvalidLength(PublisherConstants.Fields.Name.Label,
                                   PublisherConstants.Fields.Name.Length);

            Define(p => p.Ceo)
                .MaxLength(PublisherConstants.Fields.Ceo.Length)
                .WithInvalidLength(PublisherConstants.Fields.Ceo.Label,
                                   PublisherConstants.Fields.Ceo.Length);

            Define(p => p.RegisterationNumber)
                .MaxLength(PublisherConstants.Fields.RegisterationNumber.Length)
                .WithInvalidLength(PublisherConstants.Fields.RegisterationNumber.Label,
                                   PublisherConstants.Fields.RegisterationNumber.Length);

            Define(p => p.Email)
                .MaxLength(PublisherConstants.Fields.RegisterationNumber.Length)
                .WithInvalidLength(PublisherConstants.Fields.RegisterationNumber.Label,
                                   PublisherConstants.Fields.RegisterationNumber.Length)
                .And
                .IsEmail()
                .WithInvalidFormat(PublisherConstants.Fields.Email.Label);

            Define(p => p.BriefHistory)
                .MaxLength();

            Define(p => p.Website);

            Define(p => p.Logo);

            Define(p => p.Tracks);

            ValidateInstance.SafeBy((publisher, context) => {
                                        var isValid = true;

                                        if (publisher.Website != null && !string.IsNullOrEmpty(publisher.Website.TargetUrl)) {
                                            if (publisher.Website.TargetUrl.Length > PublisherConstants.Fields.Website.Length) {
                                                context.AddInvalidLength<Publisher, Redirector>(PublisherConstants.Fields.Website.Label,
                                                                                                PublisherConstants.Fields.Website.Length,
                                                                                                p => p.Website);

                                                isValid = false;
                                            } else if (!CommonHelper.IsValidUrl(publisher.Website.TargetUrl)) {
                                                context.AddInvalidFormat<Publisher, Redirector>(PublisherConstants.Fields.Website.Label,
                                                                                                p => p.Website);

                                                isValid = false;
                                            }
                                        }

                                        return isValid;
                                    });
        }
    }
}