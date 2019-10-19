namespace FaraMedia.Web.Framework.EmbeddedViews {
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Web.Hosting;

    public class EmbeddedResourceVirtualFile : VirtualFile {
        private readonly EmbeddedViewMetadata _embeddedViewMetadata;

        public EmbeddedResourceVirtualFile(EmbeddedViewMetadata embeddedViewMetadata, string virtualPath) : base(virtualPath) {
            if (embeddedViewMetadata == null)
                throw new ArgumentNullException("embeddedViewMetadata");

            _embeddedViewMetadata = embeddedViewMetadata;
        }

        public override Stream Open() {
            var assembly = GetResourceAssembly();

            if (assembly == null)
                return Stream.Null;

            return assembly.GetManifestResourceStream(_embeddedViewMetadata.Name) ?? Stream.Null;
        }

        protected virtual Assembly GetResourceAssembly() {
            return AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(assembly => string.Equals(assembly.FullName, _embeddedViewMetadata.AssemblyFullName, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}