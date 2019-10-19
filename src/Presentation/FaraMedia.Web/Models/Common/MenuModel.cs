using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.Common
{
    public class MenuModel : BaseFaraModel
    {
        public bool BlogEnabled { get; set; }
        public bool RecentlyAddedProductsEnabled { get; set; }
        public bool ForumEnabled { get; set; }
    }
}