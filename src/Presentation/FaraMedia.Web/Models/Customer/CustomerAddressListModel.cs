using System.Collections.Generic;
using Fara.Web.Framework.Mvc;
using Fara.Web.Models.Common;

namespace Fara.Web.Models.Customer
{
    public class CustomerAddressListModel : BaseFaraModel
    {
        public CustomerAddressListModel()
        {
            Addresses = new List<AddressModel>();
        }

        public IList<AddressModel> Addresses { get; set; }
        public CustomerNavigationModel NavigationModel { get; set; }
    }
}