namespace FaraMedia.Services.Extensions.Security {
    using System.Linq;

    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Services.Querying.Security;

    public sealed class PermissionInstaller {
        private readonly IDbService<PermissionRecord, PermissionRecordQuery> _permissionRecordService;
        private readonly IDbService<Role, RoleQuery> _roleService;

        public PermissionInstaller(IDbService<PermissionRecord, PermissionRecordQuery> permissionRecordService, IDbService<Role, RoleQuery> roleService) {
            _permissionRecordService = permissionRecordService;
            _roleService = roleService;
        }

        public void Install(IPermissionProvider permissionProvider) {
            var permissionRecords = permissionProvider.GetPermissionRecords();

            foreach (var permissionRecord in permissionRecords) {
                var dbPermissionRecord = _permissionRecordService.GetBySystemName(permissionRecord.SystemName);

                if (dbPermissionRecord != null)
                    continue;

                dbPermissionRecord = new PermissionRecord {
                    SystemName = permissionRecord.SystemName,
                    DisplayName = permissionRecord.DisplayName,
                    Category = permissionRecord.Category
                };

                var defaultPermissionRecords = permissionProvider.GetDefaultPermissionRecords();

                foreach (var defaultPermission in defaultPermissionRecords) {
                    var role = _roleService.GetBySystemName(defaultPermission.RoleSystemName);

                    if (role == null) {
                        role = new Role {
                            IsActive = true,
                            SystemName = defaultPermission.RoleSystemName,
                            DisplayName = defaultPermission.RoleSystemName
                        };

                        _roleService.Save(role);
                    }

                    var defaultMappingProvided = defaultPermission.Records.Any(pr => pr.SystemName == dbPermissionRecord.SystemName);

                    var mappingExists = role.Records.Any(pr => pr.SystemName == dbPermissionRecord.SystemName);

                    if (defaultMappingProvided && !mappingExists)
                        dbPermissionRecord.Roles.Add(role);
                }

                _permissionRecordService.Save(dbPermissionRecord);
            }
        }

        public void Uninstall(IPermissionProvider permissionProvider) {
            var permissionRecords = permissionProvider.GetPermissionRecords();

            foreach (var permissionRecord in
                permissionRecords.Select(pr => _permissionRecordService.GetBySystemName(pr.SystemName)).Where(pr => pr != null))
                _permissionRecordService.Delete(permissionRecord);
        }
    }
}