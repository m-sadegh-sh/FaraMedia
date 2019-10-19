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
    public class MiscellaneousSettingsController : SettingsCrudControllerBase<MiscellaneousSettings, EditableMiscellaneousSettingsModel> {
        private readonly IMiscellaneousSettingsService _miscellaneousSettingsService;

        public MiscellaneousSettingsController(IMiscellaneousSettingsService miscellaneousSettingsService) {
            _miscellaneousSettingsService = miscellaneousSettingsService;
        }

        protected override Func<PermissionRecord> AuthorizedPermissionRecord {
            get { return () => StandardPermissionProvider.ManageMiscellaneousSettings; }
        }

        protected override void InjectModelDependencies(EditableMiscellaneousSettingsModel editableMiscellaneousSettingsModel) {}

        protected override Func<MiscellaneousSettings> GetSettings() {
            return () => _miscellaneousSettingsService.LoadMiscellaneousSettings();
        }

        protected override Func<ServiceOperationResult> SaveSettingsAndReturnOperationResult(MiscellaneousSettings miscellaneousSettings) {
            return () => _miscellaneousSettingsService.SaveMiscellaneousSettings(miscellaneousSettings);
        }
    }
}