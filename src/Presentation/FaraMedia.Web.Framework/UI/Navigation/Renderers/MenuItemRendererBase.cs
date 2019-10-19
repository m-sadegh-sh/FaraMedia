namespace FaraMedia.Web.Framework.UI.Navigation.Renderers {
    using System.Web.Mvc;

    using FaraMedia.Web.Framework.UI.Navigation.Items;

    public abstract class MenuItemRendererBase {
        public abstract MvcHtmlString Render(MenuItemBase menuItem,MvcHtmlString renderedChilds);
    }
}