namespace FaraMedia.FrontEnd.Administration.Models.Configuration {
    using FaraMedia.Data.Schemas.Configuration;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Configuration;

    public class EditableSecuritySettingsModel : EditableSettingsModelBase {
        [ResourceDisplayName(SecuritySettingsConstants.Fields.HideAdminMenuItemsBasedOnPermissions.Label)]
        public bool HideAdminMenuItemsBasedOnPermissions { get; set; }

        [ResourceDisplayName(SecuritySettingsConstants.Fields.UseSsl.Label)]
        public bool UseSsl { get; set; }

        [ResourceDisplayName(SecuritySettingsConstants.Fields.EncryptionKey.Label)]
        [ResourceStringLength(SecuritySettingsConstants.Fields.EncryptionKey.Length)]
        public string EncryptionKey { get; set; }

        [ResourceDisplayName(SecuritySettingsConstants.Fields.AdminAreaAllowedIpAddress.Label)]
        [ResourceStringLength(SecuritySettingsConstants.Fields.AdminAreaAllowedIpAddress.Length)]
        [ResourceIp]
        public string AdminAreaAllowedIpAddress { get; set; }
    }
}