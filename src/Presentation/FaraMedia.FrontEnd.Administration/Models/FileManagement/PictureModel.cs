namespace FaraMedia.FrontEnd.Administration.Models.FileManagement {
    using FaraMedia.FrontEnd.Administration.Models.Common;

    public class PictureModel : UserContentModelBase {
        public string MimeType { get; set; }
        public string FileName { get; set; }
    }
}