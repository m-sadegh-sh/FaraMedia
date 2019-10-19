using System.Collections.Generic;
using Fara.Web.Framework.Mvc;
using Fara.Web.Models.Catalog;
using Fara.Web.Models.Topics;

namespace Fara.Web.Models.Common
{
    public class SitemapModel : BaseFaraModel
    {
        public SitemapModel()
        {
            Products = new List<ProductModel>();
            Categories = new List<CategoryModel>();
            Publishers = new List<PublisherModel>();
            Topics = new List<TopicModel>();
        }
        public IList<ProductModel> Products { get; set; }
        public IList<CategoryModel> Categories { get; set; }
        public IList<PublisherModel> Publishers { get; set; }
        public IList<TopicModel> Topics { get; set; }
    }
}