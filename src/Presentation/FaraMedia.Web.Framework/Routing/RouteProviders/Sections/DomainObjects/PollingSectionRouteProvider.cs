namespace FaraMedia.Web.Framework.Routing.RouteProviders.Sections.DomainObjects {
    using System.Web.Routing;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Layout.Sections;

    public sealed class PollingSectionRouteProvider : IRouteProvider {
        public int Priority {
            get { return 1; }
        }

        public void RegisterRoutes(RouteCollection routeCollection) {
            routeCollection.MapStandardRoute(PollingSectionConstants.RouteName, new {
                Controller = PollingSectionConstants.ControllerName,
                Action = PollingSectionConstants.ActionName
            });

            routeCollection.MapStandardRoute(PollingSectionConstants.PollsController.List.RouteName, new {
                Controller = PollingSectionConstants.PollsController.ControllerName,
                Action = PollingSectionConstants.PollsController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(PollingSectionConstants.PollsController.New.RouteName, new {
                Controller = PollingSectionConstants.PollsController.ControllerName,
                Action = PollingSectionConstants.PollsController.New.ActionName
            });

            routeCollection.MapStandardRoute(PollingSectionConstants.PollsController.Edit.RouteName, new {
                Controller = PollingSectionConstants.PollsController.ControllerName,
                Action = PollingSectionConstants.PollsController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(PollingSectionConstants.PollCommentsController.List.RouteName, new {
                Controller = PollingSectionConstants.PollCommentsController.ControllerName,
                Action = PollingSectionConstants.PollCommentsController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.PollId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(PollingSectionConstants.PollCommentsController.Edit.RouteName, new {
                Controller = PollingSectionConstants.PollCommentsController.ControllerName,
                Action = PollingSectionConstants.PollCommentsController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(PollingSectionConstants.PollCommentLikesController.List.RouteName, new {
                Controller = PollingSectionConstants.PollCommentLikesController.ControllerName,
                Action = PollingSectionConstants.PollCommentLikesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.PollCommentId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(PollingSectionConstants.PollLikesController.List.RouteName, new {
                Controller = PollingSectionConstants.PollLikesController.ControllerName,
                Action = PollingSectionConstants.PollLikesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.PollId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(PollingSectionConstants.PollSharesController.List.RouteName, new {
                Controller = PollingSectionConstants.PollSharesController.ControllerName,
                Action = PollingSectionConstants.PollSharesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.PollId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(PollingSectionConstants.PollAnswersController.List.RouteName, new {
                Controller = PollingSectionConstants.PollAnswersController.ControllerName,
                Action = PollingSectionConstants.PollAnswersController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.PollId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(PollingSectionConstants.PollAnswersController.New.RouteName, new {
                Controller = PollingSectionConstants.PollAnswersController.ControllerName,
                Action = PollingSectionConstants.PollAnswersController.New.ActionName
            }, RouteParameter.Add(KnownParameterNames.PollId, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(PollingSectionConstants.PollAnswersController.Edit.RouteName, new {
                Controller = PollingSectionConstants.PollAnswersController.ControllerName,
                Action = PollingSectionConstants.PollAnswersController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(PollingSectionConstants.PollVotingRecordsController.List.RouteName, new {
                Controller = PollingSectionConstants.PollVotingRecordsController.ControllerName,
                Action = PollingSectionConstants.PollVotingRecordsController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.PollAnswerId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));
        }
    }
}