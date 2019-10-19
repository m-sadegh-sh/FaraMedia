using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.Catalog
{
    public class PublisherNavigationModel : BaseFaraEntityModel
    {
        public string Name { get; set; }

        public string SeName { get; set; }
        
        public bool IsActive { get; set; }
    }
}