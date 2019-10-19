namespace FaraMedia.FrontEnd.Administration.Models.Miscellaneous {
    using FaraMedia.Core.Globalization;
    using FaraMedia.Web.Framework.Mvc.Models;

    public class ToDoModel : EntityModelBase {
        public string ToDoStatus { get; set; }

        public MultiFormatDateTime DueDate { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public long PerformerId { get; set; }
        public string PerformerFullName { get; set; }
    }
}