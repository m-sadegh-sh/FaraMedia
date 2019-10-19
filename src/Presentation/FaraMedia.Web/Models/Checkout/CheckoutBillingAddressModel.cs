﻿using System.Collections.Generic;
using Fara.Web.Framework.Mvc;
using Fara.Web.Models.Common;

namespace Fara.Web.Models.Checkout
{
    public class CheckoutBillingAddressModel : BaseFaraModel
    {
        public CheckoutBillingAddressModel()
        {
            ExistingAddresses = new List<AddressModel>();
            NewAddress = new AddressModel();
        }

        public IList<AddressModel> ExistingAddresses { get; set; }

        public AddressModel NewAddress { get; set; }

        
        
        
        public bool NewAddressPreselected { get; set; }
    }
}