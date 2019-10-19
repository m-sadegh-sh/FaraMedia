using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.Checkout
{
    public class CheckoutProgressModel : BaseFaraModel
    {
        public CheckoutProgressStep CheckoutProgressStep { get; set; }
    }

    public enum CheckoutProgressStep
    {
        Cart,
        Address,
        Shipping,
        Payment,
        Confirm,
        Complete
    }
}