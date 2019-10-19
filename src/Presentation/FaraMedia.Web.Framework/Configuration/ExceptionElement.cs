namespace FaraMedia.Web.Framework.Configuration {
    using System.Configuration;

    public class ExceptionElement : ConfigurationElement {
        [ConfigurationProperty("id", IsRequired = false)]
        public string Id {
            get { return (string) this["id"]; }
            set { this["id"] = value; }
        }

        [ConfigurationProperty("prefix", IsRequired = false)]
        public string Prefix {
            get { return (string) this["prefix"]; }
            set { this["prefix"] = value; }
        }
    }
}