namespace FaraMedia.Web.Framework.Routing.RouteProviders.Sections.DomainObjects {
    using System.Web.Routing;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Layout.Sections;

    public sealed class AlbumsSectionRouteProvider : IRouteProvider {
        public int Priority {
            get { return 1; }
        }

        public void RegisterRoutes(RouteCollection routeCollection) {
            routeCollection.MapStandardRoute(AlbumsSectionConstants.RouteName, new {
                Controller = AlbumsSectionConstants.ControllerName,
                Action = AlbumsSectionConstants.ActionName
            });

            routeCollection.MapStandardRoute(AlbumsSectionConstants.FundamentalsController.List.RouteName, new {
                Controller = AlbumsSectionConstants.FundamentalsController.ControllerName,
                Action = AlbumsSectionConstants.FundamentalsController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(AlbumsSectionConstants.FundamentalsController.New.RouteName, new {
                Controller = AlbumsSectionConstants.FundamentalsController.ControllerName,
                Action = AlbumsSectionConstants.FundamentalsController.New.ActionName
            });

            routeCollection.MapStandardRoute(AlbumsSectionConstants.FundamentalsController.Edit.RouteName, new {
                Controller = AlbumsSectionConstants.FundamentalsController.ControllerName,
                Action = AlbumsSectionConstants.FundamentalsController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(AlbumsSectionConstants.AlbumCommentsController.List.RouteName, new {
                Controller = AlbumsSectionConstants.AlbumCommentsController.ControllerName,
                Action = AlbumsSectionConstants.AlbumCommentsController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.AlbumId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(AlbumsSectionConstants.AlbumCommentsController.Edit.RouteName, new {
                Controller = AlbumsSectionConstants.AlbumCommentsController.ControllerName,
                Action = AlbumsSectionConstants.AlbumCommentsController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(AlbumsSectionConstants.AlbumCommentLikesController.List.RouteName, new {
                Controller = AlbumsSectionConstants.AlbumCommentLikesController.ControllerName,
                Action = AlbumsSectionConstants.AlbumCommentLikesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.AlbumCommentId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(AlbumsSectionConstants.AlbumLikesController.List.RouteName, new {
                Controller = AlbumsSectionConstants.AlbumLikesController.ControllerName,
                Action = AlbumsSectionConstants.AlbumLikesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.AlbumId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(AlbumsSectionConstants.AlbumSharesController.List.RouteName, new {
                Controller = AlbumsSectionConstants.AlbumSharesController.ControllerName,
                Action = AlbumsSectionConstants.AlbumSharesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.AlbumId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));
        }
    }
}