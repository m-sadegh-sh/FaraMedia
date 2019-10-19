using System.Web.Mvc;
using System.Web.Routing;
using Fara.Services.Authentication.External;
using Fara.Web.Models.Customer;
using System.Collections.Generic;

namespace Fara.Web.Controllers
{

    public class ExternalAuthenticationController : BaseFaraController
    {
		

        private readonly IOpenAuthenticationService _openAuthenticationService;

        

		

        public ExternalAuthenticationController(IOpenAuthenticationService openAuthenticationService)
        {
            this._openAuthenticationService = openAuthenticationService;
        }

        

        

        public RedirectResult RemoveParameterAssociation(string returnUrl)
        {
            ExternalAuthorizerHelper.RemoveParameters();
            return Redirect(returnUrl);
        }

        [ChildActionOnly]
        public ActionResult ExternalMethods()
        {
            
            var model = new List<ExternalAuthenticationMethodModel>();

            var externalAuthenticationMethods = _openAuthenticationService.LoadActiveExternalAuthenticationMethods();
            foreach (var eam in externalAuthenticationMethods)
            {
                var eamModel = new ExternalAuthenticationMethodModel();

                string actionName;
                string controllerName;
                RouteValueDictionary routeValues;
                eam.GetPublicInfoRoute(out actionName, out controllerName, out routeValues);
                eamModel.ActionName = actionName;
                eamModel.ControllerName = controllerName;
                eamModel.RouteValues = routeValues;

                model.Add(eamModel);
            }

            return PartialView(model);
        }

        
    }
}
