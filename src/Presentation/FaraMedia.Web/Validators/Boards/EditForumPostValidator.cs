using FluentValidation;
using Fara.Services.Localization;
using Fara.Web.Models.Boards;

namespace Fara.Web.Validators.Boards
{
    public class EditForumPostValidator : AbstractValidator<EditForumPostModel>
    {
        public EditForumPostValidator(ILocalizationService localizationService)
        {            
            RuleFor(x => x.Text).NotEmpty().WithMessage(localizationService.GetResource("Forum.TextCannotBeEmpty"));
        }
    }
}