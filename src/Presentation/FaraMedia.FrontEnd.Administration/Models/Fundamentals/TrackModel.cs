namespace FaraMedia.FrontEnd.Administration.Models.Fundamentals {
    using FaraMedia.Core.Globalization;
    using FaraMedia.FrontEnd.Administration.Models.Common;
    using FaraMedia.FrontEnd.Administration.Models.Components;

    public class TrackModel : CommentableModelBase {
        public string IsVideo { get; set; }

        public int TrackNumber { get; set; }

        public MultiFormatDateTime ReleaseDate { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public MetadataComponentModel Metadata { get; set; }

        public long GenreId { get; set; }
        public string GenreTitle { get; set; }

        public long PublisherId { get; set; }
        public string PublisherName { get; set; }

        public long AlbumId { get; set; }
        public string AlbumTitle { get; set; }

        public int SingersCount { get; set; }
        public int ComposersCount { get; set; }
        public int ArrangementersCount { get; set; }
        public int SongwritersCount { get; set; }
        public int CoversCount { get; set; }
        public int DownloadsCount { get; set; }
    }
}