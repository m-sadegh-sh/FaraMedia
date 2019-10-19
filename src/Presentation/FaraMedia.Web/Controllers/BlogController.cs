using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Web.Mvc;
using System.Xml;
using Fara.Core;
using Fara.Core.Domain;
using Fara.Core.Domain.Blogs;
using Fara.Core.Domain.Customers;
using Fara.Core.Domain.Localization;
using Fara.Core.Domain.Media;
using Fara.Services.Blogs;
using Fara.Services.Customers;
using Fara.Services.Helpers;
using Fara.Services.Localization;
using Fara.Services.Media;
using Fara.Services.Messages;
using Fara.Services.Seo;
using Fara.Web.Framework;
using Fara.Web.Framework.Controllers;
using Fara.Web.Models.Blogs;

namespace Fara.Web.Controllers
{
    public class BlogController : BaseFaraController
    {
		

        private readonly IBlogService _blogService;
        private readonly IWorkContext _workContext;
        private readonly IPictureService _pictureService;
        private readonly ILocalizationService _localizationService;
        private readonly ICustomerContentService _customerContentService;
        private readonly IDateTimeHelper _dateTimeHelper;
        private readonly IWorkflowMessageService _workflowMessageService;
        private readonly IWebHelper _webHelper;

        private readonly MediaSettings _mediaSettings;
        private readonly BlogSettings _blogSettings;
        private readonly LocalizationSettings _localizationSettings;
        private readonly CustomerSettings _customerSettings;
        private readonly StoreInformationSettings _storeInformationSettings;
        
        

		

        public BlogController(IBlogService blogService, 
            IWorkContext workContext, IPictureService pictureService, ILocalizationService localizationService,
            ICustomerContentService customerContentService, IDateTimeHelper dateTimeHelper,
            IWorkflowMessageService workflowMessageService, IWebHelper webHelper,
            MediaSettings mediaSettings, BlogSettings blogSettings,
            LocalizationSettings localizationSettings, CustomerSettings customerSettings,
            StoreInformationSettings storeInformationSettings)
        {
            this._blogService = blogService;
            this._workContext = workContext;
            this._pictureService = pictureService;
            this._localizationService = localizationService;
            this._customerContentService = customerContentService;
            this._dateTimeHelper = dateTimeHelper;
            this._workflowMessageService = workflowMessageService;
            this._webHelper = webHelper;

            this._mediaSettings = mediaSettings;
            this._blogSettings = blogSettings;
            this._localizationSettings = localizationSettings;
            this._customerSettings = customerSettings;
            this._storeInformationSettings = storeInformationSettings;
        }

		

        

        [NonAction]
        private void PrepareBlogPostModel(BlogPostModel model, BlogPost blogPost, bool prepareComments)
        {
            if (blogPost == null)
                throw new ArgumentNullException("blogPost");

            if (model == null)
                throw new ArgumentNullException("model");

            model.Id = blogPost.Id;
            model.SeName = blogPost.GetSeName();
            model.Title = blogPost.Title;
            model.Body = blogPost.Body;
            model.AllowComments = blogPost.AllowComments;
            model.CreatedOn = _dateTimeHelper.ConvertToUserTime(blogPost.CreatedOnUtc, DateTimeKind.Utc);
            model.Tags = blogPost.ParseTags().ToList();
            model.NumberOfComments = blogPost.BlogComments.Count;
            if (prepareComments)
            {
                var blogComments = blogPost.BlogComments.Where(pr => pr.IsApproved).OrderBy(pr => pr.CreatedOnUtc);
                foreach (var bc in blogComments)
                {
                    var commentModel = new BlogCommentModel()
                    {
                        Id = bc.Id,
                        CustomerId = bc.CustomerId,
                        CustomerName = bc.Customer.FormatUserName(),
                        CommentText = bc.CommentText,
                        CreatedOn = _dateTimeHelper.ConvertToUserTime(bc.CreatedOnUtc, DateTimeKind.Utc),
                        AllowViewingProfiles = _customerSettings.AllowViewingProfiles && bc.Customer != null && !bc.Customer.IsGuest(),
                    };
                    if (_customerSettings.AllowCustomersToUploadAvatars)
                    {
                        var customer = bc.Customer;
                        string avatarUrl = _pictureService.GetPictureUrl(customer.GetAttribute<int>(SystemCustomerAttributeNames.AvatarPictureId), _mediaSettings.AvatarPictureSize, false);
                        if (string.IsNullOrEmpty(avatarUrl) && _customerSettings.DefaultAvatarEnabled)
                            avatarUrl = _pictureService.GetDefaultPictureUrl(_mediaSettings.AvatarPictureSize, PictureType.Avatar);
                        commentModel.CustomerAvatarUrl = avatarUrl;
                    }
                    model.Comments.Add(commentModel);
                }
            }
        }
        
        

        

        public ActionResult List(BlogPagingFilteringModel command)
        {
            if (!_blogSettings.Enabled)
                return RedirectToAction("Index", "Home");

            var model = new BlogPostListModel();
            model.PagingFilteringContext.Tag = command.Tag;
            model.PagingFilteringContext.Month = command.Month;
            model.WorkingLanguageId = _workContext.WorkingLanguage.Id;

            if (command.PageSize <= 0) command.PageSize = _blogSettings.PostsPageSize;
            if (command.PageNumber <= 0) command.PageNumber = 1;

            DateTime? dateFrom = command.GetFromMonth();
            DateTime? dateTo = command.GetToMonth();

            IList<BlogPost> blogPosts;
            if (string.IsNullOrEmpty(command.Tag))
            {
                blogPosts = _blogService.GetAllBlogPosts(_workContext.WorkingLanguage.Id,
                    dateFrom, dateTo, command.PageNumber - 1, command.PageSize);
                model.PagingFilteringContext.LoadPagedList(blogPosts as IPagedList<BlogPost>);
            }
            else
            {
                blogPosts = _blogService.GetAllBlogPostsByTag(_workContext.WorkingLanguage.Id, command.Tag);
            }

            model.BlogPosts = blogPosts
                .Select(x =>
                {
                    var blogPostModel = new BlogPostModel();
                    PrepareBlogPostModel(blogPostModel, x, false);
                    return blogPostModel;
                })
                .ToList();

            return View(model);
        }

        public ActionResult ListRss(int languageId)
        {
            var feed = new SyndicationFeed(
                                    string.Format("{0}: Blog", _storeInformationSettings.StoreName),
                                    "Blog",
                                    new Uri(_webHelper.GetStoreLocation(false)),
                                    "BlogRSS",
                                    DateTime.UtcNow);

            if (!_blogSettings.Enabled)
                return new RssActionResult() { Feed = feed };

            var items = new List<SyndicationItem>();
            var blogPosts = _blogService.GetAllBlogPosts(languageId,
                null, null, 0, int.MaxValue);
            foreach (var blogPost in blogPosts)
            {
                string blogPostUrl = Url.RouteUrl("BlogPost", new { blogPostId = blogPost.Id, SeName = blogPost.GetSeName() }, "http");
                items.Add(new SyndicationItem(blogPost.Title, blogPost.Body, new Uri(blogPostUrl), string.Format("Blog:{0}", blogPost.Id), blogPost.CreatedOnUtc));
            }
            feed.Items = items;
            return new RssActionResult() { Feed = feed };
        }

        public ActionResult BlogPost(int blogPostId)
        {
            if (!_blogSettings.Enabled)
                return RedirectToAction("Index", "Home");

            var blogPost = _blogService.GetBlogPostById(blogPostId);
            if (blogPost == null)
                return RedirectToAction("Index", "Home");

            var model = new BlogPostModel();
            PrepareBlogPostModel(model, blogPost, true);

            return View(model);
        }

        [HttpPost, ActionName("BlogPost")]
        [FormValueRequired("add-comment")]
        public ActionResult BlogCommentAdd(int blogPostId, BlogPostModel model)
        {
            if (!_blogSettings.Enabled)
                return RedirectToAction("Index", "Home");

            var blogPost = _blogService.GetBlogPostById(blogPostId);
            if (blogPost == null || !blogPost.AllowComments)
                return RedirectToAction("Index", "Home");

            if (ModelState.IsValid)
            {
                if (_workContext.CurrentCustomer.IsGuest() && !_blogSettings.AllowNotRegisteredUsersToLeaveComments)
                {
                    ModelState.AddModelError(string.Empty, _localizationService.GetResource("Blog.Comments.OnlyRegisteredUsersLeaveComments"));
                }
                else
                {
                    var comment = new BlogPostComment()
                    {
                        BlogPostId = blogPost.Id,
                        CustomerId = _workContext.CurrentCustomer.Id,
                        IpAddress = _webHelper.GetCurrentIpAddress(),
                        CommentText = model.AddNewComment.CommentText,
                        IsApproved = true,
                        CreatedOnUtc = DateTime.UtcNow,
                        UpdatedOnUtc = DateTime.UtcNow,
                    };
                    _customerContentService.InsertCustomerContent(comment);

                    
                    if (_blogSettings.NotifyAboutNewBlogComments)
                        _workflowMessageService.SendBlogCommentNotificationMessage(comment, _localizationSettings.DefaultAdminLanguageId);

                    
                    
                    TempData["fara.blog.addcomment.result"] = _localizationService.GetResource("Blog.Comments.SuccessfullyAdded");
                    return RedirectToRoute("BlogPost", new { blogPostId = blogPost.Id, SeName = blogPost.GetSeName() });
                }
            }

            
            PrepareBlogPostModel(model, blogPost, true);
            return View(model);
        }

        [ChildActionOnly]
        
        public ActionResult BlogTags()
        {
            if (!_blogSettings.Enabled)
                return Content(string.Empty);

            var model = new BlogPostTagListModel();

            
            var tags = _blogService.GetAllBlogPostTags(_workContext.WorkingLanguage.Id)
                .OrderByDescending(x => x.BlogPostCount)
                .Take(_blogSettings.NumberOfTags)
                .ToList();
            
            tags = tags.OrderBy(x => x.Name).ToList();

            foreach (var tag in tags)
                model.Tags.Add(new BlogPostTagModel()
                    {
                        Name = tag.Name,
                        BlogPostCount = tag.BlogPostCount
                    });

            return PartialView(model);
        }

        [ChildActionOnly]
        
        public ActionResult BlogMonths()
        {
            if (!_blogSettings.Enabled)
                return Content(string.Empty);

            var model = new List<BlogPostYearModel>();

            var blogPosts = _blogService.GetAllBlogPosts(_workContext.WorkingLanguage.Id, null, null, 0, int.MaxValue);
            if (blogPosts.Count > 0)
            {
                var months = new SortedDictionary<DateTime, int>();

                var first = blogPosts[blogPosts.Count - 1].CreatedOnUtc;
                while (DateTime.SpecifyKind(first, DateTimeKind.Utc) <= DateTime.UtcNow.AddMonths(1))
                {
                    var list = blogPosts.GetPostsByDate(new DateTime(first.Year, first.Month, 1), new DateTime(first.Year, first.Month, 1).AddMonths(1).AddSeconds(-1));
                    if (list.Count > 0)
                    {
                        var date = new DateTime(first.Year, first.Month, 1);
                        months.Add(date, list.Count);
                    }

                    first = first.AddMonths(1);
                }


                int current = 0;
                foreach (var kvp in months)
                {
                    var date = kvp.Key;
                    var blogPostCount = kvp.Value;
                    if (current == 0)
                        current = date.Year;

                    if (date.Year > current || model.Count == 0)
                    {
                        var yearModel = new BlogPostYearModel()
                        {
                            Year = date.Year
                        };
                        model.Add(yearModel);
                    }

                    model.Last().Months.Add(new BlogPostMonthModel()
                        {
                            Month = date.Month,
                            BlogPostCount = blogPostCount
                        });

                    current = date.Year;
                }
            }
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult RssHeaderLink()
        {
            if (!_blogSettings.Enabled || !_blogSettings.ShowHeaderRssUrl)
                return Content(string.Empty);

            string link = string.Format("<link href=\"{0}\" rel=\"alternate\" type=\"application/rss+xml\" title=\"{1}: Blog\" />",
                Url.RouteUrl("BlogRSS", new { languageId = _workContext.WorkingLanguage.Id }, "http"), _storeInformationSettings.StoreName);

            return Content(link);
        }
        
    }
}
