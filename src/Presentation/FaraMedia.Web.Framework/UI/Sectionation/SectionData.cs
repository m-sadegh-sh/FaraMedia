namespace FaraMedia.Web.Framework.UI.Sectionation {
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using FaraMedia.Core.Infrastructure.Extensions;
    using FaraMedia.Web.Framework.UI.Sectionation.Items;

    public class SectionData {
        private readonly ICollection<string> _tags;

        public SectionData() {
            _tags = new Collection<string>();
        }

        public SectionType Type { get; set; }
        public SectionItemBase Item { get; set; }

        public IEnumerable<string> Tags {
            get { return _tags; }
        }

        public void AddTags(params string[] tags) {
            _tags.AddAll(tags);
        }
    }
}