using System.ComponentModel.DataAnnotations;
using Fara.Web.Framework;
using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.Customer
{
    public class LoginModel : BaseFaraModel
    {
        public bool CheckoutAsGuest { get; set; }

        [FaraResourceDisplayName("Account.Login.Fields.Email")]
        public string Email { get; set; }

        public bool UsernamesEnabled { get; set; }
        [FaraResourceDisplayName("Account.Login.Fields.UserName")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [FaraResourceDisplayName("Account.Login.Fields.Password")]
        public string Password { get; set; }

        [FaraResourceDisplayName("Account.Login.Fields.RememberMe")]
        public bool RememberMe { get; set; }
    }
}