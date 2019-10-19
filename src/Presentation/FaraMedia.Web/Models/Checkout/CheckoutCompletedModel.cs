using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.Checkout
{
    public class CheckoutCompletedModel : BaseFaraModel
    {
        public int OrderId { get; set; }
    }
}