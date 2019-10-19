namespace FaraMedia.FrontEnd.Administration.Models.Security {
    using FaraMedia.Core.Globalization;
    using FaraMedia.Web.Framework.Mvc.Models;

    public sealed class UserModel : EntityModelBase {
        public string IsSystemAccount { get; set; }
        public string IsBuyingBlocked { get; set; }

        public string PasswordFormat { get; set; }

        public MultiFormatDateTime LastLoginDate { get; set; }
        public MultiFormatDateTime LastActivityDate { get; set; }

        public string SystemName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string AdminComment { get; set; }
        public string LastIpAddress { get; set; }

        public int RolesCount { get; set; }
        public int ActivitiesCount { get; set; }
        public int LogsCount { get; set; }
        public int ToDosCount { get; set; }
        public int TicketsCount { get; set; }
        public int TicketResponsesCount { get; set; }
        public int IncomingFriendRequestsCount { get; set; }
        public int OutgoingFriendRequestsCount { get; set; }
        public int BlogsCount { get; set; }
        public int OrdersCount { get; set; }
    }
}