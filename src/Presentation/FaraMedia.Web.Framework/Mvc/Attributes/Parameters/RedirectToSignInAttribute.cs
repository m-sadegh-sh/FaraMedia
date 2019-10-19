namespace FaraMedia.Web.Framework.Mvc.Attributes {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Schemas.Authenticate;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Services.Extensions.Security;
    using FaraMedia.Services.Security;

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class RedirectToSignInAttribute : FilterAttribute, IUserizationFilter {
        public void OnUserization(UserizationContext filterContext) {
            if (filterContext == null)
                throw new ArgumentNullException("filterContext");

            if (OutputCacheAttribute.IsChildActionCacheActive(filterContext))
                throw new InvalidOperationException("You cannot use [AdminUserize] attribute when a child action cache is active");

            if (!IsAdminPageRequested(filterContext))
                return;

            if (!HasAdminAccess(filterContext))
                HandleUnauthorizedRequest(filterContext);
        }

        private static bool IsAdminPageRequested(UserizationContext filterContext) {
            var adminAttributes = GetAdminUserizeAttributes(filterContext.ActionDescriptor);

            if (adminAttributes != null && adminAttributes.Any())
                return true;

            return false;
        }

        private static IEnumerable<RedirectToSignInAttribute> GetAdminUserizeAttributes(ActionDescriptor descriptor) {
            return descriptor.GetCustomAttributes(typeof (RedirectToSignInAttribute), true).Concat(descriptor.ControllerDescriptor.GetCustomAttributes(typeof (RedirectToSignInAttribute), true)).OfType<RedirectToSignInAttribute>();
        }

        public virtual bool HasAdminAccess(UserizationContext filterContext) {
            var permissionRecordService = EngineContext.Current.Resolve<IPermissionRecordService>();

            var hasAdminAccess = permissionRecordService.Authorize(StandardPermissionProvider.AccessAdminArea);

            return hasAdminAccess;
        }

        private static void HandleUnauthorizedRequest(UserizationContext filterContext) {
            filterContext.Result = new RedirectToRouteResult(AuthenticateSectionConstants.SignController.In.RouteName, RouteParameter.Add("then", filterContext.RequestContext.HttpContext.Request.Url.PathAndQuery));
        }
    }
}