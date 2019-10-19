namespace FaraMedia.Services {
    using Autofac;
    using Autofac.Integration.Mvc;

    using FaraMedia.Core.Domain.Billing;
    using FaraMedia.Core.Domain.Components;
    using FaraMedia.Core.Domain.Configuration;
    using FaraMedia.Core.Domain.ContentManagement;
    using FaraMedia.Core.Domain.FileManagement;
    using FaraMedia.Core.Domain.Fundamentals;
    using FaraMedia.Core.Domain.Misc;
    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Core.Domain.Shared;
    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Core.Infrastructure.DependencyManagement;
    using FaraMedia.Core.Infrastructure.TypeFinders;
    using FaraMedia.Services.Extensions.Systematic;
    using FaraMedia.Services.Helpers;
    using FaraMedia.Services.Infrastructure;
    using FaraMedia.Services.Installation.Abstraction;
    using FaraMedia.Services.Querying.Systematic;
    using FaraMedia.Services.Systematic;
    using FaraMedia.Services.Utilities;
    using FaraMedia.Services.Validations.Billing;
    using FaraMedia.Services.Validations.Components;
    using FaraMedia.Services.Validations.Configuration;
    using FaraMedia.Services.Validations.ContentManagement;
    using FaraMedia.Services.Validations.FileManagement;
    using FaraMedia.Services.Validations.Fundamentals;
    using FaraMedia.Services.Validations.Misc;
    using FaraMedia.Services.Validations.Security;
    using FaraMedia.Services.Validations.Shared;
    using FaraMedia.Services.Validations.Systematic;

    using NHibernate.Validator.Cfg.Loquacious;

    public class DependencyRegistrar : IDependencyRegistrar {
        public int RegistrationOrder {
            get { return 2; }
        }

        public virtual void Register(ContainerBuilder containerBuilder, ITypeFinder typeFinder) {
            RegisterDataLayerTypes(containerBuilder);
            RegisterServices(containerBuilder);
            RegisterSettings(containerBuilder);
            RegisterValidationTypes(containerBuilder);
            RegisterHelpers(containerBuilder);
            RegisterUtilities(containerBuilder);
            RegisterInstallers(containerBuilder, typeFinder);
        }

        private static void RegisterDataLayerTypes(ContainerBuilder containerBuilder) {
            containerBuilder.RegisterType<ServiceOperationResult>().AsSelf().InstancePerDependency();
            containerBuilder.RegisterGeneric(typeof (ServiceOperationResultWithValue<>)).AsSelf().InstancePerDependency();

            containerBuilder.RegisterGeneric(typeof (ValidationProvider<>)).AsSelf().InstancePerHttpRequest();
        }

        private static void RegisterServices(ContainerBuilder containerBuilder) {
            containerBuilder.RegisterGeneric(typeof (DbService<,>)).As(typeof (IDbService<,>)).InstancePerDependency();
            containerBuilder.RegisterType<InMemoryResourceValueService>().As<IDbService<ResourceValue, ResourceValueQuery>>().InstancePerHttpRequest();

            containerBuilder.RegisterGeneric(typeof (DbSettingsService<>)).As(typeof (IDbSettingsService<>)).InstancePerDependency();

            containerBuilder.RegisterType<InstallationService>().As<IInstallationService>().InstancePerDependency();
        }

        private static void RegisterSettings(ContainerBuilder containerBuilder) {
            containerBuilder.Register(cc => cc.Resolve<IDbSettingsService<BillingSettings>>().Get()).As<BillingSettings>().InstancePerHttpRequest();
            containerBuilder.Register(cc => cc.Resolve<IDbSettingsService<FileManagementSettings>>().Get()).As<FileManagementSettings>().InstancePerHttpRequest();
            containerBuilder.Register(cc => cc.Resolve<IDbSettingsService<SecuritySettings>>().Get()).As<SecuritySettings>().InstancePerHttpRequest();
            containerBuilder.Register(cc => cc.Resolve<IDbSettingsService<SystemSettings>>().Get()).As<SystemSettings>().InstancePerHttpRequest();
        }

        private static void RegisterValidationTypes(ContainerBuilder containerBuilder) {
            containerBuilder.RegisterType<OrderStatusValidation>().As<IValidationDefinition<OrderStatus>>().InstancePerDependency();
            containerBuilder.RegisterType<OrderValidation>().As<IValidationDefinition<Order>>().InstancePerDependency();
            containerBuilder.RegisterType<OrderNoteValidation>().As<IValidationDefinition<OrderNote>>().InstancePerDependency();
            containerBuilder.RegisterType<OrderLineValidation>().As<IValidationDefinition<OrderLine>>().InstancePerDependency();
            containerBuilder.RegisterType<TransactionRequestValidation>().As<IValidationDefinition<TransactionRequest>>().InstancePerDependency();
            containerBuilder.RegisterType<TransactionResponseValidation>().As<IValidationDefinition<TransactionResponse>>().InstancePerDependency();

            containerBuilder.RegisterType<MetadataComponentValidation>().As<IValidationDefinition<MetadataComponent>>().InstancePerDependency();
            containerBuilder.RegisterType<CreationHistoryComponentValidation>().As<IValidationDefinition<CreationHistoryComponent>>().InstancePerDependency();
            containerBuilder.RegisterType<ModificationHistoryComponentValidation>().As<IValidationDefinition<ModificationHistoryComponent>>().InstancePerDependency();
            containerBuilder.RegisterType<VisibilityHistoryComponentValidation>().As<IValidationDefinition<VisibilityHistoryComponent>>().InstancePerDependency();
            containerBuilder.RegisterType<DeletionHistoryComponentValidation>().As<IValidationDefinition<DeletionHistoryComponent>>().InstancePerDependency();

            containerBuilder.RegisterType<SettingValidation>().As<IValidationDefinition<Setting>>().InstancePerDependency();

            containerBuilder.RegisterType<BlogValidation>().As<IValidationDefinition<Blog>>().InstancePerDependency();
            containerBuilder.RegisterType<TagValidation>().As<IValidationDefinition<Tag>>().InstancePerDependency();
            containerBuilder.RegisterType<PostValidation>().As<IValidationDefinition<Post>>().InstancePerDependency();
            containerBuilder.RegisterType<CategoryValidation>().As<IValidationDefinition<Category>>().InstancePerDependency();
            containerBuilder.RegisterType<NewsValidation>().As<IValidationDefinition<News>>().InstancePerDependency();
            containerBuilder.RegisterType<GroupValidation>().As<IValidationDefinition<Group>>().InstancePerDependency();
            containerBuilder.RegisterType<PageValidation>().As<IValidationDefinition<Page>>().InstancePerDependency();
            containerBuilder.RegisterType<PollValidation>().As<IValidationDefinition<Poll>>().InstancePerDependency();
            containerBuilder.RegisterType<PollChoiceValidation>().As<IValidationDefinition<PollChoice>>().InstancePerDependency();
            containerBuilder.RegisterType<PollChoiceItemValidation>().As<IValidationDefinition<PollChoiceItem>>().InstancePerDependency();
            containerBuilder.RegisterType<PollVotingRecordValidation>().As<IValidationDefinition<PollVotingRecord>>().InstancePerDependency();

            containerBuilder.RegisterType<DownloadValidation>().As<IValidationDefinition<Download>>().InstancePerDependency();
            containerBuilder.RegisterType<PictureValidation>().As<IValidationDefinition<Picture>>().InstancePerDependency();

            containerBuilder.RegisterType<GenreValidation>().As<IValidationDefinition<Genre>>().InstancePerDependency();
            containerBuilder.RegisterType<PublisherValidation>().As<IValidationDefinition<Publisher>>().InstancePerDependency();
            containerBuilder.RegisterType<ArtistValidation>().As<IValidationDefinition<Artist>>().InstancePerDependency();
            containerBuilder.RegisterType<PhotoAlbumValidation>().As<IValidationDefinition<PhotoAlbum>>().InstancePerDependency();
            containerBuilder.RegisterType<PhotoValidation>().As<IValidationDefinition<Photo>>().InstancePerDependency();
            containerBuilder.RegisterType<AlbumValidation>().As<IValidationDefinition<Album>>().InstancePerDependency();
            containerBuilder.RegisterType<TrackValidation>().As<IValidationDefinition<Track>>().InstancePerDependency();

            containerBuilder.RegisterType<RedirectorValidation>().As<IValidationDefinition<Redirector>>().InstancePerDependency();
            containerBuilder.RegisterType<TicketDepartmentValidation>().As<IValidationDefinition<TicketDepartment>>().InstancePerDependency();
            containerBuilder.RegisterType<TicketStatusValidation>().As<IValidationDefinition<TicketStatus>>().InstancePerDependency();
            containerBuilder.RegisterType<TicketValidation>().As<IValidationDefinition<Ticket>>().InstancePerDependency();
            containerBuilder.RegisterType<TicketValidation>().As<IValidationDefinition<Ticket>>().InstancePerDependency();
            containerBuilder.RegisterType<TicketValidation>().As<IValidationDefinition<Ticket>>().InstancePerDependency();
            containerBuilder.RegisterType<TicketResponseValidation>().As<IValidationDefinition<TicketResponse>>().InstancePerDependency();
            containerBuilder.RegisterType<ToDoStatusValidation>().As<IValidationDefinition<ToDoStatus>>().InstancePerDependency();
            containerBuilder.RegisterType<ToDoValidation>().As<IValidationDefinition<ToDo>>().InstancePerDependency();

            containerBuilder.RegisterType<BannedIpValidation>().As<IValidationDefinition<BannedIp>>().InstancePerDependency();
            containerBuilder.RegisterType<PermissionRecordValidation>().As<IValidationDefinition<PermissionRecord>>().InstancePerDependency();
            containerBuilder.RegisterType<RoleValidation>().As<IValidationDefinition<Role>>().InstancePerDependency();
            containerBuilder.RegisterType<UserValidation>().As<IValidationDefinition<User>>().InstancePerDependency();
            containerBuilder.RegisterType<FriendRequestValidation>().As<IValidationDefinition<FriendRequest>>().InstancePerDependency();

            containerBuilder.RegisterType<EntityAttributeValidation>().As<IValidationDefinition<EntityAttribute>>().InstancePerDependency();
            containerBuilder.RegisterType<CommentValidation>().As<IValidationDefinition<Comment>>().InstancePerDependency();
            containerBuilder.RegisterType<LikeValidation>().As<IValidationDefinition<Like>>().InstancePerDependency();
            containerBuilder.RegisterType<ShareValidation>().As<IValidationDefinition<Share>>().InstancePerDependency();

            containerBuilder.RegisterType<LanguageValidation>().As<IValidationDefinition<Language>>().InstancePerDependency();
            containerBuilder.RegisterType<ResourceKeyValidation>().As<IValidationDefinition<ResourceKey>>().InstancePerDependency();
            containerBuilder.RegisterType<ResourceValueValidation>().As<IValidationDefinition<ResourceValue>>().InstancePerDependency();
            containerBuilder.RegisterType<ActivityTypeValidation>().As<IValidationDefinition<ActivityType>>().InstancePerDependency();
            containerBuilder.RegisterType<ActivityValidation>().As<IValidationDefinition<Activity>>().InstancePerDependency();
            containerBuilder.RegisterType<LogValidation>().As<IValidationDefinition<Log>>().InstancePerDependency();
            containerBuilder.RegisterType<EmailAccountValidation>().As<IValidationDefinition<EmailAccount>>().InstancePerDependency();
            containerBuilder.RegisterType<MessageTemplateValidation>().As<IValidationDefinition<MessageTemplate>>().InstancePerDependency();
            containerBuilder.RegisterType<NewsletterSubscriptionValidation>().As<IValidationDefinition<NewsletterSubscription>>().InstancePerDependency();
            containerBuilder.RegisterType<QueuedEmailValidation>().As<IValidationDefinition<QueuedEmail>>().InstancePerDependency();
            containerBuilder.RegisterType<ScheduleTaskValidation>().As<IValidationDefinition<ScheduleTask>>().InstancePerDependency();

            containerBuilder.RegisterType<SystemSettingsValidation>().AsSelf().InstancePerDependency();
            containerBuilder.RegisterType<BillingSettingsValidation>().AsSelf().InstancePerDependency();
            containerBuilder.RegisterType<FileManagementSettingsValidation>().AsSelf().InstancePerDependency();
            containerBuilder.RegisterType<SecuritySettingsValidation>().AsSelf().InstancePerDependency();
        }

        private static void RegisterHelpers(ContainerBuilder containerBuilder) {
            containerBuilder.RegisterType<CdnHelper>().As<ICdnHelper>().InstancePerHttpRequest();
            containerBuilder.RegisterType<DateTimeHelper>().As<IDateTimeHelper>().InstancePerHttpRequest();
            containerBuilder.RegisterType<MobileDeviceHelper>().As<IMobileDeviceHelper>().InstancePerHttpRequest();
        }

        private static void RegisterUtilities(ContainerBuilder containerBuilder) {
            containerBuilder.RegisterType<WorkflowMessageService>().As<IWorkflowMessageService>().InstancePerHttpRequest();
            containerBuilder.RegisterType<MessageTokenProvider>().As<IMessageTokenProvider>().InstancePerHttpRequest();
            containerBuilder.RegisterType<EmailSender>().As<IEmailSender>().InstancePerHttpRequest();
            containerBuilder.RegisterType<Tokenizer>().As<ITokenizer>().InstancePerHttpRequest();
        }

        private static void RegisterInstallers(ContainerBuilder containerBuilder, ITypeFinder typeFinder) {
            var installers = typeFinder.FindClassesOfType<ResourceInstallerBase>();

            foreach (var installer in installers)
                containerBuilder.RegisterType(installer).As<ResourceInstallerBase>().InstancePerDependency();
        }
    }
}