namespace FaraMedia.FrontEnd.Administration.Models.Configuration {
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.Configuration;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Configuration;

    public class EditableEmailAccountSettingsModel : EditableSettingsModelBase {
        [ResourceDisplayName(EmailAccountSettingsConstants.Fields.DefaultEmailAccountId.Label)]
        [ResourceMin(1)]
        public long DefaultEmailAccountId { get; set; }
        public SelectList AvailableEmailAccounts { get; set; }
    }
}