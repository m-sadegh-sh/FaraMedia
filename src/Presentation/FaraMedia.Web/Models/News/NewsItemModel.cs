﻿using System;
using System.Collections.Generic;
using FluentValidation.Attributes;
using Fara.Web.Framework.Mvc;
using Fara.Web.Validators.News;

namespace Fara.Web.Models.News
{
    [Validator(typeof(NewsItemValidator))]
    public class NewsItemModel : BaseFaraEntityModel
    {
        public NewsItemModel()
        {
            Tags = new List<string>();
            Comments = new List<NewsCommentModel>();
            AddNewComment = new AddNewsCommentModel();
        }

        public string SeName { get; set; }

        public string Title { get; set; }

        public string Short { get; set; }

        public string Full { get; set; }

        public bool AllowComments { get; set; }

        public int NumberOfComments { get; set; }

        public DateTime CreatedOn { get; set; }

        public IList<string> Tags { get; set; }

        public IList<NewsCommentModel> Comments { get; set; }
        public AddNewsCommentModel AddNewComment { get; set; }
    }
}