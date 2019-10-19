namespace FaraMedia.Web.Framework.Routing.Seo {
    using System.Web.Mvc;

    using FaraMedia.Core.Domain.Configuration;
    using FaraMedia.Services.Fundamentals;
    using FaraMedia.Services.Fundamentals;
    using FaraMedia.Services.ContentManagement;
    using FaraMedia.Services.Fundamentals;
    using FaraMedia.Services.ContentManagement;
    using FaraMedia.Services.ContentManagement;
    using FaraMedia.Services.ContentManagement;
    using FaraMedia.Services.Fundamentals;
    using FaraMedia.Services.Configuration;
    using FaraMedia.Services.Fundamentals;

    public sealed class SitemapGenerator : SitemapGeneratorBase, ISitemapGenerator {
        private readonly UrlHelper _urlHelper;
        private readonly IGroupService _groupService;
        private readonly IPageService _pageService;
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly INewsService _newsService;
        private readonly IGenreService _genreService;
        private readonly IPublisherService _publisherService;
        private readonly IArtistService _artistService;
        private readonly IAlbumService _albumService;
        private readonly ITrackService _trackService;
        private readonly IPollService _pollService;
        private readonly SitemapSettings _sitemapSettings;

        public SitemapGenerator(UrlHelper urlHelper, IGroupService groupService, IPageService pageService, IPostService postService, ICategoryService categoryService, INewsService newsService, IGenreService genreService, IPublisherService publisherService, IArtistService artistService, IAlbumService albumService, ITrackService trackService, IPollService pollService, ISitemapSettingsService sitemapSettingsService) {
            _urlHelper = urlHelper;
            _groupService = groupService;
            _pageService = pageService;
            _postService = postService;
            _categoryService = categoryService;
            _newsService = newsService;
            _genreService = genreService;
            _publisherService = publisherService;
            _artistService = artistService;
            _albumService = albumService;
            _trackService = trackService;
            _pollService = pollService;
            _sitemapSettings = sitemapSettingsService.LoadSitemapSettings();
        }

        protected override void GenerateUrlNodes() {
            if (_sitemapSettings.IncludePages)
                WritePages();

            if (_sitemapSettings.IncludePosts)
                WritePosts();

            //if (_sitemapSettings.IncludeNews)
            //    WriteNews();

            //if (_sitemapSettings.IncludeGenres)
            //    WriteGenres();

            //if (_sitemapSettings.IncludePublishers)
            //    WritePublishers();

            //if (_sitemapSettings.IncludeArtists)
            //    WriteArtists();

            //if (_sitemapSettings.IncludeAlbums)
            //    WriteAlbums();

            //if (_sitemapSettings.IncludeSingleTracks)
            //    WriteSingleTracks();

            //if (_sitemapSettings.IncludePolls)
            //    WritePolls();
        }

        private void WritePages() {
            var groups = _groupService.GetAllGroups();

            foreach (var group in groups) {
                var pages = _pageService.GetAllPagesByGroupId(group.Id);
                foreach (var page in pages) {
                    var requestUrl = _urlHelper.RouteUrl("Page", new {
                        id = page
                    });

                    WriteUrlLocation(requestUrl, UpdateFrequency.Weekly, page.LastModifiedOnUtc);
                }
            }
        }

        private void WritePosts() {
            var posts = _postService.GetAllPosts();

            foreach (var post in posts) {
                var postUrl = _urlHelper.RouteUrl("Post", new {
                    id = post.Id
                });

                WriteUrlLocation(postUrl, UpdateFrequency.Weekly, post.LastModifiedOnUtc);
            }
        }

        //private void WriteNews() {
        //    var categories = _categoryService.GetAllCategories();

        //    foreach (var category in categories) {
        //        var categoryNews = _newsService.GetAllNewsByCategoryId(category.Id);
        //        foreach (var news in categoryNews) {
        //            var newsUrl = _urlHelper.DetailsUrl(news);

        //            WriteUrlLocation(newsUrl, UpdateFrequency.Weekly, news.LastModifiedOnUtc);
        //        }
        //    }
        //}

        //private void WriteGenres() {
        //    var genres = _genreService.GetAllGenres();

        //    foreach (var genre in genres) {
        //        var genreUrl = _urlHelper.DetailsUrl(genre);

        //        WriteUrlLocation(genreUrl, UpdateFrequency.Weekly, genre.LastModifiedOnUtc);
        //    }
        //}

        //private void WritePublishers() {
        //    var publishers = _publisherService.GetAllPublishers();

        //    foreach (var publisher in publishers) {
        //        var publisherUrl = _urlHelper.DetailsUrl(publisher);

        //        WriteUrlLocation(publisherUrl, UpdateFrequency.Weekly, publisher.LastModifiedOnUtc);
        //    }
        //}

        //private void WriteArtists() {
        //    var artists = _artistService.GetAllArtists();

        //    foreach (var artist in artists) {
        //        var artistUrl = _urlHelper.DetailsUrl(artist);

        //        WriteUrlLocation(artistUrl, UpdateFrequency.Weekly, artist.LastModifiedOnUtc);
        //    }
        //}

        //private void WriteAlbums() {
        //    var albums = _albumService.GetAllAlbums();

        //    foreach (var album in albums) {
        //        var albumUrl = _urlHelper.DetailsUrl(album);

        //        WriteUrlLocation(albumUrl, UpdateFrequency.Weekly, album.LastModifiedOnUtc);
        //    }
        //}

        //private void WriteSingleTracks() {
        //    var singleTracks = _trackService.GetAllSingleTracks();

        //    foreach (var singleTrack in singleTracks) {
        //        var trackUrl = _urlHelper.DetailsUrl(singleTrack);

        //        WriteUrlLocation(trackUrl, UpdateFrequency.Weekly, singleTrack.LastModifiedOnUtc);
        //    }
        //}

        //private void WritePolls() {
        //    var polls = _pollService.GetAllPolls(false);

        //    foreach (var poll in polls) {
        //        var pollUrl = _urlHelper.DetailsUrl(poll);

        //        WriteUrlLocation(pollUrl, UpdateFrequency.Weekly, poll.LastModifiedOnUtc);
        //    }
        //}
    }
}