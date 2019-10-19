using Fara.Web.Framework.Mvc;
using Fara.Web.Models.Common;

namespace Fara.Web.Models.Customer
{
    public class CustomerAddressEditModel : BaseFaraModel
    {
        public AddressModel Address { get; set; }
        public CustomerNavigationModel NavigationModel { get; set; }
    }
}