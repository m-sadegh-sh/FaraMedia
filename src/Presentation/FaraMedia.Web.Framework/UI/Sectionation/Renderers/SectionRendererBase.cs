namespace FaraMedia.Web.Framework.UI.Sectionation.Renderers {
    using System.Collections.Generic;
    using System.Web.Mvc;

    public abstract class SectionRendererBase {
        public abstract MvcHtmlString Render(List<SectionData> sectionDatas);
    }
}