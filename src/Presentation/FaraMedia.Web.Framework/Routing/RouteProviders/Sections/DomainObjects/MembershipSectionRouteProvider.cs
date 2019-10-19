namespace FaraMedia.Web.Framework.Routing.RouteProviders.Sections.DomainObjects {
    using System.Web.Routing;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Layout.Sections;

    public sealed class MembershipSectionRouteProvider : IRouteProvider {
        public int Priority {
            get { return 1; }
        }

        public void RegisterRoutes(RouteCollection routeCollection) {
            routeCollection.MapStandardRoute(MembershipSectionConstants.RouteName, new {
                Controller = MembershipSectionConstants.ControllerName,
                Action = MembershipSectionConstants.ActionName
            });

            routeCollection.MapStandardRoute(MembershipSectionConstants.RolesController.List.RouteName, new {
                Controller = MembershipSectionConstants.RolesController.ControllerName,
                Action = MembershipSectionConstants.RolesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(MembershipSectionConstants.RolesController.New.RouteName, new {
                Controller = MembershipSectionConstants.RolesController.ControllerName,
                Action = MembershipSectionConstants.RolesController.New.ActionName
            });

            routeCollection.MapStandardRoute(MembershipSectionConstants.RolesController.Edit.RouteName, new {
                Controller = MembershipSectionConstants.RolesController.ControllerName,
                Action = MembershipSectionConstants.RolesController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(MembershipSectionConstants.UsersController.List.RouteName, new {
                Controller = MembershipSectionConstants.UsersController.ControllerName,
                Action = MembershipSectionConstants.UsersController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(MembershipSectionConstants.UsersController.New.RouteName, new {
                Controller = MembershipSectionConstants.UsersController.ControllerName,
                Action = MembershipSectionConstants.UsersController.New.ActionName
            });

            routeCollection.MapStandardRoute(MembershipSectionConstants.UsersController.Edit.RouteName, new {
                Controller = MembershipSectionConstants.UsersController.ControllerName,
                Action = MembershipSectionConstants.UsersController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));
        }
    }
}