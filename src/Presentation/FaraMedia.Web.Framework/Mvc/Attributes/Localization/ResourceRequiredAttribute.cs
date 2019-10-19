namespace FaraMedia.Web.Framework.Mvc.Attributes {
    using System.ComponentModel.DataAnnotations;

    using FaraMedia.Services.Installation.Installers;

    public class ResourceRequiredAttribute : RequiredAttribute {
        public override string FormatErrorMessage(string name) {
            return ValidationMessageFormatter.RequiredName(name);
        }
    }
}