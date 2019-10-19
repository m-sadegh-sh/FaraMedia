namespace FaraMedia.FrontEnd.Administration.Models.Systematic {
    using FaraMedia.Web.Framework.Mvc.Models;

    public class ActivityTypeModel : EntityModelBase {
        public string SystemKeyword { get; set; }
        public string Name { get; set; }

        public int ActivitiesCount { get; set; }
    }
}