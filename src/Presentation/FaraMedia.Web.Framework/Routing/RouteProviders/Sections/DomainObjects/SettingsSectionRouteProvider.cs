namespace FaraMedia.Web.Framework.Routing.RouteProviders.Sections.DomainObjects {
    using System.Web.Routing;

    using FaraMedia.Data.Schemas.Layout.Sections;

    public sealed class SettingsSectionRouteProvider : IRouteProvider {
        public int Priority {
            get { return 1; }
        }

        public void RegisterRoutes(RouteCollection routeCollection) {
            routeCollection.MapStandardRoute(SettingsSectionConstants.RouteName, new {
                Controller = SettingsSectionConstants.ControllerName,
                Action = SettingsSectionConstants.ActionName
            });

            routeCollection.MapStandardRoute(SettingsSectionConstants.AdminAreaSettingsController.Save.RouteName, new {
                Controller = SettingsSectionConstants.AdminAreaSettingsController.ControllerName,
                Action = SettingsSectionConstants.AdminAreaSettingsController.Save.ActionName
            });

            routeCollection.MapStandardRoute(SettingsSectionConstants.ApplicationSettingsController.Save.RouteName, new {
                Controller = SettingsSectionConstants.ApplicationSettingsController.ControllerName,
                Action = SettingsSectionConstants.ApplicationSettingsController.Save.ActionName
            });

            routeCollection.MapStandardRoute(SettingsSectionConstants.BillingSettingsController.Save.RouteName, new {
                Controller = SettingsSectionConstants.BillingSettingsController.ControllerName,
                Action = SettingsSectionConstants.BillingSettingsController.Save.ActionName
            });

            routeCollection.MapStandardRoute(SettingsSectionConstants.ContentSettingsController.Save.RouteName, new {
                Controller = SettingsSectionConstants.ContentSettingsController.ControllerName,
                Action = SettingsSectionConstants.ContentSettingsController.Save.ActionName
            });

            routeCollection.MapStandardRoute(SettingsSectionConstants.CdnSettingsController.Save.RouteName, new {
                Controller = SettingsSectionConstants.CdnSettingsController.ControllerName,
                Action = SettingsSectionConstants.CdnSettingsController.Save.ActionName
            });

            routeCollection.MapStandardRoute(SettingsSectionConstants.CommonSettingsController.Save.RouteName, new {
                Controller = SettingsSectionConstants.CommonSettingsController.ControllerName,
                Action = SettingsSectionConstants.CommonSettingsController.Save.ActionName
            });

            routeCollection.MapStandardRoute(SettingsSectionConstants.DateTimeSettingsController.Save.RouteName, new {
                Controller = SettingsSectionConstants.DateTimeSettingsController.ControllerName,
                Action = SettingsSectionConstants.DateTimeSettingsController.Save.ActionName
            });

            routeCollection.MapStandardRoute(SettingsSectionConstants.EmailAccountSettingsController.Save.RouteName, new {
                Controller = SettingsSectionConstants.EmailAccountSettingsController.ControllerName,
                Action = SettingsSectionConstants.EmailAccountSettingsController.Save.ActionName
            });

            routeCollection.MapStandardRoute(SettingsSectionConstants.SystematicSettingsController.Save.RouteName, new {
                Controller = SettingsSectionConstants.SystematicSettingsController.ControllerName,
                Action = SettingsSectionConstants.SystematicSettingsController.Save.ActionName
            });

            routeCollection.MapStandardRoute(SettingsSectionConstants.FileManagementSettingsController.Save.RouteName, new {
                Controller = SettingsSectionConstants.FileManagementSettingsController.ControllerName,
                Action = SettingsSectionConstants.FileManagementSettingsController.Save.ActionName
            });

            routeCollection.MapStandardRoute(SettingsSectionConstants.SecuritySettingsController.Save.RouteName, new {
                Controller = SettingsSectionConstants.SecuritySettingsController.ControllerName,
                Action = SettingsSectionConstants.SecuritySettingsController.Save.ActionName
            });

            routeCollection.MapStandardRoute(SettingsSectionConstants.MessageTemplateSettingsController.Save.RouteName, new {
                Controller = SettingsSectionConstants.MessageTemplateSettingsController.ControllerName,
                Action = SettingsSectionConstants.MessageTemplateSettingsController.Save.ActionName
            });

            routeCollection.MapStandardRoute(SettingsSectionConstants.ContentManagementSettingsController.Save.RouteName, new {
                Controller = SettingsSectionConstants.ContentManagementSettingsController.ControllerName,
                Action = SettingsSectionConstants.ContentManagementSettingsController.Save.ActionName
            });

            routeCollection.MapStandardRoute(SettingsSectionConstants.SecuritySettingsController.Save.RouteName, new {
                Controller = SettingsSectionConstants.SecuritySettingsController.ControllerName,
                Action = SettingsSectionConstants.SecuritySettingsController.Save.ActionName
            });

            routeCollection.MapStandardRoute(SettingsSectionConstants.SeoSettingsController.Save.RouteName, new {
                Controller = SettingsSectionConstants.SeoSettingsController.ControllerName,
                Action = SettingsSectionConstants.SeoSettingsController.Save.ActionName
            });

            routeCollection.MapStandardRoute(SettingsSectionConstants.SitemapSettingsController.Save.RouteName, new {
                Controller = SettingsSectionConstants.SitemapSettingsController.ControllerName,
                Action = SettingsSectionConstants.SitemapSettingsController.Save.ActionName
            });

            routeCollection.MapStandardRoute(SettingsSectionConstants.MiscellaneousSettingsController.Save.RouteName, new {
                Controller = SettingsSectionConstants.MiscellaneousSettingsController.ControllerName,
                Action = SettingsSectionConstants.MiscellaneousSettingsController.Save.ActionName
            });
        }
    }
}