namespace FaraMedia.Web.Framework.UI.Sectionation.Renderers.Bootstrap {
    using System.Web.Mvc;

    using FaraMedia.Services.Installation.Installers;
    using FaraMedia.Web.Framework.Routing;
    using FaraMedia.Web.Framework.UI.Sectionation.Items;

    public sealed class BootstrapSectionItemRenderer : SectionItemRendererBase {
        private const string SECTION_ITEM = "<h2>{0}</h2><p>{1}</p><p>{2}</p>";

        private readonly HtmlHelper _htmlHelper;

        public BootstrapSectionItemRenderer(HtmlHelper htmlHelper) {
            _htmlHelper = htmlHelper;
        }

        public override MvcHtmlString Render(SectionItemBase sectionItemBase) {
            if (!sectionItemBase.IsRenderable)
                return MvcHtmlString.Empty;

            var sectionItem = (SectionItem) sectionItemBase;

            var titleText = ValidationMessageFormatter.WithKey(sectionItem.TitleKey);
            var descriptionText = ValidationMessageFormatter.WithKey(sectionItem.DescriptionKey);

            var link = _htmlHelper.LocalizedRouteLink(sectionItem.TitleKey, sectionItem.RouteName, sectionItem.RouteValues, new {
                @class = "btn"
            }, null, false);

            return MvcHtmlString.Create(string.Format(SECTION_ITEM, titleText, descriptionText, link));
        }
    }
}