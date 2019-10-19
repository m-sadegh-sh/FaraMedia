namespace FaraMedia.Core.Infrastructure.TypeFinders {
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.IO;
	using System.Linq;
	using System.Reflection;
	using System.Text.RegularExpressions;

	public class AppDomainTypeFinder : ITypeFinder {
		private readonly List<Type> _assemblyAttributesSearched = new List<Type>();
		private readonly List<AttributedAssembly> _attributedAssemblies = new List<AttributedAssembly>();

		public AppDomainTypeFinder() {
			AssemblyRestrictToLoadingPattern = ".*";
			AssemblySkipLoadingPattern =
					"^System|^mscorlib|^Microsoft|^CppCodeProvider|^VJSharpCodeProvider|^WebDev|^Castle|^Iesi|^log4net|^NHibernate|^nunit|^TestDriven|^MbUnit|^Rhino|^QuickGraph|^TestFu|^Telerik|^ComponentArt|^MvcContrib|^AjaxControlToolkit|^Antlr3|^Remotion|^Recaptcha";
			LoadAppDomainAssemblies = true;
			AssemblyNames = new List<string>();
		}

		public virtual AppDomain App {
			get { return AppDomain.CurrentDomain; }
		}

		public bool LoadAppDomainAssemblies { get; set; }

		public IList<string> AssemblyNames { get; set; }

		public string AssemblySkipLoadingPattern { get; set; }

		public string AssemblyRestrictToLoadingPattern { get; set; }

		public IEnumerable<Type> FindClassesOfType<T>(bool onlyConcreteClasses = true) {
			return FindClassesOfType(typeof (T),
			                         onlyConcreteClasses);
		}

		public IEnumerable<Type> FindClassesOfType(Type assignTypeFrom,
		                                           bool onlyConcreteClasses = true) {
			return FindClassesOfType(assignTypeFrom,
			                         GetAssemblies(),
			                         onlyConcreteClasses);
		}

		public IEnumerable<Type> FindClassesOfType<T>(IEnumerable<Assembly> assemblies,
		                                              bool onlyConcreteClasses = true) {
			return FindClassesOfType(typeof (T),
			                         assemblies,
			                         onlyConcreteClasses);
		}

		public IEnumerable<Type> FindClassesOfType(Type assignTypeFrom,
		                                           IEnumerable<Assembly> assemblies,
		                                           bool onlyConcreteClasses = true) {
			var result = new List<Type>();
			try {
				foreach (var t in from a in assemblies
				                  from t in a.GetTypes()
				                  where assignTypeFrom.IsAssignableFrom(t) || (assignTypeFrom.IsGenericTypeDefinition && DoesTypeImplementOpenGeneric(t,
				                                                                                                                                      assignTypeFrom))
				                  where !t.IsInterface
				                  select t) {
					if (onlyConcreteClasses) {
						if (t.IsClass && !t.IsAbstract)
							result.Add(t);
					} else
						result.Add(t);
				}
			} catch (ReflectionTypeLoadException typeLoadException) {
				var message = typeLoadException.LoaderExceptions.Aggregate(string.Empty,
				                                                           (current,
				                                                            e) => current + (e.Message + Environment.NewLine));

				var exception = new Exception(message,
				                              typeLoadException);

				throw exception;
			}

			return result;
		}

		public IEnumerable<Type> FindClassesOfType<T, TAssemblyAttribute>(bool onlyConcreteClasses = true) where TAssemblyAttribute : Attribute {
			var found = FindAssembliesWithAttribute<TAssemblyAttribute>();
			return FindClassesOfType<T>(found,
			                            onlyConcreteClasses);
		}

		public IEnumerable<Assembly> FindAssembliesWithAttribute<T>() {
			return FindAssembliesWithAttribute<T>(GetAssemblies());
		}

		public IEnumerable<Assembly> FindAssembliesWithAttribute<T>(IEnumerable<Assembly> assemblies) {
			if (!_assemblyAttributesSearched.Contains(typeof (T))) {
				var foundAssemblies = (from assembly in assemblies
				                       let customAttributes = assembly.GetCustomAttributes(typeof (T),
				                                                                           false)
				                       where customAttributes.Any()
				                       select assembly).ToList();
				_assemblyAttributesSearched.Add(typeof (T));
				foreach (var assembly in foundAssemblies) {
					_attributedAssemblies.Add(new AttributedAssembly {
							Assembly = assembly,
							PluginAttributeType = typeof (T)
					});
				}
			}

			return _attributedAssemblies.Where(aa => aa.PluginAttributeType == typeof (T)).
			                             Select(aa => aa.Assembly).
			                             ToList();
		}

		public IEnumerable<Assembly> FindAssembliesWithAttribute<T>(DirectoryInfo assemblyPath) {
			var assemblies = (from path in Directory.GetFiles(assemblyPath.FullName,
			                                                  "*.dll")
			                  select Assembly.LoadFrom(path)
			                  into assembly let customAttributes = assembly.GetCustomAttributes(typeof (T),
			                                                                                    false) where customAttributes.Any() select assembly).ToList();

			return FindAssembliesWithAttribute<T>(assemblies);
		}

		public virtual IList<Assembly> GetAssemblies() {
			var addedAssemblyNames = new List<string>();
			var assemblies = new List<Assembly>();

			if (LoadAppDomainAssemblies) {
				AddAssembliesInAppDomain(addedAssemblyNames,
				                         assemblies);
			}

			AddConfiguredAssemblies(addedAssemblyNames,
			                        assemblies);

			return assemblies;
		}

		private void AddAssembliesInAppDomain(ICollection<string> addedAssemblyNames,
		                                      ICollection<Assembly> assemblies) {
			foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies()) {
				if (!Matches(assembly.FullName))
					continue;

				if (addedAssemblyNames.Contains(assembly.FullName))
					continue;

				assemblies.Add(assembly);
				addedAssemblyNames.Add(assembly.FullName);
			}
		}

		protected virtual void AddConfiguredAssemblies(List<string> addedAssemblyNames,
		                                               List<Assembly> assemblies) {
			foreach (var assembly in
					AssemblyNames.Select(Assembly.Load).
					              Where(assembly => !addedAssemblyNames.Contains(assembly.FullName))) {
				assemblies.Add(assembly);
				addedAssemblyNames.Add(assembly.FullName);
			}
		}

		public virtual bool Matches(string assemblyFullName) {
			return !Matches(assemblyFullName,
			                AssemblySkipLoadingPattern) && Matches(assemblyFullName,
			                                                       AssemblyRestrictToLoadingPattern);
		}

		protected virtual bool Matches(string assemblyFullName,
		                               string pattern) {
			return Regex.IsMatch(assemblyFullName,
			                     pattern,
			                     RegexOptions.IgnoreCase | RegexOptions.Compiled);
		}

		protected virtual void LoadMatchingAssemblies(string directoryPath) {
			var loadedAssemblyNames = GetAssemblies().
					Select(a => a.FullName).
					ToList();

			if (!Directory.Exists(directoryPath))
				return;

			foreach (var dllPath in Directory.GetFiles(directoryPath,
			                                           "*.dll")) {
				try {
					var an = AssemblyName.GetAssemblyName(dllPath);
					if (Matches(an.FullName) && !loadedAssemblyNames.Contains(an.FullName))
						App.Load(an);
				} catch (BadImageFormatException ex) {
					Trace.TraceError(ex.ToString());
				}
			}
		}

		protected virtual bool DoesTypeImplementOpenGeneric(Type type,
		                                                    Type openGeneric) {
			try {
				var genericTypeDefinition = openGeneric.GetGenericTypeDefinition();
				return (from implementedInterface in type.FindInterfaces((objType,
				                                                          objCriteria) => true,
				                                                         null)
				        where implementedInterface.IsGenericType
				        select genericTypeDefinition.IsAssignableFrom(implementedInterface.GetGenericTypeDefinition())).FirstOrDefault();
			} catch {
				return false;
			}
		}
	}
}