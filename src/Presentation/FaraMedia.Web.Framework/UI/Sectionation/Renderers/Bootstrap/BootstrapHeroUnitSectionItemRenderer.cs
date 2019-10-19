namespace FaraMedia.Web.Framework.UI.Sectionation.Renderers.Bootstrap {
    using System.Web.Mvc;

    using FaraMedia.Services.Installation.Installers;
    using FaraMedia.Web.Framework.UI.Sectionation.Items;

    public sealed class BootstrapHeroUnitSectionItemRenderer : SectionItemRendererBase {
        private const string HERO_UNIT_SECTION_ITEM = "<div class=\"hero-unit\"><h1>{0}</h1><p>{1}</p></div>";

        public override MvcHtmlString Render(SectionItemBase sectionItem) {
            if(!sectionItem.IsRenderable)
                return MvcHtmlString.Empty;

            var heroUnitSectionItem = (HeroUnitSectionItem) sectionItem;

            var titleText = ValidationMessageFormatter.WithKey(heroUnitSectionItem.TitleKey);
            var descriptionText = ValidationMessageFormatter.WithKey(heroUnitSectionItem.DescriptionKey);

            return MvcHtmlString.Create(string.Format(HERO_UNIT_SECTION_ITEM, titleText, descriptionText));
        }
    }
}