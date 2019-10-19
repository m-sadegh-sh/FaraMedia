namespace FaraMedia.Web.Framework.UI.Navigation.Renderers.TopBar {
    using System.Collections.Generic;
    using System.Web.Mvc;

    using FaraMedia.Web.Framework.Mvc;

    public class TopBarMenuRenderer : MenuRendererBase {
        private readonly IDictionary<MenuType, MenuItemRendererBase> _renderers;

        public TopBarMenuRenderer(HtmlHelper htmlHelper) {
            _renderers = new Dictionary<MenuType, MenuItemRendererBase> {
                {MenuType.NonClickable, new TopBarNonClickableMenuItemRenderer()},
                {MenuType.Clickable, new TopBarMenuItemRenderer(htmlHelper)},
                {MenuType.Separator, new TopBarSeparatorMenuItemRenderer()}
            };
        }

        public override MvcHtmlString Render(List<MenuData> menuDatas) {
            var renderedIndexes = new List<int>();

            return Render(menuDatas, ref renderedIndexes);
        }

        private MvcHtmlString Render(IList<MenuData> menuDatas, ref List<int> renderedIndexes, bool isChilds = false, int differential = 0) {
            var mvcHtmlBuilder = new MvcHtmlStringBuilder();

            if (!isChilds)
                mvcHtmlBuilder.Append("<ul class=\"nav\">");

            var isPreviousRendered = false;

            for (var i = 0; i < menuDatas.Count; i++) {
                if (renderedIndexes.Contains(i + differential))
                    continue;

                renderedIndexes.Add(i + differential);

                var menuData = menuDatas[i];

                if (!isPreviousRendered && menuData.Type == MenuType.Separator)
                    continue;

                var menuItem = menuData.Item;

                var hasChilds = false;
                var childs = new List<MenuData>();

                for (var j = i + 1; j < menuDatas.Count; j++) {
                    var child = menuDatas[j];
                    if (child.Level > menuData.Level) {
                        childs.Add(child);
                        hasChilds = true;
                    } else
                        break;
                }

                var renderedChilds = MvcHtmlString.Empty;
                if (hasChilds)
                    renderedChilds = Render(childs, ref renderedIndexes, true, i + differential + 1);

                var isChildsRendered = hasChilds && !MvcHtmlString.IsNullOrEmpty(renderedChilds);

                if (!isChildsRendered && menuData.Type == MenuType.NonClickable)
                    continue;

                var renderedMenu = _renderers[menuData.Type].Render(menuItem, renderedChilds);

                isPreviousRendered = !MvcHtmlString.IsNullOrEmpty(renderedMenu);

                if (isPreviousRendered)
                    mvcHtmlBuilder.Append(renderedMenu);
            }

            if (!isChilds)
                mvcHtmlBuilder.Append("</ul>");

            return mvcHtmlBuilder.ToString();
        }
    }
}