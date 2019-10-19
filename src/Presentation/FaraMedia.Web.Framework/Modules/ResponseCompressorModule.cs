namespace FaraMedia.Web.Framework.Modules {
    using System.IO.Compression;
    using System.Web;

    using FaraMedia.Core;
    using FaraMedia.Core.Domain.Configuration;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Web.Framework.Optimization;

    public class ResponseCompressorModule : HttpModuleBase {
        protected override void OnBeginRequest(HttpContextBase context) {
            var commonSettings = EngineContext.Current.Resolve<CommonSettings>();

            if (!commonSettings.EnableHttpCompression)
                return;

            var request = context.Request;
            if (request == null)
                return;

            var acceptEncoding = request.Headers["Accept-Encoding"];

            if (string.IsNullOrEmpty(acceptEncoding))
                return;

            var response = context.Response;

            var optimizeMode = ResolveContentType(response.ContentType);

            if (optimizeMode == OptimizeMode.None)
                return;

            acceptEncoding = acceptEncoding.ToUpperInvariant();

            if (acceptEncoding.Contains("GZIP")) {
                response.Headers["Content-encoding"] = "gzip";
                response.Filter = new GZipStreamMinifier(response.Filter, CompressionMode.Compress, optimizeMode);
            } else if (acceptEncoding.Contains("DEFLATE")) {
                response.Headers["Content-encoding"] = "deflate";
                response.Filter = new DeflateStreamMinifier(response.Filter, CompressionMode.Compress, optimizeMode);
            }
        }

        private static OptimizeMode ResolveContentType(string contentType) {
            switch (contentType) {
                case "text/htm":
                case "text/html":
                    return OptimizeMode.Html;
                    //case "text/css":
                    //    return OptimizeMode.Css;
                    //case "text/javascript":
                    //    return OptimizeMode.Js;
                default:
                    return OptimizeMode.None;
            }
        }

        public static void DisableCompression(HttpContextBase context) {
            if (context.IsReady() && (context.Response.Filter is GZipStream || context.Response.Filter is DeflateStream))
                context.Response.Filter = null;
        }
    }
}