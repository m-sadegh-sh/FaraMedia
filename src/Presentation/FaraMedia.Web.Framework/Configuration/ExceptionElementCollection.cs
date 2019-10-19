namespace FaraMedia.Web.Framework.Configuration {
    using System;
    using System.Configuration;

    public class ExceptionElementCollection : ConfigurationElementCollection {
        protected override ConfigurationElement CreateNewElement() {
            return new ExceptionElement();
        }

        protected override object GetElementKey(ConfigurationElement element) {
            var exceptionElement = (ExceptionElement) element;

            if (string.IsNullOrEmpty(exceptionElement.Id) ^ string.IsNullOrEmpty(exceptionElement.Prefix))
                return exceptionElement.Id ?? exceptionElement.Prefix;

            throw new NotSupportedException("Properties id and prefix (in exceptions) are mutually exclusive.");
        }
    }
}