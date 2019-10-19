namespace FaraMedia.Web.Framework.UI.Navigation.Renderers.TopBar {
    using System;
    using System.Web.Mvc;

    using FaraMedia.Web.Framework.UI.Navigation.Items;

    public sealed class TopBarSeparatorMenuItemRenderer : MenuItemRendererBase {
        public override MvcHtmlString Render(MenuItemBase menuItem, MvcHtmlString renderedChilds) {
            if (!menuItem.IsRenderable)
                return MvcHtmlString.Empty;

            if (!MvcHtmlString.IsNullOrEmpty(renderedChilds))
                throw new NotSupportedException("Separators doesn't support nested items.");

            return MvcHtmlString.Create("<li class=\"divider\"></li>");
        }
    }
}