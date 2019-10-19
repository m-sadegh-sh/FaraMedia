namespace FaraMedia.Web.Framework.Routing.RouteProviders.Sections.DomainObjects {
    using System.Web.Routing;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Layout.Sections;

    public sealed class GenresSectionRouteProvider : IRouteProvider {
        public int Priority {
            get { return 1; }
        }

        public void RegisterRoutes(RouteCollection routeCollection) {
            routeCollection.MapStandardRoute(GenresSectionConstants.RouteName, new {
                Controller = GenresSectionConstants.ControllerName,
                Action = GenresSectionConstants.ActionName
            });

            routeCollection.MapStandardRoute(GenresSectionConstants.FundamentalsController.List.RouteName, new {
                Controller = GenresSectionConstants.FundamentalsController.ControllerName,
                Action = GenresSectionConstants.FundamentalsController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(GenresSectionConstants.FundamentalsController.New.RouteName, new {
                Controller = GenresSectionConstants.FundamentalsController.ControllerName,
                Action = GenresSectionConstants.FundamentalsController.New.ActionName
            });

            routeCollection.MapStandardRoute(GenresSectionConstants.FundamentalsController.Edit.RouteName, new {
                Controller = GenresSectionConstants.FundamentalsController.ControllerName,
                Action = GenresSectionConstants.FundamentalsController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(GenresSectionConstants.GenreCommentsController.List.RouteName, new {
                Controller = GenresSectionConstants.GenreCommentsController.ControllerName,
                Action = GenresSectionConstants.GenreCommentsController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.GenreId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(GenresSectionConstants.GenreCommentsController.Edit.RouteName, new {
                Controller = GenresSectionConstants.GenreCommentsController.ControllerName,
                Action = GenresSectionConstants.GenreCommentsController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(GenresSectionConstants.GenreCommentLikesController.List.RouteName, new {
                Controller = GenresSectionConstants.GenreCommentLikesController.ControllerName,
                Action = GenresSectionConstants.GenreCommentLikesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.GenreCommentId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(GenresSectionConstants.GenreLikesController.List.RouteName, new {
                Controller = GenresSectionConstants.GenreLikesController.ControllerName,
                Action = GenresSectionConstants.GenreLikesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.GenreId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(GenresSectionConstants.GenreSharesController.List.RouteName, new {
                Controller = GenresSectionConstants.GenreSharesController.ControllerName,
                Action = GenresSectionConstants.GenreSharesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.GenreId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));
        }
    }
}