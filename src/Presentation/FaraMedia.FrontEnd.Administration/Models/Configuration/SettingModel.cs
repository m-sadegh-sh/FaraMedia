namespace FaraMedia.FrontEnd.Administration.Models.Configuration {
    using FaraMedia.Web.Framework.Mvc.Models;

    public class SettingModel : EntityModelBase {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}