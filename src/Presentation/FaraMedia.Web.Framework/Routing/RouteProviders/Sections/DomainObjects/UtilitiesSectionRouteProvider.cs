namespace FaraMedia.Web.Framework.Routing.RouteProviders.Sections.DomainObjects {
    using System.Web.Routing;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Layout.Sections;

    public sealed class UtilitiesSectionRouteProvider : IRouteProvider {
        public int Priority {
            get { return 1; }
        }

        public void RegisterRoutes(RouteCollection routeCollection) {
            routeCollection.MapStandardRoute(UtilitiesSectionConstants.RouteName, new {
                Controller = UtilitiesSectionConstants.ControllerName,
                Action = UtilitiesSectionConstants.ActionName
            });

            routeCollection.MapStandardRoute(UtilitiesSectionConstants.ToDosController.List.RouteName, new {
                Controller = UtilitiesSectionConstants.ToDosController.ControllerName,
                Action = UtilitiesSectionConstants.ToDosController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(UtilitiesSectionConstants.ToDosController.New.RouteName, new {
                Controller = UtilitiesSectionConstants.ToDosController.ControllerName,
                Action = UtilitiesSectionConstants.ToDosController.New.ActionName
            });

            routeCollection.MapStandardRoute(UtilitiesSectionConstants.ToDosController.Edit.RouteName, new {
                Controller = UtilitiesSectionConstants.ToDosController.ControllerName,
                Action = UtilitiesSectionConstants.ToDosController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));
        }
    }
}