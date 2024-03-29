﻿using System.Web.Mvc;
using FluentValidation.Attributes;
using Fara.Core.Domain.Forums;
using Fara.Web.Validators.Boards;

namespace Fara.Web.Models.Boards
{
    [Validator(typeof(EditForumPostValidator))]
    public class EditForumPostModel
    {
        public int Id { get; set; }
        public int ForumTopicId { get; set; }

        public bool IsEdit { get; set; }

        [AllowHtml]
        public string Text { get; set; }
        public EditorType ForumEditor { get; set; }

        public string ForumName { get; set; }
        public string ForumTopicSubject { get; set; }
        public string ForumTopicSeName { get; set; }

        public bool IsCustomerAllowedToSubscribe { get; set; }
        public bool Subscribed { get; set; }

        public string PostError { get; set; }
    }
}