using FluentValidation.Attributes;
using Fara.Web.Framework.Mvc;
using Fara.Web.Validators.Newsletter;

namespace Fara.Web.Models.Newsletter
{
    [Validator(typeof(NewsletterBoxValidator))]
    public class NewsletterBoxModel : BaseFaraModel
    {
        public string Email { get; set; }
    }
}