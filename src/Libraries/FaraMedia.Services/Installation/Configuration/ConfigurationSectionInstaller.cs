namespace FaraMedia.Services.Installation.Configuration {
    using FaraMedia.Data.Schemas.Configuration;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class ConfigurationSectionInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            using (var transaction = session.BeginTransaction()) {
                NewResource(ConfigurationSectionConstants.Metadata.Title, "بخش پیکربندی");
                NewResource(ConfigurationSectionConstants.Metadata.Description, ResourceTemplates.SectionDescription("تنظیمات"));

                NewResource(ConfigurationSectionConstants.BillingSettingsController.Save.Metadata.Title, ResourceTemplates.SaveTitle("مالی"));
                NewResource(ConfigurationSectionConstants.BillingSettingsController.Save.Metadata.Description, ResourceTemplates.SaveDescription("مالی"));

                NewResource(ConfigurationSectionConstants.FileManagementSettingsController.Save.Metadata.Title, ResourceTemplates.SaveTitle("مدیا"));
                NewResource(ConfigurationSectionConstants.FileManagementSettingsController.Save.Metadata.Description, ResourceTemplates.SaveDescription("مدیا"));

                NewResource(ConfigurationSectionConstants.SecuritySettingsController.Save.Metadata.Title, ResourceTemplates.SaveTitle("امنیتی"));
                NewResource(ConfigurationSectionConstants.SecuritySettingsController.Save.Metadata.Description, ResourceTemplates.SaveDescription("امنیتی"));

                NewResource(ConfigurationSectionConstants.SystemSettingsController.Save.Metadata.Title, ResourceTemplates.SaveTitle("امنیتی"));
                NewResource(ConfigurationSectionConstants.SystemSettingsController.Save.Metadata.Description, ResourceTemplates.SaveDescription("امنیتی"));

                NewResource(ConfigurationSectionConstants.SettingsController.List.Metadata.Title, "تنظیمات");
                NewResource(ConfigurationSectionConstants.SettingsController.List.Metadata.Description, ResourceTemplates.ListDescription("تنظیمات", "تنظیمات"));
                NewResource(ConfigurationSectionConstants.SettingsController.New.Metadata.Title, ResourceTemplates.NewTitle("تنظیمات"));
                NewResource(ConfigurationSectionConstants.SettingsController.New.Metadata.Description, ResourceTemplates.NewDescription("تنظیمات"));
                NewResource(ConfigurationSectionConstants.SettingsController.Edit.Metadata.Title, ResourceTemplates.EditTitle("تنظیمات"));
                NewResource(ConfigurationSectionConstants.SettingsController.Edit.Metadata.Description, ResourceTemplates.EditDescription("تنظیمات"));

                transaction.Commit();
            }
        }
    }
}