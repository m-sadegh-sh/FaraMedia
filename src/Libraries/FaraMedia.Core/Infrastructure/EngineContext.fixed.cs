namespace FaraMedia.Core.Infrastructure {
	using System;
	using System.Configuration;
	using System.Runtime.CompilerServices;

	using FaraMedia.Core.Configuration;
	using FaraMedia.Core.Infrastructure.DependencyManagement;
	using FaraMedia.Core.Patterns;

	public sealed class EngineContext {
		public static IEngine Current {
			get {
				if (Singleton<IEngine>.Instance == null)
					Initialize(false);

				return Singleton<IEngine>.Instance;
			}
		}

		[MethodImpl(MethodImplOptions.Synchronized)]
		public static IEngine Initialize(bool forceRecreate) {
			if (forceRecreate || Singleton<IEngine>.Instance == null) {
				Singleton<IEngine>.Instance = CreateEngineInstance();

				Singleton<IEngine>.Instance.Initialize();
			}

			return Singleton<IEngine>.Instance;
		}

		private static IEngine CreateEngineInstance() {
			var config = FaraConfig.Current;

			if (!string.IsNullOrEmpty(config.EngineType)) {
				var engineType = Type.GetType(config.EngineType);

				if (engineType == null) {
					throw new ConfigurationErrorsException(string.Format("The type '{0}' could not be found. Please check the configuration at /configuration/fara/engine[@engineType] or check for missing assemblies.",
					                                                     config.EngineType));
				}

				if (!typeof (IEngine).IsAssignableFrom(engineType)) {
					throw new ConfigurationErrorsException(string.Format("The type '{0}' doesn't implement '{1}' and cannot be configured in /configuration/fara/engine[@engineType] for that purpose.",
					                                                     engineType,
					                                                     typeof (IEngine)));
				}

				return Activator.CreateInstance(engineType) as IEngine;
			}

			return new FaraEngine(new ContainerConfigurer(),
			                      config);
		}
	}
}