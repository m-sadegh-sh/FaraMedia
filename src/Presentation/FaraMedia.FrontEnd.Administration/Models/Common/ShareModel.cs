namespace FaraMedia.FrontEnd.Administration.Models.Common {
    using FaraMedia.Core.Globalization;

    public class ShareModel : UserContentModelBase {
        public long OwnerId { get; set; }

        public MultiFormatDateTime ShareDate { get; set; }

        public long UserId { get; set; }
        public string UserFullName { get; set; }
    }
}