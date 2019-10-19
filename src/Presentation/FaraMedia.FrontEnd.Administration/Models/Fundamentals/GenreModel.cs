namespace FaraMedia.FrontEnd.Administration.Models.Fundamentals {
    using FaraMedia.FrontEnd.Administration.Models.Common;
    using FaraMedia.FrontEnd.Administration.Models.Components;

    public class GenreModel : CommentableModelBase {
        public string Title { get; set; }
        public string Description { get; set; }

        public MetadataComponentModel Metadata { get; set; }

        public int TracksCount { get; set; }
    }
}