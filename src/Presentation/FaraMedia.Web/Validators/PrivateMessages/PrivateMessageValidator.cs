using FluentValidation;
using Fara.Services.Localization;
using Fara.Web.Models.PrivateMessages;

namespace Fara.Web.Validators.PrivateMessages
{
    public class PrivateMessageValidator : AbstractValidator<PrivateMessageModel>
    {
        public PrivateMessageValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Subject).NotEmpty().WithMessage(localizationService.GetResource("PrivateMessages.SubjectCannotBeEmpty"));
            RuleFor(x => x.Message).NotEmpty().WithMessage(localizationService.GetResource("PrivateMessages.MessageCannotBeEmpty"));
        }
    }
}