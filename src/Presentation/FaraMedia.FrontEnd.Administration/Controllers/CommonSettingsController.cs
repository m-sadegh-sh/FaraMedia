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
    public class CommonSettingsController : SettingsCrudControllerBase<CommonSettings, EditableCommonSettingsModel> {
        private readonly ICommonSettingsService _commonSettingsService;

        public CommonSettingsController(ICommonSettingsService commonSettingsService) {
            _commonSettingsService = commonSettingsService;
        }

        protected override Func<PermissionRecord> UserizedPermissionRecord {
            get { return () => StandardPermissionProvider.ManageCommonSettings; }
        }

        protected override void InjectModelDependencies(EditableCommonSettingsModel editableCommonSettingsModel) {}

        protected override Func<CommonSettings> GetSettings() {
            return () => _commonSettingsService.LoadCommonSettings();
        }

        protected override Func<ServiceOperationResult> SaveSettingsAndReturnOperationResult(CommonSettings commonSettings) {
            return () => _commonSettingsService.SaveCommonSettings(commonSettings);
        }
    }
}