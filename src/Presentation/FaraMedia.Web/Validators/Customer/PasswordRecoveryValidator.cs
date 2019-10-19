using FluentValidation;
using Fara.Services.Localization;
using Fara.Web.Models.Customer;

namespace Fara.Web.Validators.Customer
{
    public class PasswordRecoveryValidator : AbstractValidator<PasswordRecoveryModel>
    {
        public PasswordRecoveryValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage(localizationService.GetResource("Account.PasswordRecovery.Email.Required"));
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizationService.GetResource("Common.WrongEmail"));
        }}
}