namespace FaraMedia.Web.Framework.Modules {
    using System;
    using System.Linq;
    using System.Web;

    public class ExpireCookiesModule : HttpModuleBase {
        protected override void OnEndRequest(HttpContextBase context) {
            var cookies = context.Response.Cookies;
            foreach (var cookie in cookies.Cast<HttpCookie>()) {
                cookie.Expires = DateTime.Now.AddYears(-9999);
                cookies.Remove(cookie.Name);
            }
        }
    }
}