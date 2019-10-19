namespace FaraMedia.Web.Framework.Routing {
    using System.Web.Mvc;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;

    public static class UrlHelperExtensions {
        public static string ListRouteUrl(this UrlHelper urlHelper, string routeName, int page, object routeValues = null) {
            var routeValueDictionary = RouteValueDictionaryExtensions.Convert(routeValues);

            routeValueDictionary.Add(KnownParameterNames.Page, page);

            return urlHelper.RouteUrl(routeName, routeValueDictionary);
        }

        public static string RouteUrlWithId(this UrlHelper urlHelper, string routeName, long id) {
            return RouteUrlWithId(urlHelper, routeName, id, null);
        }

        public static string RouteUrlWithId(this UrlHelper urlHelper, string routeName, long id, object routeValues) {
            var routeValueDictionary = RouteValueDictionaryExtensions.Convert(routeValues);

            routeValueDictionary.Add(KnownParameterNames.Id, id);

            return urlHelper.RouteUrl(routeName, routeValueDictionary);
        }
    }
}