using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web.Mvc;
using Fara.Core;
using Fara.Core.Caching;
using Fara.Core.Domain;
using Fara.Core.Domain.Catalog;
using Fara.Core.Domain.Customers;
using Fara.Core.Domain.Localization;
using Fara.Core.Domain.Media;
using Fara.Core.Domain.Orders;
using Fara.Core.Infrastructure;
using Fara.Services.Catalog;
using Fara.Services.Customers;
using Fara.Services.Directory;
using Fara.Services.Helpers;
using Fara.Services.Localization;
using Fara.Services.Media;
using Fara.Services.Messages;
using Fara.Services.Orders;
using Fara.Services.Security;
using Fara.Services.Seo;
using Fara.Services.Tax;
using Fara.Web.Extensions;
using Fara.Web.Framework;
using Fara.Web.Framework.Controllers;
using Fara.Web.Infrastructure.Cache;
using Fara.Web.Models.Catalog;
using Fara.Web.Models.Media;

namespace Fara.Web.Controllers
{
    public class CatalogController : BaseFaraController
    {
		

        private readonly ICategoryService _categoryService;
        private readonly IPublisherService _publisherService;
        private readonly IProductService _productService;
        private readonly IViewTemplateService _viewTemplateService;
        private readonly IViewTemplateService _viewTemplateService;
        private readonly IViewTemplateService _viewTemplateService;
        private readonly IProductAttributeService _productAttributeService;
        private readonly IProductAttributeParser _productAttributeParser;
        private readonly IWorkContext _workContext;
        private readonly ITaxService _taxService;
        private readonly ICurrencyService _currencyService;
        private readonly IPictureService _pictureService;
        private readonly ILocalizationService _localizationService;
        private readonly IPriceCalculationService _priceCalculationService;
        private readonly IPriceFormatter _priceFormatter;
        private readonly IWebHelper _webHelper;
        private readonly ISpecificationAttributeService _specificationAttributeService;
        private readonly ICustomerContentService _customerContentService;
        private readonly IDateTimeHelper _dateTimeHelper;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IRecentlyViewedProductsService _recentlyViewedProductsService;
        private readonly ICompareProductsService _compareProductsService;
        private readonly IWorkflowMessageService _workflowMessageService;
        private readonly IProductTagService _productTagService;
        private readonly IOrderReportService _orderReportService;
        private readonly ICustomerService _customerService;
        private readonly IBackInStockSubscriptionService _backInStockSubscriptionService;
        private readonly IPermissionService _permissionService;

        private readonly MediaSettings _mediaSetting;
        private readonly CatalogSettings _catalogSettings;
        private readonly ShoppingCartSettings _shoppingCartSettings;
        private readonly StoreInformationSettings _storeInformationSettings;
        private readonly LocalizationSettings _localizationSettings;
        private readonly CustomerSettings _customerSettings;
        private readonly ICacheManager _cacheManager;
        
        

		

        public CatalogController(ICategoryService categoryService, 
            IPublisherService publisherService, IProductService productService, 
            IViewTemplateService viewTemplateService,
            IViewTemplateService viewTemplateService,
            IViewTemplateService viewTemplateService,
            IProductAttributeService productAttributeService, IProductAttributeParser productAttributeParser, 
            IWorkContext workContext, ITaxService taxService, ICurrencyService currencyService,
            IPictureService pictureService, ILocalizationService localizationService,
            IPriceCalculationService priceCalculationService, IPriceFormatter priceFormatter,
            IWebHelper webHelper, ISpecificationAttributeService specificationAttributeService,
            ICustomerContentService customerContentService, IDateTimeHelper dateTimeHelper,
            IShoppingCartService shoppingCartService,
            IRecentlyViewedProductsService recentlyViewedProductsService, ICompareProductsService compareProductsService,
            IWorkflowMessageService workflowMessageService, IProductTagService productTagService,
            IOrderReportService orderReportService, ICustomerService customerService,
            IBackInStockSubscriptionService backInStockSubscriptionService,
            IPermissionService permissionService,
            MediaSettings mediaSetting, CatalogSettings catalogSettings,
            ShoppingCartSettings shoppingCartSettings, StoreInformationSettings storeInformationSettings,
            LocalizationSettings localizationSettings, CustomerSettings customerSettings)
        {
            this._categoryService = categoryService;
            this._publisherService = publisherService;
            this._productService = productService;
            this._viewTemplateService = viewTemplateService;
            this._viewTemplateService = viewTemplateService;
            this._viewTemplateService = viewTemplateService;
            this._productAttributeService = productAttributeService;
            this._productAttributeParser = productAttributeParser;
            this._workContext = workContext;
            this._taxService = taxService;
            this._currencyService = currencyService;
            this._pictureService = pictureService;
            this._localizationService = localizationService;
            this._priceCalculationService = priceCalculationService;
            this._priceFormatter = priceFormatter;
            this._webHelper = webHelper;
            this._specificationAttributeService = specificationAttributeService;
            this._customerContentService = customerContentService;
            this._dateTimeHelper = dateTimeHelper;
            this._shoppingCartService = shoppingCartService;
            this._recentlyViewedProductsService = recentlyViewedProductsService;
            this._compareProductsService = compareProductsService;
            this._workflowMessageService = workflowMessageService;
            this._productTagService = productTagService;
            this._orderReportService = orderReportService;
            this._customerService = customerService;
            this._backInStockSubscriptionService = backInStockSubscriptionService;
            this._permissionService = permissionService;


            this._mediaSetting = mediaSetting;
            this._catalogSettings = catalogSettings;
            this._shoppingCartSettings = shoppingCartSettings;
            this._storeInformationSettings = storeInformationSettings;
            this._localizationSettings = localizationSettings;
            this._customerSettings = customerSettings;

            
            this._cacheManager = EngineContext.Current.ContainerManager.Resolve<ICacheManager>("fara_cache_static");
        }

        

        

        [NonAction]
        private ProductVariant GetMinimalPriceProductVariant(IList<ProductVariant> variants)
        {
            if (variants == null)
                throw new ArgumentNullException("variants");

            if (variants.Count == 0)
                return null;

            var tmp1 = variants.ToList();
            tmp1.Sort(new GenericComparer<ProductVariant>("Price", GenericComparer<ProductVariant>.SortOrder.Ascending));
            return tmp1.Count > 0 ? tmp1[0] : null;
        }

        [NonAction]
        private IList<Category> GetCategoryBreadCrumb(Category category)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            var breadCrumb = new List<Category>();
            
            while (category != null && 
                !category.Deleted && 
                category.Published) 
            {
                breadCrumb.Add(category);
                category = _categoryService.GetCategoryById(category.ParentCategoryId);
            }
            breadCrumb.Reverse();
            return breadCrumb;
        }

        [NonAction]
        private ProductModel.ProductPriceModel PrepareProductPriceModel(Product product)
        {
            if (product == null)
                throw new ArgumentNullException("product");

            var model = new ProductModel.ProductPriceModel();
            var productVariants = _productService.GetProductVariantsByProductId(product.Id);

            switch (productVariants.Count)
            {
                case 0:
                    {
                        
                        model.OldPrice = null;
                        model.Price = null;
                    }
                    break;
                case 1:
                    {
                        
                        var productVariant = productVariants[0];

                        if (_permissionService.Authorize(StandardPermissionProvider.DisplayPrices))
                        {
                            if (!productVariant.CustomerEntersPrice)
                            {
                                if (productVariant.CallForPrice)
                                {
                                    model.OldPrice = null;
                                    model.Price = _localizationService.GetResource("Products.CallForPrice");
                                }
                                else
                                {
                                    decimal taxRate = decimal.Zero;
                                    decimal oldPriceBase = _taxService.GetProductPrice(productVariant, productVariant.OldPrice, out taxRate);
                                    decimal finalPriceBase = _taxService.GetProductPrice(productVariant, _priceCalculationService.GetFinalPrice(productVariant, true), out taxRate);

                                    decimal oldPrice = _currencyService.ConvertFromPrimaryStoreCurrency(oldPriceBase, _workContext.WorkingCurrency);
                                    decimal finalPrice = _currencyService.ConvertFromPrimaryStoreCurrency(finalPriceBase, _workContext.WorkingCurrency);

                                    if (finalPriceBase != oldPriceBase && oldPriceBase != decimal.Zero)
                                    {
                                        model.OldPrice = _priceFormatter.FormatPrice(oldPrice);
                                        model.Price = _priceFormatter.FormatPrice(finalPrice);
                                    }
                                    else
                                    {
                                        model.OldPrice = null;
                                        model.Price = _priceFormatter.FormatPrice(finalPrice);
                                    }
                                }
                            }
                        }
                        else
                        {
                            model.OldPrice = null;
                            model.Price = null;
                        }
                    }
                    break;
                default:
                    {
                        
                        var productVariant = GetMinimalPriceProductVariant(productVariants);
                        if (productVariant != null)
                        {
                            if (_permissionService.Authorize(StandardPermissionProvider.DisplayPrices))
                            {
                                if (!productVariant.CustomerEntersPrice)
                                {
                                    if (productVariant.CallForPrice)
                                    {
                                        model.OldPrice = null;
                                        model.Price = _localizationService.GetResource("Products.CallForPrice");
                                    }
                                    else
                                    {
                                        decimal taxRate = decimal.Zero;
                                        decimal fromPriceBase = _taxService.GetProductPrice(productVariant, _priceCalculationService.GetFinalPrice(productVariant, false), out taxRate);
                                        decimal fromPrice = _currencyService.ConvertFromPrimaryStoreCurrency(fromPriceBase, _workContext.WorkingCurrency);

                                        model.OldPrice = null;
                                        model.Price = string.Format(_localizationService.GetResource("Products.PriceRangeFrom"), _priceFormatter.FormatPrice(fromPrice));
                                    }
                                }
                            }
                            else
                            {
                                model.OldPrice = null;
                                model.Price = null;
                            }
                        }
                    }
                    break;
            }

            
            switch (productVariants.Count)
            {
                case 0:
                    {
                        
                        model.DisableBuyButton = true;
                    }
                    break;
                case 1:
                    {

                        
                        var productVariant = productVariants[0];
                        model.DisableBuyButton = productVariant.DisableBuyButton || !_permissionService.Authorize(StandardPermissionProvider.EnableShoppingCart);
                        if (!_permissionService.Authorize(StandardPermissionProvider.DisplayPrices))
                        {
                            model.DisableBuyButton = true;
                        }
                    }
                    break;
                default:
                    {
                        
                        model.DisableBuyButton = true;
                    }
                    break;
            }
            
            return model;
        }

        [NonAction]
        private ProductModel PrepareProductOverviewModel(Product product, bool preparePriceModel = true, bool preparePictureModel = true, int? productThumbPictureSize = null)
        {
            if (product == null)
                throw new ArgumentNullException("product");

            var model = product.ToModel();
            
            if (preparePriceModel)
            {
                model.ProductPrice = PrepareProductPriceModel(product);
            }
            
            if (preparePictureModel)
            {
                
                int pictureSize = productThumbPictureSize.HasValue ? productThumbPictureSize.Value : _mediaSetting.ProductThumbPictureSize;
                var picture = product.GetDefaultProductPicture(_pictureService);
                if (picture != null)
                    model.DefaultPictureModel.ImageUrl = _pictureService.GetPictureUrl(picture, pictureSize, true);
                else
                    model.DefaultPictureModel.ImageUrl = _pictureService.GetDefaultPictureUrl(pictureSize);
                model.DefaultPictureModel.Title = string.Format(_localizationService.GetResource("Media.Product.ImageLinkTitleFormat"), model.Name);
                model.DefaultPictureModel.AlternateText = string.Format(_localizationService.GetResource("Media.Product.ImageAlternateTextFormat"), model.Name);
            }
            return model;
        }

        [NonAction]
        private int GetNumberOfProducts(Category category, bool includeSubCategories)
        {
            var products = _productService.SearchProducts(category.Id,
                        0, null, null, null, 0, string.Empty, false, 0, null,
                        ProductSortingMode.Position, 0, 1);

            var numberOfProducts = products.TotalCount;

            if (includeSubCategories)
            {
                var subCategories = _categoryService.GetAllCategoriesByParentCategoryId(category.Id);
                foreach (var subCategory in subCategories)
                    numberOfProducts += GetNumberOfProducts(subCategory, includeSubCategories);
            }
            return numberOfProducts;
        }

        [NonAction]
        private IList<CategoryNavigationModel> GetChildCategoryNavigationModel(IList<Category> breadCrumb, int rootCategoryId, Category currentCategory, int level)
        {
            var result = new List<CategoryNavigationModel>();
            foreach (var category in _categoryService.GetAllCategoriesByParentCategoryId(rootCategoryId))
            {
                var model = new CategoryNavigationModel()
                {
                    Id = category.Id,
                    Name = category.GetLocalized(x => x.Name),
                    SeName = category.GetSeName(),
                    IsActive = currentCategory != null && currentCategory.Id == category.Id,
                    NumberOfParentCategories = level
                };

                if (_catalogSettings.ShowCategoryProductNumber)
                {
                    model.DisplayNumberOfProducts = true;
                    model.NumberOfProducts = GetNumberOfProducts(category, _catalogSettings.ShowCategoryProductNumberIncludingSubcategories);
                }
                result.Add(model);

                for (int i = 0; i <= breadCrumb.Count - 1; i++)
                    if (breadCrumb[i].Id == category.Id)
                        result.AddRange(GetChildCategoryNavigationModel(breadCrumb, category.Id, currentCategory, level + 1));
            }

            return result;
        }
        
        [NonAction]
        private ProductModel PrepareProductDetailsPageModel(Product product)
        {
            if (product == null)
                throw new ArgumentNullException("product");

            var model = product.ToModel();

            

            var templateCacheKey = string.Format(ModelCacheEventConsumer.PRODUCT_TEMPLATE_MODEL_KEY, product.ViewTemplateId);
            model.ViewTemplateViewPath = _cacheManager.Get(templateCacheKey, () =>
            {
                var template = _viewTemplateService.GetViewTemplateById(product.ViewTemplateId);
                if (template == null)
                    template = _viewTemplateService.GetAllViewTemplates().FirstOrDefault();
                return template.ViewPath;
            });

            
            model.DefaultPictureZoomEnabled = _mediaSetting.DefaultPictureZoomEnabled;
            var pictures = _pictureService.GetPicturesByProductId(product.Id);
            if (pictures.Count > 0)
            {
                
                model.DefaultPictureModel = new PictureModel()
                {
                    ImageUrl = _pictureService.GetPictureUrl(pictures.FirstOrDefault(), _mediaSetting.ProductDetailsPictureSize),
                    FullSizeImageUrl = _pictureService.GetPictureUrl(pictures.FirstOrDefault()),
                    Title = string.Format(_localizationService.GetResource("Media.Product.ImageLinkTitleFormat"), model.Name),
                    AlternateText = string.Format(_localizationService.GetResource("Media.Product.ImageAlternateTextFormat"), model.Name),
                };
                
                foreach (var picture in pictures)
                {
                    model.PictureModels.Add(new PictureModel()
                    {
                        ImageUrl = _pictureService.GetPictureUrl(picture, _mediaSetting.ProductThumbPictureSizeOnProductDetailsPage),
                        FullSizeImageUrl = _pictureService.GetPictureUrl(picture),
                        Title = string.Format(_localizationService.GetResource("Media.Product.ImageLinkTitleFormat"), model.Name),
                        AlternateText = string.Format(_localizationService.GetResource("Media.Product.ImageAlternateTextFormat"), model.Name),

                    });
                }
            }
            else
            {
                
                model.DefaultPictureModel = new PictureModel()
                {
                    ImageUrl = _pictureService.GetDefaultPictureUrl(_mediaSetting.ProductDetailsPictureSize),
                    FullSizeImageUrl = _pictureService.GetDefaultPictureUrl(),
                    Title = string.Format(_localizationService.GetResource("Media.Product.ImageLinkTitleFormat"), model.Name),
                    AlternateText = string.Format(_localizationService.GetResource("Media.Product.ImageAlternateTextFormat"), model.Name),
                };
            }


            
            foreach (var variant in _productService.GetProductVariantsByProductId(product.Id))
                model.ProductVariantModels.Add(PrepareProductVariantModel(new ProductModel.ProductVariantModel(), variant));

            return model;
        }

        [NonAction]
        private void PrepareProductReviewsModel(ProductReviewsModel model, Product product)
        {
            if (product == null)
                throw new ArgumentNullException("product");

            if (model == null)
                throw new ArgumentNullException("model");

            model.ProductId = product.Id;
            model.ProductName = product.GetLocalized(x => x.Name);
            model.ProductSeName = product.GetSeName();

            var productReviews = product.ProductReviews.Where(pr => pr.IsApproved).OrderBy(pr => pr.CreatedOnUtc);
            foreach (var pr in productReviews)
            {
                model.Items.Add(new ProductReviewModel()
                {
                    Id = pr.Id,
                    CustomerId = pr.CustomerId,
                    CustomerName = pr.Customer.FormatUserName(),
                    AllowViewingProfiles = _customerSettings.AllowViewingProfiles && pr.Customer != null && !pr.Customer.IsGuest(),
                    Title = pr.Title,
                    ReviewText = pr.ReviewText,
                    Rating = pr.Rating,
                    Helpfulness = new ProductReviewHelpfulnessModel()
                    {
                        ProductReviewId = pr.Id,
                        HelpfulYesTotal = pr.HelpfulYesTotal,
                        HelpfulNoTotal = pr.HelpfulNoTotal,
                    },
                    WrittenOnStr = _dateTimeHelper.ConvertToUserTime(pr.CreatedOnUtc, DateTimeKind.Utc).ToString("g"),
                });
            }

            model.AddProductReview.CanCurrentCustomerLeaveReview = _catalogSettings.AllowAnonymousUsersToReviewProduct || !_workContext.CurrentCustomer.IsGuest();
        }
        
        [NonAction]
        private ProductModel.ProductVariantModel PrepareProductVariantModel(ProductModel.ProductVariantModel model, ProductVariant productVariant)
        {
            if (productVariant == null)
                throw new ArgumentNullException("productVariant");

            if (model == null)
                throw new ArgumentNullException("model");

            

            model.Id = productVariant.Id;
            model.Name = productVariant.GetLocalized(x => x.Name);
            model.ShowSku = _catalogSettings.ShowProductSku;
            model.Sku = productVariant.Sku;
            model.Description = productVariant.GetLocalized(x => x.Description);
            model.ShowPublisherPartNumber = _catalogSettings.ShowPublisherPartNumber;
            model.PublisherPartNumber = productVariant.PublisherPartNumber;
            model.ShowGtin = _catalogSettings.ShowGtin;
            model.Gtin = productVariant.Gtin;
            model.StockAvailablity = productVariant.FormatStockMessage(_localizationService);
            model.PictureModel.FullSizeImageUrl = _pictureService.GetPictureUrl(productVariant.PictureId, 0, false);
            model.PictureModel.ImageUrl = _pictureService.GetPictureUrl(productVariant.PictureId, _mediaSetting.ProductVariantPictureSize, false);
            model.PictureModel.Title = string.Format(_localizationService.GetResource("Media.Product.ImageLinkTitleFormat"), model.Name);
            model.PictureModel.AlternateText = string.Format(_localizationService.GetResource("Media.Product.ImageAlternateTextFormat"), model.Name);
            if (productVariant.IsDownload && productVariant.HasSampleDownload)
            {
                model.DownloadSampleUrl = Url.Action("Sample", "Download", new { productVariantId = productVariant.Id });
            }
            model.IsCurrentCustomerRegistered = _workContext.CurrentCustomer.IsRegistered();
            
            if (productVariant.ManageInventoryMethod == ManageInventoryMethod.ManageStock &&
                productVariant.BackorderMode == BackorderMode.NoBackorders &&
                productVariant.AllowBackInStockSubscriptions &&
                productVariant.StockQuantity <= 0)
            {
                
                model.DisplayBackInStockSubscription = true;
                model.BackInStockAlreadySubscribed = _backInStockSubscriptionService.FindSubscription(_workContext.CurrentCustomer.Id, productVariant.Id) != null;
            }

            

            
            model.ProductVariantPrice.ProductVariantId = productVariant.Id;
            model.ProductVariantPrice.DynamicPriceUpdate = _catalogSettings.EnableDynamicPriceUpdate;
            if (_permissionService.Authorize(StandardPermissionProvider.DisplayPrices))
            {
                model.ProductVariantPrice.HidePrices = false;
                if (productVariant.CustomerEntersPrice)
                {
                    model.ProductVariantPrice.CustomerEntersPrice = true;
                }
                else
                {
                    if (productVariant.CallForPrice)
                    {
                        model.ProductVariantPrice.CallForPrice = true;
                    }
                    else
                    {
                        decimal taxRate = decimal.Zero;
                        decimal oldPriceBase = _taxService.GetProductPrice(productVariant, productVariant.OldPrice, out taxRate);
                        decimal finalPriceWithoutDiscountBase = _taxService.GetProductPrice(productVariant, _priceCalculationService.GetFinalPrice(productVariant, false), out taxRate);
                        decimal finalPriceWithDiscountBase = _taxService.GetProductPrice(productVariant, _priceCalculationService.GetFinalPrice(productVariant, true), out taxRate);

                        decimal oldPrice = _currencyService.ConvertFromPrimaryStoreCurrency(oldPriceBase, _workContext.WorkingCurrency);
                        decimal finalPriceWithoutDiscount = _currencyService.ConvertFromPrimaryStoreCurrency(finalPriceWithoutDiscountBase, _workContext.WorkingCurrency);
                        decimal finalPriceWithDiscount = _currencyService.ConvertFromPrimaryStoreCurrency(finalPriceWithDiscountBase, _workContext.WorkingCurrency);

                        if (finalPriceWithoutDiscountBase != oldPriceBase && oldPriceBase > decimal.Zero)
                            model.ProductVariantPrice.OldPrice = _priceFormatter.FormatPrice(oldPrice);

                        model.ProductVariantPrice.Price = _priceFormatter.FormatPrice(finalPriceWithoutDiscount);

                        if (finalPriceWithoutDiscountBase != finalPriceWithDiscountBase)
                            model.ProductVariantPrice.PriceWithDiscount = _priceFormatter.FormatPrice(finalPriceWithDiscount);

                        model.ProductVariantPrice.PriceValue = finalPriceWithoutDiscount;
                        model.ProductVariantPrice.PriceWithDiscountValue = finalPriceWithDiscount;
                    }
                }
            }
            else
            {
                model.ProductVariantPrice.HidePrices = true;
                model.ProductVariantPrice.OldPrice = null;
                model.ProductVariantPrice.Price = null;
            }
            

            

            model.AddToCart.ProductVariantId = productVariant.Id;

            
            model.AddToCart.EnteredQuantity = productVariant.OrderMinimumQuantity;

            
            model.AddToCart.DisableBuyButton = productVariant.DisableBuyButton || !_permissionService.Authorize(StandardPermissionProvider.EnableShoppingCart);
            model.AddToCart.DisableWishlistButton = productVariant.DisableWishlistButton || !_permissionService.Authorize(StandardPermissionProvider.EnableWishlist);
            if (!_permissionService.Authorize(StandardPermissionProvider.DisplayPrices))
            {
                model.AddToCart.DisableBuyButton = true;
                model.AddToCart.DisableWishlistButton = true;
            }

            model.AddToCart.CustomerEntersPrice = productVariant.CustomerEntersPrice;
            if (model.AddToCart.CustomerEntersPrice)
            {
                decimal minimumCustomerEnteredPrice = _currencyService.ConvertFromPrimaryStoreCurrency(productVariant.MinimumCustomerEnteredPrice, _workContext.WorkingCurrency);
                decimal maximumCustomerEnteredPrice = _currencyService.ConvertFromPrimaryStoreCurrency(productVariant.MaximumCustomerEnteredPrice, _workContext.WorkingCurrency);

                model.AddToCart.CustomerEnteredPrice = minimumCustomerEnteredPrice;
                model.AddToCart.CustomerEnteredPriceRange = string.Format(_localizationService.GetResource("Products.EnterProductPrice.Range"),
                    _priceFormatter.FormatPrice(minimumCustomerEnteredPrice, false, false),
                    _priceFormatter.FormatPrice(maximumCustomerEnteredPrice, false, false));
            }

            
            
            

            model.GiftCard.IsGiftCard = productVariant.IsGiftCard;
            if (model.GiftCard.IsGiftCard)
            {
                model.GiftCard.GiftCardType = productVariant.GiftCardType;
                model.GiftCard.SenderName = _workContext.CurrentCustomer.GetFullName();
                model.GiftCard.SenderEmail = _workContext.CurrentCustomer.Email;
            }

            

            
            
            var productVariantAttributes = _productAttributeService.GetProductVariantAttributesByProductVariantId(productVariant.Id);
            foreach (var attribute in productVariantAttributes)
            {
                var pvaModel = new ProductModel.ProductVariantModel.ProductVariantAttributeModel()
                    {
                        Id = attribute.Id,
                        ProductVariantId = productVariant.Id,
                        ProductAttributeId = attribute.ProductAttributeId,
                        Name = attribute.ProductAttribute.GetLocalized(x => x.Name),
                        Description = attribute.ProductAttribute.GetLocalized(x => x.Description),
                        TextPrompt = attribute.TextPrompt,
                        IsRequired = attribute.IsRequired,
                        AttributeControlType = attribute.AttributeControlType,
                    };

                if (attribute.ShouldHaveValues())
                {
                    
                    var pvaValues = _productAttributeService.GetProductVariantAttributeValues(attribute.Id);
                    foreach (var pvaValue in pvaValues)
                    {
                        var pvaValueModel = new ProductModel.ProductVariantModel.ProductVariantAttributeValueModel()
                        {
                            Id = pvaValue.Id,
                            Name = pvaValue.GetLocalized(x=>x.Name),
                            IsPreSelected = pvaValue.IsPreSelected,
                        };
                        pvaModel.Values.Add(pvaValueModel);
                        
                        
                        if (_permissionService.Authorize(StandardPermissionProvider.DisplayPrices))
                        {
                            decimal taxRate = decimal.Zero;
                            decimal priceAdjustmentBase = _taxService.GetProductPrice(productVariant, pvaValue.PriceAdjustment, out taxRate);
                            decimal priceAdjustment = _currencyService.ConvertFromPrimaryStoreCurrency(priceAdjustmentBase, _workContext.WorkingCurrency);
                            if (priceAdjustmentBase > decimal.Zero)
                                pvaValueModel.PriceAdjustment = "+" + _priceFormatter.FormatPrice(priceAdjustment, false, false);
                            else if (priceAdjustmentBase < decimal.Zero)
                                pvaValueModel.PriceAdjustment = "-" + _priceFormatter.FormatPrice(-priceAdjustment, false, false);

                            pvaValueModel.PriceAdjustmentValue = priceAdjustment;
                        }
                    }
                }

                model.ProductVariantAttributes.Add(pvaModel);
            }

            

            return model;
        }
        
        

        

        public ActionResult Category(int categoryId, CatalogPagingFilteringModel command)
        {
            var category = _categoryService.GetCategoryById(categoryId);
            if (category == null || category.Deleted || !category.Published)
                return RedirectToAction("Index", "Home");

            
            _customerService.SaveCustomerAttribute(_workContext.CurrentCustomer, SystemCustomerAttributeNames.LastContinueShoppingPage, _webHelper.GetThisPageUrl(false));

            if (command.PageNumber <= 0) command.PageNumber = 1;

            var model = category.ToModel();
            



            
            model.AllowProductFiltering = _catalogSettings.AllowProductSorting;
            if (model.AllowProductFiltering)
            {
                foreach (ProductSortingMode enumValue in Enum.GetValues(typeof(ProductSortingMode)))
                {
                    var currentPageUrl = _webHelper.GetThisPageUrl(true);
                    var sortUrl = _webHelper.ModifyQueryString(currentPageUrl, "orderby=" + ((int)enumValue).ToString(), null);
                    
                    var sortValue = enumValue.GetLocalizedEnum(_localizationService, _workContext);
                    model.AvailableSortOptions.Add(new SelectListItem()
                        {
                            Text = sortValue,
                            Value = sortUrl,
                            Selected = enumValue == (ProductSortingMode)command.OrderBy
                        });
                }
            }



            
            model.AllowProductViewModeChanging = _catalogSettings.AllowProductViewModeChanging;
            if (model.AllowProductViewModeChanging)
            {
                var currentPageUrl = _webHelper.GetThisPageUrl(true);
                
                model.AvailableViewModes.Add(new SelectListItem()
                {
                    Text = _localizationService.GetResource("Categories.ViewMode.Grid"),
                    Value = _webHelper.ModifyQueryString(currentPageUrl, "viewmode=grid", null),
                    Selected = command.ViewMode == "grid"
                });
                
                model.AvailableViewModes.Add(new SelectListItem()
                {
                    Text = _localizationService.GetResource("Categories.ViewMode.List"),
                    Value = _webHelper.ModifyQueryString(currentPageUrl, "viewmode=list", null),
                    Selected = command.ViewMode == "list"
                });
            }
                        
            
            model.AllowCustomersToSelectPageSize = false;
            if (category.AllowCustomersToSelectPageSize && category.PageSizeOptions != null)
            {
                var pageSizes = category.PageSizeOptions.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (pageSizes.Any())
                {
                    
                    if (command.PageSize <= 0 || !pageSizes.Contains(command.PageSize.ToString()))
                    {
                        int temp = 0;

                        if (int.TryParse(pageSizes.FirstOrDefault(), out temp))
                        {
                            if (temp > 0)
                            {
                                command.PageSize = temp;
                            }
                        }
                    }

                    var currentPageUrl = _webHelper.GetThisPageUrl(true);
                    var sortUrl = _webHelper.ModifyQueryString(currentPageUrl, "pagesize={0}", null);
                    sortUrl = _webHelper.RemoveQueryString(sortUrl, "pagenumber");

                    foreach (var pageSize in pageSizes)
                    {
                        int temp = 0;
                        if (!int.TryParse(pageSize, out temp))
                        {
                            continue;
                        }
                        if (temp <= 0)
                        {
                            continue;
                        }

                        model.PageSizeOptions.Add(new SelectListItem()
                        {
                            Text = pageSize,
                            Value = string.Format(sortUrl, pageSize),
                            Selected = pageSize.Equals(command.PageSize.ToString(), StringComparison.InvariantCultureIgnoreCase)
                        });
                    }

                    if (model.PageSizeOptions.Any())
                    {
                        model.PageSizeOptions = model.PageSizeOptions.OrderBy(x => int.Parse(x.Text)).ToList();
                        model.AllowCustomersToSelectPageSize = true;

                        if (command.PageSize <= 0)
                        {
                            command.PageSize = int.Parse(model.PageSizeOptions.FirstOrDefault().Text);
                        }
                    }
                }
            }

            if (command.PageSize <= 0) command.PageSize = category.PageSize;


            
            model.PagingFilteringContext.PriceRangeFilter.LoadPriceRangeFilters(category.PriceRanges, _webHelper, _priceFormatter);
            var selectedPriceRange = model.PagingFilteringContext.PriceRangeFilter.GetSelectedPriceRange(_webHelper, category.PriceRanges);
            decimal? minPriceConverted = null;
            decimal? maxPriceConverted = null;
            if (selectedPriceRange != null)
            {
                if (selectedPriceRange.From.HasValue)
                    minPriceConverted = _currencyService.ConvertToPrimaryStoreCurrency(selectedPriceRange.From.Value, _workContext.WorkingCurrency);

                if (selectedPriceRange.To.HasValue)
                    maxPriceConverted = _currencyService.ConvertToPrimaryStoreCurrency(selectedPriceRange.To.Value, _workContext.WorkingCurrency);
            }




            
            model.PagingFilteringContext.SpecificationFilter.LoadSpecsFilters(category, _specificationAttributeService, _webHelper, _workContext);
            IList<int> selectedSpecs = model.PagingFilteringContext.SpecificationFilter.GetAlreadyFilteredSpecOptionIds(_webHelper);
            



            
            model.DisplayCategoryBreadcrumb = _catalogSettings.CategoryBreadcrumbEnabled;
            if (model.DisplayCategoryBreadcrumb)
            {
                foreach (var catBr in GetCategoryBreadCrumb(category))
                {
                    model.CategoryBreadcrumb.Add(new CategoryModel()
                    {
                        Id = catBr.Id,
                        Name = catBr.GetLocalized(x => x.Name),
                        SeName = catBr.GetSeName()
                    });
                }
            }




            
            model.SubCategories = _categoryService
                .GetAllCategoriesByParentCategoryId(categoryId)
                .Select(x =>
                {
                    var subCatName = x.GetLocalized(y => y.Name);
                    var subCatModel = new CategoryModel.SubCategoryModel()
                    {
                        Id = x.Id,
                        Name = subCatName,
                        SeName = x.GetSeName(),
                    };
                    subCatModel.PictureModel.FullSizeImageUrl = _pictureService.GetPictureUrl(x.PictureId);
                    subCatModel.PictureModel.ImageUrl = _pictureService.GetPictureUrl(x.PictureId, _mediaSetting.CategoryThumbPictureSize, true);
                    subCatModel.PictureModel.Title = string.Format(_localizationService.GetResource("Media.Category.ImageLinkTitleFormat"), subCatName);
                    subCatModel.PictureModel.AlternateText = string.Format(_localizationService.GetResource("Media.Category.ImageAlternateTextFormat"), subCatName);
                    return subCatModel;
                })
                .ToList();




            
            if (!_catalogSettings.IgnoreFeaturedProducts && _categoryService.GetTotalNumberOfFeaturedProducts(categoryId) > 0)
            {
                
                
                var featuredProducts = _productService.SearchProducts(category.Id,
                    0, true, null, null, 0, null, false,
                    _workContext.WorkingLanguage.Id, null,
                    ProductSortingMode.Position, 0, int.MaxValue);
                model.FeaturedProducts = featuredProducts.Select(x => PrepareProductOverviewModel(x)).ToList();
            }



            
            var products = _productService.SearchProducts(category.Id, 0, false, minPriceConverted, maxPriceConverted,
                0, string.Empty, false, _workContext.WorkingLanguage.Id, selectedSpecs,
                (ProductSortingMode)command.OrderBy, command.PageNumber - 1, command.PageSize);
            model.Products = products.Select(x => PrepareProductOverviewModel(x)).ToList();

            model.PagingFilteringContext.LoadPagedList(products);
            model.PagingFilteringContext.ViewMode = command.ViewMode;


            
            var templateCacheKey = string.Format(ModelCacheEventConsumer.CATEGORY_TEMPLATE_MODEL_KEY, category.ViewTemplateId);
            var templateViewPath = _cacheManager.Get(templateCacheKey, () =>
                {
                    var template = _viewTemplateService.GetViewTemplateById(category.ViewTemplateId);
                    if (template == null)
                        template = _viewTemplateService.GetAllViewTemplates().FirstOrDefault();
                    return template.ViewPath;
                });

            return View(templateViewPath, model);
        }

        [ChildActionOnly]
        
        public ActionResult CategoryNavigation(int currentCategoryId, int currentProductId)
        {
            string cacheKey = string.Format(ModelCacheEventConsumer.CATEGORY_NAVIGATION_MODEL_KEY, currentCategoryId, currentProductId, _workContext.WorkingLanguage.Id);
            var cacheModel = _cacheManager.Get(cacheKey, () =>
            {
                var currentCategory = _categoryService.GetCategoryById(currentCategoryId);
                if (currentCategory == null && currentProductId > 0)
                {
                    var productCategories = _categoryService.GetProductCategoriesByProductId(currentProductId);
                    if (productCategories.Count > 0)
                        currentCategory = productCategories[0].Category;
                }
                var breadCrumb = currentCategory != null ? GetCategoryBreadCrumb(currentCategory) : new List<Category>();
                var model = GetChildCategoryNavigationModel(breadCrumb, 0, currentCategory, 0);
                return model;
            });

            return PartialView(cacheModel);
        }

        [ChildActionOnly]
        
        public ActionResult HomepageCategories()
        {
            var listModel = _categoryService.GetAllCategoriesDisplayedOnHomePage()
                .Select(x =>
                {
                    var catModel = x.ToModel();
                    catModel.PictureModel.ImageUrl = _pictureService.GetPictureUrl(x.PictureId, _mediaSetting.CategoryThumbPictureSize, true);
                    catModel.PictureModel.Title = string.Format(_localizationService.GetResource("Media.Category.ImageLinkTitleFormat"), catModel.Name);
                    catModel.PictureModel.AlternateText = string.Format(_localizationService.GetResource("Media.Category.ImageAlternateTextFormat"), catModel.Name);
                    return catModel;
                })
                .ToList();

            return PartialView(listModel);
        }

        

        

        public ActionResult Publisher(int publisherId, CatalogPagingFilteringModel command)
        {
            var publisher = _publisherService.GetPublisherById(publisherId);
            if (publisher == null || publisher.Deleted || !publisher.Published)
                return RedirectToAction("Index", "Home");

            
            _customerService.SaveCustomerAttribute(_workContext.CurrentCustomer, SystemCustomerAttributeNames.LastContinueShoppingPage, _webHelper.GetThisPageUrl(false));

            if (command.PageNumber <= 0) command.PageNumber = 1;

            var model = publisher.ToModel();




            
            model.AllowProductFiltering = _catalogSettings.AllowProductSorting;
            if (model.AllowProductFiltering)
            {
                foreach (ProductSortingMode enumValue in Enum.GetValues(typeof(ProductSortingMode)))
                {
                    var currentPageUrl = _webHelper.GetThisPageUrl(true);
                    var sortUrl = _webHelper.ModifyQueryString(currentPageUrl, "orderby=" + ((int)enumValue).ToString(), null);

                    var sortValue = enumValue.GetLocalizedEnum(_localizationService, _workContext);
                    model.AvailableSortOptions.Add(new SelectListItem()
                    {
                        Text = sortValue,
                        Value = sortUrl,
                        Selected = enumValue == (ProductSortingMode)command.OrderBy
                    });
                }
            }



            
            model.AllowProductViewModeChanging = _catalogSettings.AllowProductViewModeChanging;
            if (model.AllowProductViewModeChanging)
            {
                var currentPageUrl = _webHelper.GetThisPageUrl(true);
                
                model.AvailableViewModes.Add(new SelectListItem()
                {
                    Text = _localizationService.GetResource("Publishers.ViewMode.Grid"),
                    Value = _webHelper.ModifyQueryString(currentPageUrl, "viewmode=grid", null),
                    Selected = command.ViewMode == "grid"
                });
                
                model.AvailableViewModes.Add(new SelectListItem()
                {
                    Text = _localizationService.GetResource("Publishers.ViewMode.List"),
                    Value = _webHelper.ModifyQueryString(currentPageUrl, "viewmode=list", null),
                    Selected = command.ViewMode == "list"
                });
            }
                        
            
            model.AllowCustomersToSelectPageSize = false;
            if (publisher.AllowCustomersToSelectPageSize && publisher.PageSizeOptions != null)
            {
                var pageSizes = publisher.PageSizeOptions.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (pageSizes.Any())
                {
                    
                    if (command.PageSize <= 0 || !pageSizes.Contains(command.PageSize.ToString()))
                    {
                        int temp = 0;

                        if (int.TryParse(pageSizes.FirstOrDefault(), out temp))
                        {
                            if (temp > 0)
                            {
                                command.PageSize = temp;
                            }
                        }
                    }

                    var currentPageUrl = _webHelper.GetThisPageUrl(true);
                    var sortUrl = _webHelper.ModifyQueryString(currentPageUrl, "pagesize={0}", null);
                    sortUrl = _webHelper.RemoveQueryString(sortUrl, "pagenumber");

                    foreach (var pageSize in pageSizes)
                    {
                        int temp = 0;
                        if (!int.TryParse(pageSize, out temp))
                        {
                            continue;
                        }
                        if (temp <= 0)
                        {
                            continue;
                        }

                        model.PageSizeOptions.Add(new SelectListItem()
                        {
                            Text = pageSize,
                            Value = string.Format(sortUrl, pageSize),
                            Selected = pageSize.Equals(command.PageSize.ToString(), StringComparison.InvariantCultureIgnoreCase)
                        });
                    }

                    model.PageSizeOptions = model.PageSizeOptions.OrderBy(x => int.Parse(x.Text)).ToList();

                    if (model.PageSizeOptions.Any())
                    {
                        model.PageSizeOptions = model.PageSizeOptions.OrderBy(x => int.Parse(x.Text)).ToList();
                        model.AllowCustomersToSelectPageSize = true;

                        if (command.PageSize <= 0)
                        {
                            command.PageSize = int.Parse(model.PageSizeOptions.FirstOrDefault().Text);
                        }
                    }
                }
            }

            if (command.PageSize <= 0) command.PageSize = publisher.PageSize;


            
            model.PagingFilteringContext.PriceRangeFilter.LoadPriceRangeFilters(publisher.PriceRanges, _webHelper, _priceFormatter);
            var selectedPriceRange = model.PagingFilteringContext.PriceRangeFilter.GetSelectedPriceRange(_webHelper, publisher.PriceRanges);
            decimal? minPriceConverted = null;
            decimal? maxPriceConverted = null;
            if (selectedPriceRange != null)
            {
                if (selectedPriceRange.From.HasValue)
                    minPriceConverted = _currencyService.ConvertToPrimaryStoreCurrency(selectedPriceRange.From.Value, _workContext.WorkingCurrency);

                if (selectedPriceRange.To.HasValue)
                    maxPriceConverted = _currencyService.ConvertToPrimaryStoreCurrency(selectedPriceRange.To.Value, _workContext.WorkingCurrency);
            }

            


            
            if (!_catalogSettings.IgnoreFeaturedProducts && _publisherService.GetTotalNumberOfFeaturedProducts(publisherId) > 0)
            {
                
                
                var featuredProducts = _productService.SearchProducts(0,
                    publisher.Id, true, null, null, 0, null,
                    false, _workContext.WorkingLanguage.Id, null,
                    ProductSortingMode.Position, 0, int.MaxValue);
                model.FeaturedProducts = featuredProducts.Select(x => PrepareProductOverviewModel(x)).ToList();
            }



            
            var products = _productService.SearchProducts(0, publisher.Id, false, minPriceConverted, maxPriceConverted,
                0, string.Empty, false, _workContext.WorkingLanguage.Id, null,
                (ProductSortingMode)command.OrderBy, command.PageNumber - 1, command.PageSize);
            model.Products = products.Select(x => PrepareProductOverviewModel(x)).ToList();

            model.PagingFilteringContext.LoadPagedList(products);
            model.PagingFilteringContext.ViewMode = command.ViewMode;


            
            var templateCacheKey = string.Format(ModelCacheEventConsumer.MANUFACTURER_TEMPLATE_MODEL_KEY, publisher.ViewTemplateId);
            var templateViewPath = _cacheManager.Get(templateCacheKey, () =>
            {
                var template = _viewTemplateService.GetViewTemplateById(publisher.ViewTemplateId);
                if (template == null)
                    template = _viewTemplateService.GetAllViewTemplates().FirstOrDefault();
                return template.ViewPath;
            });

            return View(templateViewPath, model);
        }

        public ActionResult PublisherAll()
        {
            var model = new List<PublisherModel>();
            var publishers = _publisherService.GetAllPublishers();
            foreach (var publisher in publishers)
            {
                var modelMan = publisher.ToModel();
                modelMan.PictureModel.FullSizeImageUrl = _pictureService.GetPictureUrl(publisher.PictureId);
                modelMan.PictureModel.ImageUrl = _pictureService.GetPictureUrl(publisher.PictureId, _mediaSetting.PublisherThumbPictureSize, true);
                modelMan.PictureModel.Title = string.Format(_localizationService.GetResource("Media.Publisher.ImageLinkTitleFormat"), modelMan.Name);
                modelMan.PictureModel.AlternateText = string.Format(_localizationService.GetResource("Media.Publisher.ImageAlternateTextFormat"), modelMan.Name);
                model.Add(modelMan);
            }

            return View(model);
        }

        [ChildActionOnly]
        
        public ActionResult PublisherNavigation(int currentPublisherId)
        {
            string cacheKey = string.Format(ModelCacheEventConsumer.MANUFACTURER_NAVIGATION_MODEL_KEY, currentPublisherId, _workContext.WorkingLanguage.Id);
            var cacheModel = _cacheManager.Get(cacheKey, () =>
                {
                    var currentPublisher = _publisherService.GetPublisherById(currentPublisherId);

                    var model = new List<PublisherNavigationModel>();
                    foreach (var publisher in _publisherService.GetAllPublishers())
                    {
                        var modelMan = new PublisherNavigationModel()
                        {
                            Id = publisher.Id,
                            Name = publisher.GetLocalized(x => x.Name),
                            SeName = publisher.GetSeName(),
                            IsActive = currentPublisher != null && currentPublisher.Id == publisher.Id,
                        };
                        model.Add(modelMan);
                    }
                    return model;
                });

            return PartialView(cacheModel);
        }

        

        

        
        public ActionResult Product(int productId)
        {
            var product = _productService.GetProductById(productId);
            if (product == null || product.Deleted || !product.Published)
                return RedirectToAction("Index", "Home");

            
            var model = PrepareProductDetailsPageModel(product);

            
            if (model.ProductVariantModels.Count == 0)
                return RedirectToAction("Index", "Home");
            
            
            _recentlyViewedProductsService.AddProductToRecentlyViewedList(product.Id);

            return View(model.ViewTemplateViewPath, model);
        }

        [HttpPost, ActionName("Product")]
        [ValidateInput(false)]
        public ActionResult AddToCartProduct(int productId, FormCollection form)
        {
            var product = _productService.GetProductById(productId);
            if (product == null || product.Deleted || !product.Published)
                return RedirectToAction("Index", "Home");

            
            int productVariantId = 0;
            ShoppingCartType cartType = ShoppingCartType.ShoppingCart;
            foreach (string formKey in form.AllKeys)
            {
                if (formKey.StartsWith("addtocart-"))
                {
                    productVariantId = Convert.ToInt32(formKey.Substring(("addtocart-").Length));
                    cartType = ShoppingCartType.ShoppingCart;
                }
                else if (formKey.StartsWith("addtowishlist-"))
                {
                    productVariantId = Convert.ToInt32(formKey.Substring(("addtowishlist-").Length));
                    cartType = ShoppingCartType.Wishlist;
                }
            }

            var productVariant = _productService.GetProductVariantById(productVariantId);
            if (productVariant == null)
                return RedirectToAction("Index", "Home");

            
            decimal customerEnteredPriceConverted = decimal.Zero;
            if (productVariant.CustomerEntersPrice)
            {
                foreach (string formKey in form.AllKeys)
                    if (formKey.Equals(string.Format("price_{0}.CustomerEnteredPrice", productVariantId), StringComparison.InvariantCultureIgnoreCase))
                    {
                        decimal customerEnteredPrice = decimal.Zero;
                        if (decimal.TryParse(form[formKey], out customerEnteredPrice))
                            customerEnteredPriceConverted = _currencyService.ConvertToPrimaryStoreCurrency(customerEnteredPrice, _workContext.WorkingCurrency);
                        break;
                    }
            }
            

            

            int quantity = 1;
            foreach (string formKey in form.AllKeys)
                if (formKey.Equals(string.Format("price_{0}.EnteredQuantity", productVariantId), StringComparison.InvariantCultureIgnoreCase))
                {
                    int.TryParse(form[formKey], out quantity);
                    break;
                }

            
            
            string attributes = string.Empty;

            
            string selectedAttributes = string.Empty;
            var productVariantAttributes = _productAttributeService.GetProductVariantAttributesByProductVariantId(productVariant.Id);
            foreach (var attribute in productVariantAttributes)
            {
                string controlId = string.Format("product_attribute_{0}_{1}_{2}", attribute.ProductVariantId, attribute.ProductAttributeId, attribute.Id);
                switch (attribute.AttributeControlType)
                {
                    case AttributeControlType.DropdownList:
                        {
                            var ddlAttributes = form[controlId];
                            if (!string.IsNullOrEmpty(ddlAttributes))
                            {
                                int selectedAttributeId = int.Parse(ddlAttributes);
                                if (selectedAttributeId > 0)
                                    selectedAttributes = _productAttributeParser.AddProductAttribute(selectedAttributes,
                                        attribute, selectedAttributeId.ToString());
                            }
                        }
                        break;
                    case AttributeControlType.RadioList:
                        {
                            var rblAttributes = form[controlId];
                            if (!string.IsNullOrEmpty(rblAttributes))
                            {
                                int selectedAttributeId = int.Parse(rblAttributes);
                                if (selectedAttributeId > 0)
                                    selectedAttributes = _productAttributeParser.AddProductAttribute(selectedAttributes,
                                        attribute, selectedAttributeId.ToString());
                            }
                        }
                        break;
                    case AttributeControlType.Checkboxes:
                        {
                            var cblAttributes = form[controlId];
                            if (!string.IsNullOrEmpty(cblAttributes))
                            {
                                foreach (var item in cblAttributes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                                {
                                    int selectedAttributeId =  int.Parse(item);
                                    if (selectedAttributeId > 0)
                                        selectedAttributes = _productAttributeParser.AddProductAttribute(selectedAttributes,
                                            attribute, selectedAttributeId.ToString());
                                }
                            }
                        }
                        break;
                    case AttributeControlType.TextBox:
                        {
                            var txtAttribute = form[controlId];
                            if (!string.IsNullOrEmpty(txtAttribute))
                            {
                                string enteredText = txtAttribute.Trim();
                                selectedAttributes = _productAttributeParser.AddProductAttribute(selectedAttributes,
                                    attribute, enteredText);
                            }
                        }
                        break;
                    case AttributeControlType.MultilineTextbox:
                        {
                            var txtAttribute = form[controlId];
                            if (!string.IsNullOrEmpty(txtAttribute))
                            {
                                string enteredText = txtAttribute.Trim();
                                selectedAttributes = _productAttributeParser.AddProductAttribute(selectedAttributes,
                                    attribute, enteredText);
                            }
                        }
                        break;
                    case AttributeControlType.Datepicker:
                        {
                            var date = form[controlId + "_day"];
                            var month = form[controlId + "_month"];
                            var year = form[controlId + "_year"];
                            DateTime? selectedDate = null;
                            try
                            {
                                selectedDate = new DateTime(Int32.Parse(year), Int32.Parse(month), Int32.Parse(date));
                            }
                            catch {}
                            if (selectedDate.HasValue)
                            {
                                selectedAttributes = _productAttributeParser.AddProductAttribute(selectedAttributes,
                                    attribute, selectedDate.Value.ToString("D"));
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            attributes = selectedAttributes;

            

            

            if (productVariant.IsGiftCard)
            {
                string recipientName = string.Empty;
                string recipientEmail = string.Empty;
                string senderName = string.Empty;
                string senderEmail = string.Empty;
                string giftCardMessage = string.Empty;
                foreach (string formKey in form.AllKeys)
                {
                    if (formKey.Equals(string.Format("giftcard_{0}.RecipientName", productVariantId), StringComparison.InvariantCultureIgnoreCase))
                    {
                        recipientName = form[formKey];
                        continue;
                    }
                    if (formKey.Equals(string.Format("giftcard_{0}.RecipientEmail", productVariantId), StringComparison.InvariantCultureIgnoreCase))
                    {
                        recipientEmail = form[formKey];
                        continue;
                    }
                    if (formKey.Equals(string.Format("giftcard_{0}.SenderName", productVariantId), StringComparison.InvariantCultureIgnoreCase))
                    {
                        senderName = form[formKey];
                        continue;
                    }
                    if (formKey.Equals(string.Format("giftcard_{0}.SenderEmail", productVariantId), StringComparison.InvariantCultureIgnoreCase))
                    {
                        senderEmail = form[formKey];
                        continue;
                    }
                    if (formKey.Equals(string.Format("giftcard_{0}.Message", productVariantId), StringComparison.InvariantCultureIgnoreCase))
                    {
                        giftCardMessage = form[formKey];
                        continue;
                    }
                }

                attributes = _productAttributeParser.AddGiftCardAttribute(attributes,
                    recipientName, recipientEmail, senderName, senderEmail, giftCardMessage);
            }

            

            
            var addToCartWarnings = _shoppingCartService.AddToCart(_workContext.CurrentCustomer,
                productVariant, cartType, attributes, customerEnteredPriceConverted, quantity, true);
            if (addToCartWarnings.Count == 0)
            {
                switch (cartType)
                {
                    case ShoppingCartType.ShoppingCart:
                        return RedirectToRoute("ShoppingCart");
                    case ShoppingCartType.Wishlist:
                        return RedirectToRoute("Wishlist");
                    default:
                        return RedirectToRoute("ShoppingCart");
                }
            }
            else
            {
                
                foreach (string error in addToCartWarnings)
                    ModelState.AddModelError(string.Empty, error);

                
                
                var model = PrepareProductDetailsPageModel(product);

                return View(model.ViewTemplateViewPath, model);
            }
        }

        [ChildActionOnly]
        
        public ActionResult ProductBreadcrumb(int productId)
        {
            var product = _productService.GetProductById(productId);
            if (product == null)
                throw new ArgumentException("No product found with the specified id");

            if (!_catalogSettings.CategoryBreadcrumbEnabled)
                return Content(string.Empty);

            var cacheKey = string.Format(ModelCacheEventConsumer.PRODUCT_BREADCRUMB_MODEL_KEY, product.Id, _workContext.WorkingLanguage.Id);
            var cacheModel = _cacheManager.Get(cacheKey, () =>
                {
                    var model = new ProductModel.ProductBreadcrumbModel()
                        {
                            ProductId = product.Id,
                            ProductName = product.GetLocalized(x => x.Name),
                            ProductSeName = product.GetSeName()
                        };
                        var productCategories = _categoryService.GetProductCategoriesByProductId(product.Id);
                        if (productCategories.Count > 0)
                        {
                            var category = productCategories[0].Category;
                            if (category != null)
                            {
                                foreach (var catBr in GetCategoryBreadCrumb(category))
                                {
                                    model.CategoryBreadcrumb.Add(new CategoryModel()
                                    {
                                        Id = catBr.Id,
                                        Name = catBr.GetLocalized(x => x.Name),
                                        SeName = catBr.GetSeName()
                                    });
                                }
                            }
                        }
                    return model;
                });
            
            return PartialView(cacheModel);
        }

        [ChildActionOnly]
        
        public ActionResult ProductPublishers(int productId)
        {
            string cacheKey = string.Format(ModelCacheEventConsumer.PRODUCT_MANUFACTURERS_MODEL_KEY, productId, _workContext.WorkingLanguage.Id);
            var cacheModel = _cacheManager.Get(cacheKey, () =>
            {
                var model = _publisherService.GetProductPublishersByProductId(productId)
                    .Select(x =>
                    {
                        var m = x.Publisher.ToModel();
                        
                        
                        
                        
                        return m;
                    })
                    .ToList();
                return model;
            });

            return PartialView(cacheModel);
        }

        [ChildActionOnly]
        public ActionResult ProductReviewOverview(int productId)
        {
            var product = _productService.GetProductById(productId);
            if (product == null)
                throw new ArgumentException("No product found with the specified id");

            var model = new ProductReviewOverviewModel()
            {
                ProductId = product.Id,
                RatingSum = product.ApprovedRatingSum,
                TotalReviews = product.ApprovedTotalReviews,
                AllowCustomerReviews = product.AllowCustomerReviews
            };
            return PartialView(model);
        }

        [ChildActionOnly]
        
        public ActionResult ProductSpecifications(int productId)
        {
            var product = _productService.GetProductById(productId);
            if (product == null)
                throw new ArgumentException("No product found with the specified id");

            string cacheKey = string.Format(ModelCacheEventConsumer.PRODUCT_SPECS_MODEL_KEY, product.Id, _workContext.WorkingLanguage.Id);
            var cacheModel = _cacheManager.Get(cacheKey, () =>
            {
                var model = _specificationAttributeService.GetProductSpecificationAttributesByProductId(product.Id, null, true)
                    .Select(psa =>
                    {
                        return new ProductSpecificationModel()
                        {
                            SpecificationAttributeId = psa.SpecificationAttributeOption.SpecificationAttributeId,
                            SpecificationAttributeName = psa.SpecificationAttributeOption.SpecificationAttribute.GetLocalized(x => x.Name),
                            SpecificationAttributeOption = psa.SpecificationAttributeOption.GetLocalized(x => x.Name)
                        };
                    })
                    .ToList();
                return model;
            });

            return PartialView(cacheModel);
        }

        [ChildActionOnly]
        public ActionResult ProductTierPrices(int productVariantId)
        {
            if (_catalogSettings.IgnoreTierPrices)
                return Content(string.Empty); 

            if (!_permissionService.Authorize(StandardPermissionProvider.DisplayPrices))
                return Content(string.Empty); 

            var variant = _productService.GetProductVariantById(productVariantId);
            if (variant == null)
                throw new ArgumentException("No product variant found with the specified id");

            var model = _productService.GetTierPricesByProductVariantId(productVariantId)
                .FilterForCustomer(_workContext.CurrentCustomer)
                .Select(tierPrice =>
                            {
                                var m = new ProductModel.ProductVariantModel.TierPriceModel()
                                {
                                    Quantity = tierPrice.Quantity,
                                };
                                decimal taxRate = decimal.Zero;
                                decimal priceBase = _taxService.GetProductPrice(variant, tierPrice.Price, out taxRate);
                                decimal price = _currencyService.ConvertFromPrimaryStoreCurrency(priceBase,_workContext.WorkingCurrency);
                                m.Price = _priceFormatter.FormatPrice(price, false, false);

                                return m;
                            })
                .ToList();

            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult RelatedProducts(int productId, int? productThumbPictureSize)
        {
            var products = new List<Product>();
            foreach (var rp in _productService.GetRelatedProductsByProductId1(productId))
            {
                var product = _productService.GetProductById(rp.ProductId2);
                if (product == null)
                    continue;

                
                var variants = _productService.GetProductVariantsByProductId(product.Id);
                if (variants.Count > 0)
                    products.Add(product);
            }


            var model = products.Select(x => PrepareProductOverviewModel(x, false, true, productThumbPictureSize)).ToList();
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult ProductsAlsoPurchased(int productId, int? productThumbPictureSize)
        {
            if (!_catalogSettings.ProductsAlsoPurchasedEnabled)
                return Content(string.Empty);

            var products = _orderReportService.GetProductsAlsoPurchasedById(productId,
                _catalogSettings.ProductsAlsoPurchasedNumber);

            var model = products.Select(x => PrepareProductOverviewModel(x, false, true, productThumbPictureSize)).ToList();

            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult ShareButton()
        {
            if (_catalogSettings.ShowShareButton && !string.IsNullOrEmpty(_catalogSettings.PageShareCode))
            {
                var shareCode = _catalogSettings.PageShareCode;
                if (_webHelper.IsCurrentConnectionSecured())
                {
                    
                    shareCode = shareCode.Replace("http:
                }

                return PartialView("ShareButton", shareCode);
            }

            return Content(string.Empty);
        }

        [ChildActionOnly]
        public ActionResult CrossSellProducts(int? productThumbPictureSize)
        {
            var cart = _workContext.CurrentCustomer.ShoppingCartItems.Where(sci => sci.ShoppingCartType == ShoppingCartType.ShoppingCart).ToList();

            var products = _productService.GetCrosssellProductsByShoppingCart(cart, _shoppingCartSettings.CrossSellsNumber);
            var model = products.Select(x => PrepareProductOverviewModel(x, true, true, productThumbPictureSize))
            .ToList();

            return PartialView(model);
        }

        
        public ActionResult RecentlyViewedProducts()
        {
            var model = new List<ProductModel>();
            if (_catalogSettings.RecentlyViewedProductsEnabled)
            {
                var products = _recentlyViewedProductsService.GetRecentlyViewedProducts(_catalogSettings.RecentlyViewedProductsNumber);
                foreach (var product in products)
                    model.Add(PrepareProductOverviewModel(product));
            }
            return View(model);
        }

        [ChildActionOnly]
        public ActionResult RecentlyViewedProductsBlock(int? productThumbPictureSize)
        {
            var model = new List<ProductModel>();
            if (_catalogSettings.RecentlyViewedProductsEnabled)
            {
                var products = _recentlyViewedProductsService.GetRecentlyViewedProducts(_catalogSettings.RecentlyViewedProductsNumber);
                foreach (var product in products)
                    model.Add(PrepareProductOverviewModel(product, false, false, productThumbPictureSize));
            }
            return PartialView(model);
        }

        
        public ActionResult RecentlyAddedProducts()
        {
            var model = new List<ProductModel>();
            if (_catalogSettings.RecentlyAddedProductsEnabled)
            {
                var products = _productService.SearchProducts(0, 0, null, null,
                    null, 0, null, false, _workContext.WorkingLanguage.Id,
                    null, ProductSortingMode.CreatedOn, 0, _catalogSettings.RecentlyAddedProductsNumber);
                foreach (var product in products)
                    model.Add(PrepareProductOverviewModel(product));
            }
            return View(model);
        }

        public ActionResult RecentlyAddedProductsRss()
        {
            var feed = new SyndicationFeed(
                                    string.Format("{0}: Recently added products", _storeInformationSettings.StoreName),
                                    "Information about products",
                                    new Uri(_webHelper.GetStoreLocation(false)),
                                    "RecentlyAddedProductsRSS",
                                    DateTime.UtcNow);

            if (!_catalogSettings.RecentlyAddedProductsEnabled)
                return new RssActionResult() { Feed = feed };
            
            var items = new List<SyndicationItem>();
            var products = _productService.SearchProducts(0, 0, null, null,
                null, 0, null, false, _workContext.WorkingLanguage.Id,
                null, ProductSortingMode.CreatedOn, 0, _catalogSettings.RecentlyAddedProductsNumber);
            foreach (var product in products)
            {
                string productUrl = Url.RouteUrl("Product", new { productId = product.Id, SeName = product.GetSeName() }, "http");
                items.Add(new SyndicationItem(product.GetLocalized(x => x.Name), product.GetLocalized(x => x.ShortDescription), new Uri(productUrl), string.Format("RecentlyAddedProduct:{0}", product.Id), product.CreatedOnUtc));
            }
            feed.Items = items;
            return new RssActionResult() { Feed = feed };
        }

        [ChildActionOnly]
        public ActionResult HomepageBestSellers(int? productThumbPictureSize)
        {
            if (!_catalogSettings.ShowBestsellersOnHomepage || _catalogSettings.NumberOfBestsellersOnHomepage == 0)
                return Content(string.Empty);

            var products = new List<Product>();
            var report = _orderReportService.BestSellersReport(null, null, null, null, null,
                _catalogSettings.NumberOfBestsellersOnHomepage);
            foreach (var line in report)
            {
                var productVariant = _productService.GetProductVariantById(line.ProductVariantId);
                if (productVariant != null)
                {
                    var product = productVariant.Product;
                    if (product != null)
                    {
                        bool contains = false;
                        foreach (var p in products)
                        {
                            if (p.Id == product.Id)
                            {
                                contains = true;
                                break;
                            }
                        }
                        if (!contains)
                            products.Add(product);
                    }
                }
            }


            var model = new HomePageBestsellersModel()
            {
                UseSmallProductBox = _catalogSettings.UseSmallProductBoxOnHomePage,
            };
            model.Products = products
                .Select(x => PrepareProductOverviewModel(x, !_catalogSettings.UseSmallProductBoxOnHomePage, true, productThumbPictureSize))
                .ToList();
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult HomepageProducts(int? productThumbPictureSize)
        {
            var model = new HomePageProductsModel()
            {
                UseSmallProductBox = _catalogSettings.UseSmallProductBoxOnHomePage
            };
            model.Products = _productService.GetAllProductsDisplayedOnHomePage()
                .Select(x => PrepareProductOverviewModel(x, !_catalogSettings.UseSmallProductBoxOnHomePage, true, productThumbPictureSize))
                .ToList();

            return PartialView(model);
        }

        public ActionResult BackInStockSubscribePopup(int productVariantId)
        {
            var variant = _productService.GetProductVariantById(productVariantId);
            if (variant == null || variant.Deleted)
                throw new ArgumentException("No product variant found with the specified id");

            var model = new BackInStockSubscribeModel();
            model.IsCurrentCustomerRegistered = _workContext.CurrentCustomer.IsRegistered();
            model.MaximumBackInStockSubscriptions = _catalogSettings.MaximumBackInStockSubscriptions;
            model.CurrentNumberOfBackInStockSubscriptions = _backInStockSubscriptionService.GetAllSubscriptionsByCustomerId(_workContext.CurrentCustomer.Id, 0, 1).TotalCount;
            if (variant.ManageInventoryMethod == ManageInventoryMethod.ManageStock &&
                variant.BackorderMode == BackorderMode.NoBackorders &&
                variant.AllowBackInStockSubscriptions &&
                variant.StockQuantity <= 0)
            {
                
                model.SubscriptionAllowed = true;
                model.AlreadySubscribed = _backInStockSubscriptionService.FindSubscription(_workContext.CurrentCustomer.Id, variant.Id) != null;
            }
            return View(model);
        }

        [HttpPost, ActionName("BackInStockSubscribePopup")]
        public ActionResult BackInStockSubscribePopupPOST(int productVariantId)
        {
            var variant = _productService.GetProductVariantById(productVariantId);
            if (variant == null || variant.Deleted)
                throw new ArgumentException("No product variant found with the specified id");

            if (!_workContext.CurrentCustomer.IsRegistered())
                return Content(_localizationService.GetResource("BackInStockSubscriptions.OnlyRegistered"));
            
            if (variant.ManageInventoryMethod == ManageInventoryMethod.ManageStock &&
                variant.BackorderMode == BackorderMode.NoBackorders &&
                variant.AllowBackInStockSubscriptions &&
                variant.StockQuantity <= 0)
            {
                
                var subscription = _backInStockSubscriptionService.FindSubscription(_workContext.CurrentCustomer.Id,
                                                                                    variant.Id);
                if (subscription != null)
                {
                    
                    _backInStockSubscriptionService.DeleteSubscription(subscription);
                    return Content("Unsubscribed");
                }
                else
                {
                    if (_backInStockSubscriptionService.GetAllSubscriptionsByCustomerId(_workContext.CurrentCustomer.Id, 0, 1).TotalCount >= _catalogSettings.MaximumBackInStockSubscriptions)
                        return Content(string.Format(_localizationService.GetResource("BackInStockSubscriptions.MaxSubscriptions"), _catalogSettings.MaximumBackInStockSubscriptions));
            
                    
                    subscription = new BackInStockSubscription()
                    {
                        Customer = _workContext.CurrentCustomer,
                        ProductVariant = variant,
                        CreatedOnUtc = DateTime.UtcNow
                    };
                    _backInStockSubscriptionService.InsertSubscription(subscription);
                    return Content("Subscribed");
                }
                
            }
            else
            {
                return Content(_localizationService.GetResource("BackInStockSubscriptions.NotAllowed"));
            }
        }

        

        


        

        [ChildActionOnly]
        public ActionResult ProductTags(int productId)
        {
            var product = _productService.GetProductById(productId);
            if (product == null)
                throw new ArgumentException("No product found with the specified id");

            var cacheKey = string.Format(ModelCacheEventConsumer.PRODUCTTAG_BY_PRODUCT_MODEL_KEY, product.Id);
            var cacheModel = _cacheManager.Get(cacheKey, () =>
                {
                    var model = product.ProductTags
                        .OrderByDescending(x => x.ProductCount)
                        .Select(x =>
                                    {
                                        var ptModel = new ProductTagModel()
                                        {
                                            Id = x.Id,
                                            Name = x.Name,
                                            ProductCount = x.ProductCount
                                        };
                                        return ptModel;
                                    })
                        .ToList();
                    return model;
                });

            return PartialView(cacheModel);
        }

        [ChildActionOnly]
        
        public ActionResult PopularProductTags()
        {
            var cacheKey = ModelCacheEventConsumer.PRODUCTTAG_POPULAR_MODEL_KEY;
            var cacheModel = _cacheManager.Get(cacheKey, () =>
            {
                var model = new PopularProductTagsModel();

                
                var tags = _productTagService.GetAllProductTags()
                    .OrderByDescending(x => x.ProductCount)
                    .Where(x => x.ProductCount > 0)
                    .Take(_catalogSettings.NumberOfProductTags)
                    .ToList();
                
                tags = tags.OrderBy(x => x.Name).ToList();

                foreach (var tag in tags)
                    model.Tags.Add(new ProductTagModel()
                    {
                        Id = tag.Id,
                        Name = tag.Name,
                        ProductCount = tag.ProductCount
                    });
                return model;
            });

            return PartialView(cacheModel);
        }

        public ActionResult ProductsByTag(int productTagId, CatalogPagingFilteringModel command)
        {
            var productTag = _productTagService.GetProductById(productTagId);
            if (productTag == null)
                return RedirectToAction("Index", "Home");
                        
            if (command.PageNumber <= 0) command.PageNumber = 1;

            var model = new ProductsByTagModel()
            {
                TagName = productTag.Name
            };


            
            model.AllowProductFiltering = _catalogSettings.AllowProductSorting;
            if (model.AllowProductFiltering)
            {
                foreach (ProductSortingMode enumValue in Enum.GetValues(typeof(ProductSortingMode)))
                {
                    var currentPageUrl = _webHelper.GetThisPageUrl(true);
                    var sortUrl = _webHelper.ModifyQueryString(currentPageUrl, "orderby=" + ((int)enumValue).ToString(), null);

                    var sortValue = enumValue.GetLocalizedEnum(_localizationService, _workContext);
                    model.AvailableSortOptions.Add(new SelectListItem()
                    {
                        Text = sortValue,
                        Value = sortUrl,
                        Selected = enumValue == (ProductSortingMode)command.OrderBy
                    });
                }
            }


            
            model.AllowProductViewModeChanging = _catalogSettings.AllowProductViewModeChanging;
            if (model.AllowProductViewModeChanging)
            {
                var currentPageUrl = _webHelper.GetThisPageUrl(true);
                
                model.AvailableViewModes.Add(new SelectListItem()
                {
                    Text = _localizationService.GetResource("Categories.ViewMode.Grid"),
                    Value = _webHelper.ModifyQueryString(currentPageUrl, "viewmode=grid", null),
                    Selected = command.ViewMode == "grid"
                });
                
                model.AvailableViewModes.Add(new SelectListItem()
                {
                    Text = _localizationService.GetResource("Categories.ViewMode.List"),
                    Value = _webHelper.ModifyQueryString(currentPageUrl, "viewmode=list", null),
                    Selected = command.ViewMode == "list"
                });
            }

            
            model.AllowCustomersToSelectPageSize = false;
            if (_catalogSettings.ProductsByTagAllowCustomersToSelectPageSize && _catalogSettings.ProductsByTagPageSizeOptions != null)
            {
                var pageSizes = _catalogSettings.ProductsByTagPageSizeOptions.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (pageSizes.Any())
                {
                    
                    if (command.PageSize <= 0 || !pageSizes.Contains(command.PageSize.ToString()))
                    {
                        int temp = 0;

                        if (int.TryParse(pageSizes.FirstOrDefault(), out temp))
                        {
                            if (temp > 0)
                            {
                                command.PageSize = temp;
                            }
                        }
                    }

                    var currentPageUrl = _webHelper.GetThisPageUrl(true);
                    var sortUrl = _webHelper.ModifyQueryString(currentPageUrl, "pagesize={0}", null);
                    sortUrl = _webHelper.RemoveQueryString(sortUrl, "pagenumber");

                    foreach (var pageSize in pageSizes)
                    {
                        int temp = 0;
                        if (!int.TryParse(pageSize, out temp))
                        {
                            continue;
                        }
                        if (temp <= 0)
                        {
                            continue;
                        }

                        model.PageSizeOptions.Add(new SelectListItem()
                        {
                            Text = pageSize,
                            Value = string.Format(sortUrl, pageSize),
                            Selected = pageSize.Equals(command.PageSize.ToString(), StringComparison.InvariantCultureIgnoreCase)
                        });
                    }

                    if (model.PageSizeOptions.Any())
                    {
                        model.PageSizeOptions = model.PageSizeOptions.OrderBy(x => int.Parse(x.Text)).ToList();
                        model.AllowCustomersToSelectPageSize = true;

                        if (command.PageSize <= 0)
                        {
                            command.PageSize = int.Parse(model.PageSizeOptions.FirstOrDefault().Text);
                        }
                    }
                }
            }

            if (command.PageSize <= 0) command.PageSize = _catalogSettings.ProductsByTagPageSize;

            
            var products = _productService.SearchProducts(0, 0, false, null, null,
                productTag.Id, string.Empty, false, _workContext.WorkingLanguage.Id, null,
                (ProductSortingMode)command.OrderBy, command.PageNumber - 1, command.PageSize);
            model.Products = products.Select(x => PrepareProductOverviewModel(x)).ToList();

            model.PagingFilteringContext.LoadPagedList(products);
            model.PagingFilteringContext.ViewMode = command.ViewMode;
            return View(model);
        }


        

        

        
        public ActionResult ProductReviews(int productId)
        {
            var product = _productService.GetProductById(productId);
            if (product == null || product.Deleted || !product.Published || !product.AllowCustomerReviews)
                return RedirectToAction("Index", "Home");

            var model = new ProductReviewsModel();
            PrepareProductReviewsModel(model, product);
            
            if (_workContext.CurrentCustomer.IsGuest() && !_catalogSettings.AllowAnonymousUsersToReviewProduct)
                ModelState.AddModelError(string.Empty, _localizationService.GetResource("Reviews.OnlyRegisteredUsersCanWriteReviews"));
            
            model.AddProductReview.Rating = 4;
            return View(model);
        }

        [HttpPost, ActionName("ProductReviews")]
        [FormValueRequired("add-review")]
        public ActionResult ProductReviewsAdd(int productId, ProductReviewsModel model)
        {
            var product = _productService.GetProductById(productId);
            if (product == null || product.Deleted || !product.Published || !product.AllowCustomerReviews)
                return RedirectToAction("Index", "Home");

            if (ModelState.IsValid)
            {
                if (_workContext.CurrentCustomer.IsGuest() && !_catalogSettings.AllowAnonymousUsersToReviewProduct)
                {
                    ModelState.AddModelError(string.Empty, _localizationService.GetResource("Reviews.OnlyRegisteredUsersCanWriteReviews"));
                }
                else
                {
                    
                    int rating = model.AddProductReview.Rating;
                    if (rating < 1 || rating > 5)
                        rating = 4;
                    bool isApproved = !_catalogSettings.ProductReviewsMustBeApproved;

                    var productReview = new ProductReview()
                    {
                        ProductId = product.Id,
                        CustomerId = _workContext.CurrentCustomer.Id,
                        IpAddress = _webHelper.GetCurrentIpAddress(),
                        Title = model.AddProductReview.Title,
                        ReviewText = model.AddProductReview.ReviewText,
                        Rating = rating,
                        HelpfulYesTotal = 0,
                        HelpfulNoTotal = 0,
                        IsApproved = isApproved,
                        CreatedOnUtc = DateTime.UtcNow,
                        UpdatedOnUtc = DateTime.UtcNow,
                    };
                    _customerContentService.InsertCustomerContent(productReview);

                    
                    _productService.UpdateProductReviewTotals(product);

                    
                    if (_catalogSettings.NotifyStoreOwnerAboutNewProductReviews)
                        _workflowMessageService.SendProductReviewNotificationMessage(productReview, _localizationSettings.DefaultAdminLanguageId);


                    PrepareProductReviewsModel(model, product);
                    model.AddProductReview.Title = null;
                    model.AddProductReview.ReviewText = null;

                    model.AddProductReview.SuccessfullyAdded = true;
                    if (!isApproved)
                        model.AddProductReview.Result = _localizationService.GetResource("Reviews.SeeAfterApproving");
                    else
                        model.AddProductReview.Result = _localizationService.GetResource("Reviews.SuccessfullyAdded");

                    return View(model);
                }
            }

            
            PrepareProductReviewsModel(model, product);
            return View(model);
        }

        [HttpPost]
        public ActionResult SetProductReviewHelpfulness(int productReviewId, bool washelpful)
        {
            var productReview = _customerContentService.GetCustomerContentById(productReviewId) as ProductReview;
            if (productReview == null)
                throw new ArgumentException("No product review found with the specified id");

            if (_workContext.CurrentCustomer.IsGuest() && !_catalogSettings.AllowAnonymousUsersToReviewProduct)
            {
                return Json(new
                {
                    Result = _localizationService.GetResource("Reviews.Helpfulness.OnlyRegistered"),
                    TotalYes = productReview.HelpfulYesTotal,
                    TotalNo = productReview.HelpfulNoTotal
                });
            }

            
            var oldPrh = (from prh in productReview.ProductReviewHelpfulnessEntries
                          where prh.CustomerId == _workContext.CurrentCustomer.Id
                          select prh).FirstOrDefault();
            if (oldPrh != null)
                _customerContentService.DeleteCustomerContent(oldPrh);

            
            var newPrh = new ProductReviewHelpfulness()
            {
                ProductReviewId = productReview.Id,
                CustomerId = _workContext.CurrentCustomer.Id,
                IpAddress = _webHelper.GetCurrentIpAddress(),
                WasHelpful = washelpful,
                IsApproved = true, 
                CreatedOnUtc = DateTime.UtcNow,
                UpdatedOnUtc = DateTime.UtcNow,
            };
            _customerContentService.InsertCustomerContent(newPrh);

            
            int helpfulYesTotal = (from prh in productReview.ProductReviewHelpfulnessEntries
                                   where prh.WasHelpful
                                   select prh).Count();
            int helpfulNoTotal = (from prh in productReview.ProductReviewHelpfulnessEntries
                                  where !prh.WasHelpful
                                  select prh).Count();

            productReview.HelpfulYesTotal = helpfulYesTotal;
            productReview.HelpfulNoTotal = helpfulNoTotal;
            _customerContentService.UpdateCustomerContent(productReview);

            return Json(new
            {
                Result = _localizationService.GetResource("Reviews.Helpfulness.SuccessfullyVoted"),
                TotalYes = productReview.HelpfulYesTotal,
                TotalNo = productReview.HelpfulNoTotal
            });
        }

        

        

        
        [ChildActionOnly]
        public ActionResult ProductEmailAFriendButton(int productId)
        {
            if (!_catalogSettings.EmailAFriendEnabled)
                return Content(string.Empty);
            var model = new ProductEmailAFriendModel()
            {
                ProductId = productId
            };

            return PartialView("ProductEmailAFriendButton", model);
        }

        public ActionResult ProductEmailAFriend(int productId)
        {
            var product = _productService.GetProductById(productId);
            if (product == null || product.Deleted || !product.Published || !_catalogSettings.EmailAFriendEnabled)
                return RedirectToAction("Index", "Home");

            var model = new ProductEmailAFriendModel();
            model.ProductId = product.Id;
            model.ProductName = product.GetLocalized(x => x.Name);
            model.ProductSeName = product.GetSeName();
            model.YourEmailAddress = _workContext.CurrentCustomer.Email;
            return View(model);
        }

        [HttpPost, ActionName("ProductEmailAFriend")]
        [FormValueRequired("send-email")]
        public ActionResult ProductEmailAFriendSend(int productId, ProductEmailAFriendModel model)
        {
            var product = _productService.GetProductById(productId);
            if (product == null || product.Deleted || !product.Published || !_catalogSettings.EmailAFriendEnabled)
                return RedirectToAction("Index", "Home");

            if (ModelState.IsValid)
            {
                if (_workContext.CurrentCustomer.IsGuest() && !_catalogSettings.AllowAnonymousUsersToEmailAFriend)
                {
                    ModelState.AddModelError(string.Empty, _localizationService.GetResource("Products.EmailAFriend.OnlyRegisteredUsers"));
                }
                else
                {
                    
                    _workflowMessageService.SendProductEmailAFriendMessage(_workContext.CurrentCustomer,
                            _workContext.WorkingLanguage.Id, product,
                            model.YourEmailAddress, model.FriendEmail, Core.Html.HtmlHelper.FormatText(model.PersonalMessage, false, true, false, false, false, false));

                    model.ProductId = product.Id;
                    model.ProductName = product.GetLocalized(x => x.Name);
                    model.ProductSeName = product.GetSeName();

                    model.SuccessfullySent = true;
                    model.Result = _localizationService.GetResource("Products.EmailAFriend.SuccessfullySent");

                    return View(model);
                }
            }

            
            model.ProductId = product.Id;
            model.ProductName = product.GetLocalized(x => x.Name);
            model.ProductSeName = product.GetSeName();
            return View(model);
        }

        

        

        
        public ActionResult AddProductToCompareList(int productId)
        {
            var product = _productService.GetProductById(productId);
            if (product == null || product.Deleted || !product.Published)
                return RedirectToAction("Index", "Home");

            if (!_catalogSettings.CompareProductsEnabled)
                return RedirectToAction("Index", "Home");

            _compareProductsService.AddProductToCompareList(productId);

            return RedirectToRoute("CompareProducts");
        }

        public ActionResult RemoveProductFromCompareList(int productId)
        {
            var product = _productService.GetProductById(productId);
            if (product == null)
                return RedirectToAction("Index", "Home");

            if (!_catalogSettings.CompareProductsEnabled)
                return RedirectToAction("Index", "Home");

            _compareProductsService.RemoveProductFromCompareList(productId);

            return RedirectToRoute("CompareProducts");
        }

        public ActionResult CompareProducts()
        {
            if (!_catalogSettings.CompareProductsEnabled)
                return RedirectToAction("Index", "Home");

            var model = new List<ProductModel>();
            foreach (var product in _compareProductsService.GetComparedProducts())
            {
                var productModel = PrepareProductOverviewModel(product);
                
                productModel.SpecificationAttributeModels = _specificationAttributeService.GetProductSpecificationAttributesByProductId(product.Id, null, true)
                    .Select(psa =>
                    {
                        return new ProductSpecificationModel()
                        {
                            SpecificationAttributeId = psa.SpecificationAttributeOption.SpecificationAttributeId,
                            SpecificationAttributeName = psa.SpecificationAttributeOption.SpecificationAttribute.GetLocalized(x => x.Name),
                            SpecificationAttributeOption = psa.SpecificationAttributeOption.GetLocalized(x => x.Name)
                        };
                    })
                    .ToList();
                model.Add(productModel);
            }
            return View(model);
        }

        public ActionResult ClearCompareList()
        {
            if (!_catalogSettings.CompareProductsEnabled)
                return RedirectToAction("Index", "Home");

            _compareProductsService.ClearCompareProducts();

            return RedirectToRoute("CompareProducts");
        }

        [ChildActionOnly]
        public ActionResult CompareProductsButton(int productId)
        {
            if (!_catalogSettings.CompareProductsEnabled)
                return Content(string.Empty);

            var model = new AddToCompareListModel()
            {
                ProductId = productId
            };

            return PartialView("CompareProductsButton", model);
        }

        

        

        public ActionResult Search(SearchModel model, SearchPagingFilteringModel command)
        {
            if (model == null)
                model = new SearchModel();

            if (command.PageSize <= 0) command.PageSize = _catalogSettings.SearchPageProductsPerPage;
            if (command.PageNumber <= 0) command.PageNumber = 1;
            if (model.Q == null)
                model.Q = string.Empty;
            model.Q = model.Q.Trim();

            var categories = _categoryService.GetAllCategories();
            if (categories.Count > 0)
            {
                model.AvailableCategories.Add(new SelectListItem()
                    {
                         Value = "0",
                         Text = _localizationService.GetResource("Common.All")
                    });
                foreach(var c in categories)
                    model.AvailableCategories.Add(new SelectListItem()
                        {
                            Value = c.Id.ToString(),
                            Text = c.GetCategoryBreadCrumb(_categoryService),
                            Selected = model.Cid == c.Id
                        });
            }

            var publishers = _publisherService.GetAllPublishers();
            if (publishers.Count > 0)
            {
                model.AvailablePublishers.Add(new SelectListItem()
                {
                    Value = "0",
                    Text = _localizationService.GetResource("Common.All")
                });
                foreach (var m in publishers)
                    model.AvailablePublishers.Add(new SelectListItem()
                    {
                        Value = m.Id.ToString(),
                        Text = m.Name,
                        Selected = model.Mid == m.Id
                    });
            }

            IPagedList<Product> products = new PagedList<Product>(new List<Product>(), 0, 1);
            
            if (Request.Params["Q"] != null)
            {
                if (model.Q.Length < _catalogSettings.ProductSearchTermMinimumLength)
                {
                    model.Warning = string.Format(_localizationService.GetResource("Search.SearchTermMinimumLengthIsNCharacters"), _catalogSettings.ProductSearchTermMinimumLength);
                }
                else
                {
                    int categoryId = 0;
                    int publisherId = 0;
                    decimal? minPriceConverted = null;
                    decimal? maxPriceConverted = null;
                    bool searchInDescriptions = false;
                    if (model.As)
                    {
                        
                        categoryId = model.Cid;
                        publisherId = model.Mid;

                        
                        if (!string.IsNullOrEmpty(model.Pf))
                        {
                            decimal minPrice = decimal.Zero;
                            if (decimal.TryParse(model.Pf, out minPrice))
                                minPriceConverted = _currencyService.ConvertToPrimaryStoreCurrency(minPrice, _workContext.WorkingCurrency);
                        }
                        
                        if (!string.IsNullOrEmpty(model.Pt))
                        {
                            decimal maxPrice = decimal.Zero;
                            if (decimal.TryParse(model.Pt, out maxPrice))
                                maxPriceConverted = _currencyService.ConvertToPrimaryStoreCurrency(maxPrice, _workContext.WorkingCurrency);
                        }

                        searchInDescriptions = model.Sid;
                    }

                    
                    products = _productService.SearchProducts(categoryId, publisherId, null,
                        minPriceConverted, maxPriceConverted, 0,
                        model.Q, searchInDescriptions, _workContext.WorkingLanguage.Id, null,
                    ProductSortingMode.Position, command.PageNumber - 1, command.PageSize);
                    model.Products = products.Select(x => PrepareProductOverviewModel(x)).ToList();

                    model.NoResults = !model.Products.Any();                    
                }
            }

            model.PagingFilteringContext.LoadPagedList(products);
            return View(model);
        }

        [ChildActionOnly]
        public ActionResult SearchBox()
        {
            return PartialView();
        }
        
    }
}
