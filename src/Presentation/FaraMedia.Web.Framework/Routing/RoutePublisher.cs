namespace FaraMedia.Web.Framework.Routing {
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;

    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Core.Infrastructure.Extensions;

    public class RoutePublisher : IRoutePublisher {
        public void RegisterRoutes(RouteCollection routeCollection) {
            routeCollection.IgnoreRoute("favicon.ico");

            var routeProviders = EngineContext.Current.ResolveAll<IRouteProvider>().OrderByDescending(rp => rp.Priority);

            routeProviders.ForEach(rp => rp.RegisterRoutes(routeCollection));

            routeCollection.MapRoute("_FARAMEDIA_INTERNAL_ROUTE_", "_FARAMEDIA_INTERNAL_ROUTE_");
        }
    }
}