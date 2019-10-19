using System.Collections.Generic;
using System.Web.Mvc;
using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.Boards
{
    public class TopicMoveModel : BaseFaraEntityModel
    {
        public TopicMoveModel()
        {
            ForumList = new List<SelectListItem>();
        }

        public int ForumSelected { get; set; }
        public string TopicSeName { get; set; }

        public IEnumerable<SelectListItem> ForumList { get; set; }
    }
}