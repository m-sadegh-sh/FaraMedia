namespace FaraMedia.Core.Infrastructure {
	using System;
	using System.Collections.Generic;

	using Autofac.Core;

	public interface IEngine {
		void Initialize();

		object Resolve(Type type,
		               params Parameter[] parameters);

		T Resolve<T>(params Parameter[] parameters) where T : class;
		T ResolveOptional<T>(params Parameter[] parameters) where T : class;
		IEnumerable<T> ResolveAll<T>();
	}
}