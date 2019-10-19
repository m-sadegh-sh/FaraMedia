using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Fara.Core.Domain.Directory;
using Fara.Services.Directory;
using Fara.Services.Localization;

namespace Fara.Web.Controllers
{
    public class CountryController : BaseFaraController
	{
		

        private readonly ICountryService _countryService;
        private readonly IStateProvinceService _stateProvinceService;
        private readonly ILocalizationService _localizationService;

	    

		

        public CountryController(ICountryService countryService, IStateProvinceService stateProvinceService,
            ILocalizationService localizationService)
		{
            this._countryService = countryService;
            this._stateProvinceService = stateProvinceService;
            this._localizationService = localizationService;
		}

        

        

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetStatesByCountryId(string countryId, bool addEmptyStateIfRequired)
        {
            
            if (string.IsNullOrEmpty(countryId))
                throw new ArgumentNullException("countryId");

            var country = _countryService.GetCountryById(Convert.ToInt32(countryId));
            var states = country != null ? _stateProvinceService.GetStateProvincesByCountryId(country.Id).ToList() : new List<StateProvince>();
            var result = (from s in states
                          select new { id = s.Id, name = s.GetLocalized(x => x.Name) }).ToList();
            if (addEmptyStateIfRequired && result.Count == 0)
                result.Insert(0, new { id = 0, name = _localizationService.GetResource("Address.OtherNonUS") });
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        
    }
}
