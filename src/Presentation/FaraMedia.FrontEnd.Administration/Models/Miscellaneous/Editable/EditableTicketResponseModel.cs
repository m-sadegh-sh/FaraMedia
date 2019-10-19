namespace FaraMedia.FrontEnd.Administration.Models.Miscellaneous.Editable {
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.Miscellaneous;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Editable;

    public class EditableTicketResponseModel : EditableEntityModelBase {
        [ResourceDisplayName(TicketResponseConstants.Fields.Subject.Label)]
        [ResourceRequired]
        [ResourceStringLength(TicketResponseConstants.Fields.Subject.Length)]
        public string Subject { get; set; }

        [ResourceDisplayName(TicketResponseConstants.Fields.Body.Label)]
        [ResourceRequired]
        public string Body { get; set; }

        //Code-assigned
        [ResourceDisplayName(TicketResponseConstants.Fields.InResponseTo.Label)]
        public long InResponseToId { get; set; }
        public string InResponseToSubject { get; set; }

        //Code-assigned
        [ResourceDisplayName(TicketResponseConstants.Fields.Responder.Label)]
        public long ResponderId { get; set; }
        public string ResponderFullName { get; set; }
    }
}