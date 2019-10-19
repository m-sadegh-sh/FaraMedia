namespace FaraMedia.Web.Framework.Routing.RouteProviders.Sections.DomainObjects {
    using System.Web.Routing;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Layout.Sections;

    public sealed class LoggingSectionRouteProvider : IRouteProvider {
        public int Priority {
            get { return 1; }
        }

        public void RegisterRoutes(RouteCollection routeCollection) {
            routeCollection.MapStandardRoute(LoggingSectionConstants.RouteName, new {
                Controller = LoggingSectionConstants.ControllerName,
                Action = LoggingSectionConstants.ActionName
            });

            routeCollection.MapStandardRoute(LoggingSectionConstants.ActivityTypesController.List.RouteName, new {
                Controller = LoggingSectionConstants.ActivityTypesController.ControllerName,
                Action = LoggingSectionConstants.ActivityTypesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(LoggingSectionConstants.ActivityTypesController.New.RouteName, new {
                Controller = LoggingSectionConstants.ActivityTypesController.ControllerName,
                Action = LoggingSectionConstants.ActivityTypesController.New.ActionName
            });

            routeCollection.MapStandardRoute(LoggingSectionConstants.ActivityTypesController.Edit.RouteName, new {
                Controller = LoggingSectionConstants.ActivityTypesController.ControllerName,
                Action = LoggingSectionConstants.ActivityTypesController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(LoggingSectionConstants.ActivitiesController.List.RouteName, new {
                Controller = LoggingSectionConstants.ActivitiesController.ControllerName,
                Action = LoggingSectionConstants.ActivitiesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(LoggingSectionConstants.LogsController.List.RouteName, new {
                Controller = LoggingSectionConstants.LogsController.ControllerName,
                Action = LoggingSectionConstants.LogsController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.Page, KnownConstraints.Int32));
        }
    }
}