namespace FaraMedia.Web.Framework.UI.Navigation.Items {
    public class NonClickableMenuItem : MenuItemBase {
        public NonClickableMenuItem(string resourceKey) {
            ResourceKey = resourceKey;
        }

        public string ResourceKey { get; private set; }
    }
}