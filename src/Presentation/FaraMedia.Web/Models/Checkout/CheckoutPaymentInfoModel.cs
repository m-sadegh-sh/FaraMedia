using System.Web.Routing;
using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.Checkout
{
    public class CheckoutPaymentInfoModel : BaseFaraModel
    {
        public string PaymentInfoActionName { get; set; }
        public string PaymentInfoControllerName { get; set; }
        public RouteValueDictionary PaymentInfoRouteValues { get; set; }

        
        
        
        public bool DisplayOrderTotals { get; set; }
    }
}