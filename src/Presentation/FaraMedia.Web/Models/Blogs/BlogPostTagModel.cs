using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.Blogs
{
    public class BlogPostTagModel : BaseFaraModel
    {
        public string Name { get; set; }

        public int BlogPostCount { get; set; }
    }
}