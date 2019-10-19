namespace FaraMedia.Web.Framework.Routing {
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    public static class RouteUrlProvider {
        public static string GetUrl(string routeName, RouteValueDictionary routeValues = null) {
            var requestContext = new RequestContext(new HttpContextWrapper(HttpContext.Current), new RouteData());

            var urlHelper = new UrlHelper(requestContext);

            var url = urlHelper.RouteUrl(routeName, routeValues);

            return url;
        }
    }
}