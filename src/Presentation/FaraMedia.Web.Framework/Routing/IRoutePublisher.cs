namespace FaraMedia.Web.Framework.Routing {
    using System.Web.Routing;

    public interface IRoutePublisher {
        void RegisterRoutes(RouteCollection routeCollection);
    }
}