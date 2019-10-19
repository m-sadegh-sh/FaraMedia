using System;
using System.Collections.Generic;
using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.Customer
{
    public class CustomerDownloadableProductsModel : BaseFaraModel
    {
        public CustomerDownloadableProductsModel()
        {
            Items = new List<DownloadableProductsModel>();
        }

        public IList<DownloadableProductsModel> Items { get; set; }
        public CustomerNavigationModel NavigationModel { get; set; }

        
        public class DownloadableProductsModel : BaseFaraModel
        {
            public Guid OrderProductVariantGuid { get; set; }

            public int OrderId { get; set; }

            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public string ProductSeName { get; set; }
            public string ProductAttributes { get; set; }

            public int DownloadId { get; set; }
            public int LicenseId { get; set; }

            public DateTime CreatedOn { get; set; }
        }
        
    }

    public class UserAgreementModel : BaseFaraModel
    {
        public Guid OrderProductVariantGuid { get; set; }
        public string UserAgreementText { get; set; }
    }
}