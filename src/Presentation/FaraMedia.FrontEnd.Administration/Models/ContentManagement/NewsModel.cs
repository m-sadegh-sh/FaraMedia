namespace FaraMedia.FrontEnd.Administration.Models.ContentManagement {
    using FaraMedia.FrontEnd.Administration.Models.Common;
    using FaraMedia.FrontEnd.Administration.Models.Components;

    public class NewsModel : CommentableModelBase {
        public string Title { get; set; }
        public string Short { get; set; }
        public string Full { get; set; }

        public MetadataComponentModel Metadata { get; set; }

        public long CategoryId { get; set; }
        public string CategoryTitle { get; set; }
    }
}