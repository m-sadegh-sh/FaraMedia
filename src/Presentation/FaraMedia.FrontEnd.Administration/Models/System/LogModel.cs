namespace FaraMedia.FrontEnd.Administration.Models.Systematic {
    using FaraMedia.Web.Framework.Mvc.Models;

    public class LogModel : EntityModelBase {
        public string LogLevel { get; set; }

        public string ShortMessage { get; set; }
        public string FullMessage { get; set; }
        public string IpAddress { get; set; }
        public string RequestedUrl { get; set; }
        public string ReferrerUrl { get; set; }

        public long UserId { get; set; }
        public string UserFullName { get; set; }
    }
}