namespace FaraMedia.FrontEnd.Administration.Models.Configuration {
    using FaraMedia.Data.Schemas.Configuration;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Configuration;

    public class EditableApplicationSettingsModel : EditableSettingsModelBase {
        [ResourceDisplayName(ApplicationSettingsConstants.Fields.IsClosed.Label)]
        public bool IsClosed { get; set; }
        
        [ResourceDisplayName(ApplicationSettingsConstants.Fields.MobileDevicesSupported.Label)]
        public bool MobileDevicesSupported { get; set; }

        [ResourceDisplayName(ApplicationSettingsConstants.Fields.ShowHeaderRssUrl.Label)]
        public bool ShowHeaderRssUrl { get; set; }

        [ResourceDisplayName(ApplicationSettingsConstants.Fields.DefaultPageSize.Label)]
        [ResourceMin(ApplicationSettingsConstants.Fields.DefaultPageSize.MinValue)]
        public int DefaultPageSize { get; set; }

        [ResourceDisplayName(ApplicationSettingsConstants.Fields.Name.Label)]
        [ResourceStringLength(ApplicationSettingsConstants.Fields.Name.Length)]
        public string Name { get; set; }

        [ResourceDisplayName(ApplicationSettingsConstants.Fields.Url.Label)]
        [ResourceRequired]
        [ResourceStringLength(ApplicationSettingsConstants.Fields.Url.Length)]
        [ResourceUrl]
        public string Url { get; set; }
    }
}