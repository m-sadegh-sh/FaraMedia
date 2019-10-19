using System.Collections.Generic;
using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.ShoppingCart
{
    public class MiniShoppingCartModel : BaseFaraModel
    {
        public MiniShoppingCartModel()
        {
            Items = new List<ShoppingCartItemModel>();
        }

        public IList<ShoppingCartItemModel> Items { get; set; }
        public int TotalProducts { get; set; }
        public string SubTotal { get; set; }
        public bool DisplayProducts { get; set; }


        

        public class ShoppingCartItemModel : BaseFaraEntityModel
        {
            public int ProductId { get; set; }

            public string ProductName { get; set; }

            public string ProductSeName { get; set; }

            public int Quantity { get; set; }
        }

        
    }
}