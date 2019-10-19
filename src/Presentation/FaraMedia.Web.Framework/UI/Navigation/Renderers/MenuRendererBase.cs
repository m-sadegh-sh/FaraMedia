namespace FaraMedia.Web.Framework.UI.Navigation.Renderers {
    using System.Collections.Generic;
    using System.Web.Mvc;

    public abstract class MenuRendererBase {
        public abstract MvcHtmlString Render(List<MenuData> menuDatas);
    }
}