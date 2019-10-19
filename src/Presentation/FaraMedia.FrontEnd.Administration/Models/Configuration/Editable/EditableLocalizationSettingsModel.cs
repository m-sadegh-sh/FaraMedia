namespace FaraMedia.FrontEnd.Administration.Models.Configuration {
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.Configuration;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Configuration;

    public class EditableLocalizationSettingsModel : EditableSettingsModelBase {
        [ResourceDisplayName(LocalizationSettingsConstants.Fields.LoadAllLocaleRecordsOnStartup.Label)]
        public bool LoadAllLocaleRecordsOnStartup { get; set; }

        [ResourceDisplayName(LocalizationSettingsConstants.Fields.DefaultAdminAreaLanguageId.Label)]
        [ResourceMin(1)]
        public long DefaultAdminAreaLanguageId { get; set; }
        public SelectList AvailableLanguages { get; set; }
    }
}