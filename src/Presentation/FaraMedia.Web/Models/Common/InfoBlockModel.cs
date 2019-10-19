using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.Common
{
    public class InfoBlockModel : BaseFaraModel
    {
        public bool RecentlyAddedProductsEnabled { get; set; }
        public bool RecentlyViewedProductsEnabled { get; set; }
        public bool CompareProductsEnabled { get; set; }
        public bool BlogEnabled { get; set; }
        public bool SitemapEnabled { get; set; }
        public bool ForumEnabled { get; set; }
    }
}