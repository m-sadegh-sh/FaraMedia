namespace FaraMedia.FrontEnd.Administration.Models.Common {
    using FaraMedia.Core.Globalization;

    public class LikeModel : UserContentModelBase {
        public long OwnerId { get; set; }

        public MultiFormatDateTime LikeDate { get; set; }

        public long UserId { get; set; }
        public string UserFullName { get; set; }
    }
}