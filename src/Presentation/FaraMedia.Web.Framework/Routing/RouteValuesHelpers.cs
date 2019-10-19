namespace FaraMedia.Web.Framework.Routing {
    using System.Collections.Generic;
    using System.Web.Routing;

    public static class RouteValuesHelpers {
        public static RouteValueDictionary MergeRouteValues(string actionName, string controllerName, RouteValueDictionary implicitRouteValues, RouteValueDictionary routeValues, bool includeImplicitMvcValues) {
            var mergedRouteValues = new RouteValueDictionary();

            if (includeImplicitMvcValues) {
                object implicitValue;

                if (implicitRouteValues != null && implicitRouteValues.TryGetValue("action", out implicitValue))
                    mergedRouteValues["action"] = implicitValue;

                if (implicitRouteValues != null && implicitRouteValues.TryGetValue("controller", out implicitValue))
                    mergedRouteValues["controller"] = implicitValue;
            }

            if (routeValues != null) {
                foreach (var routeElement in GetRouteValues(routeValues))
                    mergedRouteValues[routeElement.Key] = routeElement.Value;
            }

            if (actionName != null)
                mergedRouteValues["action"] = actionName;

            if (controllerName != null)
                mergedRouteValues["controller"] = controllerName;

            return mergedRouteValues;
        }

        public static IEnumerable<KeyValuePair<string, object>> GetRouteValues(IDictionary<string, object> routeValues) {
            return (routeValues != null) ? new RouteValueDictionary(routeValues) : new RouteValueDictionary();
        }
    }
}