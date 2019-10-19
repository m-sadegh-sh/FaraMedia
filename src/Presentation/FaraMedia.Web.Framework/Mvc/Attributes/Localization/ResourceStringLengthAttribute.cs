namespace FaraMedia.Web.Framework.Mvc.Attributes {
    using System.ComponentModel.DataAnnotations;

    using FaraMedia.Services.Installation.Installers;

    public class ResourceStringLengthAttribute : StringLengthAttribute {
        public ResourceStringLengthAttribute(int maximumLength) : base(maximumLength) {}

        public override string FormatErrorMessage(string name) {
            return ValidationMessageFormatter.InvalidLengthName(name, MaximumLength);
        }
    }
}