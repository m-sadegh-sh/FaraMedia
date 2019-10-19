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
    public class EmailAccountSettingsController : SettingsCrudControllerBase<EmailAccountSettings, EditableEmailAccountSettingsModel> {
        private readonly IEmailAccountSettingsService _emailAccountSettingsService;
        private readonly IEmailAccountService _emailAccountService;

        public EmailAccountSettingsController(IEmailAccountSettingsService emailAccountSettingsService, IEmailAccountService emailAccountService) {
            _emailAccountSettingsService = emailAccountSettingsService;
            _emailAccountService = emailAccountService;
        }

        protected override Func<PermissionRecord> UserizedPermissionRecord {
            get { return () => StandardPermissionProvider.ManageEmailAccountSettings; }
        }

        protected override void InjectModelDependencies(EditableEmailAccountSettingsModel editableEmailAccountSettingsModel) {
            editableEmailAccountSettingsModel.AvailableEmailAccounts = _emailAccountService.GetAllEmailAccounts().ToSelectList(ea => ea.Id, ea => ea.DisplayName, editableEmailAccountSettingsModel.DefaultEmailAccountId);
        }

        protected override Func<EmailAccountSettings> GetSettings() {
            return () => _emailAccountSettingsService.LoadEmailAccountSettings();
        }

        protected override Func<ServiceOperationResult> SaveSettingsAndReturnOperationResult(EmailAccountSettings emailAccountSettings) {
            return () => _emailAccountSettingsService.SaveEmailAccountSettings(emailAccountSettings);
        }
    }
}