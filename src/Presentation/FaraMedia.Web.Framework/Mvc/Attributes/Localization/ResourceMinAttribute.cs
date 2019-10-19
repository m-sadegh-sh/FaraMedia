namespace FaraMedia.Web.Framework.Mvc.Attributes {
    using System.ComponentModel.DataAnnotations;

    using FaraMedia.Core.Infrastructure.Extensions;
    using FaraMedia.Services.Installation.Installers;

    public sealed class ResourceMinAttribute : ValidationAttribute {
        private readonly int _min;

        public ResourceMinAttribute(int min) {
            _min = min;
        }

        public override bool IsValid(object value) {
            int temp;

            if (!int.TryParse(value.ToStringOrEmpty(), out temp))
                return false;

            if (temp < _min)
                return false;

            return true;
        }

        public override string FormatErrorMessage(string name) {
            return ValidationMessageFormatter.InvalidMinValueName(name, _min);
        }
    }
}