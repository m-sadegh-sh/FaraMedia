namespace FaraMedia.Web.Framework.UI.Navigation.Renderers.TopBar {
    using System.Web.Mvc;

    using FaraMedia.Services.Installation.Installers;
    using FaraMedia.Web.Framework.Mvc;
    using FaraMedia.Web.Framework.UI.Navigation.Items;

    public sealed class TopBarNonClickableMenuItemRenderer : MenuItemRendererBase {
        private const string NON_CLICKABLE_MENU_ITEM = "<li{0}><a trap=\"true\" href=\"#\"{1}>{2}</a>{3}</li>";

        public override MvcHtmlString Render(MenuItemBase menuItem, MvcHtmlString renderedChilds) {
            if (!menuItem.IsRenderable)
                return MvcHtmlString.Empty;

            var nonClickableMenuItem = (NonClickableMenuItem) menuItem;

            var linkText = ValidationMessageFormatter.WithKey(nonClickableMenuItem.ResourceKey);

            var hasChilds = !MvcHtmlString.IsNullOrEmpty(renderedChilds);

            if (hasChilds) {
                var mvcHtmlBuilder = new MvcHtmlStringBuilder();

                mvcHtmlBuilder.Append("<ul class=\"dropdown-menu\">");
                mvcHtmlBuilder.Append(renderedChilds);
                mvcHtmlBuilder.Append("</ul>");

                renderedChilds = mvcHtmlBuilder.ToString();
            }

            return MvcHtmlString.Create(string.Format(NON_CLICKABLE_MENU_ITEM, hasChilds ? " class=\"dropdown\"" : "", hasChilds ? " class=\"dropdown-toggle\"" : "", linkText, renderedChilds));
        }
    }
}