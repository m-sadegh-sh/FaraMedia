namespace FaraMedia.Web.Framework.UI.Navigation.Renderers.Aside {
    using System.Web.Mvc;

    using FaraMedia.Services.Installation.Installers;
    using FaraMedia.Web.Framework.Routing;
    using FaraMedia.Web.Framework.UI.Navigation.Items;

    public sealed class AsideNonClickableMenuItemRenderer : MenuItemRendererBase {
        private const string NON_CLICKABLE_MENU_ITEM = "<h3><a trap=\"true\" href=\"\">{0}</a></h3><ul>{1}</ul>";
        private const string MENU_ITEM = "<h3>{0}</h3><ul>{1}</ul>";

        private readonly HtmlHelper _htmlHelper;

        public AsideNonClickableMenuItemRenderer(HtmlHelper htmlHelper) {
            _htmlHelper = htmlHelper;
        }

        public override MvcHtmlString Render(MenuItemBase menuItemBase, MvcHtmlString renderedChilds) {
            if (!menuItemBase.IsRenderable)
                return MvcHtmlString.Empty;

            var menuItem = menuItemBase as MenuItem;
            if (menuItem != null) {
                var link = _htmlHelper.LocalizedRouteLink(menuItem.ResourceKey, menuItem.RouteName, menuItem.RouteValues, surroundUsing: null);

                return MvcHtmlString.Create(string.Format(MENU_ITEM, link, renderedChilds));
            }

            var nonClickableMenuItem = (NonClickableMenuItem) menuItemBase;

            var linkText = ValidationMessageFormatter.WithKey(nonClickableMenuItem.ResourceKey);

            return MvcHtmlString.Create(string.Format(NON_CLICKABLE_MENU_ITEM, linkText, renderedChilds));
        }
    }
}