namespace FaraMedia.Web.Framework.Configuration {
    using System.Configuration;

    public class ReplacementElementCollection : ConfigurationElementCollection {
        protected override ConfigurationElement CreateNewElement() {
            return new ReplacementElement();
        }

        protected override object GetElementKey(ConfigurationElement element) {
            return ((ReplacementElement) element).Original;
        }
    }
}