namespace FaraMedia.Web.Framework.Routing {
    using System;
    using System.Web;
    using System.Web.Routing;

    public class GuidRouteConstraint : IRouteConstraint {
        private readonly bool _allowEmpty;

        public GuidRouteConstraint(bool allowEmpty) {
            _allowEmpty = allowEmpty;
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection) {
            if (values.ContainsKey(parameterName)) {
                var stringValue = values[parameterName] as string;

                if (!string.IsNullOrEmpty(stringValue)) {
                    Guid guidValue;

                    return Guid.TryParse(stringValue, out guidValue) && (_allowEmpty || guidValue != Guid.Empty);
                }
            }

            return false;
        }
    }
}