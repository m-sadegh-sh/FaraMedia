namespace FaraMedia.Web.Framework.Routing.RouteProviders.Sections.DomainObjects {
    using System.Web.Routing;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Layout.Sections;

    public sealed class ArtistsSectionRouteProvider : IRouteProvider {
        public int Priority {
            get { return 1; }
        }

        public void RegisterRoutes(RouteCollection routeCollection) {
            routeCollection.MapStandardRoute(ArtistsSectionConstants.RouteName, new {
                Controller = ArtistsSectionConstants.ControllerName,
                Action = ArtistsSectionConstants.ActionName
            });

            routeCollection.MapStandardRoute(ArtistsSectionConstants.FundamentalsController.List.RouteName, new {
                Controller = ArtistsSectionConstants.FundamentalsController.ControllerName,
                Action = ArtistsSectionConstants.FundamentalsController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(ArtistsSectionConstants.FundamentalsController.New.RouteName, new {
                Controller = ArtistsSectionConstants.FundamentalsController.ControllerName,
                Action = ArtistsSectionConstants.FundamentalsController.New.ActionName
            });

            routeCollection.MapStandardRoute(ArtistsSectionConstants.FundamentalsController.Edit.RouteName, new {
                Controller = ArtistsSectionConstants.FundamentalsController.ControllerName,
                Action = ArtistsSectionConstants.FundamentalsController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(ArtistsSectionConstants.ArtistCommentsController.List.RouteName, new {
                Controller = ArtistsSectionConstants.ArtistCommentsController.ControllerName,
                Action = ArtistsSectionConstants.ArtistCommentsController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.ArtistId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(ArtistsSectionConstants.ArtistCommentsController.Edit.RouteName, new {
                Controller = ArtistsSectionConstants.ArtistCommentsController.ControllerName,
                Action = ArtistsSectionConstants.ArtistCommentsController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(ArtistsSectionConstants.ArtistCommentLikesController.List.RouteName, new {
                Controller = ArtistsSectionConstants.ArtistCommentLikesController.ControllerName,
                Action = ArtistsSectionConstants.ArtistCommentLikesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.ArtistCommentId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(ArtistsSectionConstants.ArtistLikesController.List.RouteName, new {
                Controller = ArtistsSectionConstants.ArtistLikesController.ControllerName,
                Action = ArtistsSectionConstants.ArtistLikesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.ArtistId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(ArtistsSectionConstants.ArtistSharesController.List.RouteName, new {
                Controller = ArtistsSectionConstants.ArtistSharesController.ControllerName,
                Action = ArtistsSectionConstants.ArtistSharesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.ArtistId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(ArtistsSectionConstants.PhotoAlbumsController.List.RouteName, new {
                Controller = ArtistsSectionConstants.PhotoAlbumsController.ControllerName,
                Action = ArtistsSectionConstants.PhotoAlbumsController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.ArtistId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(ArtistsSectionConstants.PhotoAlbumsController.New.RouteName, new {
                Controller = ArtistsSectionConstants.PhotoAlbumsController.ControllerName,
                Action = ArtistsSectionConstants.PhotoAlbumsController.New.ActionName
            }, RouteParameter.Add(KnownParameterNames.ArtistId, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(ArtistsSectionConstants.PhotoAlbumsController.Edit.RouteName, new {
                Controller = ArtistsSectionConstants.PhotoAlbumsController.ControllerName,
                Action = ArtistsSectionConstants.PhotoAlbumsController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(ArtistsSectionConstants.PhotoAlbumCommentsController.List.RouteName, new {
                Controller = ArtistsSectionConstants.PhotoAlbumCommentsController.ControllerName,
                Action = ArtistsSectionConstants.PhotoAlbumCommentsController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.PhotoAlbumId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(ArtistsSectionConstants.PhotoAlbumCommentsController.Edit.RouteName, new {
                Controller = ArtistsSectionConstants.PhotoAlbumCommentsController.ControllerName,
                Action = ArtistsSectionConstants.PhotoAlbumCommentsController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(ArtistsSectionConstants.PhotoAlbumCommentLikesController.List.RouteName, new {
                Controller = ArtistsSectionConstants.PhotoAlbumCommentLikesController.ControllerName,
                Action = ArtistsSectionConstants.PhotoAlbumCommentLikesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.PhotoAlbumCommentId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(ArtistsSectionConstants.PhotoAlbumLikesController.List.RouteName, new {
                Controller = ArtistsSectionConstants.PhotoAlbumLikesController.ControllerName,
                Action = ArtistsSectionConstants.PhotoAlbumLikesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.PhotoAlbumId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(ArtistsSectionConstants.PhotoAlbumSharesController.List.RouteName, new {
                Controller = ArtistsSectionConstants.PhotoAlbumSharesController.ControllerName,
                Action = ArtistsSectionConstants.PhotoAlbumSharesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.PhotoAlbumId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(ArtistsSectionConstants.PhotosController.List.RouteName, new {
                Controller = ArtistsSectionConstants.PhotosController.ControllerName,
                Action = ArtistsSectionConstants.PhotosController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.PhotoAlbumId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(ArtistsSectionConstants.PhotosController.New.RouteName, new {
                Controller = ArtistsSectionConstants.PhotosController.ControllerName,
                Action = ArtistsSectionConstants.PhotosController.New.ActionName
            }, RouteParameter.Add(KnownParameterNames.PhotoAlbumId, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(ArtistsSectionConstants.PhotosController.Edit.RouteName, new {
                Controller = ArtistsSectionConstants.PhotosController.ControllerName,
                Action = ArtistsSectionConstants.PhotosController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(ArtistsSectionConstants.PhotoCommentsController.List.RouteName, new {
                Controller = ArtistsSectionConstants.PhotoCommentsController.ControllerName,
                Action = ArtistsSectionConstants.PhotoCommentsController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.PhotoId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(ArtistsSectionConstants.PhotoCommentsController.Edit.RouteName, new {
                Controller = ArtistsSectionConstants.PhotoCommentsController.ControllerName,
                Action = ArtistsSectionConstants.PhotoCommentsController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(ArtistsSectionConstants.PhotoCommentLikesController.List.RouteName, new {
                Controller = ArtistsSectionConstants.PhotoCommentLikesController.ControllerName,
                Action = ArtistsSectionConstants.PhotoCommentLikesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.PhotoCommentId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(ArtistsSectionConstants.PhotoLikesController.List.RouteName, new {
                Controller = ArtistsSectionConstants.PhotoLikesController.ControllerName,
                Action = ArtistsSectionConstants.PhotoLikesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.PhotoId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(ArtistsSectionConstants.PhotoSharesController.List.RouteName, new {
                Controller = ArtistsSectionConstants.PhotoSharesController.ControllerName,
                Action = ArtistsSectionConstants.PhotoSharesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.PhotoId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));
        }
    }
}