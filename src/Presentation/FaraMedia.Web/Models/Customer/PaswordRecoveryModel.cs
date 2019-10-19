using System.Web.Mvc;
using FluentValidation.Attributes;
using Fara.Web.Framework;
using Fara.Web.Framework.Mvc;
using Fara.Web.Validators.Customer;

namespace Fara.Web.Models.Customer
{
    [Validator(typeof(PasswordRecoveryValidator))]
    public class PasswordRecoveryModel : BaseFaraModel
    {
        [AllowHtml]
        [FaraResourceDisplayName("Account.PasswordRecovery.Email")]
        public string Email { get; set; }

        public string Result { get; set; }
    }
}