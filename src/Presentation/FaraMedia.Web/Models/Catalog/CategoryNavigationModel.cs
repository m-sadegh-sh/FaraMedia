using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.Catalog
{
    public class CategoryNavigationModel : BaseFaraEntityModel
    {
        public string Name { get; set; }

        public string SeName { get; set; }

        public int NumberOfParentCategories { get; set; }

        public bool DisplayNumberOfProducts { get; set; }
        public int NumberOfProducts { get; set; }

        public bool IsActive { get; set; }
    }
}