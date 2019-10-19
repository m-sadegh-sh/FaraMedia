namespace FaraMedia.Data.NHibernating {
	using System;
	using System.Configuration;
	using System.Data;
	using System.Linq;
	using System.Reflection;

	using Autofac;

	using FaraMedia.Core.Infrastructure;
	using FaraMedia.Data.NHibernating.Conventions;

	using NHibernate;
	using NHibernate.Cfg;
	using NHibernate.Cfg.MappingSchema;
	using NHibernate.Connection;
	using NHibernate.Dialect;
	using NHibernate.Driver;
	using NHibernate.Mapping.ByCode;
	using NHibernate.Tool.hbm2ddl;
	using NHibernate.Validator.Cfg;
	using NHibernate.Validator.Cfg.Loquacious;
	using NHibernate.Validator.Engine;

	using Configuration = NHibernate.Cfg.Configuration;

	public sealed class NHibernateConfigurer {
		public NHibernateConfigurer() {
			ValidatorEngine = new ValidatorEngine();
		}

		public Action<ModelMapper> AutoMappingOverride { set; get; }

		public string ConnectionString { set; get; }

		public string DbSchemaOutputFile { set; get; }

		public bool DropTablesCreateDbSchema { set; get; }

		public Assembly MappingAssembly { set; get; }

		public Func<Type, bool> MappingTypeFinder { get; set; }

		public string OutputXmlMappingsFile { set; get; }

		public bool ShowLogs { set; get; }

		public ValidatorEngine ValidatorEngine { get; private set; }

		public Configuration Configuration { get; private set; }

		public ISessionFactory SetUpSessionFactory() {
			Configuration = ReadConfigFromCacheFileOrBuildIt();

			var sessionFactory = Configuration.BuildSessionFactory();

			//if (DropTablesCreateDbSchema)
			//    ConfirmDatabaseMatchesMappings.TryValidateAndUpdateDatabaseSchema(Configuration, sessionFactory);

			return sessionFactory;
		}

		private Configuration ReadConfigFromCacheFileOrBuildIt() {
			Configuration configuration;

			var configurationFileCache = EngineContext.Current.Resolve<ConfigurationFileCache>(new TypedParameter(typeof (Assembly),
			                                                                                                      MappingAssembly));
			var cachedConfiguration = configurationFileCache.LoadConfigurationFromFile();

			if (cachedConfiguration == null) {
				configuration = BuildConfiguration();

				configurationFileCache.SaveConfigurationToFile(configuration);
			} else
				configuration = cachedConfiguration;

			return configuration;
		}

		private Configuration BuildConfiguration() {
			var configuration = InitConfiguration();
			var hbmMapping = GetHbmMappings();

			configuration.AddDeserializedMapping(hbmMapping,
			                                     null);

			InjectValidationAndFieldLengths(ref configuration);

			SchemaMetadataUpdater.QuoteTableAndColumns(configuration);

			return configuration;
		}

		private Configuration InitConfiguration() {
			var configuration = new Configuration();
			configuration.SessionFactoryName(typeof (NHibernateConfigurer).Assembly.GetName().
			                                                               FullName);

			configuration.DataBaseIntegration(dicp => {
				                                  dicp.ConnectionProvider<DriverConnectionProvider>();
				                                  dicp.Dialect<MsSql2008Dialect>();
				                                  dicp.Driver<Sql2008ClientDriver>();
				                                  dicp.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
				                                  dicp.IsolationLevel = IsolationLevel.ReadCommitted;
				                                  dicp.ConnectionString = ConfigurationManager.ConnectionStrings[ConnectionString].ConnectionString;
				                                  dicp.Timeout = 10;
				                                  dicp.BatchSize = 20;

				                                  if (ShowLogs) {
					                                  dicp.LogFormattedSql = true;
					                                  dicp.LogSqlInConsole = true;
					                                  dicp.AutoCommentSql = false;
				                                  }
			                                  });

			return configuration;
		}

		private HbmMapping GetHbmMappings() {
			var mapper = new ConventionModelMapper();

			var mappings = MappingAssembly.GetExportedTypes().
			                               Where(MappingTypeFinder).
			                               ToList();

			mapper.AddMappings(mappings);

			mapper.ApplyNamingConventions();

			if (AutoMappingOverride != null)
				AutoMappingOverride(mapper);

			var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

			ShowOutputXmlMappings(mapping);

			return mapping;
		}

		private void ShowOutputXmlMappings(HbmMapping mapping) {
			if (!ShowLogs)
				return;

			var output = mapping.AsString();

			Console.WriteLine(output);
		}

		private void InjectValidationAndFieldLengths(ref Configuration configuration) {
			var fluentConfiguration = new FluentConfiguration();

			RegisterValidationDefinitions(fluentConfiguration);

			fluentConfiguration.SetDefaultValidatorMode(ValidatorMode.UseExternal).
			                    IntegrateWithNHibernate.ApplyingDDLConstraints().
			                    And.RegisteringListeners();

			ValidatorEngine.Configure(fluentConfiguration);

			configuration.Initialize(ValidatorEngine);
		}

		private static void RegisterValidationDefinitions(FluentConfiguration configuration) {
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<OrderStatus>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<Order>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<OrderNote>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<OrderLine>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<TransactionRequest>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<TransactionResponse>>());

			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<MetadataComponent>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<CreationHistoryComponent>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<ModificationHistoryComponent>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<VisibilityHistoryComponent>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<DeletionHistoryComponent>>());

			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<Setting>>());

			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<Blog>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<Tag>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<Post>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<Category>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<News>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<Group>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<Page>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<Poll>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<PollChoice>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<PollChoiceItem>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<PollVotingRecord>>());

			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<Download>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<Picture>>());

			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<Genre>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<Publisher>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<Artist>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<PhotoAlbum>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<Photo>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<Album>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<Track>>());

			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<Redirector>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<TicketDepartment>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<TicketStatus>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<Ticket>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<TicketResponse>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<ToDoStatus>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<ToDo>>());

			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<BannedIp>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<PermissionRecord>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<Role>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<User>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<FriendRequest>>());

			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<EntityAttribute>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<Comment>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<Like>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<Share>>());

			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<Language>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<ResourceKey>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<ResourceValue>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<ActivityType>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<Activity>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<Log>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<EmailAccount>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<MessageTemplate>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<NewsletterSubscription>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<QueuedEmail>>());
			//configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<ScheduleTask>>());

			var definitions = EngineContext.Current.ResolveAll<IValidationDefinition<dynamic>>();
			foreach (var definition in definitions)
				configuration.Register(definition);
		}
	}
}