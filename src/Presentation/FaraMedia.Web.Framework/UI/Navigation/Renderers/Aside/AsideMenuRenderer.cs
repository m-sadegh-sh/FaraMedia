namespace FaraMedia.Web.Framework.UI.Navigation.Renderers.Aside {
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using FaraMedia.Core.Infrastructure.Extensions;
    using FaraMedia.Web.Framework.Mvc;
    using FaraMedia.Web.Framework.UI.Navigation.Items;

    public class AsideMenuRenderer : MenuRendererBase {
        private readonly IDictionary<MenuType, MenuItemRendererBase> _renderers;

        public AsideMenuRenderer(HtmlHelper htmlHelper) {
            _renderers = new Dictionary<MenuType, MenuItemRendererBase> {
                {MenuType.NonClickable, new AsideNonClickableMenuItemRenderer(htmlHelper)},
                {MenuType.Clickable, new AsideMenuItemRenderer(htmlHelper)},
                {MenuType.Separator, new AsideSeparatorMenuItemRenderer()}
            };
        }

        public override MvcHtmlString Render(List<MenuData> menuDatas) {
            var ignoreNext = false;
            foreach (var menuData in menuDatas.ToList()) {
                if (ignoreNext) {
                    ignoreNext = false;
                    continue;
                }

                if (menuData.Type == MenuType.Clickable)
                    continue;

                var next = menuDatas.Next(menuData);
                if (next != null) {
                    ignoreNext = true;
                    next.Level = MenuItemLevel.Root;
                    next.Type = MenuType.NonClickable;
                }

                menuDatas.Remove(menuData);
            }

            var renderedIndexes = new List<int>();

            return Render(menuDatas, ref renderedIndexes);
        }

        private MvcHtmlString Render(IList<MenuData> menuDatas, ref List<int> renderedIndexes, bool isChilds = false, int differential = 0) {
            var mvcHtmlBuilder = new MvcHtmlStringBuilder();

            if (!isChilds)
                mvcHtmlBuilder.Append("<div class=\"sidebar\">");

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

                if (!isChilds)
                    mvcHtmlBuilder.Append("<div class=\"well\">");

                var renderedMenu = _renderers[menuData.Type].Render(menuItem, renderedChilds);

                isPreviousRendered = !MvcHtmlString.IsNullOrEmpty(renderedMenu);

                if (isPreviousRendered)
                    mvcHtmlBuilder.Append(renderedMenu);

                if (!isChilds)
                    mvcHtmlBuilder.Append("</div>");
            }

            if (!isChilds)
                mvcHtmlBuilder.Append("</div>");

            return mvcHtmlBuilder.ToString();
        }
    }
}