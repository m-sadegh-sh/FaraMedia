using System.Collections.Generic;
using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.Checkout
{
    public class CheckoutPaymentMethodModel : BaseFaraModel
    {
        public CheckoutPaymentMethodModel()
        {
            PaymentMethods = new List<PaymentMethodModel>();
        }

        public IList<PaymentMethodModel> PaymentMethods { get; set; }

        public bool DisplayRewardPoints { get; set; }
        public int RewardPointsBalance { get; set; }
        public string RewardPointsAmount { get; set; }
        public bool UseRewardPoints { get; set; }

        

        public class PaymentMethodModel : BaseFaraModel
        {
            public string PaymentMethodSystemName { get; set; }
            public string Name { get; set; }
            public string Fee { get; set; }
        }
        
    }
}