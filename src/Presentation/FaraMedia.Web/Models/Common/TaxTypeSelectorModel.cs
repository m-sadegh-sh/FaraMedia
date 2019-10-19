using Fara.Core.Domain.Tax;
using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.Common
{
    public class TaxTypeSelectorModel : BaseFaraModel
    {
        public bool Enabled { get; set; }

        public TaxDisplayType CurrentTaxType { get; set; }
    }
}