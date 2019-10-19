namespace FaraMedia.Web.Framework.Routing.RouteProviders.Sections.Application {
    using System.Web.Routing;

    using FaraMedia.Data.Schemas.Authenticate;
    using FaraMedia.Data.Schemas.Layout.Sections;

    public sealed class AuthenticateSectionRouteProvider : IRouteProvider {
        public int Priority {
            get { return 1; }
        }

        public void RegisterRoutes(RouteCollection routeCollection) {
            routeCollection.MapStandardRoute(AuthenticateSectionConstants.SignController.In.RouteName, new {
                Controller = AuthenticateSectionConstants.SignController.ControllerName,
                Action = AuthenticateSectionConstants.SignController.In.ActionName
            });

            routeCollection.MapStandardRoute(AuthenticateSectionConstants.SignController.Out.RouteName, new {
                Controller = AuthenticateSectionConstants.SignController.ControllerName,
                Action = AuthenticateSectionConstants.SignController.Out.ActionName
            });
        }
    }
}