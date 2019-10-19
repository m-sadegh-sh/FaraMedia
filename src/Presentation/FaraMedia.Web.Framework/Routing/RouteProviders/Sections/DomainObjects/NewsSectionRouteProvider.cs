namespace FaraMedia.Web.Framework.Routing.RouteProviders.Sections.DomainObjects {
    using System.Web.Routing;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Layout.Sections;

    public sealed class NewsSectionRouteProvider : IRouteProvider {
        public int Priority {
            get { return 1; }
        }

        public void RegisterRoutes(RouteCollection routeCollection) {
            routeCollection.MapStandardRoute(NewsSectionConstants.RouteName, new {
                Controller = NewsSectionConstants.ControllerName,
                Action = NewsSectionConstants.ActionName
            });

            routeCollection.MapStandardRoute(NewsSectionConstants.CategoriesController.List.RouteName, new {
                Controller = NewsSectionConstants.CategoriesController.ControllerName,
                Action = NewsSectionConstants.CategoriesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(NewsSectionConstants.CategoriesController.New.RouteName, new {
                Controller = NewsSectionConstants.CategoriesController.ControllerName,
                Action = NewsSectionConstants.CategoriesController.New.ActionName
            });

            routeCollection.MapStandardRoute(NewsSectionConstants.CategoriesController.Edit.RouteName, new {
                Controller = NewsSectionConstants.CategoriesController.ControllerName,
                Action = NewsSectionConstants.CategoriesController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(NewsSectionConstants.ContentManagementController.List.RouteName, new {
                Controller = NewsSectionConstants.ContentManagementController.ControllerName,
                Action = NewsSectionConstants.ContentManagementController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(NewsSectionConstants.ContentManagementController.New.RouteName, new {
                Controller = NewsSectionConstants.ContentManagementController.ControllerName,
                Action = NewsSectionConstants.ContentManagementController.New.ActionName
            });

            routeCollection.MapStandardRoute(NewsSectionConstants.ContentManagementController.Edit.RouteName, new {
                Controller = NewsSectionConstants.ContentManagementController.ControllerName,
                Action = NewsSectionConstants.ContentManagementController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(NewsSectionConstants.ContentManagementCommentsController.List.RouteName, new {
                Controller = NewsSectionConstants.ContentManagementCommentsController.ControllerName,
                Action = NewsSectionConstants.ContentManagementCommentsController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.ContentManagementId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(NewsSectionConstants.ContentManagementCommentsController.Edit.RouteName, new {
                Controller = NewsSectionConstants.ContentManagementCommentsController.ControllerName,
                Action = NewsSectionConstants.ContentManagementCommentsController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(NewsSectionConstants.ContentManagementCommentLikesController.List.RouteName, new {
                Controller = NewsSectionConstants.ContentManagementCommentLikesController.ControllerName,
                Action = NewsSectionConstants.ContentManagementCommentLikesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.ContentManagementCommentId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(NewsSectionConstants.ContentManagementLikesController.List.RouteName, new {
                Controller = NewsSectionConstants.ContentManagementLikesController.ControllerName,
                Action = NewsSectionConstants.ContentManagementLikesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.ContentManagementId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(NewsSectionConstants.ContentManagementSharesController.List.RouteName, new {
                Controller = NewsSectionConstants.ContentManagementSharesController.ControllerName,
                Action = NewsSectionConstants.ContentManagementSharesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.ContentManagementId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));
        }
    }
}