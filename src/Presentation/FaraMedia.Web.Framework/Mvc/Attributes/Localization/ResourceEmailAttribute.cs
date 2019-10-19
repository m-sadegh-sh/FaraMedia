namespace FaraMedia.Web.Framework.Mvc.Attributes {
    using FaraMedia.Core;

    public class ResourceEmailAttribute : ResourceFormatAttribute {
        public ResourceEmailAttribute() {
            Evaluator = v => string.IsNullOrEmpty((string) v) || CommonHelper.IsValidEmail((string) v);
        }
    }
}