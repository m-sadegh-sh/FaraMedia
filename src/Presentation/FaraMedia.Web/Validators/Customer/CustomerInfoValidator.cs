using FluentValidation;
using Fara.Services.Localization;
using Fara.Web.Models.Customer;

namespace Fara.Web.Validators.Customer
{
    public class CustomerInfoValidator : AbstractValidator<CustomerInfoModel>
    {
        public CustomerInfoValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.Email.Required"));
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizationService.GetResource("Common.WrongEmail"));
            RuleFor(x => x.FirstName).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.FirstName.Required"));
            RuleFor(x => x.LastName).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.LastName.Required"));
        }}
}