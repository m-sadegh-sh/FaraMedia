namespace FaraMedia.Web.Framework.UI.Navigation.Items {
    public sealed class MenuItem : NonClickableMenuItem {
        public MenuItem(string routeName, string resourceKey, object routeValues = null) : base(resourceKey) {
            RouteName = routeName;
            RouteValues = routeValues;
        }

        public string RouteName { get; private set; }
        public object RouteValues { get; private set; }
    }
}