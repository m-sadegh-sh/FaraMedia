using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Web.Mvc;
using System.Xml;
using Fara.Core;
using Fara.Core.Domain;
using Fara.Core.Domain.Customers;
using Fara.Core.Domain.Localization;
using Fara.Core.Domain.Media;
using Fara.Core.Domain.News;
using Fara.Services.Customers;
using Fara.Services.Helpers;
using Fara.Services.Localization;
using Fara.Services.Media;
using Fara.Services.Messages;
using Fara.Services.News;
using Fara.Services.Seo;
using Fara.Web.Framework;
using Fara.Web.Framework.Controllers;
using Fara.Web.Models.News;

namespace Fara.Web.Controllers
{
    public class NewsController : BaseFaraController
    {
		

        private readonly INewsService _newsService;
        private readonly IWorkContext _workContext;
        private readonly IPictureService _pictureService;
        private readonly ILocalizationService _localizationService;
        private readonly ICustomerContentService _customerContentService;
        private readonly IDateTimeHelper _dateTimeHelper;
        private readonly IWorkflowMessageService _workflowMessageService;
        private readonly IWebHelper _webHelper;

        private readonly MediaSettings _mediaSettings;
        private readonly NewsSettings _newsSettings;
        private readonly LocalizationSettings _localizationSettings;
        private readonly CustomerSettings _customerSettings;
        private readonly StoreInformationSettings _storeInformationSettings;
        
        

		

        public NewsController(INewsService newsService, 
            IWorkContext workContext, IPictureService pictureService, ILocalizationService localizationService,
            ICustomerContentService customerContentService, IDateTimeHelper dateTimeHelper,
            IWorkflowMessageService workflowMessageService, IWebHelper webHelper,
            MediaSettings mediaSettings, NewsSettings newsSettings,
            LocalizationSettings localizationSettings, CustomerSettings customerSettings,
            StoreInformationSettings storeInformationSettings)
        {
            this._newsService = newsService;
            this._workContext = workContext;
            this._pictureService = pictureService;
            this._localizationService = localizationService;
            this._customerContentService = customerContentService;
            this._dateTimeHelper = dateTimeHelper;
            this._workflowMessageService = workflowMessageService;
            this._webHelper = webHelper;

            this._mediaSettings = mediaSettings;
            this._newsSettings = newsSettings;
            this._localizationSettings = localizationSettings;
            this._customerSettings = customerSettings;
            this._storeInformationSettings = storeInformationSettings;
        }

        

        

        [NonAction]
        private void PrepareNewsItemModel(NewsItemModel model, NewsItem newsItem, bool prepareComments)
        {
            if (newsItem == null)
                throw new ArgumentNullException("newsItem");

            if (model == null)
                throw new ArgumentNullException("model");

            model.Id = newsItem.Id;
            model.SeName = newsItem.GetSeName();
            model.Title = newsItem.Title;
            model.Short = newsItem.Short;
            model.Full = newsItem.Full;
            model.AllowComments = newsItem.AllowComments;
            model.CreatedOn = _dateTimeHelper.ConvertToUserTime(newsItem.CreatedOnUtc, DateTimeKind.Utc);
            model.NumberOfComments = newsItem.NewsComments.Count;
            if (prepareComments)
            {
                var newsComments = newsItem.NewsComments.Where(pr => pr.IsApproved).OrderBy(pr => pr.CreatedOnUtc);
                foreach (var nc in newsComments)
                {
                    var commentModel = new NewsCommentModel()
                    {
                        Id = nc.Id,
                        CustomerId = nc.CustomerId,
                        CustomerName = nc.Customer.FormatUserName(),
                        CommentTitle = nc.CommentTitle,
                        CommentText = nc.CommentText,
                        CreatedOn = _dateTimeHelper.ConvertToUserTime(nc.CreatedOnUtc, DateTimeKind.Utc),
                        AllowViewingProfiles = _customerSettings.AllowViewingProfiles && nc.Customer != null && !nc.Customer.IsGuest(),
                    };
                    if (_customerSettings.AllowCustomersToUploadAvatars)
                    {
                        var customer = nc.Customer;
                        string avatarUrl = _pictureService.GetPictureUrl(customer.GetAttribute<int>(SystemCustomerAttributeNames.AvatarPictureId), _mediaSettings.AvatarPictureSize, false);
                        if (string.IsNullOrEmpty(avatarUrl) && _customerSettings.DefaultAvatarEnabled)
                            avatarUrl = _pictureService.GetDefaultPictureUrl(_mediaSettings.AvatarPictureSize, PictureType.Avatar);
                        commentModel.CustomerAvatarUrl = avatarUrl;
                    }
                    model.Comments.Add(commentModel);
                }
            }
        }
        
        

        

        public ActionResult HomePageNews()
        {
            if (!_newsSettings.Enabled || !_newsSettings.ShowNewsOnMainPage)
                return Content(string.Empty);

            var model = new NewsItemListModel();
            model.WorkingLanguageId = _workContext.WorkingLanguage.Id;

            var newsItems = _newsService.GetAllNews(_workContext.WorkingLanguage.Id,
                    null, null, 0, _newsSettings.MainPageNewsCount);

            model.NewsItems = newsItems
                .Select(x =>
                {
                    var newsModel = new NewsItemModel();
                    PrepareNewsItemModel(newsModel, x, false);
                    return newsModel;
                })
                .ToList();

            return PartialView(model);
        }

        public ActionResult List(NewsPagingFilteringModel command)
        {
            if (!_newsSettings.Enabled)
                return RedirectToAction("Index", "Home");

            var model = new NewsItemListModel();
            model.WorkingLanguageId = _workContext.WorkingLanguage.Id;

            if (command.PageSize <= 0) command.PageSize = _newsSettings.NewsArchivePageSize;
            if (command.PageNumber <= 0) command.PageNumber = 1;

            var newsItems = _newsService.GetAllNews(_workContext.WorkingLanguage.Id,
                    null, null, command.PageNumber - 1, command.PageSize);
            model.PagingFilteringContext.LoadPagedList(newsItems);

            model.NewsItems = newsItems
                .Select(x =>
                {
                    var newsModel = new NewsItemModel();
                    PrepareNewsItemModel(newsModel, x, false);
                    return newsModel;
                })
                .ToList();

            return View(model);
        }

        public ActionResult ListRss(int languageId)
        {
            var feed = new SyndicationFeed(
                                    string.Format("{0}: News", _storeInformationSettings.StoreName),
                                    "News",
                                    new Uri(_webHelper.GetStoreLocation(false)),
                                    "NewsRSS",
                                    DateTime.UtcNow);

            if (!_newsSettings.Enabled)
                return new RssActionResult() { Feed = feed };

            var items = new List<SyndicationItem>();
            var newsItems = _newsService.GetAllNews(languageId,
                null, null, 0, int.MaxValue);
            foreach (var n in newsItems)
            {
                string newsUrl = Url.RouteUrl("NewsItem", new { newsItemId = n.Id, SeName = n.GetSeName() }, "http");
                items.Add(new SyndicationItem(n.Title, n.Short, new Uri(newsUrl), string.Format("Blog:{0}", n.Id), n.CreatedOnUtc));
            }
            feed.Items = items;
            return new RssActionResult() { Feed = feed };
        }

        public ActionResult NewsItem(int newsItemId)
        {
            if (!_newsSettings.Enabled)
                return RedirectToAction("Index", "Home");

            var newsItem = _newsService.GetNewsById(newsItemId);
            if (newsItem == null || !newsItem.Published)
                return RedirectToAction("Index", "Home");

            var model = new NewsItemModel();
            PrepareNewsItemModel(model, newsItem, true);

            return View(model);
        }

        [HttpPost, ActionName("NewsItem")]
        [FormValueRequired("add-comment")]
        public ActionResult NewsCommentAdd(int newsItemId, NewsItemModel model)
        {
            if (!_newsSettings.Enabled)
                return RedirectToAction("Index", "Home");

            var newsItem = _newsService.GetNewsById(newsItemId);
            if (newsItem == null || !newsItem.Published || !newsItem.AllowComments)
                return RedirectToAction("Index", "Home");

            if (ModelState.IsValid)
            {
                if (_workContext.CurrentCustomer.IsGuest() && !_newsSettings.AllowNotRegisteredUsersToLeaveComments)
                {
                    ModelState.AddModelError(string.Empty, _localizationService.GetResource("News.Comments.OnlyRegisteredUsersLeaveComments"));
                }
                else
                {
                    var comment = new NewsComment()
                    {
                        NewsItemId = newsItem.Id,
                        CustomerId = _workContext.CurrentCustomer.Id,
                        IpAddress = _webHelper.GetCurrentIpAddress(),
                        CommentTitle = model.AddNewComment.CommentTitle,
                        CommentText = model.AddNewComment.CommentText,
                        IsApproved = true,
                        CreatedOnUtc = DateTime.UtcNow,
                        UpdatedOnUtc = DateTime.UtcNow,
                    };
                    _customerContentService.InsertCustomerContent(comment);

                    
                    if (_newsSettings.NotifyAboutNewNewsComments)
                        _workflowMessageService.SendNewsCommentNotificationMessage(comment, _localizationSettings.DefaultAdminLanguageId);
                    
                    
                    
                    TempData["fara.news.addcomment.result"] = _localizationService.GetResource("News.Comments.SuccessfullyAdded");
                    return RedirectToRoute("NewsItem", new { newsItemId = newsItem.Id, SeName = newsItem.GetSeName() });
                }
            }

            
            PrepareNewsItemModel(model, newsItem, true);
            return View(model);
        }

        [ChildActionOnly]
        public ActionResult RssHeaderLink()
        {
            if (!_newsSettings.Enabled || !_newsSettings.ShowHeaderRssUrl)
                return Content(string.Empty);

            string link = string.Format("<link href=\"{0}\" rel=\"alternate\" type=\"application/rss+xml\" title=\"{1}: News\" />",
                Url.RouteUrl("NewsRSS", new { languageId = _workContext.WorkingLanguage.Id }, "http"), _storeInformationSettings.StoreName);

            return Content(link);
        }

        
    }
}
