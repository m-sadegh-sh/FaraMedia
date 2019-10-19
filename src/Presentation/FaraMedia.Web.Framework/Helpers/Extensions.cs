namespace FaraMedia.Web.Framework.Helpers {
    using System.Web;

    public static class Extensions {
        public static byte[] GetStreamBits(this HttpPostedFileBase postedFile) {
            var stream = postedFile.InputStream;
            var size = postedFile.ContentLength;
            var binary = new byte[size];

            stream.Read(binary, 0, size);

            return binary;
        }
    }
}