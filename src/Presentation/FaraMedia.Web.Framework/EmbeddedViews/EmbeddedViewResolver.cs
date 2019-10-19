namespace FaraMedia.Web.Framework.EmbeddedViews {
    using System.Linq;
    using System.Reflection;

    using FaraMedia.Core.Infrastructure.TypeFinders;

    public class EmbeddedViewResolver : IEmbeddedViewResolver {
        private readonly ITypeFinder _typeFinder;

        public EmbeddedViewResolver(ITypeFinder typeFinder) {
            _typeFinder = typeFinder;
        }

        public EmbeddedViewTable GetEmbeddedViews() {
            var assemblies = _typeFinder.GetAssemblies();
            if (assemblies == null || assemblies.Count == 0)
                return null;

            var table = new EmbeddedViewTable();

            foreach (var assembly in assemblies) {
                var names = GetNamesOfAssemblyResources(assembly);
                if (names == null || names.Length == 0)
                    continue;

                foreach (var name in
                    from name in names
                    let key = name.ToLowerInvariant()
                    where key.Contains(".views.")
                    select name)
                    table.AddView(name, assembly.FullName);
            }

            return table;
        }

        private static string[] GetNamesOfAssemblyResources(Assembly assembly) {
            try {
                return assembly.GetManifestResourceNames();
            } catch {
                return new string[] {};
            }
        }
    }
}