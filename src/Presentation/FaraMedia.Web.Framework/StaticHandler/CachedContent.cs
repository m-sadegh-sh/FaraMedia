namespace FaraMedia.Web.Framework.StaticHandler {
    using System;

    public class CachedContent {
        public readonly DateTime LastModified;
        public readonly byte[] ResponseBytes;

        public CachedContent(byte[] bytes, DateTime lastModified) {
            ResponseBytes = bytes;
            LastModified = lastModified;
        }
    }
}