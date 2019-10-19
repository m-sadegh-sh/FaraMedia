namespace FaraMedia.FrontEnd.Administration.Models.Billing {
    using FaraMedia.Web.Framework.Mvc.Models;

    public class OrderLineModel : EntityModelBase {
        public int Quantity { get; set; }
        public int AccessTries { get; set; }

        public string ItemPrice { get; set; }

        public string ItemName { get; set; }

        public long OrderId { get; set; }
        public long DownloadId { get; set; }
    }
}