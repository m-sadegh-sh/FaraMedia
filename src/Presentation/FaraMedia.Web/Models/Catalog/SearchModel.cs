using System.Collections.Generic;
using System.Web.Mvc;
using Fara.Web.Framework;
using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.Catalog
{
    public class SearchModel : BaseFaraModel
    {
        public SearchModel()
        {
            PagingFilteringContext = new SearchPagingFilteringModel();
            Products = new List<ProductModel>();

            this.AvailableCategories = new List<SelectListItem>();
            this.AvailablePublishers = new List<SelectListItem>();
        }

        public string Warning { get; set; }

        public bool NoResults { get; set; }

        
        
        
        [FaraResourceDisplayName("Search.SearchTerm")]
        [AllowHtml]
        public string Q { get; set; }
        
        
        
        [FaraResourceDisplayName("Search.Category")]
        public int Cid { get; set; }
        
        
        
        [FaraResourceDisplayName("Search.Publisher")]
        public int Mid { get; set; }
        
        
        
        [AllowHtml]
        public string Pf { get; set; }
        
        
        
        [AllowHtml]
        public string Pt { get; set; }
        
        
        
        [FaraResourceDisplayName("Search.SearchInDescriptions")]
        public bool Sid { get; set; }
        
        
        
        [FaraResourceDisplayName("Search.AdvancedSearch")]
        public bool As { get; set; }
        public IList<SelectListItem> AvailableCategories { get; set; }
        public IList<SelectListItem> AvailablePublishers { get; set; }


        public SearchPagingFilteringModel PagingFilteringContext { get; set; }
        public IList<ProductModel> Products { get; set; }
    }
}