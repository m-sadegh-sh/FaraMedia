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
    public class MessageTemplateSettingsController : SettingsCrudControllerBase<SystemSettings, EditableMessageTemplateSettingsModel> {
        private readonly IMessageTemplateSettingsService _messageTemplateSettingsService;

        public MessageTemplateSettingsController(IMessageTemplateSettingsService messageTemplateSettingsService) {
            _messageTemplateSettingsService = messageTemplateSettingsService;
        }

        protected override Func<PermissionRecord> UserizedPermissionRecord {
            get { return () => StandardPermissionProvider.ManageMessageTemplateSettings; }
        }

        protected override void InjectModelDependencies(EditableMessageTemplateSettingsModel editableMessageTemplateSettingsModel) {}

        protected override Func<SystemSettings> GetSettings() {
            return () => _messageTemplateSettingsService.LoadMessageTemplateSettings();
        }

        protected override Func<ServiceOperationResult> SaveSettingsAndReturnOperationResult(SystemSettings messageTemplateSettings) {
            return () => _messageTemplateSettingsService.SaveMessageTemplateSettings(messageTemplateSettings);
        }
    }
}