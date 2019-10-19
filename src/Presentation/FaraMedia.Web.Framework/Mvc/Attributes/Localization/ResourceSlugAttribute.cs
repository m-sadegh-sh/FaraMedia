namespace FaraMedia.Web.Framework.Mvc.Attributes {
	using FaraMedia.Core.Sanitization;

	public class ResourceSlugAttribute : ResourceFormatAttribute {
        public ResourceSlugAttribute() {
            Evaluator = v => Sanitizer.IsSlug((string) v);
        }
    }
}