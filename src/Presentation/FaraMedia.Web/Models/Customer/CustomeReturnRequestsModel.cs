using System;
using System.Collections.Generic;
using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.Customer
{
    public class CustomeReturnRequestsModel : BaseFaraModel
    {
        public CustomeReturnRequestsModel()
        {
            Items = new List<ReturnRequestModel>();
        }

        public IList<ReturnRequestModel> Items { get; set; }
        public CustomerNavigationModel NavigationModel { get; set; }

        
        public class ReturnRequestModel : BaseFaraEntityModel
        {
            public string ReturnRequestStatus { get; set; }
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public string ProductSeName { get; set; }
            public int Quantity { get; set; }

            public string ReturnReason { get; set; }
            public string ReturnAction { get; set; }
            public string Comments { get; set; }

            public DateTime CreatedOn { get; set; }
        }
        
    }
}