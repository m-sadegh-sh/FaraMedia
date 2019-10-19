using System.Web.Mvc;
using FluentValidation.Attributes;
using Fara.Web.Framework;
using Fara.Web.Framework.Mvc;
using Fara.Web.Validators.ShoppingCart;

namespace Fara.Web.Models.ShoppingCart
{
    [Validator(typeof(WishlistEmailAFriendValidator))]
    public class WishlistEmailAFriendModel : BaseFaraModel
    {
        [AllowHtml]
        [FaraResourceDisplayName("Wishlist.EmailAFriend.FriendEmail")]
        public string FriendEmail { get; set; }

        [AllowHtml]
        [FaraResourceDisplayName("Wishlist.EmailAFriend.YourEmailAddress")]
        public string YourEmailAddress { get; set; }

        [AllowHtml]
        [FaraResourceDisplayName("Wishlist.EmailAFriend.PersonalMessage")]
        public string PersonalMessage { get; set; }

        public bool SuccessfullySent { get; set; }
        public string Result { get; set; }
    }
}