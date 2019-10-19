namespace FaraMedia.FrontEnd.Administration.Models.Fundamentals {
    using FaraMedia.Core.Globalization;
    using FaraMedia.FrontEnd.Administration.Models.Common;
    using FaraMedia.FrontEnd.Administration.Models.Components;

    public class AlbumModel : CommentableModelBase {
        public MultiFormatDateTime ReleaseDate { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public MetadataComponentModel Metadata { get; set; }

        public int TracksCount { get; set; }
    }
}