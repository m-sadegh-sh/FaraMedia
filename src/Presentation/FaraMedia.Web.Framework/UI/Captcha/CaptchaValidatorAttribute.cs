namespace FaraMedia.Web.Framework.UI.Captcha {
    using System.Web.Mvc;

    using FaraMedia.Core.Infrastructure;

    using Recaptcha;

    public class CaptchaValidatorAttribute : ActionFilterAttribute {
        private const string CHALLENGE_FIELD_KEY = "recaptcha_challenge_field";
        private const string RESPONSE_FIELD_KEY = "recaptcha_response_field";

        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            var captchaSettings = EngineContext.Current.Resolve<CaptchaSettings>();
            if (captchaSettings.Enabled) {
                var captchaChallengeValue = filterContext.HttpContext.Request.Form[CHALLENGE_FIELD_KEY];
                var captchaResponseValue = filterContext.HttpContext.Request.Form[RESPONSE_FIELD_KEY];
                var captchaValidtor = new RecaptchaValidator {
                    PrivateKey = captchaSettings.ReCaptchaPrivateKey,
                    RemoteIP = filterContext.HttpContext.Request.UserHostAddress,
                    Challenge = captchaChallengeValue,
                    Response = captchaResponseValue
                };

                var recaptchaResponse = captchaValidtor.Validate();

                filterContext.ActionParameters["captchaValid"] = recaptchaResponse.IsValid;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}