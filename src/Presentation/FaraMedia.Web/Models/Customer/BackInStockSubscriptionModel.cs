using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.Customer
{
    public class BackInStockSubscriptionModel : BaseFaraEntityModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string SeName { get; set; }
    }
}
