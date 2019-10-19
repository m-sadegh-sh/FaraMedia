using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Fara.Web.Framework;
using Fara.Web.Framework.Mvc;
using Fara.Web.Validators.Customer;

namespace Fara.Web.Models.Customer
{
    [Validator(typeof(ChangePasswordValidator))]
    public class ChangePasswordModel : BaseFaraModel
    {
        [AllowHtml]
        [DataType(DataType.Password)]
        [FaraResourceDisplayName("Account.ChangePassword.Fields.OldPassword")]
        public string OldPassword { get; set; }

        [AllowHtml]
        [DataType(DataType.Password)]
        [FaraResourceDisplayName("Account.ChangePassword.Fields.NewPassword")]
        public string NewPassword { get; set; }

        [AllowHtml]
        [DataType(DataType.Password)]
        [FaraResourceDisplayName("Account.ChangePassword.Fields.ConfirmNewPassword")]
        public string ConfirmNewPassword { get; set; }

        public string Result { get; set; }

        public CustomerNavigationModel NavigationModel { get; set; }

    }
}