namespace FaraMedia.Cdn {
    using System.Web;

    using FaraMedia.Core.Infrastructure;

    public class MvcApplication : HttpApplication {
        protected void Application_Start() {
            EngineContext.Initialize(false);
        }
    }
}