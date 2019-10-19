namespace FaraMedia.Web.Framework.UI.Sectionation.Renderers {
    using System.Web.Mvc;

    using FaraMedia.Web.Framework.UI.Sectionation.Items;

    public abstract class SectionItemRendererBase {
        public abstract MvcHtmlString Render(SectionItemBase sectionItem);
    }
}