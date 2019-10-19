namespace FaraMedia.FrontEnd.Administration.Models.Miscellaneous {
    using FaraMedia.Web.Framework.Mvc.Models;

    public class RedirectorModel : EntityModelBase {
        public int UsageTimes { get; set; }

        public string TargetUrl { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
    }
}