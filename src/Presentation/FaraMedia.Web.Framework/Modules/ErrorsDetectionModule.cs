namespace FaraMedia.Web.Framework.Modules {
    using System.Net;
    using System.Web;

    using FaraMedia.Core.Infrastructure.Extensions;
    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.Root;
    using FaraMedia.Web.Framework.Routing;

    public class ErrorsDetectionModule : HttpModuleBase {
        protected override void OnEndRequest(HttpContextBase context) {
            var request = context.Request;
            var response = context.Response;

            if (!response.StatusCode.Any((int) HttpStatusCode.InternalServerError, (int) HttpStatusCode.NotFound, (int) HttpStatusCode.Forbidden))
                return;

            if (request.RawUrl.Contains("favicon.ico"))
                return;

            string routeName;

            if (response.StatusCode == (int) HttpStatusCode.InternalServerError)
                return;

            switch (response.StatusCode) {
                case (int) HttpStatusCode.InternalServerError:
                    routeName = RootSectionConstants.ErrorsController.GenericError.RouteName;
                    break;
                case (int) HttpStatusCode.NotFound:
                    routeName = RootSectionConstants.ErrorsController.NotFound.RouteName;
                    break;
                default:
                    routeName = RootSectionConstants.ErrorsController.AccessDenied.RouteName;
                    break;
            }

            var url = RouteUrlProvider.GetUrl(routeName);

            if (request.RawUrl.StartsWith(url))
                return;

            response.Clear();

            response.TrySkipIisCustomErrors = true;

            url = RouteUrlProvider.GetUrl(routeName, RouteParameter.Add("url", request.RawUrl));

            response.Redirect(url);
        }
    }
}