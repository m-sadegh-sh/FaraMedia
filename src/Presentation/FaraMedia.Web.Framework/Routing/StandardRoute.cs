namespace FaraMedia.Web.Framework.Routing {
    using System.Web.Routing;

    public sealed class StandardRoute : Route {
        public StandardRoute(string url, IRouteHandler routeHandler) : base(url, routeHandler) {}
        public StandardRoute(string url, RouteValueDictionary defaults, IRouteHandler routeHandler) : base(url, defaults, routeHandler) {}
        public StandardRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, IRouteHandler routeHandler) : base(url, defaults, constraints, routeHandler) {}
        public StandardRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, RouteValueDictionary dataTokens, IRouteHandler routeHandler) : base(url, defaults, constraints, dataTokens, routeHandler) {}

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values) {
            var virutalPathData = base.GetVirtualPath(requestContext, values);

            if (virutalPathData == null)
                return null;

            //if (!string.IsNullOrEmpty(virutalPathData.VirtualPath))
            //    virutalPathData.VirtualPath = virutalPathData.VirtualPath.ToStandardUrl().EnsureTrailingSlash();

            return virutalPathData;
        }
    }
}