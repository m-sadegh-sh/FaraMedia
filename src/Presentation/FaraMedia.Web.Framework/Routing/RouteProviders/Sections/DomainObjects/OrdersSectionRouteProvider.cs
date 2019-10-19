namespace FaraMedia.Web.Framework.Routing.RouteProviders.Sections.DomainObjects {
    using System.Web.Routing;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Layout.Sections;

    public sealed class OrdersSectionRouteProvider : IRouteProvider {
        public int Priority {
            get { return 1; }
        }

        public void RegisterRoutes(RouteCollection routeCollection) {
            routeCollection.MapStandardRoute(OrdersSectionConstants.RouteName, new {
                Controller = OrdersSectionConstants.ControllerName,
                Action = OrdersSectionConstants.ActionName
            });

            routeCollection.MapStandardRoute(OrdersSectionConstants.BillingController.List.RouteName, new {
                Controller = OrdersSectionConstants.BillingController.ControllerName,
                Action = OrdersSectionConstants.BillingController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(OrdersSectionConstants.BillingController.New.RouteName, new {
                Controller = OrdersSectionConstants.BillingController.ControllerName,
                Action = OrdersSectionConstants.BillingController.New.ActionName
            });

            routeCollection.MapStandardRoute(OrdersSectionConstants.BillingController.Edit.RouteName, new {
                Controller = OrdersSectionConstants.BillingController.ControllerName,
                Action = OrdersSectionConstants.BillingController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(OrdersSectionConstants.OrderNotesController.List.RouteName, new {
                Controller = OrdersSectionConstants.OrderNotesController.ControllerName,
                Action = OrdersSectionConstants.OrderNotesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.OrderId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(OrdersSectionConstants.OrderNotesController.New.RouteName, new {
                Controller = OrdersSectionConstants.OrderNotesController.ControllerName,
                Action = OrdersSectionConstants.OrderNotesController.New.ActionName
            }, RouteParameter.Add(KnownParameterNames.OrderId, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(OrdersSectionConstants.OrderNotesController.Edit.RouteName, new {
                Controller = OrdersSectionConstants.OrderNotesController.ControllerName,
                Action = OrdersSectionConstants.OrderNotesController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(OrdersSectionConstants.OrderLinesController.List.RouteName, new {
                Controller = OrdersSectionConstants.OrderLinesController.ControllerName,
                Action = OrdersSectionConstants.OrderLinesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.OrderId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(OrdersSectionConstants.OrderLinesController.New.RouteName, new {
                Controller = OrdersSectionConstants.OrderLinesController.ControllerName,
                Action = OrdersSectionConstants.OrderLinesController.New.ActionName
            }, RouteParameter.Add(KnownParameterNames.OrderId, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(OrdersSectionConstants.OrderLinesController.Edit.RouteName, new {
                Controller = OrdersSectionConstants.OrderLinesController.ControllerName,
                Action = OrdersSectionConstants.OrderLinesController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(OrdersSectionConstants.OrderLineDownloadsController.List.RouteName, new {
                Controller = OrdersSectionConstants.OrderLineDownloadsController.ControllerName,
                Action = OrdersSectionConstants.OrderLineDownloadsController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.OrderLineId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(OrdersSectionConstants.OrderLineDownloadsController.Edit.RouteName, new {
                Controller = OrdersSectionConstants.OrderLineDownloadsController.ControllerName,
                Action = OrdersSectionConstants.OrderLineDownloadsController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));
        }
    }
}