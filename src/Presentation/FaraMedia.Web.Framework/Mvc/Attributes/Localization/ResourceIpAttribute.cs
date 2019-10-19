namespace FaraMedia.Web.Framework.Mvc.Attributes {
    using FaraMedia.Core;

    public class ResourceIpAttribute : ResourceFormatAttribute {
        public ResourceIpAttribute() {
            Evaluator = v => CommonHelper.IsValidIp((string) v);
        }
    }
}