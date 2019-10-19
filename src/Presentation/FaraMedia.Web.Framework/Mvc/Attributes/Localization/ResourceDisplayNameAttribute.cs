namespace FaraMedia.Web.Framework.Mvc.Attributes {
    using System.ComponentModel;

    using FaraMedia.Services.Installation.Installers;

    public class ResourceDisplayNameAttribute : DisplayNameAttribute {
        public ResourceDisplayNameAttribute(string key) : base(key) {
            Key = key;
        }

        public string Key { get; set; }

        public override string DisplayName {
            get { return ValidationMessageFormatter.WithKey(Key); }
        }
    }
}