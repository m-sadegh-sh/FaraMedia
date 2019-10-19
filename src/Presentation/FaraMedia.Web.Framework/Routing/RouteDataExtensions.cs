namespace FaraMedia.Web.Framework.Routing {
    using System;
    using System.Web.Routing;

    public static class RouteDataExtensions {
        public static string ControllerName(this RouteData instance) {
            if (instance == null)
                throw new ArgumentNullException("instance");

            return instance.GetRequiredString("controller");
        }

        public static string ActionName(this RouteData instance) {
            if (instance == null)
                throw new ArgumentNullException("instance");

            return instance.GetRequiredString("action");
        }
    }
}