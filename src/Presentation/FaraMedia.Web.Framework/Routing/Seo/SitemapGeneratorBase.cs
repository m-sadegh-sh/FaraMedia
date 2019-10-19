namespace FaraMedia.Web.Framework.Routing.Seo {
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;

    using FaraMedia.Core;

    public abstract class SitemapGeneratorBase {
        private const string DATE_FORMAT = @"yyyy-MM-dd";
        private XmlTextWriter _writer;

        protected abstract void GenerateUrlNodes();

        protected void WriteUrlLocation(string url, UpdateFrequency updateFrequency, DateTime lastModifiedOnUtc) {
            _writer.WriteStartElement("url");
            var loc = XmlHelper.XmlEncode(url);
            _writer.WriteElementString("loc", loc);
            _writer.WriteElementString("changefreq", updateFrequency.ToString().ToLowerInvariant());
            _writer.WriteElementString("lastmod", lastModifiedOnUtc.ToString(DATE_FORMAT));
            _writer.WriteEndElement();
        }

        public string Generate() {
            using (var stream = new MemoryStream()) {
                Generate(stream);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        public void Generate(Stream stream) {
            _writer = new XmlTextWriter(stream, Encoding.UTF8) {
                Formatting = Formatting.Indented
            };
            _writer.WriteStartDocument();
            _writer.WriteStartElement("urlset");
            _writer.WriteAttributeString("xmlns", "http://www.sitemaps.org/schemas/sitemap/0.9");
            _writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            _writer.WriteAttributeString("xsi:schemaLocation", "http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd");

            GenerateUrlNodes();

            _writer.WriteEndElement();
            _writer.Close();
        }
    }
}