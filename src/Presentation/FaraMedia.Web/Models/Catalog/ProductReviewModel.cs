using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Fara.Web.Framework;
using Fara.Web.Framework.Mvc;
using Fara.Web.Validators.Catalog;

namespace Fara.Web.Models.Catalog
{
    public class ProductReviewOverviewModel : BaseFaraModel
    {
        public int ProductId { get; set; }

        public int RatingSum { get; set; }

        public int TotalReviews { get; set; }

        public bool AllowCustomerReviews { get; set; }
    }

    [Validator(typeof(ProductReviewsValidator))]
    public class ProductReviewsModel : BaseFaraModel
    {
        public ProductReviewsModel()
        {
            Items = new List<ProductReviewModel>();
            AddProductReview = new AddProductReviewModel();
        }
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductSeName { get; set; }

        public IList<ProductReviewModel> Items { get; set; }
        public AddProductReviewModel AddProductReview { get; set; }
    }

    public class ProductReviewModel : BaseFaraEntityModel
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public bool AllowViewingProfiles { get; set; }
        
        public string Title { get; set; }

        public string ReviewText { get; set; }

        public int Rating { get; set; }

        public ProductReviewHelpfulnessModel Helpfulness { get; set; }

        public string WrittenOnStr { get; set; }
    }


    public class ProductReviewHelpfulnessModel : BaseFaraModel
    {
        public int ProductReviewId { get; set; }

        public int HelpfulYesTotal { get; set; }

        public int HelpfulNoTotal { get; set; }
    } 

    public class AddProductReviewModel : BaseFaraModel
    {
        [AllowHtml]
        [FaraResourceDisplayName("Reviews.Fields.Title")]
        public string Title { get; set; }

        [AllowHtml]
        [FaraResourceDisplayName("Reviews.Fields.ReviewText")]
        public string ReviewText { get; set; }

        [FaraResourceDisplayName("Reviews.Fields.Rating")]
        public int Rating { get; set; }

        public bool CanCurrentCustomerLeaveReview { get; set; }
        public bool SuccessfullyAdded { get; set; }
        public string Result { get; set; }
    }
}