namespace FaraMedia.Web.Framework.Mvc.Controllers {
    using System;

    using FaraMedia.Core.Domain.Security;

    public abstract class UserizedAreaControllerBase : SecuredAreaControllerBase {
        protected bool IsUserizedRequest {
            get {
                var permissionRecord = UserizedPermissionRecord();

                return CheckUserization(permissionRecord);
            }
        }

        protected abstract Func<PermissionRecord> UserizedPermissionRecord { get; }
    }
}