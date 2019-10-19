using System.Collections.Generic;
using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.News
{
    public class NewsItemListModel : BaseFaraModel
    {
        public NewsItemListModel()
        {
            PagingFilteringContext = new NewsPagingFilteringModel();
            NewsItems = new List<NewsItemModel>();
        }

        public int WorkingLanguageId { get; set; }
        public NewsPagingFilteringModel PagingFilteringContext { get; set; }
        public IList<NewsItemModel> NewsItems { get; set; }
    }
}