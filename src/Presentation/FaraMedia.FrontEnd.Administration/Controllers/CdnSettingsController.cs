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
    public class CdnSettingsController : SettingsCrudControllerBase<CdnSettings, EditableCdnSettingsModel> {
        private readonly ICdnSettingsService _cdnSettingsService;

        public CdnSettingsController(ICdnSettingsService cdnSettingsService) {
            _cdnSettingsService = cdnSettingsService;
        }

        protected override Func<PermissionRecord> UserizedPermissionRecord {
            get { return () => StandardPermissionProvider.ManageCdnSettings; }
        }

        protected override void InjectModelDependencies(EditableCdnSettingsModel editableCdnSettingsModel) {}

        protected override Func<CdnSettings> GetSettings() {
            return () => _cdnSettingsService.LoadCdnSettings();
        }

        protected override Func<ServiceOperationResult> SaveSettingsAndReturnOperationResult(CdnSettings cdnSettings) {
            return () => _cdnSettingsService.SaveCdnSettings(cdnSettings);
        }
    }
}