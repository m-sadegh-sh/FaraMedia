using System;
using System.Collections.Generic;
using FluentValidation.Attributes;
using Fara.Web.Framework.Mvc;
using Fara.Web.Validators.Blogs;

namespace Fara.Web.Models.Blogs
{
    [Validator(typeof(BlogPostValidator))]
    public class BlogPostModel : BaseFaraEntityModel
    {
        public BlogPostModel()
        {
            Tags = new List<string>();
            Comments = new List<BlogCommentModel>();
            AddNewComment = new AddBlogCommentModel();
        }

        public string SeName { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public bool AllowComments { get; set; }

        public int NumberOfComments { get; set; }

        public DateTime CreatedOn { get; set; }

        public IList<string> Tags { get; set; }

        public IList<BlogCommentModel> Comments { get; set; }
        public AddBlogCommentModel AddNewComment { get; set; }
    }
}