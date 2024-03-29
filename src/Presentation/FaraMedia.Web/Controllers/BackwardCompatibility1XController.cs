﻿using System;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Fara.Services.Blogs;
using Fara.Services.Catalog;
using Fara.Services.Customers;
using Fara.Services.Forums;
using Fara.Services.News;
using Fara.Services.Seo;
using Fara.Services.Topics;

namespace Fara.Web.Controllers
{
    public class BackwardCompatibility1XController : BaseFaraController
    {
		

        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IPublisherService _publisherService;
        private readonly IProductTagService _productTagService;
        private readonly INewsService _newsService;
        private readonly IBlogService _blogService;
        private readonly ITopicService _topicService;
        private readonly IForumService _forumService;
        private readonly ICustomerService _customerService;
        

		

        public BackwardCompatibility1XController(IProductService productService,
            ICategoryService categoryService, IPublisherService publisherService,
            IProductTagService productTagService, INewsService newsService,
            IBlogService blogService, ITopicService topicService,
            IForumService forumService, ICustomerService customerService)
        {
            this._productService = productService;
            this._categoryService = categoryService;
            this._publisherService = publisherService;
            this._productTagService = productTagService;
            this._newsService = newsService;
            this._blogService = blogService;
            this._topicService = topicService;
            this._forumService = forumService;
            this._customerService = customerService;
        }

		
        
        

        public ActionResult GeneralRedirect()
        {
            
            
            
            var regex = new Regex(@"(?<=/).+(?=\.aspx)", RegexOptions.Compiled);
            var aspxfileName = regex.Match(Request.RawUrl).Value.ToLowerInvariant();


            switch (aspxfileName)
            {
                
                case "product":
                    {
                        return RedirectProduct(Request.QueryString["productid"], false);
                    }
                case "category":
                    {
                        return RedirectCategory(Request.QueryString["categoryid"], false);
                    }
                case "publisher":
                    {
                        return RedirectPublisher(Request.QueryString["publisherid"], false);
                    }
                case "producttag":
                    {
                        return RedirectProductTag(Request.QueryString["tagid"], false);
                    }
                case "news":
                    {
                        return RedirectNewsItem(Request.QueryString["newsid"], false);
                    }
                case "blog":
                    {
                        return RedirectBlogPost(Request.QueryString["blogpostid"], false);
                    }
                case "topic":
                    {
                        return RedirectTopic(Request.QueryString["topicid"], false);
                    }
                case "profile":
                    {
                        return RedirectUserProfile(Request.QueryString["UserId"]);
                    }
                case "compareproducts":
                    {
                        return RedirectToRoutePermanent("CompareProducts");
                    }
                case "contactus":
                    {
                        return RedirectToRoutePermanent("ContactUs");
                    }
                case "passwordrecovery":
                    {
                        return RedirectToRoutePermanent("PasswordRecovery");
                    }
                case "login":
                    {
                        return RedirectToRoutePermanent("Login");
                    }
                case "register":
                    {
                        return RedirectToRoutePermanent("Register");
                    }
                case "newsarchive":
                    {
                        return RedirectToRoutePermanent("NewsArchive");
                    }
                case "search":
                    {
                        return RedirectToRoutePermanent("ProductSearch");
                    }
                case "sitemap":
                    {
                        return RedirectToRoutePermanent("Sitemap");
                    }
                case "sitemapseo":
                    {
                        return RedirectToRoutePermanent("SitemapSEO");
                    }
                case "recentlyaddedproducts":
                    {
                        return RedirectToRoutePermanent("RecentlyAddedProducts");
                    }
                case "shoppingcart":
                    {
                        return RedirectToRoutePermanent("ShoppingCart");
                    }
                case "wishlist":
                    {
                        return RedirectToRoutePermanent("Wishlist");
                    }
                default:
                    break;
            }

            
            return RedirectToAction("Index", "Home");
        }

        public ActionResult RedirectProduct(string id, bool idIncludesSename = true)
        {
            
            var productId = idIncludesSename ? Convert.ToInt32(id.Split(new char[] { '-' })[0]) : Convert.ToInt32(id);
            var product = _productService.GetProductById(productId);
            if (product == null)
                return RedirectToActionPermanent("Index", "Home");

            return RedirectToRoutePermanent("Product", new { productId = product.Id, SeName = product.GetSeName() });
        }

        public ActionResult RedirectCategory(string id, bool idIncludesSename = true)
        {
            
            var categoryid = idIncludesSename ? Convert.ToInt32(id.Split(new char[] { '-' })[0]) : Convert.ToInt32(id);
            var category = _categoryService.GetCategoryById(categoryid);
            if (category == null)
                return RedirectToActionPermanent("Index", "Home");

            return RedirectToRoutePermanent("Category", new { categoryId = category.Id, SeName = category.GetSeName() });
        }

        public ActionResult RedirectPublisher(string id, bool idIncludesSename = true)
        {
            
            var publisherId = idIncludesSename ? Convert.ToInt32(id.Split(new char[] { '-' })[0]) : Convert.ToInt32(id);
            var publisher = _publisherService.GetPublisherById(publisherId);
            if (publisher == null)
                return RedirectToActionPermanent("Index", "Home");

            return RedirectToRoutePermanent("Publisher", new { publisherId = publisher.Id, SeName = publisher.GetSeName() });
        }

        public ActionResult RedirectProductTag(string id, bool idIncludesSename = true)
        {
            
            var tagId = idIncludesSename ? Convert.ToInt32(id.Split(new char[] { '-' })[0]) : Convert.ToInt32(id);
            var tag = _productTagService.GetProductById(tagId);
            if (tag == null)
                return RedirectToActionPermanent("Index", "Home");

            return RedirectToRoutePermanent("ProductsByTag", new { productTagId = tag.Id });
        }

        public ActionResult RedirectNewsItem(string id, bool idIncludesSename = true)
        {
            
            var newsId = idIncludesSename ? Convert.ToInt32(id.Split(new char[] { '-' })[0]) : Convert.ToInt32(id);
            var newsItem = _newsService.GetNewsById(newsId);
            if (newsItem == null)
                return RedirectToActionPermanent("Index", "Home");

            return RedirectToRoutePermanent("NewsItem", new { newsItemId = newsItem.Id, SeName = newsItem.GetSeName() });
        }

        public ActionResult RedirectBlogPost(string id, bool idIncludesSename = true)
        {
            
            var blogPostId = idIncludesSename ? Convert.ToInt32(id.Split(new char[] { '-' })[0]) : Convert.ToInt32(id);
            var blogPost = _blogService.GetBlogPostById(blogPostId);
            if (blogPost == null)
                return RedirectToActionPermanent("Index", "Home");

            return RedirectToRoutePermanent("BlogPost", new { blogPostId = blogPost.Id, SeName = blogPost.GetSeName() });
        }

        public ActionResult RedirectTopic(string id, bool idIncludesSename = true)
        {
            
            var topicid = idIncludesSename ? Convert.ToInt32(id.Split(new char[] { '-' })[0]) : Convert.ToInt32(id);
            var topic = _topicService.GetTopicById(topicid);
            if (topic == null)
                return RedirectToActionPermanent("Index", "Home");

            return RedirectToRoutePermanent("Topic", new { systemName = topic.SystemName });
        }

        public ActionResult RedirectForumGroup(string id, bool idIncludesSename = true)
        {
            
            var forumGroupId = idIncludesSename ? Convert.ToInt32(id.Split(new char[] { '-' })[0]) : Convert.ToInt32(id);
            var forumGroup = _forumService.GetForumGroupById(forumGroupId);
            if (forumGroup == null)
                return RedirectToActionPermanent("Index", "Home");

            return RedirectToRoutePermanent("ForumGroupSlug", new { id = forumGroup.Id, slug = forumGroup.GetSeName() });
        }

        public ActionResult RedirectForum(string id, bool idIncludesSename = true)
        {
            
            var forumId = idIncludesSename ? Convert.ToInt32(id.Split(new char[] { '-' })[0]) : Convert.ToInt32(id);
            var forum = _forumService.GetForumById(forumId);
            if (forum == null)
                return RedirectToActionPermanent("Index", "Home");

            return RedirectToRoutePermanent("ForumSlug", new { id = forum.Id, slug = forum.GetSeName() });
        }

        public ActionResult RedirectForumTopic(string id, bool idIncludesSename = true)
        {
            
            var forumTopicId = idIncludesSename ? Convert.ToInt32(id.Split(new char[] { '-' })[0]) : Convert.ToInt32(id);
            var topic = _forumService.GetTopicById(forumTopicId);
            if (topic == null)
                return RedirectToActionPermanent("Index", "Home");

            return RedirectToRoutePermanent("TopicSlug", new { id = topic.Id, slug = topic.GetSeName() });
        }

        public ActionResult RedirectUserProfile(string id)
        {
            
            var userId = Convert.ToInt32(id);
            var user = _customerService.GetCustomerById(userId);
            if (user == null)
                return RedirectToActionPermanent("Index", "Home");

            return RedirectToRoutePermanent("CustomerProfile", new { id = user.Id});
        }
        
        
    }
}
