namespace FaraMedia.Web.Framework.Mvc.Attributes.Adapters {
    using System.Web.Mvc;

    public class FaraAttributeAdaptersRegisterar {
        public static void RegisterAllAdapters() {
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof (ResourceRequiredAttribute), typeof (RequiredAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof (ResourceStringLengthAttribute), typeof (StringLengthAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof (ResourceEmailAttribute), typeof (ResourceEmailAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof (ResourceUrlAttribute), typeof (ResourceUrlAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof (ResourceIpAttribute), typeof (ResourceIpAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof (ResourceMinAttribute), typeof (ResourceMinAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof (ResourceMaxAttribute), typeof (ResourceMaxAttributeAdapter));
        }
    }
}