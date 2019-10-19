namespace FaraMedia.FrontEnd.Administration.Models.Configuration {
    using FaraMedia.Data.Schemas.Configuration;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Configuration;

    public class EditableContentSettingsModel : EditableSettingsModelBase {
        [ResourceDisplayName(ContentSettingsConstants.Fields.MainPageSize.Label)]
        [ResourceMin(ContentSettingsConstants.Fields.MainPageSize.MinValue)]
        public int MainPageSize { get; set; }

        [ResourceDisplayName(ContentSettingsConstants.Fields.ArchivePageSize.Label)]
        [ResourceMin(ContentSettingsConstants.Fields.ArchivePageSize.MinValue)]
        public int ArchivePageSize { get; set; }
    }
}