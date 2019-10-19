namespace FaraMedia.FrontEnd.Administration.Models.Fundamentals {
    using FaraMedia.Core.Globalization;
    using FaraMedia.FrontEnd.Administration.Models.Common;
    using FaraMedia.FrontEnd.Administration.Models.Components;

    public class ArtistModel : CommentableModelBase {
        public MultiFormatDateTime BirthDate { get; set; }

        public string FullName { get; set; }
        public string AlternativeName { get; set; }
        public string HomeTown { get; set; }
        public string Biography { get; set; }

        public MetadataComponentModel Metadata { get; set; }

        public long FacebookId { get; set; }
        public string FacebookTargetUrl { get; set; }

        public long AvatarId { get; set; }
        public string AvatarFileName { get; set; }

        public int PhotoAlbumsCount { get; set; }
        public int SingedTracksCount { get; set; }
        public int ComposedTracksCount { get; set; }
        public int ArrangedTracksCount { get; set; }
        public int SongwrittenTracksCount { get; set; }
    }
}