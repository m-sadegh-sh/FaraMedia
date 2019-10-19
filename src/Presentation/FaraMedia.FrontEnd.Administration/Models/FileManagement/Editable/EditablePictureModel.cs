namespace FaraMedia.FrontEnd.Administration.Models.FileManagement.Editable {
    using System.Web;

    using FaraMedia.Data.Schemas.FileManagement;
    using FaraMedia.FrontEnd.Administration.Models.Common.Editable;
    using FaraMedia.Web.Framework.Mvc.Attributes;

    public class EditablePictureModel : EditableUserContentModelBase {
        [ResourceDisplayName(PictureConstants.Fields.MimeType.Label)]
        [ResourceStringLength(PictureConstants.Fields.MimeType.Length)]
        public string MimeType { get; set; }

        [ResourceDisplayName(PictureConstants.Fields.FileName.Label)]
        [ResourceRequired]
        [ResourceStringLength(PictureConstants.Fields.FileName.Length)]
        public string FileName { get; set; }

        [ResourceDisplayName(PictureConstants.Fields.PictureBinary.Label)]
        [ResourceRequired]
        public HttpPostedFileBase PictureBinary { get; set; }
    }
}