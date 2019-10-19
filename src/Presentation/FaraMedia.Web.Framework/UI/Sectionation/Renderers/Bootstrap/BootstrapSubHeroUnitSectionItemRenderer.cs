namespace FaraMedia.Web.Framework.UI.Sectionation.Renderers.Bootstrap {
    using System.Web.Mvc;

    using FaraMedia.Services.Installation.Installers;
    using FaraMedia.Web.Framework.UI.Sectionation.Items;

    public sealed class BootstrapSubHeroUnitSectionItemRenderer : SectionItemRendererBase {
        private const string SUB_HERO_UNIT_SECTION_ITEM = "<h2>{0}</h2><p>{1}</p>";

        public override MvcHtmlString Render(SectionItemBase sectionItem) {
            if (!sectionItem.IsRenderable)
                return MvcHtmlString.Empty;

            var heroUnitSectionItem = (HeroUnitSectionItem) sectionItem;

            var titleText = ValidationMessageFormatter.WithKey(heroUnitSectionItem.TitleKey);
            var descriptionText = ValidationMessageFormatter.WithKey(heroUnitSectionItem.DescriptionKey);

            return MvcHtmlString.Create(string.Format(SUB_HERO_UNIT_SECTION_ITEM, titleText, descriptionText));
        }
    }
}