using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.Catalog
{
    public class ProductTagModel : BaseFaraEntityModel
    {
        public string Name { get; set; }

        public int ProductCount { get; set; }
    }
}