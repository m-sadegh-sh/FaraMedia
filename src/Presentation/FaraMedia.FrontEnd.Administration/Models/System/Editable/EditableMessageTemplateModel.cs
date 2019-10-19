namespace FaraMedia.FrontEnd.Administration.Models.Systematic.Editable {
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.Systematic;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Editable;

    public class EditableMessageTemplateModel : EditableEntityModelBase {
        [ResourceDisplayName(MessageTemplateConstants.Fields.Name.Label)]
        [ResourceRequired]
        [ResourceStringLength(MessageTemplateConstants.Fields.Name.Length)]
        public string Name { get; set; }

        [ResourceDisplayName(MessageTemplateConstants.Fields.BccEmailAddresses.Label)]
        public string BccEmailAddresses { get; set; }

        [ResourceDisplayName(MessageTemplateConstants.Fields.Subject.Label)]
        [ResourceRequired]
        [ResourceStringLength(MessageTemplateConstants.Fields.Subject.Length)]
        public string Subject { get; set; }

        [ResourceDisplayName(MessageTemplateConstants.Fields.Body.Label)]
        public string Body { get; set; }

        [ResourceDisplayName(MessageTemplateConstants.Fields.EmailAccount.Label)]
        [ResourceMin(1)]
        public long EmailAccountId { get; set; }

        public SelectList AvailableEmailAccounts { get; set; }
    }
}