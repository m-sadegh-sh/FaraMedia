namespace FaraMedia.FrontEnd.Administration.Models.Miscellaneous {
    using FaraMedia.Web.Framework.Mvc.Models;

    public class TicketModel : EntityModelBase {
        public string TicketStatus { get; set; }
        public string Department { get; set; }
        public string TicketPriority { get; set; }

        public string Subject { get; set; }
        public string Body { get; set; }

        public long OpenedById { get; set; }
        public string OpenedByFullName { get; set; }

        public int TicketResponsesCount { get; set; }
    }
}