using System.Web.Mvc;
using FluentValidation.Attributes;
using Fara.Web.Framework;
using Fara.Web.Framework.Mvc;
using Fara.Web.Validators.Common;

namespace Fara.Web.Models.Common
{
    [Validator(typeof(ContactUsValidator))]
    public class ContactUsModel : BaseFaraModel
    {
        [AllowHtml]
        [FaraResourceDisplayName("ContactUs.Email")]
        public string Email { get; set; }

        [AllowHtml]
        [FaraResourceDisplayName("ContactUs.Enquiry")]
        public string Enquiry { get; set; }

        [AllowHtml]
        [FaraResourceDisplayName("ContactUs.FullName")]
        public string FullName { get; set; }
    }
}