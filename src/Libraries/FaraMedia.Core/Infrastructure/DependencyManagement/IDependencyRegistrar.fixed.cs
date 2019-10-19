namespace FaraMedia.Core.Infrastructure.DependencyManagement {
	using Autofac;

	using FaraMedia.Core.Infrastructure.TypeFinders;

	public interface IDependencyRegistrar {
		int RegistrationOrder { get; }

		void Register(ContainerBuilder builder,
		              ITypeFinder finder);
	}
}