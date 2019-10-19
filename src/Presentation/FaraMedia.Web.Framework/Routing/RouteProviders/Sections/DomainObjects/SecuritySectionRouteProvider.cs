namespace FaraMedia.Web.Framework.Routing.RouteProviders.Sections.DomainObjects {
    using System.Web.Routing;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.Security;

    public sealed class SecuritySectionRouteProvider : IRouteProvider {
        public int Priority {
            get { return 1; }
        }

        public void RegisterRoutes(RouteCollection routeCollection) {
            routeCollection.MapStandardRoute(SecuritySectionConstants.RouteName, new {
                Controller = SecuritySectionConstants.ControllerName,
                Action = SecuritySectionConstants.ActionName
            });

            routeCollection.MapStandardRoute(SecuritySectionConstants.BannedIpsController.List.RouteName, new {
                Controller = SecuritySectionConstants.BannedIpsController.ControllerName,
                Action = SecuritySectionConstants.BannedIpsController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(SecuritySectionConstants.BannedIpsController.New.RouteName, new {
                Controller = SecuritySectionConstants.BannedIpsController.ControllerName,
                Action = SecuritySectionConstants.BannedIpsController.New.ActionName
            });

            routeCollection.MapStandardRoute(SecuritySectionConstants.BannedIpsController.Edit.RouteName, new {
                Controller = SecuritySectionConstants.BannedIpsController.ControllerName,
                Action = SecuritySectionConstants.BannedIpsController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(SecuritySectionConstants.PermissionRecordsController.List.RouteName, new {
                Controller = SecuritySectionConstants.PermissionRecordsController.ControllerName,
                Action = SecuritySectionConstants.PermissionRecordsController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(SecuritySectionConstants.PermissionRecordsController.New.RouteName, new {
                Controller = SecuritySectionConstants.PermissionRecordsController.ControllerName,
                Action = SecuritySectionConstants.PermissionRecordsController.New.ActionName
            });

            routeCollection.MapStandardRoute(SecuritySectionConstants.PermissionRecordsController.Edit.RouteName, new {
                Controller = SecuritySectionConstants.PermissionRecordsController.ControllerName,
                Action = SecuritySectionConstants.PermissionRecordsController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));
        }
    }
}