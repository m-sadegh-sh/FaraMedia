using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Fara.Web.Framework;
using Fara.Web.Framework.Mvc;
using Fara.Web.Validators.Common;

namespace Fara.Web.Models.Common
{
    [Validator(typeof(AddressValidator))]
    public class AddressModel : BaseFaraEntityModel
    {
        public AddressModel()
        {
            AvailableCountries = new List<SelectListItem>();
            AvailableStates = new List<SelectListItem>();
        }

        [FaraResourceDisplayName("Address.Fields.FirstName")]
        [AllowHtml]
        public string FirstName { get; set; }
        [FaraResourceDisplayName("Address.Fields.LastName")]
        [AllowHtml]
        public string LastName { get; set; }
        [FaraResourceDisplayName("Address.Fields.Email")]
        [AllowHtml]
        public string Email { get; set; }
        [FaraResourceDisplayName("Address.Fields.Company")]
        [AllowHtml]
        public string Company { get; set; }
        [FaraResourceDisplayName("Address.Fields.Country")]
        public int? CountryId { get; set; }
        [FaraResourceDisplayName("Address.Fields.Country")]
        [AllowHtml]
        public string CountryName { get; set; }
        [FaraResourceDisplayName("Address.Fields.StateProvince")]
        public int? StateProvinceId { get; set; }
        [FaraResourceDisplayName("Address.Fields.StateProvince")]
        [AllowHtml]
        public string StateProvinceName { get; set; }
        [FaraResourceDisplayName("Address.Fields.City")]
        [AllowHtml]
        public string City { get; set; }
        [FaraResourceDisplayName("Address.Fields.Address1")]
        [AllowHtml]
        public string Address1 { get; set; }
        [FaraResourceDisplayName("Address.Fields.Address2")]
        [AllowHtml]
        public string Address2 { get; set; }
        [FaraResourceDisplayName("Address.Fields.ZipPostalCode")]
        [AllowHtml]
        public string ZipPostalCode { get; set; }
        [FaraResourceDisplayName("Address.Fields.PhoneNumber")]
        [AllowHtml]
        public string PhoneNumber { get; set; }
        [FaraResourceDisplayName("Address.Fields.FaxNumber")]
        [AllowHtml]
        public string FaxNumber { get; set; }

        public IList<SelectListItem> AvailableCountries { get; set; }
        public IList<SelectListItem> AvailableStates { get; set; }

        public bool FirstNameDisabled { get; set; }
        public bool LastNameDisabled { get; set; }
        public bool EmailDisabled { get; set; }
        public bool CompanyDisabled { get; set; }
        public bool CountryDisabled { get; set; }
        public bool StateProvinceDisabled { get; set; }
        public bool CityDisabled { get; set; }
        public bool Address1Disabled { get; set; }
        public bool Address2Disabled { get; set; }
        public bool ZipPostalCodeDisabled { get; set; }
        public bool PhoneNumberDisabled { get; set; }
        public bool FaxNumberDisabled { get; set; }
    }
}