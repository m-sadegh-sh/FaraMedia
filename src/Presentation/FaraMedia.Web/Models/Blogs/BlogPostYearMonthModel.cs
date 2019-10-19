using System.Collections.Generic;
using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.Blogs
{
    public class BlogPostYearModel : BaseFaraModel
    {
        public BlogPostYearModel()
        {
            Months = new List<BlogPostMonthModel>();
        }
        public int Year { get; set; }
        public IList<BlogPostMonthModel> Months { get; set; }
    }
    public class BlogPostMonthModel : BaseFaraModel
    {
        public int Month { get; set; }

        public int BlogPostCount { get; set; }
    }
}