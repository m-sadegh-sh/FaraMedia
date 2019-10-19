namespace FaraMedia.FrontEnd.Administration.Models.Components {
    using FaraMedia.Web.Framework.Mvc.Models;

    public class MetadataComponentModel : ModelBase {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
    }
}