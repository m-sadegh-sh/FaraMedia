using FluentValidation;
using Fara.Services.Localization;
using Fara.Web.Models.Blogs;

namespace Fara.Web.Validators.Blogs
{
    public class BlogPostModelValidator : AbstractValidator<BlogPostModel>
    {
        public BlogPostModelValidator(ILocalizationService localizationService)
        {
            RuleFor(bp => bp.AddNewComment.CommentText).NotEmpty().WithMessage(localizationService.GetResource("Blog.Comments.CommentText.Required")).When(x => x.AddNewComment != null);
        }}
}