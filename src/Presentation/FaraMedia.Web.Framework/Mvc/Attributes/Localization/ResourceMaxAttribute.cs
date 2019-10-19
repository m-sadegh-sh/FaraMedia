namespace FaraMedia.Web.Framework.Mvc.Attributes {
    using System.ComponentModel.DataAnnotations;

    using FaraMedia.Core.Infrastructure.Extensions;
    using FaraMedia.Services.Installation.Installers;

    public sealed class ResourceMaxAttribute : ValidationAttribute {
        private readonly int _max;

        public ResourceMaxAttribute(int max) {
            _max = max;
        }

        public override bool IsValid(object value) {
            int temp;

            if (int.TryParse(value.ToStringOrEmpty(), out temp))
                return false;

            if (temp > _max)
                return false;

            return true;
        }

        public override string FormatErrorMessage(string name) {
            return ValidationMessageFormatter.InvalidMaxValueName(name, _max);
        }
    }
}