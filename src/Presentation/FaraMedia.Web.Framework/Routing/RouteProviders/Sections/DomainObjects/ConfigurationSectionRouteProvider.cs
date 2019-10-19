namespace FaraMedia.Web.Framework.Routing.RouteProviders.Sections.DomainObjects {
    using System.Web.Routing;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Layout.Sections;

    public sealed class ConfigurationSectionRouteProvider : IRouteProvider {
        public int Priority {
            get { return 1; }
        }

        public void RegisterRoutes(RouteCollection routeCollection) {
            routeCollection.MapStandardRoute(ConfigurationSectionConstants.RouteName, new {
                Controller = ConfigurationSectionConstants.ControllerName,
                Action = ConfigurationSectionConstants.ActionName
            });

            routeCollection.MapStandardRoute(ConfigurationSectionConstants.ConfigurationController.List.RouteName, new {
                Controller = ConfigurationSectionConstants.ConfigurationController.ControllerName,
                Action = ConfigurationSectionConstants.ConfigurationController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(ConfigurationSectionConstants.ConfigurationController.New.RouteName, new {
                Controller = ConfigurationSectionConstants.ConfigurationController.ControllerName,
                Action = ConfigurationSectionConstants.ConfigurationController.New.ActionName
            });

            routeCollection.MapStandardRoute(ConfigurationSectionConstants.ConfigurationController.Edit.RouteName, new {
                Controller = ConfigurationSectionConstants.ConfigurationController.ControllerName,
                Action = ConfigurationSectionConstants.ConfigurationController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));
        }
    }
}