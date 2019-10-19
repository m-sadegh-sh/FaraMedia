namespace FaraMedia.Web.Framework.Optimization {
    using System.IO;
    using System.IO.Compression;
    using System.Text;

    public class DeflateStreamMinifier : DeflateStream {
        public OptimizeMode OptimizeMode { get; set; }

        public DeflateStreamMinifier(Stream stream, CompressionMode compressionMode, OptimizeMode optimizeMode) : base(stream, compressionMode) {
            OptimizeMode = optimizeMode;
        }

        public override void Write(byte[] buffer, int offset, int count) {
            var input = Encoding.UTF8.GetString(buffer);
            var faraMinifier = new FaraMinifier();

            switch (OptimizeMode) {
                case OptimizeMode.Html:
                    input = faraMinifier.MinifyHtml(input);
                    break;
                case OptimizeMode.Css:
                    input = faraMinifier.MinifyStyleSheet(input);
                    break;
                case OptimizeMode.Js:
                    input = faraMinifier.MinifyJavaScript(input);
                    break;
            }

            var output = Encoding.UTF8.GetBytes(input);
            base.Write(output, 0, output.GetLength(0));
        }
    }
}