namespace FaraMedia.FrontEnd.Administration.Models.Configuration {
    using FaraMedia.Data.Schemas.Configuration;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Configuration;

    public class EditableSitemapSettingsModel : EditableSettingsModelBase {
        [ResourceDisplayName(SitemapSettingsConstants.Fields.Enabled.Label)]
        public bool Enabled { get; set; }

        [ResourceDisplayName(SitemapSettingsConstants.Fields.IncludePages.Label)]
        public bool IncludePages { get; set; }

        [ResourceDisplayName(SitemapSettingsConstants.Fields.IncludeTags.Label)]
        public bool IncludeTags { get; set; }

        [ResourceDisplayName(SitemapSettingsConstants.Fields.IncludePosts.Label)]
        public bool IncludePosts { get; set; }

        [ResourceDisplayName(SitemapSettingsConstants.Fields.IncludeCategories.Label)]
        public bool IncludeCategories { get; set; }

        [ResourceDisplayName(SitemapSettingsConstants.Fields.IncludeNews.Label)]
        public bool IncludeNews { get; set; }

        [ResourceDisplayName(SitemapSettingsConstants.Fields.IncludeGenres.Label)]
        public bool IncludeGenres { get; set; }

        [ResourceDisplayName(SitemapSettingsConstants.Fields.IncludePublishers.Label)]
        public bool IncludePublishers { get; set; }

        [ResourceDisplayName(SitemapSettingsConstants.Fields.IncludeArtists.Label)]
        public bool IncludeArtists { get; set; }

        [ResourceDisplayName(SitemapSettingsConstants.Fields.IncludeAlbums.Label)]
        public bool IncludeAlbums { get; set; }

        [ResourceDisplayName(SitemapSettingsConstants.Fields.IncludeSingleTracks.Label)]
        public bool IncludeSingleTracks { get; set; }

        [ResourceDisplayName(SitemapSettingsConstants.Fields.IncludePolls.Label)]
        public bool IncludePolls { get; set; }
    }
}