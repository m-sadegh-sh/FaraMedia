using System.Collections.Generic;
using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.Common
{
    public class CurrencySelectorModel : BaseFaraModel
    {
        public CurrencySelectorModel()
        {
            AvailableCurrencies = new List<CurrencyModel>();
        }

        public IList<CurrencyModel> AvailableCurrencies { get; set; }

        public CurrencyModel CurrentCurrency { get; set; }
    }
}