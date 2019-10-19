namespace FaraMedia.FrontEnd.Administration.Models.Configuration {
    using FaraMedia.Data.Schemas.Configuration;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Configuration;

    public class EditableCommonSettingsModel : EditableSettingsModelBase {
        [ResourceDisplayName(CommonSettingsConstants.Fields.EnableHttpCompression.Label)]
        public bool EnableHttpCompression { get; set; }
    }
}