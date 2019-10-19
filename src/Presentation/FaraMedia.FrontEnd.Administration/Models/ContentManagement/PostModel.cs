namespace FaraMedia.FrontEnd.Administration.Models.Blogs {
    using FaraMedia.FrontEnd.Administration.Models.Common;
    using FaraMedia.FrontEnd.Administration.Models.Components;

    public class PostModel : CommentableModelBase {
        public string Title { get; set; }
        public string Body { get; set; }

        public MetadataComponentModel Metadata { get; set; }

        public long BlogId { get; set; }
        public string BlogName { get; set; }

        public int TagsCount { get; set; }
    }
}