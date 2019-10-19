using System.Collections.Generic;
using Fara.Web.Models.Common;

namespace Fara.Web.Models.PrivateMessages
{
    public class PrivateMessageListModel
    {
        public IList<PrivateMessageModel> Messages { get; set; }
        public PagerModel PagerModel { get; set; }
    }
}