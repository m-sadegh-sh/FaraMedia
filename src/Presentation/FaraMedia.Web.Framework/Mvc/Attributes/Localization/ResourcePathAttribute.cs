namespace FaraMedia.Web.Framework.Mvc.Attributes {
    using FaraMedia.Core;

    public class ResourcePathAttribute : ResourceFormatAttribute {
        public ResourcePathAttribute() {
            Evaluator = v => CommonHelper.IsValidPath((string) v);
        }
    }
}