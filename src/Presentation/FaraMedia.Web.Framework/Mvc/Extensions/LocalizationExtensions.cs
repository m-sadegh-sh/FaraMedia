namespace FaraMedia.Web.Framework.Mvc.Extensions {
    using System.Web.Mvc;

    using FaraMedia.Services.Installation.Installers;

    public static class LocalizationExtensions {
        public static string T(this HtmlHelper htmlHelper, string text, params object[] args) {
            return ValidationMessageFormatter.WithKey(text, args);
        }
    }
}