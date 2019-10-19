using System.Collections.Generic;
using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.Catalog
{
    public class HomePageProductsModel : BaseFaraModel
    {
        public HomePageProductsModel()
        {
            Products = new List<ProductModel>();
        }

        public bool UseSmallProductBox { get; set; }

        public IList<ProductModel> Products { get; set; }
    }
}