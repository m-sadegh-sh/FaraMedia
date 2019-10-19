using System.Collections.Generic;
using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.Checkout
{
    public class CheckoutConfirmModel : BaseFaraModel
    {
        public CheckoutConfirmModel()
        {
            Warnings = new List<string>();
        }

        public string MinOrderTotalWarning { get; set; }

        public IList<string> Warnings { get; set; }
    }
}