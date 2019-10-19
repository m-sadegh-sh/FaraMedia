namespace FaraMedia.FrontEnd.Administration.Models.Configuration {
    using FaraMedia.Data.Schemas.Configuration;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Configuration;

    public class EditableMessageTemplateSettingsModel : EditableSettingsModelBase {
        [ResourceDisplayName(MessageTemplateSettingsConstants.Fields.CaseInvariantReplacement.Label)]
        public bool CaseInvariantReplacement { get; set; }

        [ResourceDisplayName(MessageTemplateSettingsConstants.Fields.Color1.Label)]
        [ResourceStringLength(MessageTemplateSettingsConstants.Fields.Color1.Length)]
        public string Color1 { get; set; }

        [ResourceDisplayName(MessageTemplateSettingsConstants.Fields.Color2.Label)]
        [ResourceStringLength(MessageTemplateSettingsConstants.Fields.Color2.Length)]
        public string Color2 { get; set; }

        [ResourceDisplayName(MessageTemplateSettingsConstants.Fields.Color3.Label)]
        [ResourceStringLength(MessageTemplateSettingsConstants.Fields.Color3.Length)]
        public string Color3 { get; set; }
    }
}