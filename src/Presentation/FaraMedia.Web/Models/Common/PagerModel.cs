using Fara.Core.Infrastructure;
using Fara.Services.Localization;

namespace Fara.Web.Models.Common
{
    public class PagerModel
    {
        

        public PagerModel()
            : this(EngineContext.Current.Resolve<ILocalizationService>())
        {

        }

        public PagerModel(ILocalizationService localizationService)
        {
            this._localizationService = localizationService;
        }

        

        

        private ILocalizationService _localizationService;
        private int individualPagesDisplayedCount;
        private int pageIndex = -2;
        private int pageSize;

        private bool? showFirst;
        private bool? showIndividualPages;
        private bool? showLast;
        private bool? showNext;
        private bool? showPagerItems;
        private bool? showPrevious;
        private bool? showTotalSummary;

        private int totalRecords;
        private string firstButtonText;
        private string lastButtonText;
        private string nextButtonText;
        private string previousButtonText;
        private string currentPageText;

        

        

        
        
        
        public int CurrentPage
        {
            get
            {
                return (this.PageIndex + 1);
            }
        }

        
        
        
        public int IndividualPagesDisplayedCount
        {
            get
            {
                if (individualPagesDisplayedCount <= 0)
                    return 5;
                else
                    return individualPagesDisplayedCount;
            }
            set
            {
                individualPagesDisplayedCount = value;
            }
        }

        
        
        
        public int PageIndex
        {
            get
            {
                if (this.pageIndex < 0)
                {
                    return 0;
                }
                return this.pageIndex;
            }
            set
            {
                this.pageIndex = value;
            }
        }

        
        
        
        public int PageSize
        {
            get
            {
                return (pageSize <= 0) ? 10 : pageSize;
            }
            set
            {
                pageSize = value;
            }
        }

        
        
        
        public bool ShowFirst
        {
            get
            {
                return showFirst ?? true;
            }
            set
            {
                showFirst = value;
            }
        }

        
        
        
        public bool ShowIndividualPages
        {
            get
            {
                return showIndividualPages ?? true;
            }
            set
            {
                showIndividualPages = value;
            }
        }

        
        
        
        public bool ShowLast
        {
            get
            {
                return showLast ?? true;
            }
            set
            {
                showLast = value;
            }
        }

        
        
        
        public bool ShowNext
        {
            get
            {
                return showNext ?? true;
            }
            set
            {
                showNext = value;
            }
        }

        
        
        
        public bool ShowPagerItems
        {
            get
            {
                return showPagerItems ?? true;
            }
            set
            {
                showPagerItems = value;
            }
        }

        
        
        
        public bool ShowPrevious
        {
            get
            {
                return showPrevious ?? true;
            }
            set
            {
                showPrevious = value;
            }
        }

        
        
        
        public bool ShowTotalSummary
        {
            get
            {
                return showTotalSummary ?? false;
            }
            set
            {
                showTotalSummary = value;
            }
        }

        
        
        
        public int TotalPages
        {
            get
            {
                if ((this.TotalRecords == 0) || (this.PageSize == 0))
                {
                    return 0;
                }
                int num = this.TotalRecords / this.PageSize;
                if ((this.TotalRecords % this.PageSize) > 0)
                {
                    num++;
                }
                return num;
            }
        }

        
        
        
        public int TotalRecords
        {
            get
            {
                return totalRecords;
            }
            set
            {
                totalRecords = value;
            }
        }

        
        
        
        public string FirstButtonText
        {
            get
            {
                return (!string.IsNullOrEmpty(firstButtonText)) ?
                    firstButtonText :
                    _localizationService.GetResource("Pager.First");
            }
            set
            {
                firstButtonText = value;
            }
        }

        
        
        
        public string LastButtonText
        {
            get
            {
                return (!string.IsNullOrEmpty(lastButtonText)) ?
                    lastButtonText :
                    _localizationService.GetResource("Pager.Last");
            }
            set
            {
                lastButtonText = value;
            }
        }

        
        
        
        public string NextButtonText
        {
            get
            {
                return (!string.IsNullOrEmpty(nextButtonText)) ?
                    nextButtonText :
                    _localizationService.GetResource("Pager.Next");
            }
            set
            {
                nextButtonText = value;
            }
        }

        
        
        
        public string PreviousButtonText
        {
            get
            {
                return (!string.IsNullOrEmpty(previousButtonText)) ?
                    previousButtonText :
                    _localizationService.GetResource("Pager.Previous");
            }
            set
            {
                previousButtonText = value;
            }
        }

        
        
        
        public string CurrentPageText
        {
            get
            {
                return (!string.IsNullOrEmpty(currentPageText)) ?
                    currentPageText :
                    _localizationService.GetResource("Pager.CurrentPage");
            }
            set
            {
                currentPageText = value;
            }
        }

        
        
        
        public string RouteActionName { get; set; }

        
        
        
        
        public bool UseRouteLinks { get; set; }

        
        
        
        public IRouteValues RouteValues { get; set; }

        

        

        
        
        
        
        public int GetFirstIndividualPageIndex()
        {
            if ((this.TotalPages < this.IndividualPagesDisplayedCount) ||
                ((this.PageIndex - (this.IndividualPagesDisplayedCount / 2)) < 0))
            {
                return 0;
            }
            if ((this.PageIndex + (this.IndividualPagesDisplayedCount / 2)) >= this.TotalPages)
            {
                return (this.TotalPages - this.IndividualPagesDisplayedCount);
            }
            return (this.PageIndex - (this.IndividualPagesDisplayedCount / 2));
        }

        
        
        
        
        public int GetLastIndividualPageIndex()
        {
            int num = this.IndividualPagesDisplayedCount / 2;
            if ((this.IndividualPagesDisplayedCount % 2) == 0)
            {
                num--;
            }
            if ((this.TotalPages < this.IndividualPagesDisplayedCount) ||
                ((this.PageIndex + num) >= this.TotalPages))
            {
                return (this.TotalPages - 1);
            }
            if ((this.PageIndex - (this.IndividualPagesDisplayedCount / 2)) < 0)
            {
                return (this.IndividualPagesDisplayedCount - 1);
            }
            return (this.PageIndex + num);
        }

        
    }

    

    
    
    
    public interface IRouteValues
    {
        int page { get; set; }
    }

    
    
    
    
    public class RouteValues : IRouteValues
    {
        public int id { get; set; }
        public string slug { get; set; }
        public int page { get; set; }
    }

    
    
    
    public class ForumSearchRouteValues : IRouteValues
    {
        public string searchterms { get; set; }
        public string adv { get; set; }
        public string forumId { get; set; }
        public string within { get; set; }
        public string limitDays { get; set; }
        public int page { get; set; }
    }

    
    
    
    public class PrivateMessageRouteValues : IRouteValues
    {
        public string tab { get; set; }
        public int page { get; set; }
    }

    
    
    
    public class ForumSubscriptionsRouteValues : IRouteValues
    {        
        public int page { get; set; }
    }

    
    
    
    public class BackInStockSubscriptionsRouteValues : IRouteValues
    {
        public int page { get; set; }
    }

    
}