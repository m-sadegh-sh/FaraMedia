namespace FaraMedia.Web.Framework.Routing.RouteProviders.Sections.DomainObjects {
    using System.Web.Routing;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Layout.Sections;

    public sealed class MediaSectionRouteProvider : IRouteProvider {
        public int Priority {
            get { return 1; }
        }

        public void RegisterRoutes(RouteCollection routeCollection) {
            routeCollection.MapStandardRoute(MediaSectionConstants.RouteName, new {
                Controller = MediaSectionConstants.ControllerName,
                Action = MediaSectionConstants.ActionName
            });

            routeCollection.MapStandardRoute(MediaSectionConstants.DownloadsController.List.RouteName, new {
                Controller = MediaSectionConstants.DownloadsController.ControllerName,
                Action = MediaSectionConstants.DownloadsController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(MediaSectionConstants.DownloadsController.New.RouteName, new {
                Controller = MediaSectionConstants.DownloadsController.ControllerName,
                Action = MediaSectionConstants.DownloadsController.New.ActionName
            });

            routeCollection.MapStandardRoute(MediaSectionConstants.DownloadsController.Edit.RouteName, new {
                Controller = MediaSectionConstants.DownloadsController.ControllerName,
                Action = MediaSectionConstants.DownloadsController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(MediaSectionConstants.DownloadAttributesController.List.RouteName, new {
                Controller = MediaSectionConstants.DownloadAttributesController.ControllerName,
                Action = MediaSectionConstants.DownloadAttributesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.DownloadId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(MediaSectionConstants.DownloadAttributesController.New.RouteName, new {
                Controller = MediaSectionConstants.DownloadAttributesController.ControllerName,
                Action = MediaSectionConstants.DownloadAttributesController.New.ActionName
            }, RouteParameter.Add(KnownParameterNames.DownloadId, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(MediaSectionConstants.DownloadAttributesController.Edit.RouteName, new {
                Controller = MediaSectionConstants.DownloadAttributesController.ControllerName,
                Action = MediaSectionConstants.DownloadAttributesController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(MediaSectionConstants.PicturesController.List.RouteName, new {
                Controller = MediaSectionConstants.PicturesController.ControllerName,
                Action = MediaSectionConstants.PicturesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(MediaSectionConstants.PicturesController.New.RouteName, new {
                Controller = MediaSectionConstants.PicturesController.ControllerName,
                Action = MediaSectionConstants.PicturesController.New.ActionName
            });

            routeCollection.MapStandardRoute(MediaSectionConstants.PicturesController.Edit.RouteName, new {
                Controller = MediaSectionConstants.PicturesController.ControllerName,
                Action = MediaSectionConstants.PicturesController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(MediaSectionConstants.PictureAttributesController.List.RouteName, new {
                Controller = MediaSectionConstants.PictureAttributesController.ControllerName,
                Action = MediaSectionConstants.PictureAttributesController.List.ActionName
            }, RouteParameter.Add(KnownParameterNames.PictureId, KnownConstraints.Int32).Append(KnownParameterNames.Page, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(MediaSectionConstants.PictureAttributesController.New.RouteName, new {
                Controller = MediaSectionConstants.PictureAttributesController.ControllerName,
                Action = MediaSectionConstants.PictureAttributesController.New.ActionName
            }, RouteParameter.Add(KnownParameterNames.PictureId, KnownConstraints.Int32));

            routeCollection.MapStandardRoute(MediaSectionConstants.PictureAttributesController.Edit.RouteName, new {
                Controller = MediaSectionConstants.PictureAttributesController.ControllerName,
                Action = MediaSectionConstants.PictureAttributesController.Edit.ActionName
            }, RouteParameter.Add(KnownParameterNames.Id, KnownConstraints.Int32));
        }
    }
}