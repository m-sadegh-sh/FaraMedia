﻿using System.Collections.Generic;
using Fara.Web.Models.Common;

namespace Fara.Web.Models.Customer
{
    public class CustomerForumSubscriptionsModel
    {
        public CustomerForumSubscriptionsModel()
        {
            this.ForumSubscriptions = new List<ForumSubscriptionModel>();
        }

        public IList<ForumSubscriptionModel> ForumSubscriptions { get; set; }
        public CustomerNavigationModel NavigationModel { get; set; }
        public PagerModel PagerModel { get; set; }
    }
}