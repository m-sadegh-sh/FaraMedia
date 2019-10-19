namespace FaraMedia.Web.Framework.Configuration {
    using System.Configuration;

    public class FixFarsiCharsConfigurationSection : ConfigurationSection {
        [ConfigurationProperty("applyToJson", DefaultValue = "true", IsRequired = false)]
        public bool ApplyToJson {
            get { return (bool) this["applyToJson"]; }
            set { this["applyToJson"] = value; }
        }

        [ConfigurationProperty("applyToForm", DefaultValue = "true", IsRequired = false)]
        public bool ApplyToForm {
            get { return (bool) this["applyToForm"]; }
            set { this["applyToForm"] = value; }
        }

        [ConfigurationProperty("applyToQueryString", DefaultValue = "true", IsRequired = false)]
        public bool ApplyToQueryString {
            get { return (bool) this["applyToQueryString"]; }
            set { this["applyToQueryString"] = value; }
        }

        [ConfigurationProperty("applyToCookie", DefaultValue = "true", IsRequired = false)]
        public bool ApplyToCookie {
            get { return (bool) this["applyToCookie"]; }
            set { this["applyToCookie"] = value; }
        }

        [ConfigurationProperty("replacements")]
        public ReplacementElementCollection Replacements {
            get { return (ReplacementElementCollection) this["replacements"]; }
            set { this["replacements"] = value; }
        }

        [ConfigurationProperty("exceptions")]
        public ExceptionElementCollection Exceptions {
            get { return (ExceptionElementCollection) this["exceptions"]; }
            set { this["exceptions"] = value; }
        }
    }
}