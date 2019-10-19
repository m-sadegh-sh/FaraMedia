namespace FaraMedia.Web.Framework.Routing.RouteProviders.Sections.DomainObjects {
    using System.Web.Routing;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Layout.Sections;

    public sealed class TasksSectionRouteProvider : IRouteProvider {
        public int Priority {
            get { return 1; }
        }

        public void RegisterRoutes(RouteCollection routeCollection) {
            routeCollection.MapStandardRoute(TasksSectionConstants.RouteName, new {
                Controller = TasksSectionConstants.ControllerName,
                Action = TasksSectionConstants.ActionName
            });

            routeCollection.MapStandardRoute(TasksSectionConstants.ScheduleTasksController.List.RouteName, new {
                Controller = TasksSectionConstants.ScheduleTasksController.ControllerName,
                Action = TasksSectionConstants.ScheduleTasksController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(TasksSectionConstants.ScheduleTasksController.New.RouteName, new {
                Controller = TasksSectionConstants.ScheduleTasksController.ControllerName,
                Action = TasksSectionConstants.ScheduleTasksController.New.ActionName
            });

            routeCollection.MapStandardRoute(TasksSectionConstants.ScheduleTasksController.Edit.RouteName, new {
                Controller = TasksSectionConstants.ScheduleTasksController.ControllerName,
                Action = TasksSectionConstants.ScheduleTasksController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));
        }
    }
}