namespace FaraMedia.FrontEnd.Administration.Models.Security {
    using FaraMedia.Core.Globalization;
    using FaraMedia.Web.Framework.Mvc.Models;

    public class FriendRequestModel : EntityModelBase {
        public string IsAccepted { get; set; }

        public MultiFormatDateTime BeignFriendOn { get; set; }

        public string Message { get; set; }

        public long FromId { get; set; }
        public string FromFullName { get; set; }

        public long ToId { get; set; }
        public string ToFullName { get; set; }
    }
}