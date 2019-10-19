namespace FaraMedia.Web.Framework.Routing.RouteProviders.Sections.DomainObjects {
    using System.Web.Routing;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Layout.Sections;

    public sealed class MessagesSectionRouteProvider : IRouteProvider {
        public int Priority {
            get { return 1; }
        }

        public void RegisterRoutes(RouteCollection routeCollection) {
            routeCollection.MapStandardRoute(MessagesSectionConstants.RouteName, new {
                Controller = MessagesSectionConstants.ControllerName,
                Action = MessagesSectionConstants.ActionName
            });

            routeCollection.MapStandardRoute(MessagesSectionConstants.EmailAccountsController.List.RouteName, new {
                Controller = MessagesSectionConstants.EmailAccountsController.ControllerName,
                Action = MessagesSectionConstants.EmailAccountsController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(MessagesSectionConstants.EmailAccountsController.New.RouteName, new {
                Controller = MessagesSectionConstants.EmailAccountsController.ControllerName,
                Action = MessagesSectionConstants.EmailAccountsController.New.ActionName
            });

            routeCollection.MapStandardRoute(MessagesSectionConstants.EmailAccountsController.Edit.RouteName, new {
                Controller = MessagesSectionConstants.EmailAccountsController.ControllerName,
                Action = MessagesSectionConstants.EmailAccountsController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(MessagesSectionConstants.MessageTemplatesController.List.RouteName, new {
                Controller = MessagesSectionConstants.MessageTemplatesController.ControllerName,
                Action = MessagesSectionConstants.MessageTemplatesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(MessagesSectionConstants.MessageTemplatesController.New.RouteName, new {
                Controller = MessagesSectionConstants.MessageTemplatesController.ControllerName,
                Action = MessagesSectionConstants.MessageTemplatesController.New.ActionName
            });

            routeCollection.MapStandardRoute(MessagesSectionConstants.MessageTemplatesController.Edit.RouteName, new {
                Controller = MessagesSectionConstants.MessageTemplatesController.ControllerName,
                Action = MessagesSectionConstants.MessageTemplatesController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(MessagesSectionConstants.ContentManagementletterSubscriptionsController.List.RouteName, new {
                Controller = MessagesSectionConstants.ContentManagementletterSubscriptionsController.ControllerName,
                Action = MessagesSectionConstants.ContentManagementletterSubscriptionsController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(MessagesSectionConstants.ContentManagementletterSubscriptionsController.New.RouteName, new {
                Controller = MessagesSectionConstants.ContentManagementletterSubscriptionsController.ControllerName,
                Action = MessagesSectionConstants.ContentManagementletterSubscriptionsController.New.ActionName
            });

            routeCollection.MapStandardRoute(MessagesSectionConstants.ContentManagementletterSubscriptionsController.Edit.RouteName, new {
                Controller = MessagesSectionConstants.ContentManagementletterSubscriptionsController.ControllerName,
                Action = MessagesSectionConstants.ContentManagementletterSubscriptionsController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(MessagesSectionConstants.QueuedEmailsController.List.RouteName, new {
                Controller = MessagesSectionConstants.QueuedEmailsController.ControllerName,
                Action = MessagesSectionConstants.QueuedEmailsController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(MessagesSectionConstants.QueuedEmailsController.New.RouteName, new {
                Controller = MessagesSectionConstants.QueuedEmailsController.ControllerName,
                Action = MessagesSectionConstants.QueuedEmailsController.New.ActionName
            });

            routeCollection.MapStandardRoute(MessagesSectionConstants.QueuedEmailsController.Edit.RouteName, new {
                Controller = MessagesSectionConstants.QueuedEmailsController.ControllerName,
                Action = MessagesSectionConstants.QueuedEmailsController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));
        }
    }
}