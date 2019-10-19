using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fara.Core;
using Fara.Core.Domain;
using Fara.Core.Domain.Blogs;
using Fara.Core.Domain.Catalog;
using Fara.Core.Domain.Common;
using Fara.Core.Domain.Customers;
using Fara.Core.Domain.Forums;
using Fara.Core.Domain.Localization;
using Fara.Core.Domain.Messages;
using Fara.Core.Domain.Orders;
using Fara.Core.Domain.Tax;
using Fara.Services.Catalog;
using Fara.Services.Common;
using Fara.Services.Customers;
using Fara.Services.Directory;
using Fara.Services.Forums;
using Fara.Services.Localization;
using Fara.Services.Messages;
using Fara.Services.Orders;
using Fara.Services.Security;
using Fara.Services.Seo;
using Fara.Services.Topics;
using Fara.Web.Extensions;
using Fara.Web.Framework.Localization;
using Fara.Web.Framework.Themes;
using Fara.Web.Models.Common;

namespace Fara.Web.Controllers
{
    public class CommonController : BaseFaraController
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IPublisherService _publisherService;
        private readonly ITopicService _topicService;
        private readonly ILanguageService _languageService;
        private readonly ICurrencyService _currencyService;
        private readonly ILocalizationService _localizationService;
        private readonly IWorkContext _workContext;
        private readonly IQueuedEmailService _queuedEmailService;
        private readonly IEmailAccountService _emailAccountService;
        private readonly ISitemapGenerator _sitemapGenerator;
        private readonly IThemeContext _themeContext;
        private readonly IThemeProvider _themeProvider;
        private readonly IForumService _forumservice;
        private readonly ICustomerService _customerService;
        private readonly IWebHelper _webHelper;
        private readonly IPermissionService _permissionService;
        private readonly IMobileDeviceHelper _mobileDeviceHelper;
        private readonly HttpContextBase _httpContext;

        private readonly CustomerSettings _customerSettings;
        private readonly TaxSettings _taxSettings;
        private readonly CatalogSettings _catalogSettings;
        private readonly StoreInformationSettings _storeInformationSettings;
        private readonly EmailAccountSettings _emailAccountSettings;
        private readonly CommonSettings _commonSettings;
        private readonly BlogSettings _blogSettings;
        private readonly ForumSettings _forumSettings;
        private readonly LocalizationSettings _localizationSettings;

        public CommonController(ICategoryService categoryService, IProductService productService,
            IPublisherService publisherService, ITopicService topicService,
            ILanguageService languageService,
            ICurrencyService currencyService, ILocalizationService localizationService,
            IWorkContext workContext,
            IQueuedEmailService queuedEmailService, IEmailAccountService emailAccountService,
            ISitemapGenerator sitemapGenerator, IThemeContext themeContext,
            IThemeProvider themeProvider, IForumService forumService,
            ICustomerService customerService, IWebHelper webHelper,
            IPermissionService permissionService, IMobileDeviceHelper mobileDeviceHelper,
            HttpContextBase httpContext, CustomerSettings customerSettings, 
            TaxSettings taxSettings, CatalogSettings catalogSettings,
            StoreInformationSettings storeInformationSettings, EmailAccountSettings emailAccountSettings,
            CommonSettings commonSettings, BlogSettings blogSettings, ForumSettings forumSettings,
            LocalizationSettings localizationSettings)
        {
            this._categoryService = categoryService;
            this._productService = productService;
            this._publisherService = publisherService;
            this._topicService = topicService;
            this._languageService = languageService;
            this._currencyService = currencyService;
            this._localizationService = localizationService;
            this._workContext = workContext;
            this._queuedEmailService = queuedEmailService;
            this._emailAccountService = emailAccountService;
            this._sitemapGenerator = sitemapGenerator;
            this._themeContext = themeContext;
            this._themeProvider = themeProvider;
            this._forumservice = forumService;
            this._customerService = customerService;
            this._webHelper = webHelper;
            this._permissionService = permissionService;
            this._mobileDeviceHelper = mobileDeviceHelper;
            this._httpContext = httpContext;

            this._customerSettings = customerSettings;
            this._taxSettings = taxSettings;
            this._catalogSettings = catalogSettings;
            this._storeInformationSettings = storeInformationSettings;
            this._emailAccountSettings = emailAccountSettings;
            this._commonSettings = commonSettings;
            this._blogSettings = blogSettings;
            this._forumSettings = forumSettings;
            this._localizationSettings = localizationSettings;
        }

        
        [ChildActionOnly]
        public ActionResult LanguageSelector()
        {
            var model = new LanguageSelectorModel()
            {
                CurrentLanguage = _workContext.WorkingLanguage.ToModel(),
                AvailableLanguages = _languageService.GetAllLanguages().Select(x => x.ToModel()).ToList(),
                UseImages = _localizationSettings.UseImagesForLanguageSelection
            };
            return PartialView(model);
        }

        public ActionResult SetLanguage(int langid)
        {
            var language = _languageService.GetLanguageById(langid);
            if (language != null && language.Published)
            {
                _workContext.WorkingLanguage = language;
            }


            if (_localizationSettings.SeoFriendlyUrlsForLanguagesEnabled)
            {
                string applicationPath = HttpContext.Request.ApplicationPath;
                if (HttpContext.Request.UrlReferrer != null)
                {
                    string redirectUrl = HttpContext.Request.UrlReferrer.PathAndQuery;
                    if (redirectUrl.IsLocalizedUrl(applicationPath, true))
                    {
                        
                        redirectUrl = redirectUrl.RemoveLocalizedPathFromRawUrl(applicationPath);
                    }
                    redirectUrl = redirectUrl.AddLocalizedPathToRawUrl(applicationPath, _workContext.WorkingLanguage);
                    return Redirect(redirectUrl);
                }
                else
                {
                    string redirectUrl = Url.Action("Index", "Home");
                    redirectUrl = redirectUrl.AddLocalizedPathToRawUrl(applicationPath, _workContext.WorkingLanguage);
                    return Redirect(redirectUrl);
                }
            }
            else
            {
                
                if (HttpContext.Request.UrlReferrer != null)
                {
                    return Redirect(HttpContext.Request.UrlReferrer.PathAndQuery);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        
        [ChildActionOnly]
        public ActionResult CurrencySelector()
        {
            var model = new CurrencySelectorModel();
            model.CurrentCurrency = _workContext.WorkingCurrency.ToModel();
            model.AvailableCurrencies = _currencyService.GetAllCurrencies().Select(x => x.ToModel()).ToList();
            return PartialView(model);
        }

        public ActionResult CurrencySelected(int customerCurrency)
        {
            var currency = _currencyService.GetCurrencyById(customerCurrency);
            if (currency != null)
            {
                _workContext.WorkingCurrency = currency;
            }
            var model = new CurrencySelectorModel();
            model.CurrentCurrency = _workContext.WorkingCurrency.ToModel();
            model.AvailableCurrencies = _currencyService.GetAllCurrencies().Select(x => x.ToModel()).ToList();
            return PartialView("CurrencySelector", model);
        }

        
        [ChildActionOnly]
        public ActionResult TaxTypeSelector()
        {
            var model = new TaxTypeSelectorModel();
            model.Enabled = _taxSettings.AllowCustomersToSelectTaxDisplayType;
            model.CurrentTaxType = _workContext.TaxDisplayType;
            return PartialView(model);
        }

        public ActionResult TaxTypeSelected(int customerTaxType)
        {
            var taxDisplayType = (TaxDisplayType)Enum.ToObject(typeof(TaxDisplayType), customerTaxType);
            _workContext.TaxDisplayType = taxDisplayType;

            var model = new TaxTypeSelectorModel();
            model.Enabled = _taxSettings.AllowCustomersToSelectTaxDisplayType;
            model.CurrentTaxType = _workContext.TaxDisplayType;
            return PartialView("TaxTypeSelector", model);
        }

        
        [ChildActionOnly]
        public ActionResult HeaderLinks()
        {
            var customer = _workContext.CurrentCustomer;

            var unreadMessageCount = GetUnreadPrivateMessages();
            var unreadMessage = string.Empty;
            var alertMessage = string.Empty;
            if (unreadMessageCount > 0)
            {
                unreadMessage = string.Format(_localizationService.GetResource("PrivateMessages.TotalUnread"), unreadMessageCount);

                
                if (_forumSettings.ShowAlertForPM && 
                    !customer.GetAttribute<bool>(SystemCustomerAttributeNames.NotifiedAboutNewPrivateMessages))
                {
                    _customerService.SaveCustomerAttribute<bool>(customer, SystemCustomerAttributeNames.NotifiedAboutNewPrivateMessages, true);
                    alertMessage = string.Format(_localizationService.GetResource("PrivateMessages.YouHaveUnreadPM"), unreadMessageCount);
                }
            }

            var model = new HeaderLinksModel()
            {
                IsAuthenticated = customer.IsRegistered(),
                CustomerEmailUsername = customer.IsRegistered() ? (_customerSettings.UsernamesEnabled ? customer.Username : customer.Email) : string.Empty,
                IsCustomerImpersonated = _workContext.OriginalCustomerIfImpersonated != null,
                DisplayAdminLink = _permissionService.Authorize(StandardPermissionProvider.AccessAdminPanel),
                ShoppingCartEnabled = _permissionService.Authorize(StandardPermissionProvider.EnableShoppingCart),
                ShoppingCartItems = customer.ShoppingCartItems.Where(sci => sci.ShoppingCartType == ShoppingCartType.ShoppingCart).ToList().GetTotalProducts(),
                WishlistEnabled = _permissionService.Authorize(StandardPermissionProvider.EnableWishlist),
                WishlistItems = customer.ShoppingCartItems.Where(sci => sci.ShoppingCartType == ShoppingCartType.Wishlist).ToList().GetTotalProducts(),
                AllowPrivateMessages = _forumSettings.AllowPrivateMessages,
                UnreadPrivateMessages = unreadMessage,
                AlertMessage = alertMessage,
            };

            return PartialView(model);
        }

        [NonAction]
        private int GetUnreadPrivateMessages()
        {
            var result = 0;
            var customer = _workContext.CurrentCustomer;
            if (_forumSettings.AllowPrivateMessages && !customer.IsGuest())
            {
                var privateMessages = _forumservice.GetAllPrivateMessages(0, customer.Id, false, null, false, string.Empty, 0, 1);

                if (privateMessages.TotalCount > 0)
                {
                    result = privateMessages.TotalCount;
                }
            }

            return result;
        }

        
        [ChildActionOnly]
        public ActionResult Footer()
        {
            var model = new FooterModel()
            {
                StoreName = _storeInformationSettings.StoreName
            };

            return PartialView(model);
        }

        
        [ChildActionOnly]
        public ActionResult Menu()
        {
            var model = new MenuModel()
            {
                RecentlyAddedProductsEnabled = _catalogSettings.RecentlyAddedProductsEnabled,
                BlogEnabled = _blogSettings.Enabled,
                ForumEnabled = _forumSettings.ForumsEnabled
            };

            return PartialView(model);
        }

        
        [ChildActionOnly]
        public ActionResult InfoBlock()
        {
            var model = new InfoBlockModel()
            {
                RecentlyAddedProductsEnabled = _catalogSettings.RecentlyAddedProductsEnabled,
                RecentlyViewedProductsEnabled = _catalogSettings.RecentlyViewedProductsEnabled,
                CompareProductsEnabled = _catalogSettings.CompareProductsEnabled,
                BlogEnabled = _blogSettings.Enabled,
                SitemapEnabled = _commonSettings.SitemapEnabled,
                ForumEnabled = _forumSettings.ForumsEnabled
            };

            return PartialView(model);
        }

        
        public ActionResult ContactUs()
        {
            var model = new ContactUsModel()
            {
                Email = _workContext.CurrentCustomer.Email,
                FullName = _workContext.CurrentCustomer.GetFullName()
            };
            return View(model);
        }

        [HttpPost, ActionName("ContactUs")]
        public ActionResult ContactUsSend(ContactUsModel model)
        {
            
            if (ModelState.IsValid)
            {
                string email = model.Email.Trim();
                string fullName = model.FullName;
                string subject = string.Format("{0}. {1}", _storeInformationSettings.StoreName, "Contact us");

                var emailAccount = _emailAccountService.GetEmailAccountById(_emailAccountSettings.DefaultEmailAccountId);

                string from = null;
                string fromName = null;
                string body = Core.Html.HtmlHelper.FormatText(model.Enquiry, false, true, false, false, false, false);
                
                if (_commonSettings.UseSystemEmailForContactUsForm)
                {
                    from = emailAccount.Email;
                    fromName = emailAccount.DisplayName;
                    body = string.Format("<b>From</b>: {0} - {1}<br /><br />{2}", 
                        Server.HtmlEncode(fullName), 
                        Server.HtmlEncode(email), body);
                }
                else
                {
                    from = email;
                    fromName = fullName;
                }
                _queuedEmailService.InsertQueuedEmail(new QueuedEmail()
                {
                    From = from,
                    FromName = fromName,
                    To = emailAccount.Email,
                    ToName = emailAccount.DisplayName,
                    Priority = 5,
                    Subject = subject,
                    Body = body,
                    CreatedOnUtc = DateTime.UtcNow,
                    EmailAccountId = emailAccount.Id
                });

                return Json(new { SuccessfullySent = true, Result = _localizationService.GetResource("ContactUs.YourEnquiryHasBeenSent") });
            }

            
            var errors = new List<string>();
            foreach (var modelState in ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
            }
            return Json(new { SuccessfullySent = false, Result = errors.FirstOrDefault() });
        }

        
        public ActionResult Sitemap()
        {
            if (!_commonSettings.SitemapEnabled)
                return RedirectToAction("Index", "Home");

            var model = new SitemapModel();
            if (_commonSettings.SitemapIncludeCategories)
            {
                var categories = _categoryService.GetAllCategories();
                model.Categories = categories.Select(x => x.ToModel()).ToList();
            }
            if (_commonSettings.SitemapIncludePublishers)
            {
                var publishers = _publisherService.GetAllPublishers();
                model.Publishers = publishers.Select(x => x.ToModel()).ToList();
            }
            if (_commonSettings.SitemapIncludeProducts)
            {
                
                var products = _productService.SearchProducts(0, 0, null, null, null, 0, null, false, 0, null,
                     ProductSortingMode.Position, 0, 200);
                model.Products = products.Select(x => x.ToModel()).ToList();
            }
            if (_commonSettings.SitemapIncludeTopics)
            {
                var topics = _topicService.GetAllTopics().ToList().FindAll(t => t.IncludeInSitemap);
                model.Topics = topics.Select(x => x.ToModel()).ToList();
            }
            return View(model);
        }

        
        public ActionResult SitemapSeo()
        {
            if (!_commonSettings.SitemapEnabled)
                return RedirectToAction("Index", "Home");

            string siteMap = _sitemapGenerator.Generate();
            return Content(siteMap, "text/xml");
        }

        
        [ChildActionOnly]
        public ActionResult StoreThemeSelector()
        {
            if (!_storeInformationSettings.AllowCustomerToSelectTheme)
                return Content(string.Empty);

            var model = new StoreThemeSelectorModel();
            var currentTheme = _themeProvider.GetThemeConfiguration(_themeContext.WorkingDesktopTheme);
            model.CurrentStoreTheme = new StoreThemeModel()
            {
                Name = currentTheme.ThemeName,
                Title = currentTheme.ThemeTitle
            };
            model.AvailableStoreThemes = _themeProvider.GetThemeConfigurations()
                
                .Where(x => !x.MobileTheme)
                .Select(x =>
                {
                    return new StoreThemeModel()
                    {
                        Name = x.ThemeName,
                        Title = x.ThemeTitle
                    };
                })
                .ToList();
            return PartialView(model);
        }

        public ActionResult StoreThemeSelected(string themeName)
        {
            _themeContext.WorkingDesktopTheme = themeName;
            
            var model = new StoreThemeSelectorModel();
            var currentTheme = _themeProvider.GetThemeConfiguration(_themeContext.WorkingDesktopTheme);
            model.CurrentStoreTheme = new StoreThemeModel()
            {
                Name = currentTheme.ThemeName,
                Title = currentTheme.ThemeTitle
            };
            model.AvailableStoreThemes = _themeProvider.GetThemeConfigurations()
                
                .Where(x => !x.MobileTheme)
                .Select(x =>
                {
                    return new StoreThemeModel()
                    {
                        Name = x.ThemeName,
                        Title = x.ThemeTitle
                    };
                })
                .ToList();
            return PartialView("StoreThemeSelector", model);
        }

        
        [ChildActionOnly]
        public ActionResult Favicon()
        {
            var model = new FaviconModel()
            {
                Uploaded = System.IO.File.Exists(Request.PhysicalApplicationPath + "favicon.ico"),
                FaviconUrl = _webHelper.GetStoreLocation() + "favicon.ico"
            };
            
            return PartialView(model);
        }

        
        
        
        
        
        public ActionResult ChangeDevice(bool dontUseMobileVersion)
        {
            _customerService.SaveCustomerAttribute(_workContext.CurrentCustomer,
                SystemCustomerAttributeNames.DontUseMobileVersion, dontUseMobileVersion);
            return RedirectToAction("Index", "Home");
        }
        [ChildActionOnly]
        public ActionResult ChangeDeviceBlock()
        {
            if (!_mobileDeviceHelper.MobileDevicesSupported())
                
                return Content(string.Empty);

            if (!_mobileDeviceHelper.IsMobileDevice(_httpContext))
                
                return Content(string.Empty);

            return View();
        }
    }
}
