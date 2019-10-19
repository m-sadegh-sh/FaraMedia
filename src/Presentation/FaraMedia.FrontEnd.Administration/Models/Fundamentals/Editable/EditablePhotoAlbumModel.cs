namespace FaraMedia.FrontEnd.Administration.Models.Fundamentals.Editable {
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.Fundamentals;
    using FaraMedia.FrontEnd.Administration.Models.Common.Editable;
    using FaraMedia.FrontEnd.Administration.Models.Components.Editable;
    using FaraMedia.Web.Framework.Mvc.Attributes;

    public class EditablePhotoAlbumModel : EditableCommentableModelBase {
        [ResourceDisplayName(PhotoAlbumConstants.Fields.Title.Label)]
        [ResourceRequired]
        [ResourceStringLength(PhotoAlbumConstants.Fields.Title.Length)]
        public string Title { get; set; }

        [ResourceDisplayName(PhotoAlbumConstants.Fields.Description.Label)]
        public string Description { get; set; }

        public EditableMetadataComponentModel Metadata { get; set; }

        //Code-assigned
        [ResourceDisplayName(PhotoAlbumConstants.Fields.Artist.Label)]
        public long ArtistId { get; set; }
        public string ArtistFullName { get; set; }
    }
}