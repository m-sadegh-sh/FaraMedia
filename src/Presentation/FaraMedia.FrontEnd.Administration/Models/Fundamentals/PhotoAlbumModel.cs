namespace FaraMedia.FrontEnd.Administration.Models.Fundamentals {
    using FaraMedia.FrontEnd.Administration.Models.Common;
    using FaraMedia.FrontEnd.Administration.Models.Components;

    public class PhotoAlbumModel : CommentableModelBase {
        public string Title { get; set; }
        public string Description { get; set; }

        public MetadataComponentModel Metadata { get; set; }

        public long ArtistId { get; set; }
        public string ArtistFullName { get; set; }

        public int PhotosCount { get; set; }
    }
}