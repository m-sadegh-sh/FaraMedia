namespace FaraMedia.FrontEnd.Administration.Models.Configuration {
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.Configuration;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Configuration;

    public class EditableDateTimeSettingsModel : EditableSettingsModelBase {
        [ResourceDisplayName(DateTimeSettingsConstants.Fields.AllowUsersToSetTimeZone.Label)]
        public bool AllowUsersToSetTimeZone { get; set; }

        [ResourceDisplayName(DateTimeSettingsConstants.Fields.DefaultTimeZoneId.Label)]
        public string DefaultTimeZoneId { get; set; }
        public SelectList AvailableTimeZones { get; set; }
    }
}