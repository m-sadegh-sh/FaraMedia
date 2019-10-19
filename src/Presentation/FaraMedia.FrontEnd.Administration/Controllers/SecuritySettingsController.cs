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
    public class SecuritySettingsController : SettingsCrudControllerBase<SecuritySettings, EditableSecuritySettingsModel> {
        private readonly ISecuritySettingsService _securitySettingsService;

        public SecuritySettingsController(ISecuritySettingsService securitySettingsService) {
            _securitySettingsService = securitySettingsService;
        }

        protected override Func<PermissionRecord> UserizedPermissionRecord {
            get { return () => StandardPermissionProvider.ManageSecuritySettings; }
        }

        protected override void InjectModelDependencies(EditableSecuritySettingsModel editableSecuritySettingsModel) {}

        protected override Func<SecuritySettings> GetSettings() {
            return () => _securitySettingsService.LoadSecuritySettings();
        }

        protected override Func<ServiceOperationResult> SaveSettingsAndReturnOperationResult(SecuritySettings securitySettings) {
            return () => _securitySettingsService.SaveSecuritySettings(securitySettings);
        }
    }
}