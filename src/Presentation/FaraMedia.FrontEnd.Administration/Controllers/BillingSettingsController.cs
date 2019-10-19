namespace FaraMedia.FrontEnd.Administration.Controllers {
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Core.Domain.Configuration;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.Configuration;
    using FaraMedia.FrontEnd.Administration.Controllers.Abstracts;
    using FaraMedia.FrontEnd.Administration.Models.Configuration;
    using FaraMedia.Services.Infrastructure;
    using FaraMedia.Services.Security;
    using FaraMedia.Services.Configuration;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.UI;

    [SectionName(SettingsSectionConstants.SectionName)]
    public class BillingSettingsController : SettingsCrudControllerBase<BillingSettings, EditableBillingSettingsModel> {
        private readonly IBillingSettingsService _billingSettingsService;

        public BillingSettingsController(IBillingSettingsService billingSettingsService) {
            _billingSettingsService = billingSettingsService;
        }

        protected override Func<PermissionRecord> UserizedPermissionRecord {
            get { return () => StandardPermissionProvider.ManageBillingSettings; }
        }

        protected override void InjectModelDependencies(EditableBillingSettingsModel editableBillingSettingsModel) {
            var availableTaxPayTypes = new List<SelectListItem> {
                new SelectListItem {
                    Text = T(BillingSettingsConstants.Fields.TaxPayType.ByPublisher),
                    Value = ((int) TaxPayType.ByPublisher).ToString()
                },
                new SelectListItem {
                    Text = T(BillingSettingsConstants.Fields.TaxPayType.ByUser),
                    Value = ((int) TaxPayType.ByUser).ToString()
                }
            };

            editableBillingSettingsModel.AvailableTaxPayTypes = availableTaxPayTypes.ToSelectList(sli => sli.Value, sli => sli.Text, editableBillingSettingsModel.TaxPayType);
        }

        protected override Func<BillingSettings> GetSettings() {
            return () => _billingSettingsService.LoadBillingSettings();
        }

        protected override Func<ServiceOperationResult> SaveSettingsAndReturnOperationResult(BillingSettings billingSettings) {
            return () => _billingSettingsService.SaveBillingSettings(billingSettings);
        }
    }
}