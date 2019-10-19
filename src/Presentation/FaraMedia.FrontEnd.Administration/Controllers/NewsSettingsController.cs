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
    public class NewsSettingsController : SettingsCrudControllerBase<NewsSettings, EditableNewsSettingsModel> {
        private readonly INewsSettingsService _newsSettingsService;

        public NewsSettingsController(INewsSettingsService newsSettingsService) {
            _newsSettingsService = newsSettingsService;
        }

        protected override Func<PermissionRecord> UserizedPermissionRecord {
            get { return () => StandardPermissionProvider.ManageNewsSettings; }
        }

        protected override void InjectModelDependencies(EditableNewsSettingsModel editableNewsSettingsModel) {}

        protected override Func<NewsSettings> GetSettings() {
            return () => _newsSettingsService.LoadNewsSettings();
        }

        protected override Func<ServiceOperationResult> SaveSettingsAndReturnOperationResult(NewsSettings newsSettings) {
            return () => _newsSettingsService.SaveNewsSettings(newsSettings);
        }
    }
}