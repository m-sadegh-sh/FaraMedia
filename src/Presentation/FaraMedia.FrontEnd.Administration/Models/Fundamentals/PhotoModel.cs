namespace FaraMedia.FrontEnd.Administration.Models.Fundamentals {
    using FaraMedia.FrontEnd.Administration.Models.Common;
    using FaraMedia.FrontEnd.Administration.Models.Components;

    public class PhotoModel : CommentableModelBase {
        public string Title { get; set; }
        public string Description { get; set; }

        public MetadataComponentModel Metadata { get; set; }

        public long PhotoAlbumId { get; set; }
        public string PhotoAlbumTitle { get; set; }

        public long PictureId { get; set; }
        public string PictureFileName { get; set; }
    }
}