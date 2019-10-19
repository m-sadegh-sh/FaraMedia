namespace FaraMedia.FrontEnd.Administration.Models.Common {
    using FaraMedia.Web.Framework.Mvc.Models;

    public class FaviconModel : ModelBase {
        public bool Uploaded { get; set; }

        public string FaviconUrl { get; set; }
    }
}