namespace FaraMedia.FrontEnd.Administration.Models.FileManagement.Editable {
    using System.Web;

    using FaraMedia.Data.Schemas.FileManagement;
    using FaraMedia.FrontEnd.Administration.Models.Common.Editable;
    using FaraMedia.Web.Framework.Mvc.Attributes;

    public class EditableDownloadModel : EditableUserContentModelBase {
        [ResourceDisplayName(DownloadConstants.Fields.UseDownloadUrl.Label)]
        public bool UseDownloadUrl { get; set; }

        [ResourceDisplayName(DownloadConstants.Fields.ContentType.Label)]
        public string ContentType { get; set; }

        [ResourceDisplayName(DownloadConstants.Fields.FileName.Label)]
        [ResourceStringLength(DownloadConstants.Fields.FileName.Length)]
        public string FileName { get; set; }

        [ResourceDisplayName(DownloadConstants.Fields.Extension.Label)]
        [ResourceStringLength(DownloadConstants.Fields.Extension.Length)]
        public string Extension { get; set; }

        [ResourceDisplayName(DownloadConstants.Fields.DownloadBinary.Label)]
        public HttpPostedFileBase DownloadBinary { get; set; }

        [ResourceDisplayName(DownloadConstants.Fields.DownloadUrl.Label)]
        [ResourceStringLength(DownloadConstants.Fields.DownloadUrl.Length)]
        [ResourceUrl]
        public string DownloadUrl { get; set; }
    }
}