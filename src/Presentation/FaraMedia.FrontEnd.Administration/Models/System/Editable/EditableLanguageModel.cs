namespace FaraMedia.FrontEnd.Administration.Models.Systematic.Editable {
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.Systematic;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Editable;

    public class EditableLanguageModel : EditableEntityModelBase {
        [ResourceDisplayName(LanguageConstants.Fields.IsRightToLeft.Label)]
        public bool IsRightToLeft { get; set; }
        
        [ResourceDisplayName(LanguageConstants.Fields.Name.Label)]
        [ResourceRequired]
        [ResourceStringLength(LanguageConstants.Fields.Name.Length)]
        public string Name { get; set; }

        [ResourceDisplayName(LanguageConstants.Fields.IsoCode.Label)]
        [ResourceRequired]
        [ResourceStringLength(LanguageConstants.Fields.IsoCode.Length)]
        public string IsoCode { get; set; }
    }
}