namespace FaraMedia.FrontEnd.Administration.Models.Blogs {
    using FaraMedia.FrontEnd.Administration.Models.Components;
    using FaraMedia.Web.Framework.Mvc.Models;

    public class BlogModel : EntityModelBase {
        public string IsActive { get; set; }

        public string Name { get; set; }

        public MetadataComponentModel Metadata { get; set; }

        public long UserId { get; set; }
        public string UserFullName { get; set; }

        public int TagsCount { get; set; }
        public int PostsCount { get; set; }
    }
}