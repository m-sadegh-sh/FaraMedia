namespace FaraMedia.Web.Framework.Mvc.Controllers {
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Web.Routing;

    using FaraMedia.Core;
    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.Root;
    using FaraMedia.Services.Systematic;
    using FaraMedia.Services.Systematic;
    using FaraMedia.Services.Security;
    using FaraMedia.Services.Configuration;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Security;
    using FaraMedia.Web.Framework.UI;

    public abstract class FaraControllerBase : Controller {
        protected IStringResourceService StringResourceService { get; set; }

        protected IPermissionRecordService PermissionRecordService { get; private set; }

        protected override void Initialize(RequestContext requestContext) {
            EngineContext.Current.Resolve<IWorkContext>().IsAdmin = true;

            base.Initialize(requestContext);

            StringResourceService = EngineContext.Current.Resolve<IStringResourceService>();

            PermissionRecordService = EngineContext.Current.Resolve<IPermissionRecordService>();
        }

        public void CoreExecute(RequestContext requestContext) {
            Execute(requestContext);
        }
        
        protected bool CheckUserization(PermissionRecord permissionRecord) {
            return permissionRecord != null && PermissionRecordService.Authorize(permissionRecord);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext) {
            ValidateIpAddress(filterContext);

            base.OnActionExecuting(filterContext);
        }

        protected override void OnException(ExceptionContext filterContext) {
            if (filterContext.Exception != null)
                LogException(filterContext.Exception);

            base.OnException(filterContext);
        }

        protected virtual void ValidateIpAddress(ActionExecutingContext filterContext) {
            var isValid = true;
            var webHelper = EngineContext.Current.Resolve<IWebHelper>();
            var allowedIpAddress = EngineContext.Current.Resolve<ISecuritySettingsService>().LoadSecuritySettings().AdminAreaAllowedIpAddress;

            if (!string.IsNullOrEmpty(allowedIpAddress)) {
                var currentIpAddress = webHelper.GetIpAddress();
                isValid = allowedIpAddress.Equals(currentIpAddress, StringComparison.InvariantCultureIgnoreCase);
            }

            if (isValid)
                return;

            var currentUrl = webHelper.GetUrl(true, false);
            if (!currentUrl.StartsWith(Url.RouteUrl(RootSectionConstants.ErrorsController.AccessDenied.RouteName), StringComparison.InvariantCultureIgnoreCase))
                filterContext.Result = RedirectToRoute(RootSectionConstants.ErrorsController.AccessDenied.RouteName);
        }

        protected ActionResult AccessDeniedView() {
            return RedirectToRoute(RootSectionConstants.ErrorsController.AccessDenied.RouteName, RouteParameter.Add("url", Request.RawUrl));
        }

        private static void LogException(Exception exception) {
            var workContext = EngineContext.Current.Resolve<IWorkContext>();
            var logService = EngineContext.Current.Resolve<ILogService>();

            var user = workContext.CurrentUser;
            logService.Error(exception.Message, exception, user);
        }

        protected virtual void ResourceSuccessNotification(string key, bool persistForTheNextRequest = true) {
            var message = T(key);

            SuccessNotification(message, persistForTheNextRequest);
        }

        protected virtual void SuccessNotification(string message, bool persistForTheNextRequest = true) {
            AddNotification(NotifyType.Success, message, persistForTheNextRequest);
        }

        protected virtual void ResourceErrorNotification(string key, bool persistForTheNextRequest = true) {
            var message = T(key);

            ErrorNotification(message);
        }

        protected virtual void ErrorNotification(string message, bool persistForTheNextRequest = true) {
            AddNotification(NotifyType.Error, message, persistForTheNextRequest);
        }

        protected virtual void ErrorNotification(Exception exception, bool persistForTheNextRequest = true) {
            LogException(exception);
            AddNotification(NotifyType.Error, exception.Message, persistForTheNextRequest);
        }

        protected virtual void AddNotification(NotifyType notifyType, string message, bool persistForTheNextRequest) {
            var dataKey = string.Format("fara.notifications.{0}", notifyType);
            if (persistForTheNextRequest) {
                if (TempData[dataKey] == null)
                    TempData[dataKey] = new List<string>();
                ((List<string>) TempData[dataKey]).Add(message);
            } else {
                if (ViewData[dataKey] == null)
                    ViewData[dataKey] = new List<string>();
                ((List<string>) ViewData[dataKey]).Add(message);
            }
        }

        protected string T(string resourceKey, params object[] args) {
            var resourceFormat = StringResourceService.GetResourceValue(resourceKey);

            if (string.IsNullOrEmpty(resourceFormat))
                return resourceKey;

            return args == null || args.Length == 0 ? resourceFormat : string.Format(resourceFormat, args);
        }
    }
}