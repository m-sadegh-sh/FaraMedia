namespace FaraMedia.FrontEnd.Administration.Models.Fundamentals.Editable {
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.Fundamentals;
    using FaraMedia.FrontEnd.Administration.Models.Common.Editable;
    using FaraMedia.FrontEnd.Administration.Models.Components.Editable;
    using FaraMedia.Web.Framework.Mvc.Attributes;

    public class EditablePhotoModel : EditableCommentableModelBase {
        [ResourceDisplayName(PhotoConstants.Fields.Title.Label)]
        [ResourceRequired]
        [ResourceStringLength(PhotoConstants.Fields.Title.Length)]
        public string Title { get; set; }

        [ResourceDisplayName(PhotoConstants.Fields.Description.Label)]
        public string Description { get; set; }

        public EditableMetadataComponentModel Metadata { get; set; }

        //Code-assigned
        [ResourceDisplayName(PhotoConstants.Fields.PhotoAlbum.Label)]
        public long PhotoAlbumId { get; set; }
        public string PhotoAlbumTitle { get; set; }

        [ResourceDisplayName(PhotoConstants.Fields.Picture.Label)]
        [ResourceMin(1)]
        public long PictureId { get; set; }

        public SelectList AvailablePictures { get; set; }
    }
}