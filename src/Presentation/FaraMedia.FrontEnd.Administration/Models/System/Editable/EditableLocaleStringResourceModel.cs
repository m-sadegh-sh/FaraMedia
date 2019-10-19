namespace FaraMedia.FrontEnd.Administration.Models.Systematic.Editable {
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.Systematic;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Editable;

    public class EditableStringResourceModel : EditableEntityModelBase {
        [ResourceDisplayName(StringResourceConstants.Fields.Key.Label)]
        [ResourceRequired]
        [ResourceStringLength(StringResourceConstants.Fields.Key.Length)]
        public string Key { get; set; }

        [ResourceDisplayName(StringResourceConstants.Fields.Value.Label)]
        public string Value { get; set; }

        //Code-assigned
        [ResourceDisplayName(StringResourceConstants.Fields.Language.Label)]
        public long LanguageId { get; set; }
        public string LanguageName { get; set; }
    }
}