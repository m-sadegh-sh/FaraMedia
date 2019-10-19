namespace FaraMedia.FrontEnd.Administration.Models.Systematic {
    using FaraMedia.Web.Framework.Mvc.Models;

    public class LanguageModel : EntityModelBase {
        public string IsRightToLeft { get; set; }

        public string Name { get; set; }
        public string IsoCode { get; set; }

        public int StringResourcesCount { get; set; }
    }
}