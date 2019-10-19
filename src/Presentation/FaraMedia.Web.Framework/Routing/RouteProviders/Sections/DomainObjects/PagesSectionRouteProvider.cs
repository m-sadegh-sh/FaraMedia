namespace FaraMedia.Web.Framework.Routing.RouteProviders.Sections.DomainObjects {
    using System.Web.Routing;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Layout.Sections;

    public sealed class PagesSectionRouteProvider : IRouteProvider {
        public int Priority {
            get { return 1; }
        }

        public void RegisterRoutes(RouteCollection routeCollection) {
            routeCollection.MapStandardRoute(PagesSectionConstants.RouteName, new {
                Controller = PagesSectionConstants.ControllerName,
                Action = PagesSectionConstants.ActionName
            });

            routeCollection.MapStandardRoute(PagesSectionConstants.GroupsController.List.RouteName, new {
                Controller = PagesSectionConstants.GroupsController.ControllerName,
                Action = PagesSectionConstants.GroupsController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(PagesSectionConstants.GroupsController.New.RouteName, new {
                Controller = PagesSectionConstants.GroupsController.ControllerName,
                Action = PagesSectionConstants.GroupsController.New.ActionName
            });

            routeCollection.MapStandardRoute(PagesSectionConstants.GroupsController.Edit.RouteName, new {
                Controller = PagesSectionConstants.GroupsController.ControllerName,
                Action = PagesSectionConstants.GroupsController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(PagesSectionConstants.ContentManagementController.List.RouteName, new {
                Controller = PagesSectionConstants.ContentManagementController.ControllerName,
                Action = PagesSectionConstants.ContentManagementController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(PagesSectionConstants.ContentManagementController.New.RouteName, new {
                Controller = PagesSectionConstants.ContentManagementController.ControllerName,
                Action = PagesSectionConstants.ContentManagementController.New.ActionName
            });

            routeCollection.MapStandardRoute(PagesSectionConstants.ContentManagementController.Edit.RouteName, new {
                Controller = PagesSectionConstants.ContentManagementController.ControllerName,
                Action = PagesSectionConstants.ContentManagementController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));
        }
    }
}