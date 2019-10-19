namespace FaraMedia.FrontEnd.Administration.Models.Common {
    using FaraMedia.Web.Framework.Mvc.Models;

    public abstract class UserContentModelBase : EntityModelBase {
        public string IpAddress { get; set; }

        public long UserId { get; set; }
        public string UserFullName { get; set; }
    }
}