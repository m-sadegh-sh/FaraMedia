namespace FaraMedia.Web.Framework.UI.Navigation {
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using FaraMedia.Core.Infrastructure.Extensions;
    using FaraMedia.Web.Framework.UI.Navigation.Items;

    public class MenuData {
        private readonly ICollection<string> _tags;

        public MenuData() {
            _tags = new Collection<string>();
        }

        public MenuItemLevel Level { get; set; }
        public MenuType Type { get; set; }
        public MenuItemBase Item { get; set; }

        public IEnumerable<string> Tags {
            get { return _tags; }
        }

        public void AddTags(params string[] tags) {
            _tags.AddAll(tags);
        }
    }
}