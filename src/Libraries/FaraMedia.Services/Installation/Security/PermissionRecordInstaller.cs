namespace FaraMedia.Services.Installation.Security {
    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Data.Schemas.Security;
    using FaraMedia.Services.Extensions.Security;
    using FaraMedia.Services.Installation.Abstraction;
    using FaraMedia.Services.Querying.Security;

    using NHibernate;

    public sealed class PermissionRecordInstaller : EntityInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(PermissionRecordConstants.Fields.SystemName.Label, "نام سیستمی");
                NewResource(PermissionRecordConstants.Fields.DisplayName.Label, "نام");
                NewResource(PermissionRecordConstants.Fields.Category.Label, "گروه");
                NewResource(PermissionRecordConstants.Fields.Description.Label, "گروه");

                NewResource(PermissionRecordConstants.Fields.Roles.Label, "گروه");

                transaction.Commit();
            }
        }

        public override void InstallEntities(IStatelessSession session) {
            var permissionProvider = EngineContext.Current.Resolve<IPermissionProvider>();

            var permissionInstaller = EngineContext.Current.Resolve<PermissionInstaller>();

            permissionInstaller.Install(permissionProvider);
        }
    }
}