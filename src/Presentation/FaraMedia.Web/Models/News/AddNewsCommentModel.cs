using System.Web.Mvc;
using Fara.Web.Framework;
using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.News
{
    public class AddNewsCommentModel : BaseFaraEntityModel
    {
        [FaraResourceDisplayName("News.Comments.CommentTitle")]
        [AllowHtml]
        public string CommentTitle { get; set; }

        [FaraResourceDisplayName("News.Comments.CommentText")]
        [AllowHtml]
        public string CommentText { get; set; }
    }
}