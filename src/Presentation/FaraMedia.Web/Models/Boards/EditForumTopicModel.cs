﻿using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Fara.Core.Domain.Forums;
using Fara.Web.Validators.Boards;

namespace Fara.Web.Models.Boards
{
    [Validator(typeof(EditForumTopicValidator))]
    public class EditForumTopicModel
    {
        public EditForumTopicModel()
        {
            TopicPriorities = new List<SelectListItem>();
        }

        public bool IsEdit { get; set; }

        public int Id { get; set; }

        public int ForumId { get; set; }
        public string ForumName { get; set; }
        public string ForumSeName { get; set; }

        public int TopicTypeId { get; set; }
        public EditorType ForumEditor { get; set; }
        [AllowHtml]
        public string Subject { get; set; }
        [AllowHtml]
        public string Text { get; set; }
        
        public string PostError { get; set; }

        public bool IsCustomerAllowedToSetTopicPriority { get; set; }
        public IEnumerable<SelectListItem> TopicPriorities { get; set; }

        public bool IsCustomerAllowedToSubscribe { get; set; }
        public bool Subscribed { get; set; }

    }
}