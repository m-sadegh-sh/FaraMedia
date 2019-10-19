namespace FaraMedia.Web.Framework.Routing.RouteProviders.Sections.DomainObjects {
    using System.Web.Routing;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Billing;
    using FaraMedia.Data.Schemas.Layout.Sections;

    public sealed class BillingSectionRouteProvider : IRouteProvider {
        public int Priority {
            get { return 1; }
        }

        public void RegisterRoutes(RouteCollection routeCollection) {
            routeCollection.MapStandardRoute(BillingSectionConstants.RouteName, new {
                Controller = BillingSectionConstants.ControllerName,
                Action = BillingSectionConstants.ActionName
            });

            routeCollection.MapStandardRoute(BillingSectionConstants.TransactionDebugsController.List.RouteName, new {
                Controller = BillingSectionConstants.TransactionDebugsController.ControllerName,
                Action = BillingSectionConstants.TransactionDebugsController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.Page, KnownConstraints.Int32));
        }
    }
}