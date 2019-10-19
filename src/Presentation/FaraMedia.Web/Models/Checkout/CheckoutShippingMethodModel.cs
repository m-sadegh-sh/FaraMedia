using System.Collections.Generic;
using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.Checkout
{
    public class CheckoutShippingMethodModel : BaseFaraModel
    {
        public CheckoutShippingMethodModel()
        {
            ShippingMethods = new List<ShippingMethodModel>();
            Warnings = new List<string>();
        }

        public IList<ShippingMethodModel> ShippingMethods { get; set; }

        public IList<string> Warnings { get; set; }

        

        public class ShippingMethodModel : BaseFaraModel
        {
            public string ShippingRateComputationMethodSystemName { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Fee { get; set; }
        }
        
    }
}