namespace FaraMedia.Services.Tests {
    using System;
    using System.Linq;

    using Autofac;
    using Autofac.Core;

    using FaraMedia.Core.Caching;
    using FaraMedia.Core.Configuration;
    using FaraMedia.Core.Data;
    using FaraMedia.Core.Domain.Albums;
    using FaraMedia.Core.Domain.Artists;
    using FaraMedia.Core.Domain.Billing;
    using FaraMedia.Core.Domain.Blogging;
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
    using FaraMedia.Core.Domain.Settings;
    using FaraMedia.Core.Domain.Statistics;
    using FaraMedia.Core.Domain.Tasks;
    using FaraMedia.Core.Domain.Ticketing;
    using FaraMedia.Core.Domain.Tracks;
    using FaraMedia.Core.Domain.Utilities;
    using FaraMedia.Core.Events;
    using FaraMedia.Core.Infrastructure.DependencyManagement;
    using FaraMedia.Core.Infrastructure.TypeFinders;
    using FaraMedia.Core.Text.Pluralization;
    using FaraMedia.Data;
    using FaraMedia.Data.Core;
    using FaraMedia.Data.Mapping;
    using FaraMedia.Services.Albums;
    using FaraMedia.Services.Albums.Installers;
    using FaraMedia.Services.Artists;
    using FaraMedia.Services.Artists.Installers;
    using FaraMedia.Services.Billing;
    using FaraMedia.Services.Billing.Installers;
    using FaraMedia.Services.Blogging;
    using FaraMedia.Services.Blogging.Installers;
    using FaraMedia.Services.Common;
    using FaraMedia.Services.Common.Installers;
    using FaraMedia.Services.Components.Installers;
    using FaraMedia.Services.Configuration;
    using FaraMedia.Services.Configuration.Installers;
    using FaraMedia.Services.Genres;
    using FaraMedia.Services.Genres.Installers;
    using FaraMedia.Services.Helpers;
    using FaraMedia.Services.Infrastructure;
    using FaraMedia.Services.Installation;
    using FaraMedia.Services.Layout.Installers;
    using FaraMedia.Services.Layout.Installers.Sections;
    using FaraMedia.Services.Localization;
    using FaraMedia.Services.Localization.Installers;
    using FaraMedia.Services.Logging;
    using FaraMedia.Services.Logging.Installers;
    using FaraMedia.Services.Media;
    using FaraMedia.Services.Media.Installers;
    using FaraMedia.Services.Membership;
    using FaraMedia.Services.Membership.Installers;
    using FaraMedia.Services.Messages;
    using FaraMedia.Services.Messages.Installers;
    using FaraMedia.Services.News;
    using FaraMedia.Services.News.Installers;
    using FaraMedia.Services.Orders;
    using FaraMedia.Services.Orders.Installers;
    using FaraMedia.Services.Pages;
    using FaraMedia.Services.Pages.Installers;
    using FaraMedia.Services.Polling;
    using FaraMedia.Services.Polling.Installers;
    using FaraMedia.Services.Publishers;
    using FaraMedia.Services.Publishers.Installers;
    using FaraMedia.Services.Security;
    using FaraMedia.Services.Security.Installers;
    using FaraMedia.Services.Settings;
    using FaraMedia.Services.Settings.Installers;
    using FaraMedia.Services.Statistics;
    using FaraMedia.Services.Statistics.Installers;
    using FaraMedia.Services.Tasks;
    using FaraMedia.Services.Tasks.Installers;
    using FaraMedia.Services.Ticketing;
    using FaraMedia.Services.Ticketing.Installers;
    using FaraMedia.Services.Tracks;
    using FaraMedia.Services.Tracks.Installers;
    using FaraMedia.Services.Utilities;
    using FaraMedia.Services.Utilities.Installers;
    using FaraMedia.Services.Validations;
    using FaraMedia.Services.Validations.Albums;
    using FaraMedia.Services.Validations.Artists;
    using FaraMedia.Services.Validations.Billing;
    using FaraMedia.Services.Validations.Blogging;
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
    using FaraMedia.Services.Validations.Settings;
    using FaraMedia.Services.Validations.Statistics;
    using FaraMedia.Services.Validations.Tasks;
    using FaraMedia.Services.Validations.Ticketing;
    using FaraMedia.Services.Validations.Tracks;
    using FaraMedia.Services.Validations.Utilities;

    using NHibernate.Validator.Cfg.Loquacious;

    public class DependencyRegistrar : IDependencyRegistrar {
        public int Order {
            get { return 0; }
        }

        public virtual void Register(ContainerBuilder containerBuilder, ITypeFinder typeFinder) {
            RegisterUtilityTypes(containerBuilder);
            RegisterConfigTypes(containerBuilder);
            RegisterCacheManagerTypes(containerBuilder);
            RegisterDataLayerTypes(containerBuilder);
            RegisterHelperTypes(containerBuilder);
            RegisterValidationTypes(containerBuilder);
            RegisterServiceTypes(containerBuilder);
            RegisterInstallers(containerBuilder);
            RegisterCunsomerTypes(containerBuilder, typeFinder);
            RegisterPresentationTypes(containerBuilder, typeFinder);
        }

        private static void RegisterUtilityTypes(ContainerBuilder containerBuilder) {
            containerBuilder.RegisterType<PluralizeService>().As<IPluralizeService>().SingleInstance();
        }

        private static void RegisterConfigTypes(ContainerBuilder containerBuilder) {
            //FaraConfig is already registered (EngineContext)
            //containerBuilder.RegisterInstance(FaraConfig.Load()).As<FaraConfig>().SingleInstance();
            containerBuilder.Register(cc => BootstrapConfig.Load()).AsSelf().SingleInstance();
        }

        private static void RegisterCacheManagerTypes(ContainerBuilder containerBuilder) {
            containerBuilder.RegisterType<MemoryCacheManager>().As<ICacheManager>().Named<ICacheManager>(MemoryCacheManager.Key).SingleInstance();
        }

        private static void RegisterDataLayerTypes(ContainerBuilder containerBuilder) {
            containerBuilder.Register(cc => new NHibernateConfigurer {
                ConnectionString = cc.Resolve<FaraConfig>().ConnectionStringName,
                DropTablesCreateDbSchema = true,
                MappingAssembly = typeof (EntityMapBase<>).Assembly,
                MappingTypeFinder = t => t.Namespace != null && t.Namespace.StartsWith(typeof (EntityMapBase<>).Namespace) && !t.IsAbstract,
                ValidationsAssembly = typeof (EntityValidation<>).Assembly,
                ValidationsTypeFinder = t => t.Namespace != null && t.Namespace.StartsWith(typeof (EntityValidation<>).Namespace) && !t.IsAbstract
            }).AsSelf().SingleInstance();

            containerBuilder.RegisterType<SessionProvider>().As<ISessionProvider>().SingleInstance();
            containerBuilder.RegisterType<SessionManager>().As<ISessionManager>().InstancePerDependency();
            containerBuilder.RegisterGeneric(typeof (Repository<>)).As(typeof (IRepository<>)).InstancePerLifetimeScope();

            containerBuilder.RegisterType<ServiceOperationResult>().As<ServiceOperationResult>().InstancePerDependency();
            containerBuilder.RegisterGeneric(typeof (ServiceOperationResultWithValue<>)).As(typeof (ServiceOperationResultWithValue<>)).InstancePerDependency();
        }

        private static void RegisterHelperTypes(ContainerBuilder containerBuilder) {
            //containerBuilder.RegisterType<WebHelper>().As<IWebHelper>().InstancePerLifetimeScope();
            //containerBuilder.RegisterType<WebWorkContext>().As<IWorkContext>().InstancePerLifetimeScope();
            //containerBuilder.RegisterType<MobileDeviceHelper>().As<IMobileDeviceHelper>().InstancePerLifetimeScope();
        }

        private static void RegisterServiceTypes(ContainerBuilder containerBuilder) {
            containerBuilder.RegisterType<AlbumService>().As<IAlbumService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<AlbumCommentService>().As<IAlbumCommentService>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<ArtistService>().As<IArtistService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<ArtistCommentService>().As<IArtistCommentService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<PhotoAlbumService>().As<IPhotoAlbumService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<PhotoAlbumCommentService>().As<IPhotoAlbumCommentService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<PhotoService>().As<IPhotoService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<PhotoCommentService>().As<IPhotoCommentService>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<TransactionDebugService>().As<ITransactionDenugService>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<TagService>().As<ITagService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<PostService>().As<IPostService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<PostCommentService>().As<IPostCommentService>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<CdnService>().As<ICdnService>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<SettingService>().As<ISettingService>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<GenreService>().As<IGenreService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<GenreCommentService>().As<IGenreCommentService>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<DateTimeHelper>().As<IDateTimeHelper>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<MobileDeviceHelper>().As<IMobileDeviceHelper>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<InstallationService>().As<IInstallationService>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<LanguageService>().As<ILanguageService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<LocaleStringResourceService>().As<ILocaleStringResourceService>().WithParameter(ResolvedParameter.ForNamed<ICacheManager>(MemoryCacheManager.Key)).InstancePerLifetimeScope();

            containerBuilder.RegisterType<ActivityLogTypeService>().As<IActivityLogTypeService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<ActivityLogService>().As<IActivityLogService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<LogService>().As<ILogService>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<DownloadService>().As<IDownloadService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<DownloadAttributeService>().As<IDownloadAttributeService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<PictureService>().As<IPictureService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<PictureAttributeService>().As<IPictureAttributeService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<MediaUtils>().AsSelf().InstancePerLifetimeScope();

            containerBuilder.RegisterType<RoleService>().As<IRoleService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<UserAttributeService>().As<IUserAttributeService>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<EmailAccountService>().As<IEmailAccountService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<MessageTemplateService>().As<IMessageTemplateService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<NewsletterSubscriptionService>().As<INewsletterSubscriptionService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<QueuedEmailService>().As<IQueuedEmailService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<WorkflowMessageService>().As<IWorkflowMessageService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<MessageTokenProvider>().As<IMessageTokenProvider>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<EmailSender>().As<IEmailSender>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<Tokenizer>().As<ITokenizer>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<NewsService>().As<INewsService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<NewsCommentService>().As<INewsCommentService>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<OrderService>().As<IOrderService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<OrderNoteService>().As<IOrderNoteService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<OrderLineService>().As<IOrderLineService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<OrderLineDownloadService>().As<IOrderLineDownloadService>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<GroupService>().As<IGroupService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<PageService>().As<IPageService>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<PollService>().As<IPollService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<PollCommentService>().As<IPollCommentService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<PollAnswerService>().As<IPollAnswerService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<PollVotingRecordService>().As<IPollVotingRecordService>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<PublisherService>().As<IPublisherService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<PublisherCommentService>().As<IPublisherCommentService>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<BannedIpService>().As<IBannedIpService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<PermissionRecordService>().As<IPermissionRecordService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<EncryptionService>().As<IEncryptionService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StandardPermissionProvider>().As<IPermissionProvider>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<AdminAreaSettingsService>().As<IAdminAreaSettingsService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<ApplicationSettingsService>().As<IApplicationSettingsService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<BillingSettingsService>().As<IBillingSettingsService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<BloggingSettingsService>().As<IBloggingSettingsService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<CdnSettingsService>().As<ICdnSettingsService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<CommonSettingsService>().As<ICommonSettingsService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<DateTimeSettingsService>().As<IDateTimeSettingsService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<EmailAccountSettingsService>().As<IEmailAccountSettingsService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<LocalizationSettingsService>().As<ILocalizationSettingsService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<MediaSettingsService>().As<IMediaSettingsService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<MembershipSettingsService>().As<IMembershipSettingsService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<MessageTemplateSettingsService>().As<IMessageTemplateSettingsService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<NewsSettingsService>().As<INewsSettingsService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<SecuritySettingsService>().As<ISecuritySettingsService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<SeoSettingsService>().As<ISeoSettingsService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<SitemapSettingsService>().As<ISitemapSettingsService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StatisticsSettingsService>().As<IStatisticsSettingsService>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<RedirectorService>().As<IRedirectorService>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<ScheduleTaskService>().As<IScheduleTaskService>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<TicketService>().As<ITicketService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<TicketResponseService>().As<ITicketResponseService>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<TrackService>().As<ITrackService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<TrackCommentService>().As<ITrackCommentService>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<ToDoService>().As<IToDoService>().InstancePerLifetimeScope();
        }

        private static void RegisterInstallers(ContainerBuilder containerBuilder) {
            containerBuilder.RegisterType<AlbumInstaller>().AsSelf().InstancePerLifetimeScope();

            containerBuilder.RegisterType<ArtistInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<PhotoAlbumInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<PhotoInstaller>().AsSelf().InstancePerLifetimeScope();

            containerBuilder.RegisterType<TransactionDebugInstaller>().AsSelf().InstancePerLifetimeScope();

            containerBuilder.RegisterType<TagInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<PostInstaller>().AsSelf().InstancePerLifetimeScope();

            containerBuilder.RegisterType<CommonInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<EntityInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<UserContentInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<InteractInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<EntityAttributeInstaller>().AsSelf().InstancePerLifetimeScope();

            containerBuilder.RegisterType<MetadataComponentInstaller>().AsSelf().InstancePerLifetimeScope();

            containerBuilder.RegisterType<SettingInstaller>().AsSelf().InstancePerLifetimeScope();

            containerBuilder.RegisterType<GenreInstaller>().AsSelf().InstancePerLifetimeScope();

            containerBuilder.RegisterType<MappingInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<ControlHelpersInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<CrudSharedInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<PartialsInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<RootSectionInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<AuthenticateSectionInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<ComponentModelsInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<NewsSectionInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<MembershipSectionInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<SettingsSectionInstaller>().AsSelf().InstancePerLifetimeScope();

            containerBuilder.RegisterType<LanguageInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<LocaleStringResourceInstaller>().AsSelf().InstancePerLifetimeScope();

            containerBuilder.RegisterType<ActivityLogTypeInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<ActivityLogInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<LogInstaller>().AsSelf().InstancePerLifetimeScope();

            containerBuilder.RegisterType<PictureInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<DownloadInstaller>().AsSelf().InstancePerLifetimeScope();

            containerBuilder.RegisterType<RoleInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<UserInstaller>().AsSelf().InstancePerLifetimeScope();

            containerBuilder.RegisterType<EmailAccountInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<MessageTemplateInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<NewsletterSubscriptionInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<QueuedEmailInstaller>().AsSelf().InstancePerLifetimeScope();

            containerBuilder.RegisterType<CategoryInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<NewsInstaller>().AsSelf().InstancePerLifetimeScope();

            containerBuilder.RegisterType<OrderInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<OrderNoteInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<OrderLineInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<OrderLineDownloadInstaller>().AsSelf().InstancePerLifetimeScope();

            containerBuilder.RegisterType<GroupInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<PageInstaller>().AsSelf().InstancePerLifetimeScope();

            containerBuilder.RegisterType<PollInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<PollAnswerInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<PollVotingRecordInstaller>().AsSelf().InstancePerLifetimeScope();

            containerBuilder.RegisterType<PublisherInstaller>().AsSelf().InstancePerLifetimeScope();

            containerBuilder.RegisterType<BannedIpInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<PermissionRecordInstaller>().AsSelf().InstancePerLifetimeScope();

            containerBuilder.RegisterType<AdminAreaSettingsInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<ApplicationSettingsInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<BillingSettingsInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<BloggingSettingsInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<CdnSettingsInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<CommonSettingsInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<DateTimeSettingsInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<EmailAccountInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<LocalizationSettingsInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<MediaSettingsInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<MembershipSettingsInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<MessageTemplateSettingsInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<NewsSettingsInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<SecuritySettingsInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<SeoSettingsInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<SitemapSettingsInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StatisticsSettingsInstaller>().AsSelf().InstancePerLifetimeScope();

            containerBuilder.RegisterType<RedirectorInstaller>().AsSelf().InstancePerLifetimeScope();

            containerBuilder.RegisterType<ScheduleTaskInstaller>().AsSelf().InstancePerLifetimeScope();

            containerBuilder.RegisterType<TicketInstaller>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<TicketResponseInstaller>().AsSelf().InstancePerLifetimeScope();

            containerBuilder.RegisterType<TrackInstaller>().AsSelf().InstancePerLifetimeScope();

            containerBuilder.RegisterType<ToDoInstaller>().AsSelf().InstancePerLifetimeScope();
        }

        private static void RegisterCunsomerTypes(ContainerBuilder containerBuilder, ITypeFinder typeFinder) {
            var consumers = typeFinder.FindClassesOfType(typeof (IConsumer<>)).ToList();

            foreach (var consumer in consumers) {
                var interfaceTypes = consumer.FindInterfaces((type, criteria) => {
                                                                 var isMatch = type.IsGenericType && ((Type) criteria).IsAssignableFrom(type.GetGenericTypeDefinition());
                                                                 return isMatch;
                                                             }, typeof (IConsumer<>));

                containerBuilder.RegisterType(consumer).As(interfaceTypes).InstancePerLifetimeScope();
            }
        }

        private static void RegisterPresentationTypes(ContainerBuilder containerBuilder, ITypeFinder typeFinder) {
            containerBuilder.RegisterType<EventPublisher>().As<IEventPublisher>().SingleInstance();
            containerBuilder.RegisterType<SubscriptionService>().As<ISubscriptionService>().SingleInstance();
        }
    }
}