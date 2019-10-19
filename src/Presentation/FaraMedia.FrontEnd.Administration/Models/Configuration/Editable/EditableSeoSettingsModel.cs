namespace FaraMedia.FrontEnd.Administration.Models.Configuration {
    using FaraMedia.Data.Schemas.Configuration;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Configuration;

    public class EditableSeoSettingsModel : EditableSettingsModelBase {
        [ResourceDisplayName(SeoSettingsConstants.Fields.ConvertNonWesternChars.Label)]
        public bool ConvertNonWesternChars { get; set; }

        [ResourceDisplayName(SeoSettingsConstants.Fields.AllowUnicodeCharsInUrls.Label)]
        public bool AllowUnicodeCharsInUrls { get; set; }

        [ResourceDisplayName(SeoSettingsConstants.Fields.CanonicalUrlsEnabled.Label)]
        public bool CanonicalUrlsEnabled { get; set; }

        [ResourceDisplayName(SeoSettingsConstants.Fields.TitleSeparator.Label)]
        [ResourceStringLength(SeoSettingsConstants.Fields.TitleSeparator.Length)]
        public string TitleSeparator { get; set; }

        [ResourceDisplayName(SeoSettingsConstants.Fields.DefaultTitle.Label)]
        [ResourceStringLength(SeoSettingsConstants.Fields.DefaultTitle.Length)]
        public string DefaultTitle { get; set; }

        [ResourceDisplayName(SeoSettingsConstants.Fields.DefaultMetaKeywords.Label)]
        [ResourceStringLength(SeoSettingsConstants.Fields.DefaultMetaKeywords.Length)]
        public string DefaultMetaKeywords { get; set; }

        [ResourceDisplayName(SeoSettingsConstants.Fields.DefaultMetaDescription.Label)]
        [ResourceStringLength(SeoSettingsConstants.Fields.DefaultMetaDescription.Length)]
        public string DefaultMetaDescription { get; set; }

        [ResourceDisplayName(SeoSettingsConstants.Fields.BreadcrumbSeparator.Label)]
        [ResourceStringLength(SeoSettingsConstants.Fields.BreadcrumbSeparator.Length)]
        public string BreadcrumbSeparator { get; set; }
    }
}