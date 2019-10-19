namespace FaraMedia.Core.Infrastructure.DependencyManagement {
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using Autofac;
	using Autofac.Core;

	public sealed class ContainerManager {
		private readonly IContainer _container;

		public ContainerManager(IContainer container) {
			_container = container;
		}

		public IContainer Container {
			get { return _container; }
		}

		public void AddComponent<TService>(string key = "",
		                                   ComponentLifeStyle lifeStyle = ComponentLifeStyle.Singleton) {
			AddComponent<TService, TService>(key,
			                                 lifeStyle);
		}

		public void AddComponent(Type service,
		                         string key = "",
		                         ComponentLifeStyle lifeStyle = ComponentLifeStyle.Singleton) {
			AddComponent(service,
			             service,
			             key,
			             lifeStyle);
		}

		public void AddComponent<TService, TImplementation>(string key = "",
		                                                    ComponentLifeStyle lifeStyle = ComponentLifeStyle.Singleton) {
			AddComponent(typeof (TService),
			             typeof (TImplementation),
			             key,
			             lifeStyle);
		}

		public void AddComponent(Type serviceType,
		                         Type implementationType,
		                         string key = "",
		                         ComponentLifeStyle lifeStyle = ComponentLifeStyle.Singleton) {
			UpdateContainer(cb => {
				                var serviceTypes = new List<Type> {
						                serviceType
				                };

				                if (serviceType.IsGenericType) {
					                var temp = cb.RegisterGeneric(implementationType).
					                              As(serviceTypes.ToArray()).
					                              PerLifeStyle(lifeStyle);

					                if (!string.IsNullOrEmpty(key)) {
						                temp.Keyed(key,
						                           serviceType);
					                }
				                } else {
					                var temp = cb.RegisterType(implementationType).
					                              As(serviceTypes.ToArray()).
					                              PerLifeStyle(lifeStyle);

					                if (!string.IsNullOrEmpty(key)) {
						                temp.Keyed(key,
						                           serviceType);
					                }
				                }
			                });
		}

		public void AddComponentInstance<TService>(object instance,
		                                           string key = "",
		                                           ComponentLifeStyle lifeStyle = ComponentLifeStyle.Singleton) {
			AddComponentInstance(typeof (TService),
			                     instance,
			                     key,
			                     lifeStyle);
		}

		public void AddComponentInstance(Type service,
		                                 object instance,
		                                 string key = "",
		                                 ComponentLifeStyle lifeStyle = ComponentLifeStyle.Singleton) {
			UpdateContainer(x => x.RegisterInstance(instance).
			                       Keyed(key,
			                             service).
			                       As(service).
			                       PerLifeStyle(lifeStyle));
		}

		public void AddComponentInstance(object instance,
		                                 string key = "",
		                                 ComponentLifeStyle lifeStyle = ComponentLifeStyle.Singleton) {
			AddComponentInstance(instance.GetType(),
			                     instance,
			                     key,
			                     lifeStyle);
		}

		public void AddComponentWithParameters<TService, TImplementation>(IDictionary<string, string> properties,
		                                                                  string key = "",
		                                                                  ComponentLifeStyle lifeStyle = ComponentLifeStyle.Singleton) {
			AddComponentWithParameters(typeof (TService),
			                           typeof (TImplementation),
			                           properties);
		}

		public void AddComponentWithParameters(Type service,
		                                       Type implementation,
		                                       IDictionary<string, string> properties,
		                                       string key = "",
		                                       ComponentLifeStyle lifeStyle = ComponentLifeStyle.Singleton) {
			UpdateContainer(cb => {
				                var serviceTypes = new List<Type> {
						                service
				                };

				                if (string.IsNullOrEmpty(key))
					                return;

				                var temp = cb.RegisterType(implementation).
				                              As(serviceTypes.ToArray()).
				                              WithParameters(properties.Select(y => new NamedParameter(y.Key,
				                                                                                       y.Value)));
				                temp.Keyed(key,
				                           service);
			                });
		}

		public T Resolve<T>(string key = "",
		                    params Parameter[] parameters) where T : class {
			if (string.IsNullOrEmpty(key))
				return Container.Resolve<T>(parameters);

			return Container.ResolveKeyed<T>(key);
		}

		public T ResolveOptional<T>(string key = "",
		                            params Parameter[] parameters) where T : class {
			if (string.IsNullOrEmpty(key))
				return Container.ResolveOptional<T>(parameters);

			return Container.ResolveOptionalKeyed<T>(key);
		}

		public object Resolve(Type type,
		                      params Parameter[] parameters) {
			return Container.Resolve(type,
			                         parameters);
		}

		public IEnumerable<T> ResolveAll<T>(string key = "") {
			if (string.IsNullOrEmpty(key))
				return Container.Resolve<IEnumerable<T>>();

			return Container.ResolveKeyed<IEnumerable<T>>(key);
		}

		public T ResolveUnregistered<T>() where T : class {
			return ResolveUnregistered(typeof (T)) as T;
		}

		public object ResolveUnregistered(Type type) {
			var constructors = type.GetConstructors();
			foreach (var constructor in constructors) {
				try {
					var parameters = constructor.GetParameters();
					var parameterInstances = new List<object>();
					foreach (var service in parameters.Select(p => Resolve(p.ParameterType))) {
						if (service == null)
							throw new InvalidOperationException("Unknown Dependency");

						parameterInstances.Add(service);
					}
					return Activator.CreateInstance(type,
					                                parameterInstances.ToArray());
				} catch (FaraException) {}
			}
			throw new FaraException("No contructor was found that had all the dependencies satisfied.");
		}

		public void UpdateContainer(Action<ContainerBuilder> action) {
			var builder = new ContainerBuilder();
			action.Invoke(builder);
			builder.Update(_container);
		}
	}
}