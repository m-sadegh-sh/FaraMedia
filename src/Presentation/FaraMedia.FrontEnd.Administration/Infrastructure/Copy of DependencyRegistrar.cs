namespace FaraMedia.FrontEnd.Administration.Infrastructure {
    using System;
    using System.Linq;
    using System.Web;

    using Autofac;
    using Autofac.Integration.Mvc;

    using FaraMedia.Core;
    using FaraMedia.Core.Caching;
    using FaraMedia.Core.Configuration;
    using FaraMedia.Core.Data;
    using FaraMedia.Core.Domain.Albums;
    using FaraMedia.Core.Domain.Artists;
    using FaraMedia.Core.Domain.Billing;
    using FaraMedia.Core.Domain.Blogging;
    using FaraMedia.Core.Domain.Components;
    using FaraMedia.Core.Domain.Configuration;
    using FaraMedia.Core.Domain.Genres;
    using FaraMedia.Core.Domain.Localization;
    using FaraMedia.Core.Domain.Logging;
    using FaraMedia.Core.Domain.Media;
    using FaraMedia.Core.Domain.Membership;
    using FaraMedia.Core.Domain.Messages;
    using FaraMedia.Core.Domain.News;
    using FaraMedia.Core.Domain.Orders;
    using FaraMedia.Core.Domain.Pages;
    using FaraMedia.Core.Domain.Polling;
    using FaraMedia.Core.Domain.Publishers;
    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Core.Domain.Settings;
    using FaraMedia.Core.Domain.Statistics;
    using FaraMedia.Core.Domain.Tasks;
    using FaraMedia.Core.Domain.Ticketing;
    using FaraMedia.Core.Domain.Tracks;
    using FaraMedia.Core.Domain.Utilities;
    using FaraMedia.Core.Events;
    using FaraMedia.Core.Infrastructure.DependencyManagement;
    using FaraMedia.Core.Infrastructure.TypeFinders;
    using FaraMedia.Core.States;
    using FaraMedia.Core.Text.Pluralization;
    using FaraMedia.Data;
    using FaraMedia.Data.Core;
    using FaraMedia.Data.Mapping.Common;
    using FaraMedia.Data.Mapping.Extensions;
    using FaraMedia.FrontEnd.Administration.Integrations;
    using FaraMedia.Services.Albums;
    using FaraMedia.Services.Artists;
    using FaraMedia.Services.Authentication;
    using FaraMedia.Services.Billing;
    using FaraMedia.Services.Blogging;
    using FaraMedia.Services.Common;
    using FaraMedia.Services.Configuration;
    using FaraMedia.Services.Genres;
    using FaraMedia.Services.Helpers;
    using FaraMedia.Services.Infrastructure;
    using FaraMedia.Services.Installation;
    using FaraMedia.Services.Installation.Installers;
    using FaraMedia.Services.Integrations;
    using FaraMedia.Services.Localization;
    using FaraMedia.Services.Logging;
    using FaraMedia.Services.Media;
    using FaraMedia.Services.Membership;
    using FaraMedia.Services.Messages;
    using FaraMedia.Services.News;
    using FaraMedia.Services.Orders;
    using FaraMedia.Services.Pages;
    using FaraMedia.Services.Polling;
    using FaraMedia.Services.Publishers;
    using FaraMedia.Services.Security;
    using FaraMedia.Services.Settings;
    using FaraMedia.Services.Statistics;
    using FaraMedia.Services.Tasks;
    using FaraMedia.Services.Ticketing;
    using FaraMedia.Services.Tracks;
    using FaraMedia.Services.Utilities;
    using FaraMedia.Services.Validations.Albums;
    using FaraMedia.Services.Validations.Artists;
    using FaraMedia.Services.Validations.Billing;
    using FaraMedia.Services.Validations.Blogging;
    using FaraMedia.Services.Validations.Components;
    using FaraMedia.Services.Validations.Configuration;
    using FaraMedia.Services.Validations.Genres;
    using FaraMedia.Services.Validations.Localization;
    using FaraMedia.Services.Validations.Logging;
    using FaraMedia.Services.Validations.Media;
    using FaraMedia.Services.Validations.Membership;
    using FaraMedia.Services.Validations.Messages;
    using FaraMedia.Services.Validations.News;
    using FaraMedia.Services.Validations.Orders;
    using FaraMedia.Services.Validations.Pages;
    using FaraMedia.Services.Validations.Polling;
    using FaraMedia.Services.Validations.Publishers;
    using FaraMedia.Services.Validations.Security;
    using FaraMedia.Services.Validations.Settings;
    using FaraMedia.Services.Validations.Statistics;
    using FaraMedia.Services.Validations.Tasks;
    using FaraMedia.Services.Validations.Ticketing;
    using FaraMedia.Services.Validations.Tracks;
    using FaraMedia.Services.Validations.Utilities;
    using FaraMedia.Web.Framework;
    using FaraMedia.Web.Framework.EmbeddedViews;
    using FaraMedia.Web.Framework.Routing;
    using FaraMedia.Web.Framework.Routing.Seo;
    using FaraMedia.Web.Framework.UI;

    using NHibernate;
    using NHibernate.Validator.Cfg.Loquacious;
    using NHibernate.Validator.Engine;

    public class DependencyRegistrar : IDependencyRegistrar {
        public int Order {
            get { return 0; }
        }

        public virtual void Register(ContainerBuilder containerBuilder, ITypeFinder typeFinder) {
            RegisterUtilityTypes(containerBuilder);
            RegisterConfigTypes(containerBuilder);
            RegisterStateTypes(containerBuilder);
            RegisterFrameworkLevelTypes(containerBuilder);
            RegisterCacheManagerTypes(containerBuilder);
            RegisterDataLayerTypes(containerBuilder);
            RegisterHelperTypes(containerBuilder);
            RegisterValidationTypes(containerBuilder);
            RegisterServiceTypes(containerBuilder);
            RegisterSettingsTypes(containerBuilder);
            RegisterInstallers(containerBuilder, typeFinder);
            RegisterCunsomerTypes(containerBuilder, typeFinder);
            RegisterPresentationTypes(containerBuilder, typeFinder);
            RegisterRoutingRelatedTypes(containerBuilder, typeFinder);
        }

        private static void RegisterUtilityTypes(ContainerBuilder containerBuilder) {
            containerBuilder.RegisterType<PluralizeServiceWrapper>().As<IPluralizeService>().SingleInstance();
        }

        private static void RegisterConfigTypes(ContainerBuilder containerBuilder) {
            //FaraConfig is already registered (EngineContext)
            //containerBuilder.RegisterInstance(FaraConfig.Load()).As<FaraConfig>().SingleInstance();
            containerBuilder.Register(cc => BootstrapConfig.Load()).AsSelf().SingleInstance();
        }

        private static void RegisterStateTypes(ContainerBuilder containerBuilder) {
            containerBuilder.RegisterType<DbConfigurationState>().AsSelf().SingleInstance();
        }

        private static void RegisterFrameworkLevelTypes(ContainerBuilder containerBuilder) {
            containerBuilder.Register(cc => (new HttpContextWrapper(HttpContext.Current) as HttpContextBase)).As<HttpContextBase>().InstancePerHttpRequest();
            containerBuilder.Register(cc => cc.Resolve<HttpContextBase>().Request).As<HttpRequestBase>().InstancePerHttpRequest();
            containerBuilder.Register(cc => cc.Resolve<HttpContextBase>().Response).As<HttpResponseBase>().InstancePerHttpRequest();
            containerBuilder.Register(cc => cc.Resolve<HttpContextBase>().Server).As<HttpServerUtilityBase>().InstancePerHttpRequest();
            containerBuilder.Register(cc => cc.Resolve<HttpContextBase>().Session).As<HttpSessionStateBase>().InstancePerHttpRequest();
        }

        private static void RegisterCacheManagerTypes(ContainerBuilder containerBuilder) {
            containerBuilder.RegisterType<MemoryCacheManager>().As<ICacheManager>().Named<ICacheManager>(MemoryCacheManager.Key).SingleInstance();
        }

        private static void RegisterDataLayerTypes(ContainerBuilder containerBuilder) {
            containerBuilder.Register(cc => new NHibernateConfigurer {
                ConnectionString = cc.Resolve<FaraConfig>().ConnectionStringName,
                DropTablesCreateDbSchema = true,
                MappingAssembly = typeof (EntityMapBase<>).Assembly,
                MappingTypeFinder = t => t.IsMappingType()
            }).AsSelf().SingleInstance();

            containerBuilder.Register(cc => cc.Resolve<NHibernateConfigurer>().ValidatorEngine).As<ValidatorEngine>().InstancePerHttpRequest();

            containerBuilder.RegisterType<SessionProvider>().As<ISessionProvider>().SingleInstance();
            containerBuilder.Register(cc => cc.Resolve<ISessionProvider>().Open()).As<ISession>().InstancePerHttpRequest();
            containerBuilder.RegisterGeneric(typeof (Repository<>)).As(typeof (IRepository<>)).InstancePerHttpRequest();

            containerBuilder.RegisterType<DevelopmentDatabaseSyncer>().As<IDatabaseSyncer>().InstancePerHttpRequest();

            containerBuilder.RegisterType<ServiceOperationResult>().AsSelf().InstancePerDependency();
            containerBuilder.RegisterGeneric(typeof (ServiceOperationResultWithValue<>)).AsSelf().InstancePerDependency();
        }

        private static void RegisterHelperTypes(ContainerBuilder containerBuilder) {
            containerBuilder.RegisterType<WebHelper>().As<IWebHelper>().InstancePerHttpRequest();
            containerBuilder.RegisterType<WebWorkContext>().As<IWorkContext>().InstancePerHttpRequest();
            containerBuilder.RegisterType<DateTimeHelper>().As<IDateTimeHelper>().InstancePerHttpRequest();
            containerBuilder.RegisterType<MobileDeviceHelper>().As<IMobileDeviceHelper>().InstancePerHttpRequest();
        }

        private static void RegisterValidationTypes(ContainerBuilder containerBuilder) {
            containerBuilder.RegisterType<AlbumValidation>().As<IValidationDefinition<Album>>().InstancePerDependency();
            containerBuilder.RegisterType<AlbumCommentValidation>().As<IValidationDefinition<AlbumComment>>().InstancePerDependency();
            containerBuilder.RegisterType<AlbumCommentLikeValidation>().As<IValidationDefinition<AlbumCommentLike>>().InstancePerDependency();
            containerBuilder.RegisterType<AlbumLikeValidation>().As<IValidationDefinition<AlbumLike>>().InstancePerDependency();
            containerBuilder.RegisterType<AlbumShareValidation>().As<IValidationDefinition<AlbumShare>>().InstancePerDependency();

            containerBuilder.RegisterType<ArtistValidation>().As<IValidationDefinition<Artist>>().InstancePerDependency();
            containerBuilder.RegisterType<ArtistCommentValidation>().As<IValidationDefinition<ArtistComment>>().InstancePerDependency();
            containerBuilder.RegisterType<ArtistCommentLikeValidation>().As<IValidationDefinition<ArtistCommentLike>>().InstancePerDependency();
            containerBuilder.RegisterType<ArtistLikeValidation>().As<IValidationDefinition<ArtistLike>>().InstancePerDependency();
            containerBuilder.RegisterType<ArtistShareValidation>().As<IValidationDefinition<ArtistShare>>().InstancePerDependency();
            containerBuilder.RegisterType<PhotoAlbumValidation>().As<IValidationDefinition<PhotoAlbum>>().InstancePerDependency();
            containerBuilder.RegisterType<PhotoAlbumCommentValidation>().As<IValidationDefinition<PhotoAlbumComment>>().InstancePerDependency();
            containerBuilder.RegisterType<PhotoAlbumCommentLikeValidation>().As<IValidationDefinition<PhotoAlbumCommentLike>>().InstancePerDependency();
            containerBuilder.RegisterType<PhotoAlbumLikeValidation>().As<IValidationDefinition<PhotoAlbumLike>>().InstancePerDependency();
            containerBuilder.RegisterType<PhotoAlbumShareValidation>().As<IValidationDefinition<PhotoAlbumShare>>().InstancePerDependency();
            containerBuilder.RegisterType<PhotoValidation>().As<IValidationDefinition<Photo>>().InstancePerDependency();
            containerBuilder.RegisterType<PhotoCommentValidation>().As<IValidationDefinition<PhotoComment>>().InstancePerDependency();
            containerBuilder.RegisterType<PhotoCommentLikeValidation>().As<IValidationDefinition<PhotoCommentLike>>().InstancePerDependency();
            containerBuilder.RegisterType<PhotoLikeValidation>().As<IValidationDefinition<PhotoLike>>().InstancePerDependency();
            containerBuilder.RegisterType<PhotoShareValidation>().As<IValidationDefinition<PhotoShare>>().InstancePerDependency();

            containerBuilder.RegisterType<TransactionDebugValidation>().As<IValidationDefinition<TransactionDebug>>().InstancePerDependency();

            containerBuilder.RegisterType<BlogValidation>().As<IValidationDefinition<Blog>>().InstancePerDependency();
            containerBuilder.RegisterType<TagValidation>().As<IValidationDefinition<Tag>>().InstancePerDependency();
            containerBuilder.RegisterType<PostValidation>().As<IValidationDefinition<Post>>().InstancePerDependency();
            containerBuilder.RegisterType<PostCommentValidation>().As<IValidationDefinition<PostComment>>().InstancePerDependency();
            containerBuilder.RegisterType<PostCommentLikeValidation>().As<IValidationDefinition<PostCommentLike>>().InstancePerDependency();
            containerBuilder.RegisterType<PostLikeValidation>().As<IValidationDefinition<PostLike>>().InstancePerDependency();
            containerBuilder.RegisterType<PostShareValidation>().As<IValidationDefinition<PostShare>>().InstancePerDependency();

            containerBuilder.RegisterType<MetadataComponentValidation>().As<IValidationDefinition<MetadataComponent>>().InstancePerDependency();

            containerBuilder.RegisterType<SettingValidation>().As<IValidationDefinition<Setting>>().InstancePerDependency();

            containerBuilder.RegisterType<GenreValidation>().As<IValidationDefinition<Genre>>().InstancePerDependency();
            containerBuilder.RegisterType<GenreCommentValidation>().As<IValidationDefinition<GenreComment>>().InstancePerDependency();
            containerBuilder.RegisterType<GenreCommentLikeValidation>().As<IValidationDefinition<GenreCommentLike>>().InstancePerDependency();
            containerBuilder.RegisterType<GenreLikeValidation>().As<IValidationDefinition<GenreLike>>().InstancePerDependency();
            containerBuilder.RegisterType<GenreShareValidation>().As<IValidationDefinition<GenreShare>>().InstancePerDependency();

            containerBuilder.RegisterType<LanguageValidation>().As<IValidationDefinition<Language>>().InstancePerDependency();
            containerBuilder.RegisterType<LocaleStringResourceValidation>().As<IValidationDefinition<LocaleStringResource>>().InstancePerDependency();

            containerBuilder.RegisterType<ActivityLogTypeValidation>().As<IValidationDefinition<ActivityLogType>>().InstancePerDependency();
            containerBuilder.RegisterType<ActivityLogValidation>().As<IValidationDefinition<ActivityLog>>().InstancePerDependency();
            containerBuilder.RegisterType<LogValidation>().As<IValidationDefinition<Log>>().InstancePerDependency();

            containerBuilder.RegisterType<DownloadValidation>().As<IValidationDefinition<Download>>().InstancePerDependency();
            containerBuilder.RegisterType<DownloadAttributeValidation>().As<IValidationDefinition<DownloadAttribute>>().InstancePerDependency();
            containerBuilder.RegisterType<PictureValidation>().As<IValidationDefinition<Picture>>().InstancePerDependency();
            containerBuilder.RegisterType<PictureAttributeValidation>().As<IValidationDefinition<PictureAttribute>>().InstancePerDependency();

            containerBuilder.RegisterType<RoleValidation>().As<IValidationDefinition<Role>>().InstancePerDependency();
            containerBuilder.RegisterType<UserValidation>().As<IValidationDefinition<User>>().InstancePerDependency();
            containerBuilder.RegisterType<UserAttributeValidation>().As<IValidationDefinition<UserAttribute>>().InstancePerDependency();
            containerBuilder.RegisterType<FriendRelationValidation>().As<IValidationDefinition<FriendRelation>>().InstancePerDependency();

            containerBuilder.RegisterType<EmailAccountValidation>().As<IValidationDefinition<EmailAccount>>().InstancePerDependency();
            containerBuilder.RegisterType<MessageTemplateValidation>().As<IValidationDefinition<MessageTemplate>>().InstancePerDependency();
            containerBuilder.RegisterType<NewsletterSubscriptionValidation>().As<IValidationDefinition<NewsletterSubscription>>().InstancePerDependency();
            containerBuilder.RegisterType<QueuedEmailValidation>().As<IValidationDefinition<QueuedEmail>>().InstancePerDependency();

            containerBuilder.RegisterType<CategoryValidation>().As<IValidationDefinition<Category>>().InstancePerDependency();
            containerBuilder.RegisterType<NewsValidation>().As<IValidationDefinition<News>>().InstancePerDependency();
            containerBuilder.RegisterType<NewsCommentValidation>().As<IValidationDefinition<NewsComment>>().InstancePerDependency();
            containerBuilder.RegisterType<NewsCommentLikeValidation>().As<IValidationDefinition<NewsCommentLike>>().InstancePerDependency();
            containerBuilder.RegisterType<NewsLikeValidation>().As<IValidationDefinition<NewsLike>>().InstancePerDependency();
            containerBuilder.RegisterType<NewsShareValidation>().As<IValidationDefinition<NewsShare>>().InstancePerDependency();

            containerBuilder.RegisterType<OrderValidation>().As<IValidationDefinition<Order>>().InstancePerDependency();
            containerBuilder.RegisterType<OrderNoteValidation>().As<IValidationDefinition<OrderNote>>().InstancePerDependency();
            containerBuilder.RegisterType<OrderLineValidation>().As<IValidationDefinition<OrderLine>>().InstancePerDependency();
            containerBuilder.RegisterType<OrderLineDownloadValidation>().As<IValidationDefinition<OrderLineDownload>>().InstancePerDependency();

            containerBuilder.RegisterType<GroupValidation>().As<IValidationDefinition<Group>>().InstancePerDependency();
            containerBuilder.RegisterType<PageValidation>().As<IValidationDefinition<Page>>().InstancePerDependency();

            containerBuilder.RegisterType<PollValidation>().As<IValidationDefinition<Poll>>().InstancePerDependency();
            containerBuilder.RegisterType<PollCommentValidation>().As<IValidationDefinition<PollComment>>().InstancePerDependency();
            containerBuilder.RegisterType<PollCommentLikeValidation>().As<IValidationDefinition<PollCommentLike>>().InstancePerDependency();
            containerBuilder.RegisterType<PollLikeValidation>().As<IValidationDefinition<PollLike>>().InstancePerDependency();
            containerBuilder.RegisterType<PollShareValidation>().As<IValidationDefinition<PollShare>>().InstancePerDependency();
            containerBuilder.RegisterType<PollAnswerValidation>().As<IValidationDefinition<PollAnswer>>().InstancePerDependency();
            containerBuilder.RegisterType<PollVotingRecordValidation>().As<IValidationDefinition<PollVotingRecord>>().InstancePerDependency();

            containerBuilder.RegisterType<PublisherValidation>().As<IValidationDefinition<Publisher>>().InstancePerDependency();
            containerBuilder.RegisterType<PublisherCommentValidation>().As<IValidationDefinition<PublisherComment>>().InstancePerDependency();
            containerBuilder.RegisterType<PublisherCommentLikeValidation>().As<IValidationDefinition<PublisherCommentLike>>().InstancePerDependency();
            containerBuilder.RegisterType<PublisherLikeValidation>().As<IValidationDefinition<PublisherLike>>().InstancePerDependency();
            containerBuilder.RegisterType<PublisherShareValidation>().As<IValidationDefinition<PublisherShare>>().InstancePerDependency();

            containerBuilder.RegisterType<BannedIpValidation>().As<IValidationDefinition<BannedIp>>().InstancePerDependency();
            containerBuilder.RegisterType<PermissionRecordValidation>().As<IValidationDefinition<PermissionRecord>>().InstancePerDependency();

            containerBuilder.RegisterType<AdminAreaSettingsValidation>().AsSelf().InstancePerDependency();
            containerBuilder.RegisterType<ApplicationSettingsValidation>().AsSelf().InstancePerDependency();
            containerBuilder.RegisterType<BillingSettingsValidation>().AsSelf().InstancePerDependency();
            containerBuilder.RegisterType<BloggingSettingsValidation>().AsSelf().InstancePerDependency();
            containerBuilder.RegisterType<CdnSettingsValidation>().AsSelf().InstancePerDependency();
            containerBuilder.RegisterType<CommonSettingsValidation>().AsSelf().InstancePerDependency();
            containerBuilder.RegisterType<DateTimeSettingsValidation>().AsSelf().InstancePerDependency();
            containerBuilder.RegisterType<EmailAccountSettingsValidation>().AsSelf().InstancePerDependency();
            containerBuilder.RegisterType<LocalizationSettingsValidation>().AsSelf().InstancePerDependency();
            containerBuilder.RegisterType<MediaSettingsValidation>().AsSelf().InstancePerDependency();
            containerBuilder.RegisterType<MembershipSettingsValidation>().AsSelf().InstancePerDependency();
            containerBuilder.RegisterType<MessageTemplateSettingsValidation>().AsSelf().InstancePerDependency();
            containerBuilder.RegisterType<NewsSettingsValidation>().AsSelf().InstancePerDependency();
            containerBuilder.RegisterType<SecuritySettingsValidation>().AsSelf().InstancePerDependency();
            containerBuilder.RegisterType<SeoSettingsValidation>().AsSelf().InstancePerDependency();
            containerBuilder.RegisterType<SitemapSettingsValidation>().AsSelf().InstancePerDependency();
            containerBuilder.RegisterType<StatisticsSettingsValidation>().AsSelf().InstancePerDependency();

            containerBuilder.RegisterType<RedirectorValidation>().As<IValidationDefinition<Redirector>>().InstancePerDependency();

            containerBuilder.RegisterType<ScheduleTaskValidation>().As<IValidationDefinition<ScheduleTask>>().InstancePerDependency();

            containerBuilder.RegisterType<TicketValidation>().As<IValidationDefinition<Ticket>>().InstancePerDependency();
            containerBuilder.RegisterType<TicketResponseValidation>().As<IValidationDefinition<TicketResponse>>().InstancePerDependency();

            containerBuilder.RegisterType<TrackValidation>().As<IValidationDefinition<Track>>().InstancePerDependency();
            containerBuilder.RegisterType<TrackCommentValidation>().As<IValidationDefinition<TrackComment>>().InstancePerDependency();
            containerBuilder.RegisterType<TrackCommentLikeValidation>().As<IValidationDefinition<TrackCommentLike>>().InstancePerDependency();
            containerBuilder.RegisterType<TrackLikeValidation>().As<IValidationDefinition<TrackLike>>().InstancePerDependency();
            containerBuilder.RegisterType<TrackShareValidation>().As<IValidationDefinition<TrackShare>>().InstancePerDependency();

            containerBuilder.RegisterType<ToDoValidation>().As<IValidationDefinition<ToDo>>().InstancePerDependency();
        }

        private static void RegisterServiceTypes(ContainerBuilder containerBuilder) {
            containerBuilder.RegisterType<AlbumService>().As<IAlbumService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<AlbumCommentService>().As<IAlbumCommentService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<AlbumCommentLikeService>().As<IAlbumCommentLikeService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<AlbumLikeService>().As<IAlbumLikeService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<AlbumShareService>().As<IAlbumShareService>().InstancePerHttpRequest();

            containerBuilder.RegisterType<ArtistService>().As<IArtistService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<ArtistCommentService>().As<IArtistCommentService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<ArtistCommentLikeService>().As<IArtistCommentLikeService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<ArtistLikeService>().As<IArtistLikeService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<ArtistShareService>().As<IArtistShareService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<PhotoAlbumService>().As<IPhotoAlbumService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<PhotoAlbumCommentService>().As<IPhotoAlbumCommentService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<PhotoAlbumCommentLikeService>().As<IPhotoAlbumCommentLikeService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<PhotoAlbumLikeService>().As<IPhotoAlbumLikeService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<PhotoAlbumShareService>().As<IPhotoAlbumShareService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<PhotoService>().As<IPhotoService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<PhotoCommentService>().As<IPhotoCommentService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<PhotoCommentLikeService>().As<IPhotoCommentLikeService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<PhotoLikeService>().As<IPhotoLikeService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<PhotoShareService>().As<IPhotoShareService>().InstancePerHttpRequest();

            containerBuilder.RegisterType<FormsAuthenticationService>().As<IAuthenticationService>().InstancePerHttpRequest();

            containerBuilder.RegisterType<TransactionDebugService>().As<ITransactionDebugService>().InstancePerHttpRequest();

            containerBuilder.RegisterType<BlogService>().As<IBlogService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<TagService>().As<ITagService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<PostService>().As<IPostService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<PostCommentService>().As<IPostCommentService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<PostCommentLikeService>().As<IPostCommentLikeService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<PostLikeService>().As<IPostLikeService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<PostShareService>().As<IPostShareService>().InstancePerHttpRequest();

            containerBuilder.RegisterType<CdnService>().As<ICdnService>().InstancePerHttpRequest();

            containerBuilder.RegisterType<SettingService>().As<ISettingService>().InstancePerHttpRequest();

            containerBuilder.RegisterType<GenreService>().As<IGenreService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<GenreCommentService>().As<IGenreCommentService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<GenreCommentLikeService>().As<IGenreCommentLikeService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<GenreLikeService>().As<IGenreLikeService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<GenreShareService>().As<IGenreShareService>().InstancePerHttpRequest();

            containerBuilder.RegisterType<InstallationService>().As<IInstallationService>().InstancePerDependency();

            containerBuilder.RegisterType<LanguageService>().As<ILanguageService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<InMemoryLocaleStringResourceService>().As<ILocaleStringResourceService>().InstancePerHttpRequest();

            containerBuilder.RegisterType<ActivityLogTypeService>().As<IActivityLogTypeService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<ActivityLogService>().As<IActivityLogService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<LogService>().As<ILogService>().InstancePerHttpRequest();

            containerBuilder.RegisterType<DownloadService>().As<IDownloadService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<DownloadAttributeService>().As<IDownloadAttributeService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<PictureService>().As<IPictureService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<PictureAttributeService>().As<IPictureAttributeService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<MediaUtils>().AsSelf().InstancePerHttpRequest();

            containerBuilder.RegisterType<RoleService>().As<IRoleService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<UserService>().As<IUserService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<UserAttributeService>().As<IUserAttributeService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<FriendRelationService>().As<IFriendRelationService>().InstancePerHttpRequest();

            containerBuilder.RegisterType<EmailAccountService>().As<IEmailAccountService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<MessageTemplateService>().As<IMessageTemplateService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<NewsletterSubscriptionService>().As<INewsletterSubscriptionService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<QueuedEmailService>().As<IQueuedEmailService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<WorkflowMessageService>().As<IWorkflowMessageService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<MessageTokenProvider>().As<IMessageTokenProvider>().InstancePerHttpRequest();
            containerBuilder.RegisterType<EmailSender>().As<IEmailSender>().InstancePerHttpRequest();
            containerBuilder.RegisterType<Tokenizer>().As<ITokenizer>().InstancePerHttpRequest();

            containerBuilder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<NewsService>().As<INewsService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<NewsCommentService>().As<INewsCommentService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<NewsCommentLikeService>().As<INewsCommentLikeService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<NewsLikeService>().As<INewsLikeService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<NewsShareService>().As<INewsShareService>().InstancePerHttpRequest();

            containerBuilder.RegisterType<OrderService>().As<IOrderService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<OrderNoteService>().As<IOrderNoteService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<OrderLineService>().As<IOrderLineService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<OrderLineDownloadService>().As<IOrderLineDownloadService>().InstancePerHttpRequest();

            containerBuilder.RegisterType<GroupService>().As<IGroupService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<PageService>().As<IPageService>().InstancePerHttpRequest();

            containerBuilder.RegisterType<PollService>().As<IPollService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<PollCommentService>().As<IPollCommentService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<PollCommentLikeService>().As<IPollCommentLikeService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<PollLikeService>().As<IPollLikeService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<PollShareService>().As<IPollShareService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<PollAnswerService>().As<IPollAnswerService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<PollVotingRecordService>().As<IPollVotingRecordService>().InstancePerHttpRequest();

            containerBuilder.RegisterType<PublisherService>().As<IPublisherService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<PublisherCommentService>().As<IPublisherCommentService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<PublisherCommentLikeService>().As<IPublisherCommentLikeService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<PublisherLikeService>().As<IPublisherLikeService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<PublisherShareService>().As<IPublisherShareService>().InstancePerHttpRequest();

            containerBuilder.RegisterType<BannedIpService>().As<IBannedIpService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<PermissionRecordService>().As<IPermissionRecordService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<EncryptionService>().As<IEncryptionService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<StandardPermissionProvider>().As<IPermissionProvider>().InstancePerHttpRequest();

            containerBuilder.RegisterType<AdminAreaSettingsService>().As<IAdminAreaSettingsService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<ApplicationSettingsService>().As<IApplicationSettingsService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<BillingSettingsService>().As<IBillingSettingsService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<BloggingSettingsService>().As<IBloggingSettingsService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<CdnSettingsService>().As<ICdnSettingsService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<CommonSettingsService>().As<ICommonSettingsService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<DateTimeSettingsService>().As<IDateTimeSettingsService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<EmailAccountSettingsService>().As<IEmailAccountSettingsService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<LocalizationSettingsService>().As<ILocalizationSettingsService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<MediaSettingsService>().As<IMediaSettingsService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<MembershipSettingsService>().As<IMembershipSettingsService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<MessageTemplateSettingsService>().As<IMessageTemplateSettingsService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<NewsSettingsService>().As<INewsSettingsService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<SecuritySettingsService>().As<ISecuritySettingsService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<SeoSettingsService>().As<ISeoSettingsService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<SitemapSettingsService>().As<ISitemapSettingsService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<StatisticsSettingsService>().As<IStatisticsSettingsService>().InstancePerHttpRequest();

            containerBuilder.RegisterType<RedirectorService>().As<IRedirectorService>().InstancePerHttpRequest();

            containerBuilder.RegisterType<ScheduleTaskService>().As<IScheduleTaskService>().InstancePerHttpRequest();

            containerBuilder.RegisterType<TicketService>().As<ITicketService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<TicketResponseService>().As<ITicketResponseService>().InstancePerHttpRequest();

            containerBuilder.RegisterType<TrackService>().As<ITrackService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<TrackCommentService>().As<ITrackCommentService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<TrackCommentLikeService>().As<ITrackCommentLikeService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<TrackLikeService>().As<ITrackLikeService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<TrackShareService>().As<ITrackShareService>().InstancePerHttpRequest();

            containerBuilder.RegisterType<ToDoService>().As<IToDoService>().InstancePerHttpRequest();
        }

        private static void RegisterSettingsTypes(ContainerBuilder containerBuilder) {
            containerBuilder.Register(cc => cc.Resolve<IAdminAreaSettingsService>().LoadAdminAreaSettings()).As<AdminAreaSettings>().InstancePerHttpRequest();
            containerBuilder.Register(cc => cc.Resolve<IApplicationSettingsService>().LoadApplicationSettings()).As<ApplicationSettings>().InstancePerHttpRequest();
            containerBuilder.Register(cc => cc.Resolve<IBillingSettingsService>().LoadBillingSettings()).As<BillingSettings>().InstancePerHttpRequest();
            containerBuilder.Register(cc => cc.Resolve<IBloggingSettingsService>().LoadBloggingSettings()).As<BloggingSettings>().InstancePerHttpRequest();
            containerBuilder.Register(cc => cc.Resolve<ICdnSettingsService>().LoadCdnSettings()).As<CdnSettings>().InstancePerHttpRequest();
            containerBuilder.Register(cc => cc.Resolve<ICommonSettingsService>().LoadCommonSettings()).As<CommonSettings>().InstancePerHttpRequest();
            containerBuilder.Register(cc => cc.Resolve<IDateTimeSettingsService>().LoadDateTimeSettings()).As<DateTimeSettings>().InstancePerHttpRequest();
            containerBuilder.Register(cc => cc.Resolve<IEmailAccountSettingsService>().LoadEmailAccountSettings()).As<EmailAccountSettings>().InstancePerHttpRequest();
            containerBuilder.Register(cc => cc.Resolve<ILocalizationSettingsService>().LoadLocalizationSettings()).As<LocalizationSettings>().InstancePerHttpRequest();
            containerBuilder.Register(cc => cc.Resolve<IMediaSettingsService>().LoadMediaSettings()).As<MediaSettings>().InstancePerHttpRequest();
            containerBuilder.Register(cc => cc.Resolve<IMembershipSettingsService>().LoadMembershipSettings()).As<MembershipSettings>().InstancePerHttpRequest();
            containerBuilder.Register(cc => cc.Resolve<IMessageTemplateSettingsService>().LoadMessageTemplateSettings()).As<MessageTemplateSettings>().InstancePerHttpRequest();
            containerBuilder.Register(cc => cc.Resolve<INewsSettingsService>().LoadNewsSettings()).As<NewsSettings>().InstancePerHttpRequest();
            containerBuilder.Register(cc => cc.Resolve<ISecuritySettingsService>().LoadSecuritySettings()).As<SecuritySettings>().InstancePerHttpRequest();
            containerBuilder.Register(cc => cc.Resolve<ISeoSettingsService>().LoadSeoSettings()).As<SeoSettings>().InstancePerHttpRequest();
            containerBuilder.Register(cc => cc.Resolve<ISitemapSettingsService>().LoadSitemapSettings()).As<SitemapSettings>().InstancePerHttpRequest();
            containerBuilder.Register(cc => cc.Resolve<IStatisticsSettingsService>().LoadStatisticsSettings()).As<StatisticsSettings>().InstancePerHttpRequest();
        }

        private static void RegisterInstallers(ContainerBuilder containerBuilder, ITypeFinder typeFinder) {
            var installers = typeFinder.FindClassesOfType<ResourceInstallerBase>();

            foreach (var installer in installers)
                containerBuilder.RegisterType(installer).As<ResourceInstallerBase>().InstancePerDependency();
        }

        private static void RegisterCunsomerTypes(ContainerBuilder containerBuilder, ITypeFinder typeFinder) {
            var consumers = typeFinder.FindClassesOfType(typeof (IConsumer<>)).ToList();

            foreach (var consumer in consumers) {
                var interfaceTypes = consumer.FindInterfaces((type, criteria) => {
                                                                 var isMatch = type.IsGenericType && ((Type) criteria).IsAssignableFrom(type.GetGenericTypeDefinition());
                                                                 return isMatch;
                                                             }, typeof (IConsumer<>));

                containerBuilder.RegisterType(consumer).As(interfaceTypes).InstancePerHttpRequest();
            }
        }

        private static void RegisterPresentationTypes(ContainerBuilder containerBuilder, ITypeFinder typeFinder) {
            containerBuilder.RegisterType<SitemapGenerator>().As<ISitemapGenerator>().InstancePerHttpRequest();
            containerBuilder.RegisterType<PagePartBuilder>().As<IPagePartBuilder>().InstancePerHttpRequest();

            containerBuilder.RegisterType<EmbeddedViewResolver>().As<IEmbeddedViewResolver>().SingleInstance();

            containerBuilder.RegisterType<EventPublisher>().As<IEventPublisher>().SingleInstance();
            containerBuilder.RegisterType<SubscriptionService>().As<ISubscriptionService>().SingleInstance();

            containerBuilder.RegisterControllers(typeFinder.GetAssemblies().ToArray());
        }

        private static void RegisterRoutingRelatedTypes(ContainerBuilder containerBuilder, ITypeFinder typeFinder) {
            var routeProviders = typeFinder.FindClassesOfType<IRouteProvider>();

            foreach (var routeProvider in routeProviders)
                containerBuilder.RegisterType(routeProvider).As<IRouteProvider>().SingleInstance();

            containerBuilder.RegisterType<RoutePublisher>().As<IRoutePublisher>().SingleInstance();
        }
    }
}