using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.Checkout
{
    public class OnePageCheckoutModel : BaseFaraModel
    {
        public bool ShippingRequired { get; set; }
    }
}