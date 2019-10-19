namespace FaraMedia.FrontEnd.Administration.Models.Billing {
    using FaraMedia.Web.Framework.Mvc.Models;

    public class OrderNoteModel : EntityModelBase {
        public string VisibleForUser { get; set; }

        public string Note { get; set; }

        public long OrderId { get; set; }
    }
}