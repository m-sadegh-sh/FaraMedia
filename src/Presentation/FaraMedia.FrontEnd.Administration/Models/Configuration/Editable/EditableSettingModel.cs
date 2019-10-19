namespace FaraMedia.FrontEnd.Administration.Models.Configuration.Editable {
    using FaraMedia.Data.Schemas.Configuration;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Editable;

    public class EditableSettingModel : EditableEntityModelBase {
        [ResourceDisplayName(SettingConstants.Fields.Key.Label)]
        [ResourceRequired]
        [ResourceStringLength(SettingConstants.Fields.Key.Length)]
        public string Key { get; set; }

        [ResourceDisplayName(SettingConstants.Fields.Value.Label)]
        public string Value { get; set; }
    }
}