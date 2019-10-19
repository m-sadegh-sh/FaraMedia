namespace FaraMedia.FrontEnd.Administration.Models.ContentManagement {
    using FaraMedia.FrontEnd.Administration.Models.Components;
    using FaraMedia.Web.Framework.Mvc.Models;

    public class PageModel : EntityModelBase {
        public string Title { get; set; }
        public string Body { get; set; }

        public MetadataComponentModel Metadata { get; set; }

        public long GroupId { get; set; }
        public string GroupTitle { get; set; }
    }
}