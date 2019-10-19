namespace FaraMedia.FrontEnd.Administration.Models.Blogs {
    using FaraMedia.FrontEnd.Administration.Models.Components;
    using FaraMedia.Web.Framework.Mvc.Models;

    public class TagModel : EntityModelBase {
        public string Text { get; set; }

        public MetadataComponentModel Metadata { get; set; }

        public long BlogId { get; set; }
        public string BlogName { get; set; }

        public int PostsCount { get; set; }
    }
}