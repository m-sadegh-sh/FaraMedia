namespace FaraMedia.FrontEnd.Administration.Models.Configuration {
    using FaraMedia.Data.Schemas.Configuration;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Configuration;

    public class EditableAdminAreaSettingsModel : EditableSettingsModelBase {
        [ResourceDisplayName(AdminAreaSettingsConstants.Fields.HideAdvertisementsOnAdminArea.Label)]
        public bool HideAdvertisementsOnAdminArea { get; set; }

        [ResourceDisplayName(AdminAreaSettingsConstants.Fields.GridPageSize.Label)]
        [ResourceMin(AdminAreaSettingsConstants.Fields.GridPageSize.MinValue)]
        public int GridPageSize { get; set; }
    }
}