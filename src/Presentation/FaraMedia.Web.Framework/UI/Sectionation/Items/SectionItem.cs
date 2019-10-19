namespace FaraMedia.Web.Framework.UI.Sectionation.Items {
    public sealed class SectionItem : HeroUnitSectionItem {
        public SectionItem(string titleKey, string descriptionKey, string routeName, object routeValues = null) : base(titleKey, descriptionKey) {
            RouteName = routeName;
            RouteValues = routeValues;
        }

        public string RouteName { get; private set; }
        public object RouteValues { get; private set; }
    }
}