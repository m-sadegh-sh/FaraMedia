namespace FaraMedia.Web.Framework.Routing.RouteProviders.Sections.DomainObjects {
    using System.Web.Routing;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Layout.Sections;

    public sealed class TracksSectionRouteProvider : IRouteProvider {
        public int Priority {
            get { return 1; }
        }

        public void RegisterRoutes(RouteCollection routeCollection) {
            routeCollection.MapStandardRoute(TracksSectionConstants.RouteName, new {
                Controller = TracksSectionConstants.ControllerName,
                Action = TracksSectionConstants.ActionName
            });

            routeCollection.MapStandardRoute(TracksSectionConstants.FundamentalsController.List.RouteName, new {
                Controller = TracksSectionConstants.FundamentalsController.ControllerName,
                Action = TracksSectionConstants.FundamentalsController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(TracksSectionConstants.FundamentalsController.New.RouteName, new {
                Controller = TracksSectionConstants.FundamentalsController.ControllerName,
                Action = TracksSectionConstants.FundamentalsController.New.ActionName
            });

            routeCollection.MapStandardRoute(TracksSectionConstants.FundamentalsController.Edit.RouteName, new {
                Controller = TracksSectionConstants.FundamentalsController.ControllerName,
                Action = TracksSectionConstants.FundamentalsController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(TracksSectionConstants.TrackCommentsController.List.RouteName, new {
                Controller = TracksSectionConstants.TrackCommentsController.ControllerName,
                Action = TracksSectionConstants.TrackCommentsController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.TrackId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(TracksSectionConstants.TrackCommentsController.Edit.RouteName, new {
                Controller = TracksSectionConstants.TrackCommentsController.ControllerName,
                Action = TracksSectionConstants.TrackCommentsController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(TracksSectionConstants.TrackCommentLikesController.List.RouteName, new {
                Controller = TracksSectionConstants.TrackCommentLikesController.ControllerName,
                Action = TracksSectionConstants.TrackCommentLikesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.TrackCommentId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(TracksSectionConstants.TrackLikesController.List.RouteName, new {
                Controller = TracksSectionConstants.TrackLikesController.ControllerName,
                Action = TracksSectionConstants.TrackLikesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.TrackId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(TracksSectionConstants.TrackSharesController.List.RouteName, new {
                Controller = TracksSectionConstants.TrackSharesController.ControllerName,
                Action = TracksSectionConstants.TrackSharesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.TrackId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));
        }
    }
}