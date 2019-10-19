using System.Collections.Generic;
using System.Web.Mvc;
using Fara.Web.Framework;
using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.Order
{
    public class SubmitReturnRequestModel : BaseFaraModel
    {
        public SubmitReturnRequestModel()
        {
            Items = new List<OrderProductVariantModel>();
            AvailableReturnReasons = new List<SelectListItem>();
            AvailableReturnActions= new List<SelectListItem>();
        }

        public int OrderId { get; set; }
        
        public IList<OrderProductVariantModel> Items { get; set; }
        
        [AllowHtml]
        [FaraResourceDisplayName("ReturnRequests.ReturnReason")]
        public string ReturnReason { get; set; }
        public IList<SelectListItem> AvailableReturnReasons { get; set; }

        [AllowHtml]
        [FaraResourceDisplayName("ReturnRequests.ReturnAction")]
        public string ReturnAction { get; set; }
        public IList<SelectListItem> AvailableReturnActions { get; set; }

        [AllowHtml]
        [FaraResourceDisplayName("ReturnRequests.Comments")]
        public string Comments { get; set; }

        public string Result { get; set; }
        
        

        public class OrderProductVariantModel : BaseFaraEntityModel
        {
            public int ProductId { get; set; }

            public string ProductName { get; set; }

            public string ProductSeName { get; set; }

            public string AttributeInfo { get; set; }

            public string UnitPrice { get; set; }

            public int Quantity { get; set; }
        }

        
    }

}