using System.Collections.Generic;

namespace Fara.Web.Models.Boards
{
    public class BoardsIndexModel
    {
        public BoardsIndexModel()
        {
            this.ForumGroups = new List<ForumGroupModel>();
        }
        
        public IList<ForumGroupModel> ForumGroups { get; set; }
    }
}