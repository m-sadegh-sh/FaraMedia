namespace FaraMedia.FrontEnd.Administration.Models.Billing {
    using FaraMedia.Web.Framework.Mvc.Models;

    public class TransactionDebugModel : EntityModelBase {
        public string TransactionDebugStatus { get; set; }

        public string OriginalStatus { get; set; }
        public string AuthorityCode { get; set; }

        public long OrderId { get; set; }
    }
}