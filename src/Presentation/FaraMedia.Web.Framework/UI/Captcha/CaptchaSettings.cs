namespace FaraMedia.Web.Framework.UI.Captcha {
    using FaraMedia.Core.Domain.Configuration;

    public class CaptchaSettings : ISettings {
        public bool Enabled { get; set; }
        public string ReCaptchaPublicKey { get; set; }
        public string ReCaptchaPrivateKey { get; set; }
    }
}