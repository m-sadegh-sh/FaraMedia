namespace FaraMedia.FrontEnd.Administration.Models.Systematic {
    using FaraMedia.Web.Framework.Mvc.Models;

    public class EmailAccountModel : EntityModelBase {
        public string SslEnabled { get; set; }
        public string UseDefaultCredentials { get; set; }

        public int Port { get; set; }

        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Host { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public int MessageTemplatesCount { get; set; }
        public int QueuedEmailsCount { get; set; }
    }
}