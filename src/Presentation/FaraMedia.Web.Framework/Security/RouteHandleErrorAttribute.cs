namespace FaraMedia.Web.Framework.Security {
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    using FaraMedia.Core.Infrastructure.Extensions;
    using FaraMedia.Core.Routing;

    public sealed class RouteHandleErrorAttribute : HandleErrorAttribute {
        private readonly string _routeName;
        private readonly RouteValueDictionary _routeValues;

        public RouteHandleErrorAttribute(string routeName) : this(routeName, null) {}

        public RouteHandleErrorAttribute(string routeName, object routeValues) {
            _routeName = routeName;
            _routeValues = RouteValueDictionaryExtensions.Convert(routeValues);
        }

        public override void OnException(ExceptionContext filterContext) {
            if (filterContext == null)
                throw new ArgumentNullException("filterContext");

            if (filterContext.IsChildAction)
                return;

            if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled)
                return;

            var exception = filterContext.Exception;

            if (new HttpException(null, exception).GetHttpCode() != 500)
                return;

            if (!ExceptionType.IsInstanceOfType(exception))
                return;

            _routeValues.Add("url", filterContext.HttpContext.Request.RawUrl);

            filterContext.Result = new RedirectToRouteResult(_routeName.ReplaceAll("*", ""), _routeValues);

            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500;

            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
        }
    }
}