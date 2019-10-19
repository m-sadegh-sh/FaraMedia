namespace FaraMedia.Services.Installation.Security {
    using FaraMedia.Data.Schemas.Security;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class SecuritySectionInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(SecuritySectionConstants.Metadata.Title, "بخش عضویت");
                NewResource(SecuritySectionConstants.Metadata.Description, ResourceTemplates.SectionDescription("نقش ها و کاربران"));

                NewResource(SecuritySectionConstants.RolesController.List.Metadata.Title, "نقش ها");
                NewResource(SecuritySectionConstants.RolesController.List.Metadata.Description, ResourceTemplates.ListDescription("نقش ها", "نقش"));
                NewResource(SecuritySectionConstants.RolesController.New.Metadata.Title, ResourceTemplates.NewTitle("نقش"));
                NewResource(SecuritySectionConstants.RolesController.New.Metadata.Description, ResourceTemplates.NewDescription("نقش"));
                NewResource(SecuritySectionConstants.RolesController.Edit.Metadata.Title, ResourceTemplates.EditTitle("نقش"));
                NewResource(SecuritySectionConstants.RolesController.Edit.Metadata.Description, ResourceTemplates.EditDescription("نقش"));

                NewResource(SecuritySectionConstants.UsersController.List.Metadata.Title, "کاربران");
                NewResource(SecuritySectionConstants.UsersController.List.Metadata.Description, ResourceTemplates.ListDescription("کاربران", "کاربر"));
                NewResource(SecuritySectionConstants.UsersController.New.Metadata.Title, ResourceTemplates.NewTitle("کاربر"));
                NewResource(SecuritySectionConstants.UsersController.New.Metadata.Description, ResourceTemplates.NewDescription("کاربر"));
                NewResource(SecuritySectionConstants.UsersController.Edit.Metadata.Title, ResourceTemplates.EditTitle("کاربر"));
                NewResource(SecuritySectionConstants.UsersController.Edit.Metadata.Description, ResourceTemplates.EditDescription("کاربر"));

                NewResource(SecuritySectionConstants.BannedIpsController.List.Metadata.Title, "آی پی های بن شده");
                NewResource(SecuritySectionConstants.BannedIpsController.List.Metadata.Description, ResourceTemplates.ListDescription("آی پی های بن شده", "آی پی بن شده"));
                NewResource(SecuritySectionConstants.BannedIpsController.New.Metadata.Title, ResourceTemplates.NewTitle("آی پی بن شده"));
                NewResource(SecuritySectionConstants.BannedIpsController.New.Metadata.Description, ResourceTemplates.NewDescription("آی پی بن شده"));
                NewResource(SecuritySectionConstants.BannedIpsController.Edit.Metadata.Title, ResourceTemplates.EditTitle("آی پی بن شده"));
                NewResource(SecuritySectionConstants.BannedIpsController.Edit.Metadata.Description, ResourceTemplates.EditDescription("آی پی بن شده"));

                NewResource(SecuritySectionConstants.PermissionRecordsController.List.Metadata.Title, "سطوح دسترسی");
                NewResource(SecuritySectionConstants.PermissionRecordsController.List.Metadata.Description, ResourceTemplates.ListDescription("سطوح دسترسی", "سطح دسترسی"));
                NewResource(SecuritySectionConstants.PermissionRecordsController.New.Metadata.Title, ResourceTemplates.NewTitle("سطح دسترسی"));
                NewResource(SecuritySectionConstants.PermissionRecordsController.New.Metadata.Description, ResourceTemplates.NewDescription("سطح دسترسی"));
                NewResource(SecuritySectionConstants.PermissionRecordsController.Edit.Metadata.Title, ResourceTemplates.EditTitle("سطح دسترسی"));
                NewResource(SecuritySectionConstants.PermissionRecordsController.Edit.Metadata.Description, ResourceTemplates.EditDescription("سطح دسترسی"));

                transaction.Commit();
            }
        }
    }
}