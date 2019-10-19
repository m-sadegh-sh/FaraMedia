namespace FaraMedia.FrontEnd.Administration.Models.Fundamentals.Editable {
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.Fundamentals;
    using FaraMedia.FrontEnd.Administration.Models.Common.Editable;
    using FaraMedia.FrontEnd.Administration.Models.Components.Editable;
    using FaraMedia.Web.Framework.Mvc.Attributes;

    public class EditableTrackModel : EditableCommentableModelBase {
        [ResourceDisplayName(TrackConstants.Fields.IsVideo.Label)]
        public bool IsVideo { get; set; }

        [ResourceDisplayName(TrackConstants.Fields.TrackNumber.Label)]
        [ResourceMin(TrackConstants.Fields.TrackNumber.MinValue)]
        public int TrackNumber { get; set; }

        [ResourceDisplayName(TrackConstants.Fields.ReleaseDateUtc.Label)]
        [ResourceRequired]
        [ResourceMin(1)]
        public int ReleaseDateDay { get; set; }

        [ResourceRequired]
        [ResourceMin(1)]
        public int ReleaseDateMonth { get; set; }

        [ResourceRequired]
        [ResourceMin(1)]
        public int ReleaseDateYear { get; set; }

        [ResourceDisplayName(TrackConstants.Fields.Title.Label)]
        [ResourceRequired]
        [ResourceStringLength(TrackConstants.Fields.Title.Length)]
        public string Title { get; set; }

        [ResourceDisplayName(TrackConstants.Fields.Description.Label)]
        public string Description { get; set; }

        public EditableMetadataComponentModel Metadata { get; set; }

        [ResourceDisplayName(TrackConstants.Fields.Genre.Label)]
        [ResourceMin(1)]
        public long GenreId { get; set; }

        public SelectList AvailableGenres { get; set; }

        [ResourceDisplayName(TrackConstants.Fields.Publisher.Label)]
        [ResourceMin(1)]
        public long PublisherId { get; set; }

        public SelectList AvailablePublishers { get; set; }

        [ResourceDisplayName(TrackConstants.Fields.Album.Label)]
        [ResourceMin(1)]
        public long AlbumId { get; set; }

        public SelectList AvailableAlbums { get; set; }
    }
}