namespace FaraMedia.FrontEnd.Administration.Models.Systematic {
    using FaraMedia.Core.Globalization;
    using FaraMedia.Web.Framework.Mvc.Models;

    public class QueuedEmailModel : EntityModelBase {
        public int SentTries { get; set; }

        public string QueuedEmailPriority { get; set; }

        public MultiFormatDateTime SentDate { get; set; }

        public string From { get; set; }
        public string FromName { get; set; }
        public string To { get; set; }
        public string ToName { get; set; }
        public string Cc { get; set; }
        public string Bcc { get; set; }
        public string Subject { get; set; }

        public long EmailAccountId { get; set; }
        public string EmailAccountDisplayName { get; set; }
    }
}