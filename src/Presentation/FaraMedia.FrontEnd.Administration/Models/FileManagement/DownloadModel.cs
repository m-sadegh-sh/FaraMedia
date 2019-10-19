namespace FaraMedia.FrontEnd.Administration.Models.FileManagement {
    using FaraMedia.FrontEnd.Administration.Models.Common;

    public class DownloadModel : UserContentModelBase {
        public string UseDownloadUrl { get; set; }

        public string ContentType { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }

        public string DownloadUrlTargetUrl { get; set; }
    }
}