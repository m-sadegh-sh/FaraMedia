namespace FaraMedia.FrontEnd.Administration.Models.Billing.Editable {
    using FaraMedia.Data.Schemas.Billing;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Editable;

    public class EditableOrderNoteModel : EditableEntityModelBase {
        [ResourceDisplayName(OrderNoteConstants.Fields.VisibleForUser.Label)]
        public bool VisibleForUser { get; set; }

        [ResourceDisplayName(OrderNoteConstants.Fields.Note.Label)]
        [ResourceRequired]
        public string Note { get; set; }

        //Code-assigned
        [ResourceDisplayName(OrderLineConstants.Fields.Order.Label)]
        public long OrderId { get; set; }
    }
}