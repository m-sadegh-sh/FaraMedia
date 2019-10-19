using System;
using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.Blogs
{
    public class BlogCommentModel : BaseFaraEntityModel
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerAvatarUrl { get; set; }

        public string CommentText { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool AllowViewingProfiles { get; set; }
    }
}