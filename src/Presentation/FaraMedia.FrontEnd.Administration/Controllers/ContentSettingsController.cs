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
    public class ContentSettingsController : SettingsCrudControllerBase<ContentManagementSettings, EditableContentSettingsModel> {
        private readonly IContentSettingsService _contentSettingsService;

        public ContentSettingsController(IContentSettingsService contentSettingsService) {
            _contentSettingsService = contentSettingsService;
        }

        protected override Func<PermissionRecord> UserizedPermissionRecord {
            get { return () => StandardPermissionProvider.ManageContentSettings; }
        }

        protected override void InjectModelDependencies(EditableContentSettingsModel editableContentSettingsModel) {}

        protected override Func<ContentManagementSettings> GetSettings() {
            return () => _contentSettingsService.LoadContentSettings();
        }

        protected override Func<ServiceOperationResult> SaveSettingsAndReturnOperationResult(ContentManagementSettings contentSettings) {
            return () => _contentSettingsService.SaveContentSettings(contentSettings);
        }
    }
}