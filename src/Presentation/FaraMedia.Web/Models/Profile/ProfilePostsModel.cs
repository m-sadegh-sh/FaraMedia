using System.Collections.Generic;
using Fara.Web.Models.Common;

namespace Fara.Web.Models.Profile
{
    public class ProfilePostsModel
    {
        public IList<PostsModel> Posts { get; set; }
        public PagerModel PagerModel { get; set; }
    }
}