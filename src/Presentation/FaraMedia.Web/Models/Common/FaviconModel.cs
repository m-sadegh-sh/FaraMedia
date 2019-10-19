using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.Common
{
    public class FaviconModel : BaseFaraModel
    {
        public bool Uploaded { get; set; }
        public string FaviconUrl { get; set; }
    }
}