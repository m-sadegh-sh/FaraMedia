namespace FaraMedia.Web.Framework.Routing {
    using System.Web.Routing;

    public interface IRouteProvider {
        int Priority { get; }

        void RegisterRoutes(RouteCollection routeCollection);
    }
}