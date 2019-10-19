namespace FaraMedia.Web.Framework.Routing.RouteProviders.Sections.DomainObjects {
    using System.Web.Routing;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Layout.Sections;

    public sealed class BloggingSectionRouteProvider : IRouteProvider {
        public int Priority {
            get { return 1; }
        }

        public void RegisterRoutes(RouteCollection routeCollection) {
            routeCollection.MapStandardRoute(BloggingSectionConstants.RouteName, new {
                Controller = BloggingSectionConstants.ControllerName,
                Action = BloggingSectionConstants.ActionName
            });

            routeCollection.MapStandardRoute(BloggingSectionConstants.BlogsController.List.RouteName, new {
                Controller = BloggingSectionConstants.BlogsController.ControllerName,
                Action = BloggingSectionConstants.BlogsController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(BloggingSectionConstants.BlogsController.New.RouteName, new {
                Controller = BloggingSectionConstants.BlogsController.ControllerName,
                Action = BloggingSectionConstants.BlogsController.New.ActionName
            });

            routeCollection.MapStandardRoute(BloggingSectionConstants.BlogsController.Edit.RouteName, new {
                Controller = BloggingSectionConstants.BlogsController.ControllerName,
                Action = BloggingSectionConstants.BlogsController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(BloggingSectionConstants.TagsController.List.RouteName, new {
                Controller = BloggingSectionConstants.TagsController.ControllerName,
                Action = BloggingSectionConstants.TagsController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.BlogId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(BloggingSectionConstants.TagsController.New.RouteName, new {
                Controller = BloggingSectionConstants.TagsController.ControllerName,
                Action = BloggingSectionConstants.TagsController.New.ActionName
            },RouteParameter.Add(KnownParameterNames.BlogId, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(BloggingSectionConstants.TagsController.Edit.RouteName, new {
                Controller = BloggingSectionConstants.TagsController.ControllerName,
                Action = BloggingSectionConstants.TagsController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(BloggingSectionConstants.PostsController.List.RouteName, new {
                Controller = BloggingSectionConstants.PostsController.ControllerName,
                Action = BloggingSectionConstants.PostsController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.BlogId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(BloggingSectionConstants.PostsController.New.RouteName, new {
                Controller = BloggingSectionConstants.PostsController.ControllerName,
                Action = BloggingSectionConstants.PostsController.New.ActionName
            },RouteParameter.Add(KnownParameterNames.BlogId, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(BloggingSectionConstants.PostsController.Edit.RouteName, new {
                Controller = BloggingSectionConstants.PostsController.ControllerName,
                Action = BloggingSectionConstants.PostsController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(BloggingSectionConstants.PostCommentsController.List.RouteName, new {
                Controller = BloggingSectionConstants.PostCommentsController.ControllerName,
                Action = BloggingSectionConstants.PostCommentsController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.PostId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(BloggingSectionConstants.PostCommentsController.Edit.RouteName, new {
                Controller = BloggingSectionConstants.PostCommentsController.ControllerName,
                Action = BloggingSectionConstants.PostCommentsController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(BloggingSectionConstants.PostCommentLikesController.List.RouteName, new {
                Controller = BloggingSectionConstants.PostCommentLikesController.ControllerName,
                Action = BloggingSectionConstants.PostCommentLikesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.PostCommentId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(BloggingSectionConstants.PostLikesController.List.RouteName, new {
                Controller = BloggingSectionConstants.PostLikesController.ControllerName,
                Action = BloggingSectionConstants.PostLikesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.PostId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(BloggingSectionConstants.PostSharesController.List.RouteName, new {
                Controller = BloggingSectionConstants.PostSharesController.ControllerName,
                Action = BloggingSectionConstants.PostSharesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.PostId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));
        }
    }
}