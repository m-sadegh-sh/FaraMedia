namespace FaraMedia.FrontEnd.Administration.Models.Systematic {
    using FaraMedia.Web.Framework.Mvc.Models;

    public class ActivityModel : EntityModelBase {
        public string Comment { get; set; }

        public long ActivityTypeId { get; set; }
        public string ActivityTypeName { get; set; }

        public long UserId { get; set; }
        public string UserFullName { get; set; }
    }
}