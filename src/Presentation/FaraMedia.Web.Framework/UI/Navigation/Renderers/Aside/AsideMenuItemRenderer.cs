namespace FaraMedia.Web.Framework.UI.Navigation.Renderers.Aside {
    using System.Web.Mvc;

    using FaraMedia.Web.Framework.Mvc;
    using FaraMedia.Web.Framework.Routing;
    using FaraMedia.Web.Framework.UI.Navigation.Items;

    public sealed class AsideMenuItemRenderer : MenuItemRendererBase {
        private readonly HtmlHelper _htmlHelper;

        public AsideMenuItemRenderer(HtmlHelper htmlHelper) {
            _htmlHelper = htmlHelper;
        }

        public override MvcHtmlString Render(MenuItemBase menuItemBase, MvcHtmlString renderedChilds) {
            if (!menuItemBase.IsRenderable)
                return MvcHtmlString.Empty;

            var menuItem = (MenuItem) menuItemBase;
            
            var link = _htmlHelper.LocalizedRouteLink(menuItem.ResourceKey, menuItem.RouteName, menuItem.RouteValues, innerHtml: renderedChilds);

            return link;
        }
    }
}