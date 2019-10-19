namespace FaraMedia.Services.Extensions.Security {
    using System.Collections.Generic;

    using FaraMedia.Core.Domain.Security;

    public interface IPermissionProvider {
        IEnumerable<PermissionRecord> GetPermissionRecords();
        IEnumerable<DefaultPermissionRecord> GetDefaultPermissionRecords();
    }
}