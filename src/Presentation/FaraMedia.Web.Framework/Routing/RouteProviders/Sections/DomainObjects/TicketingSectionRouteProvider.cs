namespace FaraMedia.Web.Framework.Routing.RouteProviders.Sections.DomainObjects {
    using System.Web.Routing;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Layout.Sections;

    public sealed class TicketingSectionRouteProvider : IRouteProvider {
        public int Priority {
            get { return 1; }
        }

        public void RegisterRoutes(RouteCollection routeCollection) {
            routeCollection.MapStandardRoute(TicketingSectionConstants.RouteName, new {
                Controller = TicketingSectionConstants.ControllerName,
                Action = TicketingSectionConstants.ActionName
            });

            routeCollection.MapStandardRoute(TicketingSectionConstants.TicketsController.List.RouteName, new {
                Controller = TicketingSectionConstants.TicketsController.ControllerName,
                Action = TicketingSectionConstants.TicketsController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(TicketingSectionConstants.TicketsController.New.RouteName, new {
                Controller = TicketingSectionConstants.TicketsController.ControllerName,
                Action = TicketingSectionConstants.TicketsController.New.ActionName
            });

            routeCollection.MapStandardRoute(TicketingSectionConstants.TicketsController.Edit.RouteName, new {
                Controller = TicketingSectionConstants.TicketsController.ControllerName,
                Action = TicketingSectionConstants.TicketsController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(TicketingSectionConstants.TicketResponsesController.List.RouteName, new {
                Controller = TicketingSectionConstants.TicketResponsesController.ControllerName,
                Action = TicketingSectionConstants.TicketResponsesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.Page, KnownConstraints.Int32).Append(KnownParameterNames.TicketId, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(TicketingSectionConstants.TicketResponsesController.New.RouteName, new {
                Controller = TicketingSectionConstants.TicketResponsesController.ControllerName,
                Action = TicketingSectionConstants.TicketResponsesController.New.ActionName
            }, RouteParameter.Add(KnownParameterNames.TicketId, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(TicketingSectionConstants.TicketResponsesController.Edit.RouteName, new {
                Controller = TicketingSectionConstants.TicketResponsesController.ControllerName,
                Action = TicketingSectionConstants.TicketResponsesController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));
        }
    }
}