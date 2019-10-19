namespace FaraMedia.Web.Framework.Mvc.Extensions {
    using System.Web.Mvc;

    public static class TagBuilderExtensions {
        public static void AppendAttribute(this TagBuilder tagBuilder, string key, string value) {
            if (tagBuilder.Attributes.ContainsKey(key))
                tagBuilder.Attributes[key] = tagBuilder.Attributes[key] + " " + value;
            else
                tagBuilder.MergeAttribute(key, value);
        }
        
        public static MvcHtmlString ToMvcHtmlString(this TagBuilder tagBuilder, TagRenderMode renderMode) {
            return new MvcHtmlString(tagBuilder.ToString(renderMode));
        }
    }
}