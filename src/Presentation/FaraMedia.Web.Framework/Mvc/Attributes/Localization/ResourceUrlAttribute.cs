namespace FaraMedia.Web.Framework.Mvc.Attributes {
    using FaraMedia.Core;

    public class ResourceUrlAttribute : ResourceFormatAttribute {
        public ResourceUrlAttribute() {
            Evaluator = v => string.IsNullOrEmpty((string) v) || CommonHelper.IsValidUrl((string) v);
        }
    }
}