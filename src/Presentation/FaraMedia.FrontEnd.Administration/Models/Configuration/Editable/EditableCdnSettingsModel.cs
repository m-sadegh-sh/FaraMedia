namespace FaraMedia.FrontEnd.Administration.Models.Configuration {
    using FaraMedia.Data.Schemas.Configuration;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Configuration;

    public class EditableCdnSettingsModel : EditableSettingsModelBase {
        [ResourceDisplayName(CdnSettingsConstants.Fields.CdnUrl.Label)]
        [ResourceStringLength(CdnSettingsConstants.Fields.CdnUrl.Length)]
        [ResourceUrl]
        public string CdnUrl { get; set; }

        [ResourceDisplayName(CdnSettingsConstants.Fields.ImagesPath.Label)]
        [ResourceStringLength(CdnSettingsConstants.Fields.ImagesPath.Length)]
        [ResourcePath]
        public string ImagesPath { get; set; }

        [ResourceDisplayName(CdnSettingsConstants.Fields.CssPath.Label)]
        [ResourceStringLength(CdnSettingsConstants.Fields.CssPath.Length)]
        [ResourcePath]
        public string CssPath { get; set; }

        [ResourceDisplayName(CdnSettingsConstants.Fields.JsPath.Label)]
        [ResourceStringLength(CdnSettingsConstants.Fields.JsPath.Length)]
        [ResourcePath]
        public string JsPath { get; set; }

        [ResourceDisplayName(CdnSettingsConstants.Fields.DownloadsPath.Label)]
        [ResourceStringLength(CdnSettingsConstants.Fields.DownloadsPath.Length)]
        [ResourcePath]
        public string DownloadsPath { get; set; }
    }
}