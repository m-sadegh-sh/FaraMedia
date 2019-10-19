namespace FaraMedia.Core.Infrastructure {
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using Autofac;
	using Autofac.Core;

	using FaraMedia.Core.Configuration;
	using FaraMedia.Core.Infrastructure.DependencyManagement;
	using FaraMedia.Core.Infrastructure.TypeFinders;

	public sealed class FaraEngine : IEngine {
		public FaraEngine(ContainerConfigurer configurer,
		                  FaraConfig config) {
			InitializeContainer(configurer,
			                    config);
		}

		public IContainer Container {
			get { return ContainerManager.Container; }
		}

		public void Initialize() {
			RunStartupTasks();
		}

		public object Resolve(Type type,
		                      params Parameter[] parameters) {
			return ContainerManager.Resolve(type,
			                                parameters);
		}

		public T Resolve<T>(params Parameter[] parameters) where T : class {
			return ContainerManager.Resolve<T>("",
			                                   parameters);
		}

		public T ResolveOptional<T>(params Parameter[] parameters) where T : class {
			return ContainerManager.ResolveOptional<T>("",
			                                           parameters);
		}

		public IEnumerable<T> ResolveAll<T>() {
			return ContainerManager.ResolveAll<T>();
		}

		public ContainerManager ContainerManager { get; private set; }

		private void RunStartupTasks() {
			var typeFinder = ContainerManager.Resolve<ITypeFinder>();
			var startUpTaskTypes = typeFinder.FindClassesOfType<IStartupTask>();
			var startUpTasks = startUpTaskTypes.Select(stt => (IStartupTask) Activator.CreateInstance(stt)).
			                                    ToList();

			startUpTasks = startUpTasks.AsQueryable().
			                            OrderBy(st => st.ExecutionOrder).
			                            ToList();

			foreach (var startUpTask in startUpTasks)
				startUpTask.Execute();
		}

		private void InitializeContainer(ContainerConfigurer configurer,
		                                 FaraConfig config) {
			var builder = new ContainerBuilder();

			ContainerManager = new ContainerManager(builder.Build());

			configurer.Configure(this,
			                     ContainerManager,
			                     config);
		}
	}
}