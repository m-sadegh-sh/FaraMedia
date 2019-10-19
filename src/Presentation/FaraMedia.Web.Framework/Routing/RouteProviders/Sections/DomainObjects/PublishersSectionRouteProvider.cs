namespace FaraMedia.Web.Framework.Routing.RouteProviders.Sections.DomainObjects {
    using System.Web.Routing;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Layout.Sections;

    public sealed class PublishersSectionRouteProvider : IRouteProvider {
        public int Priority {
            get { return 1; }
        }

        public void RegisterRoutes(RouteCollection routeCollection) {
            routeCollection.MapStandardRoute(PublishersSectionConstants.RouteName, new {
                Controller = PublishersSectionConstants.ControllerName,
                Action = PublishersSectionConstants.ActionName
            });

            routeCollection.MapStandardRoute(PublishersSectionConstants.FundamentalsController.List.RouteName, new {
                Controller = PublishersSectionConstants.FundamentalsController.ControllerName,
                Action = PublishersSectionConstants.FundamentalsController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(PublishersSectionConstants.FundamentalsController.New.RouteName, new {
                Controller = PublishersSectionConstants.FundamentalsController.ControllerName,
                Action = PublishersSectionConstants.FundamentalsController.New.ActionName
            });

            routeCollection.MapStandardRoute(PublishersSectionConstants.FundamentalsController.Edit.RouteName, new {
                Controller = PublishersSectionConstants.FundamentalsController.ControllerName,
                Action = PublishersSectionConstants.FundamentalsController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(PublishersSectionConstants.PublisherCommentsController.List.RouteName, new {
                Controller = PublishersSectionConstants.PublisherCommentsController.ControllerName,
                Action = PublishersSectionConstants.PublisherCommentsController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.PublisherId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(PublishersSectionConstants.PublisherCommentsController.Edit.RouteName, new {
                Controller = PublishersSectionConstants.PublisherCommentsController.ControllerName,
                Action = PublishersSectionConstants.PublisherCommentsController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(PublishersSectionConstants.PublisherCommentLikesController.List.RouteName, new {
                Controller = PublishersSectionConstants.PublisherCommentLikesController.ControllerName,
                Action = PublishersSectionConstants.PublisherCommentLikesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.PublisherCommentId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(PublishersSectionConstants.PublisherLikesController.List.RouteName, new {
                Controller = PublishersSectionConstants.PublisherLikesController.ControllerName,
                Action = PublishersSectionConstants.PublisherLikesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.PublisherId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(PublishersSectionConstants.PublisherSharesController.List.RouteName, new {
                Controller = PublishersSectionConstants.PublisherSharesController.ControllerName,
                Action = PublishersSectionConstants.PublisherSharesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.PublisherId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));
        }
    }
}