namespace FaraMedia.Web.Framework.Modules {
    using System.Net;
    using System.Web;

    using FaraMedia.Web.Framework.Helpers;

    public class UrlNormalizerModule : HttpModuleBase {
        protected override void OnBeginRequest(HttpContextBase context) {
            var request = context.Request;

            if (request.HttpMethod == "POST")
                return;

            var originUrl = request.Url.ToString();
            var normalizedUrl = originUrl.ToStandardUrl();
            if (string.CompareOrdinal(originUrl, normalizedUrl.UrlDecode()) != 0) {
                var response = context.Response;

                response.StatusCode = (int) HttpStatusCode.MovedPermanently;
                response.Status = "301 Moved Permanently";
                response.RedirectLocation = normalizedUrl;
                response.SuppressContent = true;
                response.End();
            }
        }
    }
}