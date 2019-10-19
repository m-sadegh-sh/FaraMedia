namespace FaraMedia.Web.Framework.Mvc.UI {
    using System.Web.Mvc;

    public static class CustomHelperExtensions {
        public static CustomHelper Custom(this HtmlHelper htmlHelper) {
            return new CustomHelper(htmlHelper);
        }

        public static GenericCustomHelper<TModel> Custom<TModel>(this HtmlHelper<TModel> htmlHelper) {
            return new GenericCustomHelper<TModel>(htmlHelper);
        }
    }
}