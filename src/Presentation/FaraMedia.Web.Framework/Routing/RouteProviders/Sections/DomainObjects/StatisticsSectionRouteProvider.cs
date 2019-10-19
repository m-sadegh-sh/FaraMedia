namespace FaraMedia.Web.Framework.Routing.RouteProviders.Sections.DomainObjects {
    using System.Web.Routing;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Layout.Sections;

    public sealed class StatisticsSectionRouteProvider : IRouteProvider {
        public int Priority {
            get { return 1; }
        }

        public void RegisterRoutes(RouteCollection routeCollection) {
            routeCollection.MapStandardRoute(StatisticsSectionConstants.RouteName, new {
                Controller = StatisticsSectionConstants.ControllerName,
                Action = StatisticsSectionConstants.ActionName
            });

            routeCollection.MapStandardRoute(StatisticsSectionConstants.RedirectorsController.List.RouteName, new {
                Controller = StatisticsSectionConstants.RedirectorsController.ControllerName,
                Action = StatisticsSectionConstants.RedirectorsController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(StatisticsSectionConstants.RedirectorsController.New.RouteName, new {
                Controller = StatisticsSectionConstants.RedirectorsController.ControllerName,
                Action = StatisticsSectionConstants.RedirectorsController.New.ActionName
            });

            routeCollection.MapStandardRoute(StatisticsSectionConstants.RedirectorsController.Edit.RouteName, new {
                Controller = StatisticsSectionConstants.RedirectorsController.ControllerName,
                Action = StatisticsSectionConstants.RedirectorsController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));
        }
    }
}