namespace FaraMedia.Web.Framework.Mvc.Attributes {
    using System.Web.Mvc;
    using System.Web.Routing;

    using FaraMedia.Core;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Core.Infrastructure.Extensions;
    using FaraMedia.Data.Schemas.Authenticate;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.Root;
    using FaraMedia.Services.Security;
    using FaraMedia.Services.Configuration;

    public class AppClosedAttribute : ActionFilterAttribute {
        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            if (filterContext == null || filterContext.HttpContext == null)
                return;

            var request = filterContext.HttpContext.Request;
            if (request == null)
                return;

            var actionName = filterContext.ActionDescriptor.ActionName;
            if (string.IsNullOrEmpty(actionName))
                return;

            var controllerName = filterContext.Controller.ToString();
            if (string.IsNullOrEmpty(controllerName))
                return;

            if (filterContext.IsChildAction)
                return;

            var applicationSettings = EngineContext.Current.Resolve<IApplicationSettingsService>().LoadApplicationSettings();
            if (!applicationSettings.IsClosed || filterContext.RouteData.Route.Any(RouteTable.Routes[AuthenticateSectionConstants.SignController.In.ActionName], RouteTable.Routes[AuthenticateSectionConstants.SignController.Out.ActionName]))
                return;

            if (applicationSettings.IsClosedAllowForAdmins && EngineContext.Current.Resolve<IWorkContext>().CurrentUser.IsAdmin())
                return;

            filterContext.Result = new RedirectToRouteResult(RootSectionConstants.ErrorsController.AppClosed.RouteName, null);
        }
    }
}