namespace FaraMedia.FrontEnd.Administration.Controllers {
    using System;

    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Core.Domain.Configuration;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.FrontEnd.Administration.Controllers.Abstracts;
    using FaraMedia.FrontEnd.Administration.Models.Configuration;
    using FaraMedia.Services.Infrastructure;
    using FaraMedia.Services.Security;
    using FaraMedia.Services.Configuration;
    using FaraMedia.Web.Framework.Mvc.Attributes;

    [SectionName(SettingsSectionConstants.SectionName)]
    public class AdminAreaSettingsController : SettingsCrudControllerBase<AdminAreaSettings, EditableAdminAreaSettingsModel> {
        private readonly IAdminAreaSettingsService _adminAreaSettingsService;

        public AdminAreaSettingsController(IAdminAreaSettingsService adminAreaSettingsService) {
            _adminAreaSettingsService = adminAreaSettingsService;
        }

        protected override Func<PermissionRecord> UserizedPermissionRecord {
            get { return () => StandardPermissionProvider.ManageAdminAreaSettings; }
        }

        protected override void InjectModelDependencies(EditableAdminAreaSettingsModel editableAdminAreaSettingsModel) {}

        protected override Func<AdminAreaSettings> GetSettings() {
            return () => _adminAreaSettingsService.LoadAdminAreaSettings();
        }

        protected override Func<ServiceOperationResult> SaveSettingsAndReturnOperationResult(AdminAreaSettings adminAreaSettings) {
            return () => _adminAreaSettingsService.SaveAdminAreaSettings(adminAreaSettings);
        }
    }
}