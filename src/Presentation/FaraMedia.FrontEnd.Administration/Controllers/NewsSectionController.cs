﻿namespace FaraMedia.FrontEnd.Administration.Controllers {
    using System;
    using System.Web.Mvc;

    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Services.Security;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Controllers;

    [SectionName(NewsSectionConstants.SectionName)]
    public class NewsSectionController : UserizedAreaControllerBase {
        public ActionResult Default() {
            if (!IsUserizedRequest)
                return AccessDeniedView();

            return View();
        }

        protected override Func<PermissionRecord> UserizedPermissionRecord {
            get { return () => StandardPermissionProvider.ContentManagementSection; }
        }
    }
}