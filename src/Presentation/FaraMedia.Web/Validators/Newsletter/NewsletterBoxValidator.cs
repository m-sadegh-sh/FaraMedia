using FluentValidation;
using Fara.Services.Localization;
using Fara.Web.Models.Newsletter;

namespace Fara.Web.Validators.Newsletter
{
    public class NewsletterBoxValidator : AbstractValidator<NewsletterBoxModel>
    {
        public NewsletterBoxValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("*");
            RuleFor(x => x.Email).EmailAddress().WithMessage("*");
        }}
}