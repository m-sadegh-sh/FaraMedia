namespace FaraMedia.Web.Framework.UI.Sectionation.Renderers.Bootstrap {
    using System.Web.Mvc;

    using FaraMedia.Web.Framework.UI.Sectionation.Items;

    public sealed class BootstrapSeparatorSectionItemRenderer : SectionItemRendererBase {
        public override MvcHtmlString Render(SectionItemBase sectionItem) {
            return MvcHtmlString.Create("<hr />");
        }
    }
}