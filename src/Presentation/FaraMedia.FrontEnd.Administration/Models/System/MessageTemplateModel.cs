namespace FaraMedia.FrontEnd.Administration.Models.Systematic {
    using FaraMedia.Web.Framework.Mvc.Models;

    public class MessageTemplateModel : EntityModelBase {
        public string Name { get; set; }
        public string BccEmailAddresses { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public long EmailAccountId { get; set; }
        public string EmailAccountDisplayName { get; set; }
    }
}