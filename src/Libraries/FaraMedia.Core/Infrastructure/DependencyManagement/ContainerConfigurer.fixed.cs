namespace FaraMedia.Core.Infrastructure.DependencyManagement {
	using System;
	using System.Linq;

	using FaraMedia.Core.Configuration;
	using FaraMedia.Core.Infrastructure.TypeFinders;

	public sealed class ContainerConfigurer {
		public void Configure(IEngine engine,
		                      ContainerManager containerManager,
		                      FaraConfig faraConfig) {
			containerManager.AddComponentInstance<IEngine>(engine);
			containerManager.AddComponentInstance<FaraConfig>(faraConfig);
			containerManager.AddComponentInstance<ContainerConfigurer>(this);

			containerManager.AddComponent<ITypeFinder, WebAppTypeFinder>();

			var typeFinder = containerManager.Resolve<ITypeFinder>();
			containerManager.UpdateContainer(cb => {
				                                 var dependencyRegistrarTypes = typeFinder.FindClassesOfType<IDependencyRegistrar>();
				                                 var dependencyRegistrars = dependencyRegistrarTypes.Select(t => (IDependencyRegistrar) Activator.CreateInstance(t)).
				                                                                                     OrderBy(dr => dr.RegistrationOrder).
				                                                                                     ToList();

				                                 foreach (var dependencyRegistrar in dependencyRegistrars) {
					                                 dependencyRegistrar.Register(cb,
					                                                              typeFinder);
				                                 }
			                                 });
		}
	}
}