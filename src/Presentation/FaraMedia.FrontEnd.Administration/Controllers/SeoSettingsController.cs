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
    public class SeoSettingsController : SettingsCrudControllerBase<SeoSettings, EditableSeoSettingsModel> {
        private readonly ISeoSettingsService _seoSettingsService;

        public SeoSettingsController(ISeoSettingsService seoSettingsService) {
            _seoSettingsService = seoSettingsService;
        }

        protected override Func<PermissionRecord> UserizedPermissionRecord {
            get { return () => StandardPermissionProvider.ManageSeoSettings; }
        }

        protected override void InjectModelDependencies(EditableSeoSettingsModel editableSeoSettingsModel) {}

        protected override Func<SeoSettings> GetSettings() {
            return () => _seoSettingsService.LoadSeoSettings();
        }

        protected override Func<ServiceOperationResult> SaveSettingsAndReturnOperationResult(SeoSettings seoSettings) {
            return () => _seoSettingsService.SaveSeoSettings(seoSettings);
        }
    }
}