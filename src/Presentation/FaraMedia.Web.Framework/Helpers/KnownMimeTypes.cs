namespace FaraMedia.Web.Framework.Helpers {
    public static class KnownMimeTypes {
        private static readonly string[] _htmlTypes = new[] {"text/html", "application/xhtml+xml", "*/*"};
        private static readonly string[] _xmlTypes = new[] {"application/xml", "text/xml"};
        private static readonly string[] _jsonTypes = new[] {"application/json", "text/json"};

        public static string[] HtmlTypes() {
            return _htmlTypes;
        }

        public static string[] XmlTypes() {
            return _xmlTypes;
        }

        public static string[] JsonTypes() {
            return _jsonTypes;
        }
    }
}