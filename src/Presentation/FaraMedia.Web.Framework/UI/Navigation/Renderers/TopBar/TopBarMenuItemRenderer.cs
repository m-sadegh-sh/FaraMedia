namespace FaraMedia.Web.Framework.UI.Navigation.Renderers.TopBar {
    using System.Web.Mvc;

    using FaraMedia.Web.Framework.Mvc;
    using FaraMedia.Web.Framework.Routing;
    using FaraMedia.Web.Framework.UI.Navigation.Items;

    public sealed class TopBarMenuItemRenderer : MenuItemRendererBase {
        private readonly HtmlHelper _htmlHelper;

        public TopBarMenuItemRenderer(HtmlHelper htmlHelper) {
            _htmlHelper = htmlHelper;
        }

        public override MvcHtmlString Render(MenuItemBase menuItemBase, MvcHtmlString renderedChilds) {
            if(!menuItemBase.IsRenderable)
                return MvcHtmlString.Empty;

            var menuItem = (MenuItem) menuItemBase;
            
            var hasChilds = !MvcHtmlString.IsNullOrEmpty(renderedChilds);

            if (hasChilds) {
                var mvcHtmlBuilder = new MvcHtmlStringBuilder();

                mvcHtmlBuilder.Append("<ul class=\"dropdown-menu\">");
                mvcHtmlBuilder.Append(renderedChilds);
                mvcHtmlBuilder.Append("</ul>");

                renderedChilds = mvcHtmlBuilder.ToString();
            }

            var link = _htmlHelper.LocalizedRouteLink(menuItem.ResourceKey, menuItem.RouteName, menuItem.RouteValues, innerHtml: renderedChilds, surrounderAttributes: hasChilds ? new {
                @class = "dropdown"
            } : null);

            return link;
        }
    }
}