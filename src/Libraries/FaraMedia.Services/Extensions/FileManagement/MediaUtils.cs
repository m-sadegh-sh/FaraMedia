namespace FaraMedia.Services.FileManagement {
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;

    using FaraMedia.Core.Domain.Configuration;

    public sealed class MediaUtils {
        private readonly FileManagementSettings _fileManagementSettings;

        public MediaUtils(FileManagementSettings fileManagementSettings) {
            _fileManagementSettings = fileManagementSettings;
        }

        public string GetFileExtensionFromMimeType(string mimeType) {
            if (mimeType == null)
                return null;

            var extension = mimeType.Split('/').LastOrDefault();

            switch (extension) {
                case "pjpeg":
                    extension = "jpg";
                    break;
                case "x-png":
                    extension = "png";
                    break;
                case "x-icon":
                    extension = "ico";
                    break;
            }

            return extension;
        }

        public ImageCodecInfo GetImageCodecInfoFromMimeType(string mimeType) {
            return ImageCodecInfo.GetImageEncoders().FirstOrDefault(ici => ici.MimeType.Equals(mimeType, StringComparison.OrdinalIgnoreCase));
        }

        public ImageCodecInfo GetImageCodecInfoFromExtension(string extension) {
            extension = extension.TrimStart(".".ToCharArray()).ToLower().Trim();

            switch (extension) {
                case "jpg":
                case "jpeg":
                    return GetImageCodecInfoFromMimeType("image/jpeg");
                case "png":
                    return GetImageCodecInfoFromMimeType("image/png");
                case "gif":
                    return GetImageCodecInfoFromMimeType("image/png");
                default:
                    return GetImageCodecInfoFromMimeType("image/jpeg");
            }
        }

        public Size CalculateDimensions(Size originalSize, int targetSize) {
            var newSize = new Size();

            if (originalSize.Height > originalSize.Width) {
                newSize.Width = (int) (originalSize.Width*(targetSize/(float) originalSize.Height));
                newSize.Height = targetSize;
            } else {
                newSize.Height = (int) (originalSize.Height*(targetSize/(float) originalSize.Width));
                newSize.Width = targetSize;
            }

            return newSize;
        }

        public byte[] ValidatePicture(byte[] pictureBinary, string mimeType) {
            using (var stream = new MemoryStream(pictureBinary)) {
                var bitmap = new Bitmap(stream);
                var maxSize = _fileManagementSettings.MaximumImageSize;

                if ((bitmap.Height > maxSize) || (bitmap.Width > maxSize)) {
                    var newSize = CalculateDimensions(bitmap.Size, maxSize);
                    var newBitMap = new Bitmap(newSize.Width, newSize.Height);
                    var g = Graphics.FromImage(newBitMap);
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.DrawImage(bitmap, 0, 0, newSize.Width, newSize.Height);

                    var m = new MemoryStream();
                    var ep = new EncoderParameters();
                    ep.Param[0] = new EncoderParameter(Encoder.Quality, _fileManagementSettings.ImageQuality);
                    var ici = GetImageCodecInfoFromMimeType(mimeType) ?? GetImageCodecInfoFromMimeType("image/jpeg");
                    newBitMap.Save(m, ici, ep);
                    newBitMap.Dispose();
                    bitmap.Dispose();

                    return m.GetBuffer();
                }

                bitmap.Dispose();
                return pictureBinary;
            }
        }
    }
}