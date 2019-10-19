namespace FaraMedia.Data {
	using Autofac;
	using Autofac.Integration.Mvc;

	using FaraMedia.Core.Configuration;
	using FaraMedia.Core.Data;
	using FaraMedia.Core.Infrastructure.DependencyManagement;
	using FaraMedia.Core.Infrastructure.TypeFinders;
	using FaraMedia.Data.Mapping;
	using FaraMedia.Data.Mapping.Extensions;
	using FaraMedia.Data.NHibernating;

	using NHibernate;
	using NHibernate.Validator.Engine;

	public sealed class DependencyRegistrar : IDependencyRegistrar {
		public int RegistrationOrder {
			get { return 1; }
		}

		public void Register(ContainerBuilder builder,
		                     ITypeFinder finder) {
			RegisterDataLayerTypes(builder);
		}

		private static void RegisterDataLayerTypes(ContainerBuilder builder) {
			builder.RegisterType<ConfigurationFileCache>().
			        AsSelf().
			        SingleInstance();

			builder.Register(cc => new NHibernateConfigurer {
					ConnectionString = cc.Resolve<FaraConfig>().
					                      ConnectionStringName,
					DropTablesCreateDbSchema = true,
					MappingAssembly = typeof (EntityMapBase<>).Assembly,
					MappingTypeFinder = t => t.IsMappingType()
			}).
			        AsSelf().
			        SingleInstance();

			builder.Register(cc => cc.Resolve<NHibernateConfigurer>().
			                          ValidatorEngine).
			        As<ValidatorEngine>().
			        InstancePerHttpRequest();

			builder.RegisterType<SessionProvider>().
			        As<ISessionProvider>().
			        SingleInstance();
			builder.Register(cc => cc.Resolve<ISessionProvider>().
			                          CreateStateless()).
			        As<IStatelessSession>().
			        InstancePerHttpRequest();
			builder.Register(cc => cc.Resolve<ISessionProvider>().
			                          Create()).
			        As<ISession>().
			        InstancePerHttpRequest();
		}
	}
}