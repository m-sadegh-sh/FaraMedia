namespace FaraMedia.FrontEnd.Administration.Controllers {
    using System;

    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Core.Domain.Configuration;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.FrontEnd.Administration.Controllers.Abstracts;
    using FaraMedia.FrontEnd.Administration.Models.Configuration;
    using FaraMedia.Services.Helpers;
    using FaraMedia.Services.Infrastructure;
    using FaraMedia.Services.Security;
    using FaraMedia.Services.Configuration;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.UI;

    [SectionName(SettingsSectionConstants.SectionName)]
    public class DateTimeSettingsController : SettingsCrudControllerBase<DateTimeSettings, EditableDateTimeSettingsModel> {
        private readonly IDateTimeSettingsService _dateTimeSettingsService;
        private readonly IDateTimeHelper _dateTimeHelper;

        public DateTimeSettingsController(IDateTimeSettingsService dateTimeSettingsService, IDateTimeHelper dateTimeHelper) {
            _dateTimeSettingsService = dateTimeSettingsService;
            _dateTimeHelper = dateTimeHelper;
        }

        protected override Func<PermissionRecord> UserizedPermissionRecord {
            get { return () => StandardPermissionProvider.ManageDateTimeSettings; }
        }

        protected override void InjectModelDependencies(EditableDateTimeSettingsModel editableDateTimeSettingsModel) {
            editableDateTimeSettingsModel.AvailableTimeZones = _dateTimeHelper.GetSystemTimeZones().ToSelectList(tzi => tzi.Id, tzi => tzi.DisplayName, editableDateTimeSettingsModel.DefaultTimeZoneId);
        }

        protected override Func<DateTimeSettings> GetSettings() {
            return () => _dateTimeSettingsService.LoadDateTimeSettings();
        }

        protected override Func<ServiceOperationResult> SaveSettingsAndReturnOperationResult(DateTimeSettings dateTimeSettings) {
            return () => _dateTimeSettingsService.SaveDateTimeSettings(dateTimeSettings);
        }
    }
}