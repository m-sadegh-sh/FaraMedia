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
    public class ApplicationSettingsController : SettingsCrudControllerBase<ApplicationSettings, EditableApplicationSettingsModel> {
        private readonly IApplicationSettingsService _applicationSettingsService;

        public ApplicationSettingsController(IApplicationSettingsService applicationSettingsService) {
            _applicationSettingsService = applicationSettingsService;
        }

        protected override Func<PermissionRecord> UserizedPermissionRecord {
            get { return () => StandardPermissionProvider.ManageApplicationSettings; }
        }

        protected override void InjectModelDependencies(EditableApplicationSettingsModel editableApplicationSettingsModel) {}

        protected override Func<ApplicationSettings> GetSettings() {
            return () => _applicationSettingsService.LoadApplicationSettings();
        }

        protected override Func<ServiceOperationResult> SaveSettingsAndReturnOperationResult(ApplicationSettings applicationSettings) {
            return () => _applicationSettingsService.SaveApplicationSettings(applicationSettings);
        }
    }
}