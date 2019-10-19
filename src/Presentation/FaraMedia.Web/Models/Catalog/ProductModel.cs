using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Fara.Core.Domain.Catalog;
using Fara.Web.Framework;
using Fara.Web.Framework.Mvc;
using Fara.Web.Models.Media;

namespace Fara.Web.Models.Catalog
{
    public class ProductModel : BaseFaraEntityModel
    {
        public ProductModel()
        {
            ProductPrice = new ProductPriceModel();
            DefaultPictureModel = new PictureModel();
            PictureModels = new List<PictureModel>();
            ProductVariantModels = new List<ProductVariantModel>();
            SpecificationAttributeModels = new List<ProductSpecificationModel>();
        }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string FullDescription { get; set; }

        public string ViewTemplateViewPath { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }

        public string MetaTitle { get; set; }

        public string SeName { get; set; }

        
        public ProductPriceModel ProductPrice { get; set; }

        
        public bool DefaultPictureZoomEnabled { get; set; }
        public PictureModel DefaultPictureModel { get; set; }
        public IList<PictureModel> PictureModels { get; set; }
        public IList<ProductVariantModel> ProductVariantModels { get; set; }
        public IList<ProductSpecificationModel> SpecificationAttributeModels { get; set; }

		

        public class ProductPriceModel : BaseFaraModel
        {
            public string OldPrice { get; set; }

            public string Price {get;set;}

            public bool DisableBuyButton { get; set; }
        }

        public class ProductBreadcrumbModel : BaseFaraModel
        {
            public ProductBreadcrumbModel()
            {
                CategoryBreadcrumb = new List<CategoryModel>();
            }

            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public string ProductSeName { get; set; }
            public IList<CategoryModel> CategoryBreadcrumb { get; set; }
        }
        
        public class ProductVariantModel : BaseFaraEntityModel
        {
            public ProductVariantModel()
            {
                GiftCard = new GiftCardModel();
                ProductVariantPrice = new ProductVariantPriceModel();
                PictureModel = new PictureModel();
                AddToCart = new AddToCartModel();
                ProductVariantAttributes = new List<ProductVariantAttributeModel>();
            }

            public string Name { get; set; }

            public bool ShowSku { get; set; }
            public string Sku { get; set; }

            public string Description { get; set; }

            public bool ShowPublisherPartNumber { get; set; }
            public string PublisherPartNumber { get; set; }

            public bool ShowGtin { get; set; }
            public string Gtin { get; set; }

            public string DownloadSampleUrl { get; set; }

            public GiftCardModel GiftCard { get; set; }

            public string StockAvailablity { get; set; }

            public bool IsCurrentCustomerRegistered { get; set; }
            public bool DisplayBackInStockSubscription { get; set; }
            public bool BackInStockAlreadySubscribed { get; set; }

            public ProductVariantPriceModel ProductVariantPrice { get; set; }

            public AddToCartModel AddToCart { get; set; }

            public PictureModel PictureModel { get; set; }

            public IList<ProductVariantAttributeModel> ProductVariantAttributes { get; set; }

            

            public class AddToCartModel : BaseFaraModel
            {
                public int ProductVariantId { get; set; }

                [FaraResourceDisplayName("Products.Qty")]
                public int EnteredQuantity { get; set; }

                [FaraResourceDisplayName("Products.EnterProductPrice")]
                public bool CustomerEntersPrice { get; set; }
                [FaraResourceDisplayName("Products.EnterProductPrice")]
                public decimal CustomerEnteredPrice { get; set; }
                public String CustomerEnteredPriceRange { get; set; }
                
                public bool DisableBuyButton { get; set; }
                public bool DisableWishlistButton { get; set; }
            }

            public class ProductVariantPriceModel : BaseFaraModel
            {
                public string OldPrice { get; set; }

                public string Price { get; set; }
                public string PriceWithDiscount { get; set; }

                public decimal PriceValue { get; set; }
                public decimal PriceWithDiscountValue { get; set; }

                public bool CustomerEntersPrice { get; set; }

                public bool CallForPrice { get; set; }

                public int ProductVariantId { get; set; }

                public bool HidePrices { get; set; }

                public bool DynamicPriceUpdate { get; set; }
            }

            public class GiftCardModel : BaseFaraModel
            {
                public bool IsGiftCard { get; set; }

                [FaraResourceDisplayName("Products.GiftCard.RecipientName")]
                [AllowHtml]
                public string RecipientName { get; set; }
                [FaraResourceDisplayName("Products.GiftCard.RecipientEmail")]
                [AllowHtml]
                public string RecipientEmail { get; set; }
                [FaraResourceDisplayName("Products.GiftCard.SenderName")]
                [AllowHtml]
                public string SenderName { get; set; }
                [FaraResourceDisplayName("Products.GiftCard.SenderEmail")]
                [AllowHtml]
                public string SenderEmail { get; set; }
                [FaraResourceDisplayName("Products.GiftCard.Message")]
                [AllowHtml]
                public string Message { get; set; }

                public GiftCardType GiftCardType { get; set; }
            }

            public class TierPriceModel : BaseFaraModel
            {
                public string Price { get; set; }

                public int Quantity { get; set; }
            }

            public class ProductVariantAttributeModel : BaseFaraEntityModel
            {
                public ProductVariantAttributeModel()
                {
                    Values = new List<ProductVariantAttributeValueModel>();
                }

                public int ProductVariantId { get; set; }

                public int ProductAttributeId { get; set; }

                public string Name { get; set; }

                public string Description { get; set; }

                public string TextPrompt { get; set; }

                public bool IsRequired { get; set; }

                public AttributeControlType AttributeControlType { get; set; }

                public IList<ProductVariantAttributeValueModel> Values { get; set; }

            }

            public class ProductVariantAttributeValueModel : BaseFaraEntityModel
            {
                public string Name { get; set; }

                public string PriceAdjustment { get; set; }

                public decimal PriceAdjustmentValue { get; set; }

                public bool IsPreSelected { get; set; }
            }
            
        }

		
    }
}