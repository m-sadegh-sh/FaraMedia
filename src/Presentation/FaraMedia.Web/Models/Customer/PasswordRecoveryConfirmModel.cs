using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Fara.Web.Framework;
using Fara.Web.Framework.Mvc;
using Fara.Web.Validators.Customer;

namespace Fara.Web.Models.Customer
{
    [Validator(typeof(PasswordRecoveryConfirmValidator))]
    public class PasswordRecoveryConfirmModel : BaseFaraModel
    {
        [AllowHtml]
        [DataType(DataType.Password)]
        [FaraResourceDisplayName("Account.PasswordRecovery.NewPassword")]
        public string NewPassword { get; set; }

        [AllowHtml]
        [DataType(DataType.Password)]
        [FaraResourceDisplayName("Account.PasswordRecovery.ConfirmNewPassword")]
        public string ConfirmNewPassword { get; set; }

        public bool SuccessfullyChanged { get; set; }
        public string Result { get; set; }
    }
}