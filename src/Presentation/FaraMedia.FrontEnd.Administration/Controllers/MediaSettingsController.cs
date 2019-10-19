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
    public class FileManagementSettingsController : SettingsCrudControllerBase<FileManagementSettings, EditableFileManagementSettingsModel> {
        private readonly IFileManagementSettingsService _fileManagementSettingsService;

        public FileManagementSettingsController(IFileManagementSettingsService fileManagementSettingsService) {
            _fileManagementSettingsService = fileManagementSettingsService;
        }

        protected override Func<PermissionRecord> AuthorizedPermissionRecord {
            get { return () => StandardPermissionProvider.ManageFileManagementSettings; }
        }

        protected override void InjectModelDependencies(EditableFileManagementSettingsModel editableFileManagementSettingsModel) {}

        protected override Func<FileManagementSettings> GetSettings() {
            return () => _fileManagementSettingsService.LoadFileManagementSettings();
        }

        protected override Func<ServiceOperationResult> SaveSettingsAndReturnOperationResult(FileManagementSettings fileManagementSettings) {
            return () => _fileManagementSettingsService.SaveFileManagementSettings(fileManagementSettings);
        }
    }
}