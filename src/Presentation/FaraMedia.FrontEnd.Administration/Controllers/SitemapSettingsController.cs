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
    public class SitemapSettingsController : SettingsCrudControllerBase<SitemapSettings, EditableSitemapSettingsModel> {
        private readonly ISitemapSettingsService _sitemapSettingsService;

        public SitemapSettingsController(ISitemapSettingsService sitemapSettingsService) {
            _sitemapSettingsService = sitemapSettingsService;
        }

        protected override Func<PermissionRecord> UserizedPermissionRecord {
            get { return () => StandardPermissionProvider.ManageSitemapSettings; }
        }

        protected override void InjectModelDependencies(EditableSitemapSettingsModel editableSitemapSettingsModel) {}

        protected override Func<SitemapSettings> GetSettings() {
            return () => _sitemapSettingsService.LoadSitemapSettings();
        }

        protected override Func<ServiceOperationResult> SaveSettingsAndReturnOperationResult(SitemapSettings sitemapSettings) {
            return () => _sitemapSettingsService.SaveSitemapSettings(sitemapSettings);
        }
    }
}