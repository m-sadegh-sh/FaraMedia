namespace FaraMedia.FrontEnd.Administration.Models.Miscellaneous.Editable {
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.Miscellaneous;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Editable;

    public class EditableTicketModel : EditableEntityModelBase {
        [ResourceDisplayName(TicketConstants.Fields.TicketStatus.Label)]
        [ResourceMin(TicketConstants.Fields.TicketStatus.MinValue)]
        [ResourceMax(TicketConstants.Fields.TicketStatus.MaxValue)]
        public int TicketStatus { get; set; }

        public SelectList AvailableTicketStatuses { get; set; }

        [ResourceDisplayName(TicketConstants.Fields.Department.Label)]
        [ResourceMin(TicketConstants.Fields.Department.MinValue)]
        [ResourceMax(TicketConstants.Fields.Department.MaxValue)]
        public int Department { get; set; }

        public SelectList AvailableDepartments { get; set; }

        [ResourceDisplayName(TicketConstants.Fields.TicketPriority.Label)]
        [ResourceMin(TicketConstants.Fields.TicketPriority.MinValue)]
        [ResourceMax(TicketConstants.Fields.TicketPriority.MaxValue)]
        public int TicketPriority { get; set; }

        public SelectList AvailableTicketPriorities { get; set; }

        [ResourceDisplayName(TicketConstants.Fields.Subject.Label)]
        [ResourceRequired]
        [ResourceStringLength(TicketConstants.Fields.Subject.Length)]
        public string Subject { get; set; }

        [ResourceDisplayName(TicketConstants.Fields.Body.Label)]
        [ResourceRequired]
        public string Body { get; set; }

        //Code-assigned
        [ResourceDisplayName(TicketConstants.Fields.Opener.Label)]
        public long OpenedById { get; set; }
        public string OpenedByFullName { get; set; }
    }
}