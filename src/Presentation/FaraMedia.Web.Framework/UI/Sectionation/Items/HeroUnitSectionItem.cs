namespace FaraMedia.Web.Framework.UI.Sectionation.Items {
    public class HeroUnitSectionItem : SectionItemBase {
        public HeroUnitSectionItem(string titleKey, string descriptionKey) {
            TitleKey = titleKey;
            DescriptionKey = descriptionKey;
        }

        public string TitleKey { get; private set; }
        public string DescriptionKey { get; private set; }
    }
}