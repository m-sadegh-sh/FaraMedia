namespace FaraMedia.Web.Framework.Routing {
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;

    using FaraMedia.Core;
    using FaraMedia.Core.Infrastructure.Extensions;
    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;

    public static class RouteCollectionExtensions {
        public static StandardRoute MapStandardRoute(this RouteCollection routeCollection, string routeName, string url) {
            return MapStandardRoute(routeCollection, routeName, url, constraints: null);
        }

        public static StandardRoute MapStandardRoute(this RouteCollection routeCollection, string routeName) {
            return MapStandardRoute(routeCollection, routeName, null);
        }

        public static StandardRoute MapStandardRoute(this RouteCollection routeCollection, string routeName, string url, object defaults) {
            return MapStandardRoute(routeCollection, routeName, url, defaults, constraints: null);
        }

        public static StandardRoute MapStandardRoute(this RouteCollection routeCollection, string routeName, object defaults) {
            return MapStandardRoute(routeCollection, routeName, defaults, constraints: null);
        }

        public static StandardRoute MapStandardRoute(this RouteCollection routeCollection, string routeName, string domain, string url, string[] routeNamespaces) {
            return MapStandardRoute(routeCollection, routeName, domain, url, null, routeNamespaces);
        }

        public static StandardRoute MapStandardRoute(this RouteCollection routeCollection, string routeName, object defaults, object constraints) {
            return MapStandardRoute(routeCollection, routeName, defaults, constraints, null);
        }

        public static StandardRoute MapStandardRoute(this RouteCollection routeCollection, string routeName, string url, object defaults, object constraints) {
            url = CommonHelper.BuildUrlFromRouteName(url, true, false, true, KnownActionNames.NonPluralizableTokens);

            return MapStandardRoute(routeCollection, routeName, url, defaults, constraints, null);
        }

        public static StandardRoute MapStandardRoute(this RouteCollection routeCollection, string routeName, object defaults, string[] routeNamespaces) {
            return MapStandardRoute(routeCollection, routeName, defaults, null, routeNamespaces);
        }

        public static StandardRoute MapStandardRoute(this RouteCollection routeCollection, string routeName, string url, object defaults, string[] routeNamespaces) {
            return MapStandardRoute(routeCollection, routeName, url, defaults, null, routeNamespaces);
        }

        public static StandardRoute MapStandardRoute(this RouteCollection routeCollection, string routeName, object defaults, object constraints, string[] routeNamespaces) {
            var url = CommonHelper.BuildUrlFromRouteName(routeName, true, false, true, KnownActionNames.NonPluralizableTokens);

            return MapStandardRoute(routeCollection, routeName, url, defaults, constraints, routeNamespaces);
        }

        public static StandardRoute MapStandardRoute(this RouteCollection routeCollection, string routeName, string url, object defaults, object constraints, string[] routeNamespaces) {
            if (routeCollection == null)
                throw new ArgumentNullException("routeCollection");

            var standardRoute = new StandardRoute(url, new MvcRouteHandler()) {
                Defaults = RouteValueDictionaryExtensions.Convert(defaults),
                Constraints = RouteValueDictionaryExtensions.Convert(constraints),
                DataTokens = new RouteValueDictionary()
            };

            foreach (var @default in standardRoute.Defaults.ToList()) {
                if (@default.Value.ToString().Contains("*")) {
                    standardRoute.Defaults.Remove(@default.Key);
                    standardRoute.Defaults.Add(@default.Key, @default.Value.ToString().ReplaceAll("*", ""));
                }
            }

            if (routeNamespaces != null && routeNamespaces.Length > 0)
                standardRoute.DataTokens["Namespaces"] = routeNamespaces;

            routeCollection.Add(routeName, standardRoute);

            return standardRoute;
        }
    }
}