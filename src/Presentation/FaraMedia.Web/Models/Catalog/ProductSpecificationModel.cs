using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.Catalog
{
    public class ProductSpecificationModel : BaseFaraModel
    {
        public int SpecificationAttributeId { get; set; }

        public string SpecificationAttributeName { get; set; }

        public string SpecificationAttributeOption { get; set; }
    }
}