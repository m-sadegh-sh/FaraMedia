﻿using FluentValidation;
using Fara.Core.Domain.Customers;
using Fara.Services.Localization;
using Fara.Web.Models.Customer;

namespace Fara.Web.Validators.Customer
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordModel>
    {
        public ChangePasswordValidator(ILocalizationService localizationService, CustomerSettings customerSettings)
        {
            RuleFor(x => x.OldPassword).NotEmpty().WithMessage(localizationService.GetResource("Account.ChangePassword.Fields.OldPassword.Required"));
            RuleFor(x => x.NewPassword).NotEmpty().WithMessage(localizationService.GetResource("Account.ChangePassword.Fields.NewPassword.Required"));
            RuleFor(x => x.ConfirmNewPassword).NotEmpty().WithMessage(localizationService.GetResource("Account.ChangePassword.Fields.ConfirmNewPassword.Required"));
            RuleFor(x => x.NewPassword).Equal(x => x.ConfirmNewPassword).WithMessage(localizationService.GetResource("Account.ChangePassword.Fields.NewPassword.EnteredPasswordsDoNotMatch"));
            RuleFor(x => x.NewPassword).Length(customerSettings.PasswordMinLength, 999).WithMessage(string.Format(localizationService.GetResource("Account.ChangePassword.Fields.NewPassword.LengthValidation"), customerSettings.PasswordMinLength));
        }}
}