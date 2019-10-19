namespace FaraMedia.Web.Framework.Mvc.Attributes {
    using System;
    using System.ComponentModel.DataAnnotations;

    using FaraMedia.Services.Installation.Installers;

    public class ResourceFormatAttribute : ValidationAttribute {
        public Func<object, bool> Evaluator { get; set; }

        public override bool IsValid(object value) {
            return Evaluator(value);
        }

        public override string FormatErrorMessage(string name) {
            return ValidationMessageFormatter.InvalidFormatName(name);
        }
    }
}