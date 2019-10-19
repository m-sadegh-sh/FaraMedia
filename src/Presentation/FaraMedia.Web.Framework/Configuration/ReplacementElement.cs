namespace FaraMedia.Web.Framework.Configuration {
    using System.Configuration;

    public class ReplacementElement : ConfigurationElement {
        [ConfigurationProperty("original", IsRequired = true)]
        public string Original {
            get { return (string) this["original"]; }
            set { this["original"] = value; }
        }

        [ConfigurationProperty("replacement", IsRequired = true)]
        public string Replacement {
            get { return (string) this["replacement"]; }
            set { this["replacement"] = value; }
        }
    }
}