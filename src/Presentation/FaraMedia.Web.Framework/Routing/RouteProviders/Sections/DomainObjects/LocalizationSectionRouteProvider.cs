namespace FaraMedia.Web.Framework.Routing.RouteProviders.Sections.DomainObjects {
    using System.Web.Routing;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Layout.Sections;

    public sealed class LocalizationSectionRouteProvider : IRouteProvider {
        public int Priority {
            get { return 1; }
        }

        public void RegisterRoutes(RouteCollection routeCollection) {
            routeCollection.MapStandardRoute(LocalizationSectionConstants.RouteName, new {
                Controller = LocalizationSectionConstants.ControllerName,
                Action = LocalizationSectionConstants.ActionName
            });

            routeCollection.MapStandardRoute(LocalizationSectionConstants.LanguagesController.List.RouteName, new {
                Controller = LocalizationSectionConstants.LanguagesController.ControllerName,
                Action = LocalizationSectionConstants.LanguagesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(LocalizationSectionConstants.LanguagesController.New.RouteName, new {
                Controller = LocalizationSectionConstants.LanguagesController.ControllerName,
                Action = LocalizationSectionConstants.LanguagesController.New.ActionName
            });

            routeCollection.MapStandardRoute(LocalizationSectionConstants.LanguagesController.Edit.RouteName, new {
                Controller = LocalizationSectionConstants.LanguagesController.ControllerName,
                Action = LocalizationSectionConstants.LanguagesController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(LocalizationSectionConstants.StringResourcesController.List.RouteName, new {
                Controller = LocalizationSectionConstants.StringResourcesController.ControllerName,
                Action = LocalizationSectionConstants.StringResourcesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(LocalizationSectionConstants.StringResourcesController.New.RouteName, new {
                Controller = LocalizationSectionConstants.StringResourcesController.ControllerName,
                Action = LocalizationSectionConstants.StringResourcesController.New.ActionName
            });

            routeCollection.MapStandardRoute(LocalizationSectionConstants.StringResourcesController.Edit.RouteName, new {
                Controller = LocalizationSectionConstants.StringResourcesController.ControllerName,
                Action = LocalizationSectionConstants.StringResourcesController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));
        }
    }
}