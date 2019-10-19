namespace FaraMedia.Web.Framework.Routing.RouteProviders.Sections.Application {
    using System.Web.Routing;

    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.Root;

    public sealed class RootSectionRouteProvider : IRouteProvider {
        public int Priority {
            get { return 100; }
        }

        public void RegisterRoutes(RouteCollection routeCollection) {
            routeCollection.MapStandardRoute(RootSectionConstants.CommonController.Root.RouteName, "", new {
                Controller = RootSectionConstants.CommonController.ControllerName,
                Action = RootSectionConstants.CommonController.Root.ActionName
            });

            routeCollection.MapStandardRoute(RootSectionConstants.CommonController.Home.RouteName, RootSectionConstants.CommonController.Home.ActionName, new {
                Controller = RootSectionConstants.CommonController.ControllerName,
                Action = RootSectionConstants.CommonController.Home.ActionName
            });

            routeCollection.MapStandardRoute(RootSectionConstants.ErrorsController.GenericError.RouteName, RootSectionConstants.ErrorsController.GenericError.ActionName, new {
                Controller = RootSectionConstants.ErrorsController.ControllerName,
                Action = RootSectionConstants.ErrorsController.GenericError.ActionName
            });

            routeCollection.MapStandardRoute(RootSectionConstants.ErrorsController.NotFound.RouteName, RootSectionConstants.ErrorsController.NotFound.ActionName, new {
                Controller = RootSectionConstants.ErrorsController.ControllerName,
                Action = RootSectionConstants.ErrorsController.NotFound.ActionName
            });

            routeCollection.MapStandardRoute(RootSectionConstants.ErrorsController.AccessDenied.RouteName, RootSectionConstants.ErrorsController.AccessDenied.ActionName, new {
                Controller = RootSectionConstants.ErrorsController.ControllerName,
                Action = RootSectionConstants.ErrorsController.AccessDenied.ActionName
            });

            routeCollection.MapStandardRoute(RootSectionConstants.ErrorsController.AppClosed.RouteName, RootSectionConstants.ErrorsController.AppClosed.ActionName, new {
                Controller = RootSectionConstants.ErrorsController.ControllerName,
                Action = RootSectionConstants.ErrorsController.AppClosed.ActionName
            });

            routeCollection.MapStandardRoute(RootSectionConstants.MaintenanceController.ClearCache.RouteName, RootSectionConstants.MaintenanceController.ClearCache.ActionName, new {
                Controller = RootSectionConstants.MaintenanceController.ControllerName,
                Action = RootSectionConstants.MaintenanceController.ClearCache.ActionName
            });

            routeCollection.MapStandardRoute(RootSectionConstants.MaintenanceController.RecoverDefaults.RouteName, RootSectionConstants.MaintenanceController.RecoverDefaults.ActionName, new {
                Controller = RootSectionConstants.MaintenanceController.ControllerName,
                Action = RootSectionConstants.MaintenanceController.RecoverDefaults.ActionName
            });

            routeCollection.MapStandardRoute(RootSectionConstants.MaintenanceController.RestartApplication.RouteName, RootSectionConstants.MaintenanceController.RestartApplication.ActionName, new {
                Controller = RootSectionConstants.MaintenanceController.ControllerName,
                Action = RootSectionConstants.MaintenanceController.RestartApplication.ActionName
            });
        }
    }
}