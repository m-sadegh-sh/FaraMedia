namespace FaraMedia.Services.Extensions.Security {
    using System;
    using System.Linq;

    using FaraMedia.Core;
    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Core.SafeCode;
    using FaraMedia.Services.Querying.Security;

    public static class PermissionRecordServiceExtensions {
        public static bool AuthorizeBySystemName(this IDbService<PermissionRecord, PermissionRecordQuery> service, string systemName) {
            if (Neutrals.Is(systemName))
                return false;

            var permissionRecord = service.GetBySystemName(systemName);

            return Authorize(permissionRecord);
        }

        public static bool Authorize(PermissionRecord permissionRecord) {
            var workContext = EngineContext.Current.Resolve<IWorkContext>();

            return Authorize(permissionRecord, workContext.CurrentUser);
        }

        public static bool Authorize(PermissionRecord permissionRecord, User user) {
            var workContext = EngineContext.Current.Resolve<IWorkContext>();

            if (permissionRecord == null)
                return false;

            if (user == null)
                return false;

            var roles = workContext.CurrentUser.Roles.Where(r => r.IsActive);

            return roles.Any(r => r.Records.Any(pr => pr.SystemName.Equals(permissionRecord.SystemName, StringComparison.InvariantCultureIgnoreCase)));
        }
    }
}