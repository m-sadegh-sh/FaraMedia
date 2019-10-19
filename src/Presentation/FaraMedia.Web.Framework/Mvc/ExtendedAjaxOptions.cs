namespace FaraMedia.Web.Framework.Mvc {
    using System.Web.Mvc.Ajax;

    using FaraMedia.Web.Framework.UI;

    public sealed class ExtendedAjaxOptions : AjaxOptions {
        public ExtendedAjaxOptions() {
            var pageElementsConfig = PageElementsConfig.Load();

            LoadingElementId = pageElementsConfig.AjaxLoadingElementId;
            UpdateTargetId = pageElementsConfig.AjaxPlaceHolderElementId;
            InsertionMode = InsertionMode.Replace;
            HttpMethod = "Get";
        }
    }
}