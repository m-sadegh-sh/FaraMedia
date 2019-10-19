namespace FaraMedia.FrontEnd.Administration.Controllers {
    using System;
    using System.Web.Mvc;

    using FaraMedia.Core;
    using FaraMedia.Core.Caching;
    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Data.Schemas.Common;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.Root;
    using FaraMedia.Services.Installation;
    using FaraMedia.Services.Security;
    using FaraMedia.Web.Framework.Mvc.Controllers;

    public class MaintenanceController : UserizedAreaControllerBase {
        [HttpGet]
        public ActionResult ClearCache() {
            if (!IsUserizedRequest)
                return AccessDeniedView();

            var cacheManager = EngineContext.Current.Resolve<ICacheManager>();

            cacheManager.Clear();

            ResourceSuccessNotification(CommonConstants.Systematic.ActionSucceded);

            return RedirectToRoute(RootSectionConstants.CommonController.Home.RouteName);
        }

        [HttpGet]
        public ActionResult RecoverDefaults() {
            if (!IsUserizedRequest)
                return AccessDeniedView();

            var installationService = EngineContext.Current.Resolve<IInstallationService>();

            installationService.InstallAll();

            ResourceSuccessNotification(CommonConstants.Systematic.ActionSucceded);

            return RedirectToRoute(RootSectionConstants.CommonController.Home.RouteName);
        }

        [HttpGet]
        public ActionResult RestartApplication() {
            if (!IsUserizedRequest)
                return AccessDeniedView();

            var webHelper = EngineContext.Current.Resolve<IWebHelper>();

            var success = webHelper.RestartAppDomain();

            if (success)
                ResourceSuccessNotification(CommonConstants.Systematic.ActionSucceded);
            else
                ResourceErrorNotification(CommonConstants.Systematic.ActionFailed);

            return RedirectToRoute(RootSectionConstants.CommonController.Home.RouteName);
        }

        protected override Func<PermissionRecord> UserizedPermissionRecord {
            get { return () => StandardPermissionProvider.AccessAdminArea; }
        }
    }
}