using System.Collections.Generic;
using Fara.Web.Models.Common;

namespace Fara.Web.Models.Customer
{
    public class CustomerBackInStockSubscriptionsModel
    {
        public CustomerBackInStockSubscriptionsModel()
        {
            this.Subscriptions = new List<BackInStockSubscriptionModel>();
        }

        public IList<BackInStockSubscriptionModel> Subscriptions { get; set; }
        public CustomerNavigationModel NavigationModel { get; set; }
        public PagerModel PagerModel { get; set; }
    }
}