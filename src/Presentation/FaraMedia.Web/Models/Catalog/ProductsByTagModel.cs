using System.Collections.Generic;
using System.Web.Mvc;
using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.Catalog
{
    public class ProductsByTagModel : BaseFaraEntityModel
    {
        public ProductsByTagModel()
        {
            Products = new List<ProductModel>();
            PagingFilteringContext = new CatalogPagingFilteringModel();
            AvailableSortOptions = new List<SelectListItem>();
            AvailableViewModes = new List<SelectListItem>();
            PageSizeOptions = new List<SelectListItem>();
        }

        public string TagName { get; set; }

        public CatalogPagingFilteringModel PagingFilteringContext { get; set; }
        public bool AllowProductFiltering { get; set; }
        public IList<SelectListItem> AvailableSortOptions { get; set; }
        public bool AllowProductViewModeChanging { get; set; }
        public IList<SelectListItem> AvailableViewModes { get; set; }
        
        public bool AllowCustomersToSelectPageSize { get; set; }
        public IList<SelectListItem> PageSizeOptions { get; set; }

        public IList<ProductModel> Products { get; set; }
    }
}