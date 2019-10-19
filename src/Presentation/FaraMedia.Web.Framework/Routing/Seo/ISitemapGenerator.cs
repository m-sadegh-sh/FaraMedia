namespace FaraMedia.Web.Framework.Routing.Seo {
    using System.IO;

    public interface ISitemapGenerator {
        string Generate();
        void Generate(Stream stream);
    }
}