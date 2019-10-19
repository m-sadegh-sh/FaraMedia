namespace FaraMedia.Web.Framework.Security {
    using System;
    using System.Web.Mvc;

    using FaraMedia.Core;
    using FaraMedia.Core.Domain.Configuration;
    using FaraMedia.Core.Infrastructure;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class HttpsRequirementAttribute : FilterAttribute, IUserizationFilter {
        public HttpsRequirementAttribute(SslRequirement sslRequirement) {
            SslRequirement = sslRequirement;
        }

        public SslRequirement SslRequirement { get; set; }

        public virtual void OnUserization(UserizationContext filterContext) {
            if (filterContext == null)
                throw new ArgumentNullException("filterContext");

            var request = filterContext.HttpContext.Request;

            if (!string.Equals(request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
                return;

            var securitySettings = EngineContext.Current.Resolve<SecuritySettings>();

            var currentConnectionSecured = request.IsSecureConnection;
            var currentUrl = request.Url.AbsoluteUri;

            switch (SslRequirement) {
                case SslRequirement.Yes: {
                    if (!currentConnectionSecured) {
                        var webHelper = EngineContext.Current.Resolve<IWebHelper>();

                        if (securitySettings.UseSsl) {
                            var url = webHelper.GetUrltrue, true);

                            if (string.CompareOrdinal(url, currentUrl) != 0)
                                filterContext.Result = new RedirectResult(url);
                        }
                    }
                }
                    break;
                case SslRequirement.No: {
                    if (currentConnectionSecured) {
                        var webHelper = EngineContext.Current.Resolve<IWebHelper>();

                        var url = webHelper.GetUrltrue, false);

                        if (string.CompareOrdinal(url, currentUrl) != 0)
                            filterContext.Result = new RedirectResult(url);
                    }
                }
                    break;
            }
        }
    }
}