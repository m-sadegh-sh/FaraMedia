namespace FaraMedia.FrontEnd.Administration.Models.Miscellaneous {
    using FaraMedia.Web.Framework.Mvc.Models;

    public class TicketResponseModel : EntityModelBase {
        public string Subject { get; set; }
        public string Body { get; set; }

        public long InResponseToId { get; set; }
        public string InResponseToSubject { get; set; }

        public long ResponderId { get; set; }
        public string ResponderFullName { get; set; }
    }
}