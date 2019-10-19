namespace FaraMedia.Web.Framework.Modules {
    using System.Linq;
    using System.Web;

    public class HeaderCleanerModule : HttpModuleBase {
        protected override void OnPreSendRequestHeaders(HttpContextBase context) {
            var headers = new[] { "Server", "X-Powered-By", "X-AspNet-Version", "X-AspNetMvc-Version" }.ToList();

            headers.ForEach(h => context.Response.Headers.Remove(h));
        }
    }
}