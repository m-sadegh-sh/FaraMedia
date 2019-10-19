namespace FaraMedia.FrontEnd.Administration.Controllers {
    using System;

    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Core.Domain.Configuration;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.FrontEnd.Administration.Controllers.Abstracts;
    using FaraMedia.FrontEnd.Administration.Models.Configuration;
    using FaraMedia.Services.Infrastructure;
    using FaraMedia.Services.Systematic;
    using FaraMedia.Services.Security;
    using FaraMedia.Services.Configuration;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.UI;

    [SectionName(SettingsSectionConstants.SectionName)]
    public class LocalizationSettingsController : SettingsCrudControllerBase<LocalizationSettings, EditableLocalizationSettingsModel> {
        private readonly ILocalizationSettingsService _localizationSettingsService;
        private readonly ILanguageService _languageService;

        public LocalizationSettingsController(ILocalizationSettingsService localizationSettingsService, ILanguageService languageService) {
            _localizationSettingsService = localizationSettingsService;
            _languageService = languageService;
        }

        protected override Func<PermissionRecord> UserizedPermissionRecord {
            get { return () => StandardPermissionProvider.ManageLocalizationSettings; }
        }

        protected override void InjectModelDependencies(EditableLocalizationSettingsModel editableLocalizationSettingsModel) {
            editableLocalizationSettingsModel.AvailableLanguages = _languageService.GetAllLanguages().ToSelectList(l => l.Id, l => l.Name, editableLocalizationSettingsModel.DefaultAdminAreaLanguageId);
        }

        protected override Func<LocalizationSettings> GetSettings() {
            return () => _localizationSettingsService.LoadLocalizationSettings();
        }

        protected override Func<ServiceOperationResult> SaveSettingsAndReturnOperationResult(LocalizationSettings localizationSettings) {
            return () => _localizationSettingsService.SaveLocalizationSettings(localizationSettings);
        }
    }
}