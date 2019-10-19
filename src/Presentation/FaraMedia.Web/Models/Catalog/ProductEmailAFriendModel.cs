using System.Web.Mvc;
using FluentValidation.Attributes;
using Fara.Web.Framework;
using Fara.Web.Framework.Mvc;
using Fara.Web.Validators.Catalog;

namespace Fara.Web.Models.Catalog
{
    [Validator(typeof(ProductEmailAFriendValidator))]
    public class ProductEmailAFriendModel : BaseFaraModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductSeName { get; set; }

        [AllowHtml]
        [FaraResourceDisplayName("Products.EmailAFriend.FriendEmail")]
        public string FriendEmail { get; set; }

        [AllowHtml]
        [FaraResourceDisplayName("Products.EmailAFriend.YourEmailAddress")]
        public string YourEmailAddress { get; set; }

        [AllowHtml]
        [FaraResourceDisplayName("Products.EmailAFriend.PersonalMessage")]
        public string PersonalMessage { get; set; }

        public bool SuccessfullySent { get; set; }
        public string Result { get; set; }
    }
}