namespace FaraMedia.Web.Framework.Mvc.ActionResults {
    using System.IO;
    using System.Web.Mvc;

    using FaraMedia.Core.Domain.FileManagement;
    using FaraMedia.Core.Infrastructure;

    public class PictureResult : FileStreamResult {
        public PictureResult(Picture picture, int targetSize) : base(GetMemoryStream(picture, targetSize), picture.MimeType) {}

        private static MemoryStream GetMemoryStream(Picture picture, int targetSize) {
            var localUrl = EngineContext.Current.Resolve<IPictureService>().GetPictureLocalPath(picture, targetSize);
            var fileStream = new FileStream(localUrl, FileMode.Open, FileAccess.Read, FileShare.Read);
            var memoryStream = StreamToMemory(fileStream);
            fileStream.Close();
            return memoryStream;
        }

        private static MemoryStream StreamToMemory(Stream input) {
            var buffer = new byte[1024];
            var count = 1024;
            MemoryStream output;

            if (input.CanSeek)
                output = new MemoryStream((int) input.Length);
            else
                output = new MemoryStream();

            do {
                count = input.Read(buffer, 0, count);
                if (count == 0)
                    break;
                output.Write(buffer, 0, count);
            } while (true);

            output.Position = 0;

            return output;
        }
    }
}