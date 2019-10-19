using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.Customer
{
    public class ForumSubscriptionModel : BaseFaraEntityModel
    {
        public int ForumId { get; set; }
        public int ForumTopicId { get; set; }
        public bool TopicSubscription { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
    }
}
