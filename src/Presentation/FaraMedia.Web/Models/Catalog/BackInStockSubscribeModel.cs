using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.Catalog
{
    public class BackInStockSubscribeModel : BaseFaraModel
    {
        public bool IsCurrentCustomerRegistered { get; set; }
        public bool SubscriptionAllowed { get; set; }
        public bool AlreadySubscribed { get; set; }

        public int MaximumBackInStockSubscriptions { get; set; }
        public int CurrentNumberOfBackInStockSubscriptions { get; set; }
    }
}