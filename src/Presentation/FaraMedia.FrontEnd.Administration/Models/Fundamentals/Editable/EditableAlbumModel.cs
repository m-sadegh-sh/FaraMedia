namespace FaraMedia.FrontEnd.Administration.Models.Fundamentals.Editable {
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.Fundamentals;
    using FaraMedia.FrontEnd.Administration.Models.Common.Editable;
    using FaraMedia.FrontEnd.Administration.Models.Components.Editable;
    using FaraMedia.Web.Framework.Mvc.Attributes;

    public class EditableAlbumModel : EditableCommentableModelBase {
        [ResourceDisplayName(AlbumConstants.Fields.ReleaseDateUtc.Label)]
        [ResourceRequired]
        [ResourceMin(1)]
        public int ReleaseDateDay { get; set; }

        [ResourceRequired]
        [ResourceMin(1)]
        public int ReleaseDateMonth { get; set; }

        [ResourceRequired]
        [ResourceMin(1)]
        public int ReleaseDateYear { get; set; }

        [ResourceDisplayName(AlbumConstants.Fields.Title.Label)]
        [ResourceRequired]
        [ResourceStringLength(AlbumConstants.Fields.Title.Length)]
        public string Title { get; set; }

        [ResourceDisplayName(AlbumConstants.Fields.Description.Label)]
        public string Description { get; set; }

        public EditableMetadataComponentModel Metadata { get; set; }

        [ResourceDisplayName(AlbumConstants.Fields.Publisher.Label)]
        [ResourceMin(1)]
        public long? PublisherId { get; set; }
        public SelectList AvailablePublishers { get; set; }
    }
}