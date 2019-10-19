namespace FaraMedia.Web.Framework.UI.Sectionation.Renderers.Bootstrap {
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using FaraMedia.Web.Framework.Mvc;

    public class BootstrapSectionRenderer : SectionRendererBase {
        private readonly IDictionary<SectionType, SectionItemRendererBase> _renderers;

        public BootstrapSectionRenderer(HtmlHelper htmlHelper) {
            _renderers = new Dictionary<SectionType, SectionItemRendererBase> {
                {SectionType.HeroUnit, new BootstrapHeroUnitSectionItemRenderer()},
                {SectionType.SubHeroUnit, new BootstrapSectionItemRenderer(htmlHelper)},
                {SectionType.SpecialSubHeroUnit, new BootstrapHeroUnitSectionItemRenderer()},
                {SectionType.Section, new BootstrapSectionItemRenderer(htmlHelper)},
                {SectionType.Separator, new BootstrapSeparatorSectionItemRenderer()}
            };
        }

        public override MvcHtmlString Render(List<SectionData> sectionDatas) {
            var mvcHtmlBuilder = new MvcHtmlStringBuilder();
            var renderedItems = 0;

            var hasHeroUnit = sectionDatas.Any(sd => sd.Type == SectionType.HeroUnit);

            for (var i = 0; i < sectionDatas.Count; i++) {
                var sectionData = sectionDatas[i];

                var sectionItem = sectionData.Item;
                var sectionType = sectionData.Type;

                if (sectionType == SectionType.Separator && renderedItems > 0)
                    renderedItems = 3;

                var isSpecialCase = !hasHeroUnit && sectionType == SectionType.SubHeroUnit;

                var renderedSection = _renderers[isSpecialCase ? SectionType.SpecialSubHeroUnit : sectionType].Render(sectionItem);

                var isRowItem = sectionType == (hasHeroUnit ? SectionType.SubHeroUnit : SectionType.Section);

                if (isRowItem)
                    renderedItems++;

                var isRowStart = renderedItems == 1;
                if (isRowStart)
                    mvcHtmlBuilder.Append("<div class=\"row\">");

                if (isRowItem)
                    mvcHtmlBuilder.Append("<div class=\"span" + (renderedItems == 1 ? "6" : "5") + "\">");

                if (sectionType != SectionType.Separator)
                    mvcHtmlBuilder.Append(renderedSection);

                if (isRowItem)
                    mvcHtmlBuilder.Append("</div>");

                var isRowEnd = renderedItems == 3 || i == sectionDatas.Count - 1;
                if (isRowEnd) {
                    mvcHtmlBuilder.Append("</div>");
                    renderedItems = 0;
                }

                if (sectionType == SectionType.Separator)
                    mvcHtmlBuilder.Append(renderedSection);
            }

            return mvcHtmlBuilder.ToString();
        }
    }
}