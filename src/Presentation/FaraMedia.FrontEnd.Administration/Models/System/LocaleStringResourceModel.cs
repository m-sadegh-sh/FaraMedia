namespace FaraMedia.FrontEnd.Administration.Models.Systematic {
    using FaraMedia.Web.Framework.Mvc.Models;

    public class StringResourceModel : EntityModelBase {
        public string Key { get; set; }
        public string Value { get; set; }

        public long LanguageId { get; set; }
        public string LanguageName { get; set; }
    }
}