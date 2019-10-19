using System.Web.Mvc;
using Fara.Web.Framework;
using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.Blogs
{
    public class AddBlogCommentModel : BaseFaraEntityModel
    {
        [FaraResourceDisplayName("Blog.Comments.CommentText")]
        [AllowHtml]
        public string CommentText { get; set; }
    }
}