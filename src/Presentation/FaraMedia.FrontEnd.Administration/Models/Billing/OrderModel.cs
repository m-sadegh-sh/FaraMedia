namespace FaraMedia.FrontEnd.Administration.Models.Billing {
    using FaraMedia.Core.Globalization;
    using FaraMedia.Web.Framework.Mvc.Models;

    public class OrderModel : EntityModelBase {
        public string OrderStatus { get; set; }

        public MultiFormatDateTime PaidDate { get; set; }

        public long UserId { get; set; }
        public string UserFullName { get; set; }

        public int OrderLinesCount { get; set; }
        public int OrderNotesCount { get; set; }
        public int TransactionDebugsCount { get; set; }
    }
}