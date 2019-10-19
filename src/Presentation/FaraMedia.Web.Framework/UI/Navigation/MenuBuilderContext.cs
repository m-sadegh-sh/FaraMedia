namespace FaraMedia.Web.Framework.UI.Navigation {
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    using FaraMedia.Web.Framework.UI.Navigation.Items;
    using FaraMedia.Web.Framework.UI.Navigation.Renderers;

    public sealed class MenuBuilderContext {
        private List<MenuData> _menuDatas;
        private readonly ICollection<string> _tags;

        private MenuData _current;

        public MenuBuilderContext() {
            _menuDatas = new List<MenuData>();
            _tags = new Collection<string>();
        }

        public MenuBuilderContext AddTag(string tag) {
            if (!string.IsNullOrWhiteSpace(tag))
                _tags.Add(tag);

            return this;
        }

        public MenuBuilderContext AddSeparator() {
            var separator = new SeparatorMenuItem();

            var menuData = new MenuData {
                Level = _current.Level,
                Item = separator,
                Type = MenuType.Separator
            };

            _current = menuData;

            _menuDatas.Add(menuData);

            return this;
        }

        public MenuBuilderContext AddNonClickable(string resourceKey, params string[] tags) {
            var nonClickable = new NonClickableMenuItem(resourceKey);

            var menuData = new MenuData {
                Level = MenuItemLevel.Root,
                Item = nonClickable,
                Type = MenuType.NonClickable
            };

            menuData.AddTags(tags);

            _current = menuData;

            _menuDatas.Add(menuData);

            return this;
        }

        public MenuBuilderContext Add(string routeName, string resourceKey, params string[] tags) {
            return Add(routeName, resourceKey, null, tags);
        }

        public MenuBuilderContext Add(string routeName, string resourceKey, object routeValues, params string[] tags) {
            var clickable = new MenuItem(routeName, resourceKey, routeValues);

            var menuData = new MenuData {
                Level = MenuItemLevel.Parent,
                Item = clickable,
                Type = MenuType.Clickable
            };

            menuData.AddTags(tags);

            _current = menuData;

            _menuDatas.Add(menuData);

            return this;
        }

        public MenuBuilderContext If(Expression<Func<bool>> predicate) {
            if (_current != null)
                _current.Item.Predicate = predicate;

            return this;
        }

        public MenuBuilderContext Reset() {
            _menuDatas.Clear();

            return this;
        }

        public bool Any() {
            return _menuDatas.Any();
        }

        public MvcHtmlString RenderUsing<TMenuRenderer>(TMenuRenderer menuRenderer) where TMenuRenderer : MenuRendererBase {
            if (_tags.Any())
                _menuDatas = _menuDatas.Where(md => md.Tags.Any(mdt => _tags.Any(t => t == mdt))).ToList();

            return menuRenderer.Render(_menuDatas);
        }
    }
}