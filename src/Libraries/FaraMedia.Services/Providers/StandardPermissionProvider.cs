namespace FaraMedia.Services.Extensions.Security {
    using System.Collections.Generic;

    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Knowns.Security;

    public sealed class StandardPermissionProvider : IPermissionProvider {
        public static readonly PermissionRecord AccessAdminArea = new PermissionRecord {
            DisplayName = "دسترسی به بخش مدیریت",
            SystemName = "AccessAdminArea",
            Category = "AdminArea"
        };

        public static readonly PermissionRecord Maintenance = new PermissionRecord {
            DisplayName = "دسترسی به بخش مدیریت",
            SystemName = "Maintenance",
            Category = "AdminArea"
        };

        public static readonly PermissionRecord AlbumsSection = new PermissionRecord {
            DisplayName = "مدیریت بخش آلبوم ها",
            SystemName = "AlbumsSection",
            Category = "Albums"
        };

        public static readonly PermissionRecord ManageAlbums = new PermissionRecord {
            DisplayName = "مدیریت آلبوم ها",
            SystemName = "ManageAlbums",
            Category = "Albums"
        };

        public static readonly PermissionRecord ManageAlbumComments = new PermissionRecord {
            DisplayName = "مدیریت نظرات آلبوم ها",
            SystemName = "ManageAlbumComments",
            Category = "Albums"
        };

        public static readonly PermissionRecord ManageAlbumCommentLikes = new PermissionRecord {
            DisplayName = "مدیریت لایک های نظرات آلبوم ها",
            SystemName = "ManageAlbumCommentLikes",
            Category = "Albums"
        };

        public static readonly PermissionRecord ManageAlbumLikes = new PermissionRecord {
            DisplayName = "مدیریت لایک های آلبوم ها",
            SystemName = "ManageAlbumLikes",
            Category = "Albums"
        };

        public static readonly PermissionRecord ManageAlbumShares = new PermissionRecord {
            DisplayName = "مدیریت اشتراک گذاری های آلبوم ها",
            SystemName = "ManageAlbumShares",
            Category = "Albums"
        };

        public static readonly PermissionRecord ArtistsSection = new PermissionRecord {
            DisplayName = "مدیریت بخش آلبوم ها",
            SystemName = "ArtistsSection",
            Category = "Artists"
        };

        public static readonly PermissionRecord ManageArtists = new PermissionRecord {
            DisplayName = "مدیریت هنرمندان",
            SystemName = "ManageArtists",
            Category = "Artists"
        };

        public static readonly PermissionRecord ManageArtistComments = new PermissionRecord {
            DisplayName = "مدیریت نظرات هنرمندان",
            SystemName = "ManageArtistComments",
            Category = "Artists"
        };

        public static readonly PermissionRecord ManageArtistCommentLikes = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManageArtistCommentLikes",
            Category = "Artists"
        };

        public static readonly PermissionRecord ManageArtistLikes = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManageArtistLikes",
            Category = "Artists"
        };

        public static readonly PermissionRecord ManageArtistShares = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManageArtistShares",
            Category = "Artists"
        };

        public static readonly PermissionRecord ManagePhotoAlbums = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManagePhotoAlbums",
            Category = "Artists"
        };

        public static readonly PermissionRecord ManagePhotoAlbumComments = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManagePhotoAlbumComments",
            Category = "PhotoAlbums"
        };

        public static readonly PermissionRecord ManagePhotoAlbumCommentLikes = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManagePhotoAlbumCommentLikes",
            Category = "PhotoAlbums"
        };

        public static readonly PermissionRecord ManagePhotoAlbumLikes = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManagePhotoAlbumLikes",
            Category = "PhotoAlbums"
        };

        public static readonly PermissionRecord ManagePhotoAlbumShares = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManagePhotoAlbumShares",
            Category = "PhotoAlbums"
        };

        public static readonly PermissionRecord ManagePhotos = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManagePhotos",
            Category = "Artists"
        };

        public static readonly PermissionRecord ManagePhotoComments = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManagePhotoComments",
            Category = "Photos"
        };

        public static readonly PermissionRecord ManagePhotoCommentLikes = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManagePhotoCommentLikes",
            Category = "Photos"
        };

        public static readonly PermissionRecord ManagePhotoLikes = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManagePhotoLikes",
            Category = "Photos"
        };

        public static readonly PermissionRecord ManagePhotoShares = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManagePhotoShares",
            Category = "Photos"
        };

        public static readonly PermissionRecord BillingSection = new PermissionRecord {
            DisplayName = "مدیریت بخش آلبوم ها",
            SystemName = "BillingSection",
            Category = "Billing"
        };

        public static readonly PermissionRecord ManageTransactionDebugs = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManageTransactionDebugs",
            Category = "Billing"
        };

        public static readonly PermissionRecord BloggingSection = new PermissionRecord {
            DisplayName = "مدیریت بخش آلبوم ها",
            SystemName = "BloggingSection",
            Category = "Blogging"
        };

        public static readonly PermissionRecord ManageBlogs = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManageBlogs",
            Category = "Blogging"
        };

        public static readonly PermissionRecord ManageTags = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManageTags",
            Category = "Blogging"
        };

        public static readonly PermissionRecord ManagePosts = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManagePosts",
            Category = "Blogging"
        };

        public static readonly PermissionRecord ManagePostComments = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManagePostComments",
            Category = "Blogging"
        };

        public static readonly PermissionRecord ManagePostCommentLikes = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManagePostCommentLikes",
            Category = "Blogging"
        };

        public static readonly PermissionRecord ManagePostLikes = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManagePostLikes",
            Category = "Blogging"
        };

        public static readonly PermissionRecord ManagePostShares = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManagePostShares",
            Category = "Blogging"
        };

        public static readonly PermissionRecord ConfigurationSection = new PermissionRecord {
            DisplayName = "مدیریت بخش آلبوم ها",
            SystemName = "ConfigurationSection",
            Category = "Configuration"
        };

        public static readonly PermissionRecord ManageSettings = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManageSettings",
            Category = "Configuration"
        };

        public static readonly PermissionRecord GenresSection = new PermissionRecord {
            DisplayName = "مدیریت بخش آلبوم ها",
            SystemName = "GenresSection",
            Category = "Genres"
        };

        public static readonly PermissionRecord ManageGenres = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManageGenres",
            Category = "Genres"
        };

        public static readonly PermissionRecord ManageGenreComments = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManageGenreComments",
            Category = "Genres"
        };

        public static readonly PermissionRecord ManageGenreCommentLikes = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManageGenreCommentLikes",
            Category = "Genres"
        };

        public static readonly PermissionRecord ManageGenreLikes = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManageGenreLikes",
            Category = "Genres"
        };

        public static readonly PermissionRecord ManageGenreShares = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManageGenreShares",
            Category = "Genres"
        };

        public static readonly PermissionRecord LocalizationSection = new PermissionRecord {
            DisplayName = "مدیریت بخش آلبوم ها",
            SystemName = "LocalizationSection",
            Category = "Localization"
        };

        public static readonly PermissionRecord ManageLanguages = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManageLanguages",
            Category = "Localization"
        };

        public static readonly PermissionRecord ManageStringResources = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManageStringResources",
            Category = "Localization"
        };

        public static readonly PermissionRecord LoggingSection = new PermissionRecord {
            DisplayName = "مدیریت بخش آلبوم ها",
            SystemName = "LoggingSection",
            Category = "Logging"
        };

        public static readonly PermissionRecord ManageActivityTypes = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManageActivityTypes",
            Category = "Logging"
        };

        public static readonly PermissionRecord ManageActivities = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManageActivities",
            Category = "Logging"
        };

        public static readonly PermissionRecord ManageLogs = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManageLogs",
            Category = "Logging"
        };

        public static readonly PermissionRecord MediaSection = new PermissionRecord {
            DisplayName = "مدیریت بخش آلبوم ها",
            SystemName = "MediaSection",
            Category = "Media"
        };

        public static readonly PermissionRecord ManageDownloads = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManageDownloads",
            Category = "Media"
        };

        public static readonly PermissionRecord ManageDownloadAttributes = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManageDownloadAttributes",
            Category = "Media"
        };

        public static readonly PermissionRecord ManagePictures = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManagePictures",
            Category = "Media"
        };

        public static readonly PermissionRecord ManagePictureAttributes = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManagePictureAttributes",
            Category = "Media"
        };

        public static readonly PermissionRecord MembershipSection = new PermissionRecord {
            DisplayName = "مدیریت بخش آلبوم ها",
            SystemName = "MembershipSection",
            Category = "Membership"
        };

        public static readonly PermissionRecord ManageRoles = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManageRoles",
            Category = "Membership"
        };

        public static readonly PermissionRecord ManageUsers = new PermissionRecord {
            DisplayName = "مدیریت کاربران",
            SystemName = "ManageUsers",
            Category = "Membership"
        };

        public static readonly PermissionRecord ManageUserAttributes = new PermissionRecord {
            DisplayName = "مدیریت کاربران",
            SystemName = "ManageUserAttributes",
            Category = "Membership"
        };

        public static readonly PermissionRecord ManageFriendRequests = new PermissionRecord {
            DisplayName = "مدیریت کاربران",
            SystemName = "ManageFriendRequests",
            Category = "Membership"
        };

        public static readonly PermissionRecord MessagesSection = new PermissionRecord {
            DisplayName = "مدیریت بخش آلبوم ها",
            SystemName = "MessagesSection",
            Category = "Messages"
        };

        public static readonly PermissionRecord ManageEmailAccounts = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManageEmailAccounts",
            Category = "Messages"
        };

        public static readonly PermissionRecord ManageMessageTemplates = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManageMessageTemplates",
            Category = "Messages"
        };

        public static readonly PermissionRecord ManageNewsletterSubscriptions = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManageNewsletterSubscriptions",
            Category = "Messages"
        };

        public static readonly PermissionRecord ManageQueuedEmails = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManageQueuedEmails",
            Category = "Messages"
        };

        public static readonly PermissionRecord NewsSection = new PermissionRecord {
            DisplayName = "مدیریت بخش آلبوم ها",
            SystemName = "NewsSection",
            Category = "News"
        };

        public static readonly PermissionRecord ManageCategories = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManageCategories",
            Category = "News"
        };

        public static readonly PermissionRecord ManageNews = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManageNews",
            Category = "News"
        };

        public static readonly PermissionRecord ManageNewsComments = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManageNewsComments",
            Category = "News"
        };

        public static readonly PermissionRecord ManageNewsCommentLikes = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManageNewsCommentLikes",
            Category = "News"
        };

        public static readonly PermissionRecord ManageNewsLikes = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManageNewsLikes",
            Category = "News"
        };

        public static readonly PermissionRecord ManageNewsShares = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManageNewsShares",
            Category = "News"
        };

        public static readonly PermissionRecord OrdersSection = new PermissionRecord {
            DisplayName = "مدیریت بخش آلبوم ها",
            SystemName = "OrdersSection",
            Category = "Orders"
        };

        public static readonly PermissionRecord ManageOrders = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManageOrders",
            Category = "Orders"
        };

        public static readonly PermissionRecord ManageOrderNotes = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManageOrderNotes",
            Category = "Orders"
        };

        public static readonly PermissionRecord ManageOrderLines = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManageOrderLines",
            Category = "Orders"
        };

        public static readonly PermissionRecord ManageOrderLineDownloads = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManageOrderLineDownloads",
            Category = "Orders"
        };

        public static readonly PermissionRecord PagesSection = new PermissionRecord {
            DisplayName = "مدیریت بخش آلبوم ها",
            SystemName = "PagesSection",
            Category = "Pages"
        };

        public static readonly PermissionRecord ManageGroups = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManageGroups",
            Category = "Pages"
        };

        public static readonly PermissionRecord ManagePages = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManagePages",
            Category = "Pages"
        };

        public static readonly PermissionRecord PollingSection = new PermissionRecord {
            DisplayName = "مدیریت بخش آلبوم ها",
            SystemName = "PollingSection",
            Category = "Polling"
        };

        public static readonly PermissionRecord ManagePolls = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManagePolls",
            Category = "Polling"
        };

        public static readonly PermissionRecord ManagePollComments = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManagePollComments",
            Category = "Polls"
        };

        public static readonly PermissionRecord ManagePollCommentLikes = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManagePollCommentLikes",
            Category = "Polls"
        };

        public static readonly PermissionRecord ManagePollLikes = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManagePollLikes",
            Category = "Polls"
        };

        public static readonly PermissionRecord ManagePollShares = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManagePollShares",
            Category = "Polls"
        };

        public static readonly PermissionRecord ManagePollAnswers = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManagePollAnswers",
            Category = "Polling"
        };

        public static readonly PermissionRecord ManagePollVotingRecords = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManagePollVotingRecords",
            Category = "Polling"
        };

        public static readonly PermissionRecord PublishersSection = new PermissionRecord {
            DisplayName = "مدیریت بخش آلبوم ها",
            SystemName = "PublishersSection",
            Category = "Publishers"
        };

        public static readonly PermissionRecord ManagePublishers = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManagePublishers",
            Category = "Publishers"
        };

        public static readonly PermissionRecord ManagePublisherComments = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManagePublisherComments",
            Category = "Publishers"
        };

        public static readonly PermissionRecord ManagePublisherCommentLikes = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManagePublisherCommentLikes",
            Category = "Publishers"
        };

        public static readonly PermissionRecord ManagePublisherLikes = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManagePublisherLikes",
            Category = "Publishers"
        };

        public static readonly PermissionRecord ManagePublisherShares = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManagePublisherShares",
            Category = "Publishers"
        };

        public static readonly PermissionRecord SettingsSection = new PermissionRecord {
            DisplayName = "مدیریت بخش آلبوم ها",
            SystemName = "SettingsSection",
            Category = "Settings"
        };

        public static readonly PermissionRecord ManageAdminAreaSettings = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManageAdminAreaSettings",
            Category = "Settings"
        };

        public static readonly PermissionRecord ManageApplicationSettings = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManageApplicationSettings",
            Category = "Settings"
        };

        public static readonly PermissionRecord ManageBillingSettings = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManageBillingSettings",
            Category = "Settings"
        };

        public static readonly PermissionRecord ManageContentSettings = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManageContentSettings",
            Category = "Settings"
        };

        public static readonly PermissionRecord ManageCdnSettings = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManageCdnSettings",
            Category = "Settings"
        };

        public static readonly PermissionRecord ManageCommonSettings = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManageCommonSettings",
            Category = "Settings"
        };

        public static readonly PermissionRecord ManageDateTimeSettings = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManageDateTimeSettings",
            Category = "Settings"
        };

        public static readonly PermissionRecord ManageEmailAccountSettings = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManageEmailAccountSettings",
            Category = "Settings"
        };

        public static readonly PermissionRecord ManageLocalizationSettings = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManageLocalizationSettings",
            Category = "Settings"
        };

        public static readonly PermissionRecord ManageFileManagementSettings = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManageFileManagementSettings",
            Category = "Settings"
        };

        public static readonly PermissionRecord ManageMembershipSettings = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManageMembershipSettings",
            Category = "Settings"
        };

        public static readonly PermissionRecord ManageMessageTemplateSettings = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManageMessageTemplateSettings",
            Category = "Settings"
        };

        public static readonly PermissionRecord ManageNewsSettings = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManageNewsSettings",
            Category = "Settings"
        };

        public static readonly PermissionRecord ManageSecuritySettings = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManageSecuritySettings",
            Category = "Settings"
        };

        public static readonly PermissionRecord ManageSeoSettings = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManageSeoSettings",
            Category = "Settings"
        };

        public static readonly PermissionRecord ManageSitemapSettings = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManageSitemapSettings",
            Category = "Settings"
        };

        public static readonly PermissionRecord ManageMiscellaneousSettings = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManageMiscellaneousSettings",
            Category = "Settings"
        };

        public static readonly PermissionRecord SecuritySection = new PermissionRecord {
            DisplayName = "مدیریت بخش آلبوم ها",
            SystemName = "SecuritySection",
            Category = "Security"
        };

        public static readonly PermissionRecord ManageBannedIps = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManageBannedIps",
            Category = "Security"
        };

        public static readonly PermissionRecord ManagePermissionRecords = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManagePermissionRecords",
            Category = "Security"
        };

        public static readonly PermissionRecord StatisticsSection = new PermissionRecord {
            DisplayName = "مدیریت بخش آلبوم ها",
            SystemName = "StatisticsSection",
            Category = "Statistics"
        };

        public static readonly PermissionRecord ManageRedirectors = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManageRedirectors",
            Category = "Statistics"
        };

        public static readonly PermissionRecord TasksSection = new PermissionRecord {
            DisplayName = "مدیریت بخش آلبوم ها",
            SystemName = "TasksSection",
            Category = "Tasks"
        };

        public static readonly PermissionRecord ManageScheduleTasks = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManageScheduleTasks",
            Category = "Tasks"
        };

        public static readonly PermissionRecord TicketingSection = new PermissionRecord {
            DisplayName = "مدیریت بخش آلبوم ها",
            SystemName = "TicketingSection",
            Category = "Ticketing"
        };

        public static readonly PermissionRecord ManageTickets = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManageTickets",
            Category = "Ticketing"
        };

        public static readonly PermissionRecord ManageTicketResponses = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManageTicketResponses",
            Category = "Ticketing"
        };

        public static readonly PermissionRecord TracksSection = new PermissionRecord {
            DisplayName = "مدیریت بخش آلبوم ها",
            SystemName = "TracksSection",
            Category = "Tracks"
        };

        public static readonly PermissionRecord ManageTracks = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManageTracks",
            Category = "Tracks"
        };

        public static readonly PermissionRecord ManageTrackComments = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManageTrackComments",
            Category = "Tracks"
        };

        public static readonly PermissionRecord ManageTrackCommentLikes = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManageTrackCommentLikes",
            Category = "Tracks"
        };

        public static readonly PermissionRecord ManageTrackLikes = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManageTrackLikes",
            Category = "Tracks"
        };

        public static readonly PermissionRecord ManageTrackShares = new PermissionRecord {
            DisplayName = "مدیریت نقش ها",
            SystemName = "ManageTrackShares",
            Category = "Tracks"
        };

        public static readonly PermissionRecord UtilitiesSection = new PermissionRecord {
            DisplayName = "مدیریت بخش آلبوم ها",
            SystemName = "UtilitiesSection",
            Category = "Utilities"
        };

        public static readonly PermissionRecord ManageToDos = new PermissionRecord {
            DisplayName = "Admin area. Manage Albums",
            SystemName = "ManageToDos",
            Category = "Utilities"
        };

        public IEnumerable<PermissionRecord> GetPermissionRecords() {
            return new[] {AccessAdminArea, Maintenance, AlbumsSection, ManageAlbums, ManageAlbumComments, ManageAlbumCommentLikes, ManageAlbumLikes, ManageAlbumShares, ArtistsSection, ManageArtists, ManageArtistComments, ManageArtistCommentLikes, ManageArtistLikes, ManageArtistShares, ManagePhotoAlbums, ManagePhotoAlbumComments, ManagePhotoAlbumCommentLikes, ManagePhotoAlbumLikes, ManagePhotoAlbumShares, ManagePhotos, ManagePhotoComments, ManagePhotoCommentLikes, ManagePhotoLikes, ManagePhotoShares, BillingSection, ManageTransactionDebugs, BloggingSection, ManageBlogs, ManageTags, ManagePosts, ManagePostComments, ManagePostCommentLikes, ManagePostLikes, ManagePostShares, ConfigurationSection, ManageSettings, GenresSection, ManageGenres, ManageGenreComments, ManageGenreCommentLikes, ManageGenreLikes, ManageGenreShares, LocalizationSection, ManageLanguages, ManageStringResources, LoggingSection, ManageActivityTypes, ManageActivities, ManageLogs, MediaSection, ManageDownloads, ManageDownloadAttributes, ManagePictures, ManagePictureAttributes, MembershipSection, ManageRoles, ManageUsers, ManageUserAttributes, ManageFriendRequests, MessagesSection, ManageEmailAccounts, ManageMessageTemplates, ManageNewsletterSubscriptions, ManageQueuedEmails, NewsSection, ManageCategories, ManageNews, ManageNewsComments, ManageNewsCommentLikes, ManageNewsLikes, ManageNewsShares, OrdersSection, ManageOrders, ManageOrderNotes, ManageOrderLines, ManageOrderLineDownloads, PagesSection, ManageGroups, ManagePages, PollingSection, ManagePolls, ManagePollComments, ManagePollCommentLikes, ManagePollLikes, ManagePollShares, ManagePollAnswers, ManagePollVotingRecords, PublishersSection, ManagePublishers, ManagePublisherComments, ManagePublisherCommentLikes, ManagePublisherLikes, ManagePublisherShares, SettingsSection, ManageAdminAreaSettings, ManageApplicationSettings, ManageBillingSettings, ManageContentSettings, ManageCdnSettings, ManageCommonSettings, ManageDateTimeSettings, ManageEmailAccountSettings, ManageLocalizationSettings, ManageFileManagementSettings, ManageMembershipSettings, ManageMessageTemplateSettings, ManageNewsSettings, ManageSecuritySettings, ManageSeoSettings, ManageSitemapSettings, ManageMiscellaneousSettings, SecuritySection, ManageBannedIps, ManagePermissionRecords, StatisticsSection, ManageRedirectors, TasksSection, ManageScheduleTasks, TicketingSection, ManageTickets, ManageTicketResponses, TracksSection, ManageTracks, ManageTrackComments, ManageTrackCommentLikes, ManageTrackLikes, ManageTrackShares, UtilitiesSection, ManageToDos};
        }

        public IEnumerable<DefaultPermissionRecord> GetDefaultPermissionRecords() {
            return new[] {
                new DefaultPermissionRecord {
                    RoleSystemName = RoleNames.Administrators,
                    Records = new[] {AccessAdminArea, Maintenance, AlbumsSection, ManageAlbums, ManageAlbumComments, ManageAlbumCommentLikes, ManageAlbumLikes, ManageAlbumShares, ArtistsSection, ManageArtists, ManageArtistComments, ManageArtistCommentLikes, ManageArtistLikes, ManageArtistShares, ManagePhotoAlbums, ManagePhotoAlbumComments, ManagePhotoAlbumCommentLikes, ManagePhotoAlbumLikes, ManagePhotoAlbumShares, ManagePhotos, ManagePhotoComments, ManagePhotoCommentLikes, ManagePhotoLikes, ManagePhotoShares, BillingSection, ManageTransactionDebugs, BloggingSection, ManageBlogs, ManageTags, ManagePosts, ManagePostComments, ManagePostCommentLikes, ManagePostLikes, ManagePostShares, ConfigurationSection, ManageSettings, GenresSection, ManageGenres, ManageGenreComments, ManageGenreCommentLikes, ManageGenreLikes, ManageGenreShares, LocalizationSection, ManageLanguages, ManageStringResources, LoggingSection, ManageActivityTypes, ManageActivities, ManageLogs, MediaSection, ManageDownloads, ManageDownloadAttributes, ManagePictures, ManagePictureAttributes, MembershipSection, ManageRoles, ManageUsers, ManageUserAttributes, ManageFriendRequests, MessagesSection, ManageEmailAccounts, ManageMessageTemplates, ManageNewsletterSubscriptions, ManageQueuedEmails, NewsSection, ManageCategories, ManageNews, ManageNewsComments, ManageNewsCommentLikes, ManageNewsLikes, ManageNewsShares, OrdersSection, ManageOrders, ManageOrderNotes, ManageOrderLines, ManageOrderLineDownloads, PagesSection, ManageGroups, ManagePages, PollingSection, ManagePolls, ManagePollComments, ManagePollCommentLikes, ManagePollLikes, ManagePollShares, ManagePollAnswers, ManagePollVotingRecords, PublishersSection, ManagePublishers, ManagePublisherComments, ManagePublisherCommentLikes, ManagePublisherLikes, ManagePublisherShares, SettingsSection, ManageAdminAreaSettings, ManageApplicationSettings, ManageBillingSettings, ManageContentSettings, ManageCdnSettings, ManageCommonSettings, ManageDateTimeSettings, ManageEmailAccountSettings, ManageLocalizationSettings, ManageFileManagementSettings, ManageMembershipSettings, ManageMessageTemplateSettings, ManageNewsSettings, ManageSecuritySettings, ManageSeoSettings, ManageSitemapSettings, ManageMiscellaneousSettings, SecuritySection, ManageBannedIps, ManagePermissionRecords, StatisticsSection, ManageRedirectors, TasksSection, ManageScheduleTasks, TicketingSection, ManageTickets, ManageTicketResponses, TracksSection, ManageTracks, ManageTrackComments, ManageTrackCommentLikes, ManageTrackLikes, ManageTrackShares, UtilitiesSection, ManageToDos}
                }, new DefaultPermissionRecord {
                    RoleSystemName = RoleNames.Moderators,
                    Records = new[] {AccessAdminArea}
                }, new DefaultPermissionRecord {
                    RoleSystemName = RoleNames.ContentProviders,
                    Records = new[] {AccessAdminArea}
                }, new DefaultPermissionRecord {
                    RoleSystemName = RoleNames.Companies,
                    Records = new[] {AccessAdminArea}
                }, new DefaultPermissionRecord {
                    RoleSystemName = RoleNames.Registered,
                    Records = new List<PermissionRecord>()
                }, new DefaultPermissionRecord {
                    RoleSystemName = RoleNames.Guests,
                    Records = new List<PermissionRecord>()
                }
            };
        }
    }
}