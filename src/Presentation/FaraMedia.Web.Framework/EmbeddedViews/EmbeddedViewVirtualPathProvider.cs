namespace FaraMedia.Web.Framework.EmbeddedViews {
    using System;
    using System.Collections;
    using System.Web;
    using System.Web.Caching;
    using System.Web.Hosting;

    public class EmbeddedViewVirtualPathProvider : VirtualPathProvider {
        private readonly EmbeddedViewTable _embeddedViews;

        public EmbeddedViewVirtualPathProvider(EmbeddedViewTable embeddedViews) {
            if (embeddedViews == null)
                throw new ArgumentNullException("embeddedViews");

            _embeddedViews = embeddedViews;
        }

        private bool IsEmbeddedView(string virtualPath) {
            if (string.IsNullOrEmpty(virtualPath))
                return false;

            var virtualPathAppRelative = VirtualPathUtility.ToAppRelative(virtualPath);
            if (!virtualPathAppRelative.StartsWith("~/Views/", StringComparison.InvariantCultureIgnoreCase))
                return false;

            var fullyQualifiedViewName = virtualPathAppRelative.Substring(virtualPathAppRelative.LastIndexOf("/", StringComparison.Ordinal) + 1, virtualPathAppRelative.Length - 1 - virtualPathAppRelative.LastIndexOf("/", StringComparison.Ordinal));

            var isEmbedded = _embeddedViews.ContainsEmbeddedView(fullyQualifiedViewName);
            return isEmbedded;
        }

        public override bool FileExists(string virtualPath) {
            return (IsEmbeddedView(virtualPath) || Previous.FileExists(virtualPath));
        }

        public override VirtualFile GetFile(string virtualPath) {
            if (IsEmbeddedView(virtualPath)) {
                var virtualPathAppRelative = VirtualPathUtility.ToAppRelative(virtualPath);
                var fullyQualifiedViewName = virtualPathAppRelative.Substring(virtualPathAppRelative.LastIndexOf("/", StringComparison.Ordinal) + 1, virtualPathAppRelative.Length - 1 - virtualPathAppRelative.LastIndexOf("/", StringComparison.Ordinal));

                var embeddedViewMetadata = _embeddedViews.FindEmbeddedView(fullyQualifiedViewName);
                return new EmbeddedResourceVirtualFile(embeddedViewMetadata, virtualPath);
            }

            return Previous.GetFile(virtualPath);
        }

        public override CacheDependency GetCacheDependency(string virtualPath, IEnumerable virtualPathDependencies, DateTime utcStart) {
            return IsEmbeddedView(virtualPath) ? null : Previous.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart);
        }
    }
}