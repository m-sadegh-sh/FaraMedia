namespace FaraMedia.Core {
	using Autofac;

	using FaraMedia.Core.Caching;
	using FaraMedia.Core.Configuration;
	using FaraMedia.Core.Infrastructure.DependencyManagement;
	using FaraMedia.Core.Infrastructure.TypeFinders;

	using Utilities.Caching;

	public sealed class DependencyRegistrar : IDependencyRegistrar {
		public int RegistrationOrder {
			get { return 0; }
		}

		public void Register(ContainerBuilder builder,
		                     ITypeFinder finder) {
			RegisterConfigTypes(builder);
			RegisterStateTypes(builder);
			RegisterCacheManagerTypes(builder);
		}

		private static void RegisterConfigTypes(ContainerBuilder builder) {
			builder.Register(cc => BootstrapConfig.Current).
			        AsSelf().
			        SingleInstance();
		}

		private static void RegisterStateTypes(ContainerBuilder builder) {
			builder.RegisterType<DbConfigurationState>().
			        AsSelf().
			        SingleInstance();
		}

		private static void RegisterCacheManagerTypes(ContainerBuilder builder) {
			builder.RegisterType<Cache<string>>().
			        As<ICache>().
			        SingleInstance();
		}
	}
}