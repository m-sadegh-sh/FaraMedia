namespace FaraMedia.Web.Framework.StaticHandler {
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.IO.Compression;
    using System.Net;
    using System.Web;
    using System.Web.Caching;

    public class StaticFileHandler : IHttpAsyncHandler {
        private static readonly TimeSpan _defaultCacheDuration = TimeSpan.FromDays(30);

        private static readonly string[] _fileTypes = new[] {".css", ".js", ".html", ".htm", ".png", ".jpeg", ".jpg", ".gif", ".bmp"};

        private static readonly string[] _compressFileTypes = new[] {".css", ".js", ".html", ".htm"};

        static StaticFileHandler() {
            Array.Sort(_fileTypes);
            Array.Sort(_compressFileTypes);
        }

        public void ProcessRequest(HttpContext context) {}

        public bool IsReusable {
            get { return false; }
        }

        public virtual IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback callback, object state) {
            var response = context.Response;
            var request = context.Request;

            try {
                EnsureProperRequest(request);

                var physicalFilePath = request.PhysicalPath;

                var compressionType = GetCompressionMode(request);

                var file = new FileInfo(physicalFilePath);
                var fileExtension = file.Extension.ToLower();

                if (Array.BinarySearch(_fileTypes, fileExtension) >= 0) {
                    if (Array.BinarySearch(_compressFileTypes, fileExtension) < 0)
                        compressionType = ResponseCompressionType.None;

                    var cacheKey = typeof (StaticFileHandler) + ":" + compressionType.ToString() + ":" + physicalFilePath;

                    if (DeliverFromCache(context, request, response, cacheKey, physicalFilePath, compressionType)) {} else {
                        if (file.Exists) {
                            using (var memoryStream = new MemoryStream(compressionType == ResponseCompressionType.None ? Convert.ToInt32(file.Length) : Convert.ToInt32((double) file.Length/3))) {
                                ReadFileData(compressionType, file, memoryStream);

                                CacheAndDeliver(context, request, response, physicalFilePath, compressionType, cacheKey, memoryStream, file);
                            }
                        } else
                            throw new HttpException((int) HttpStatusCode.NotFound, request.FilePath + " Not Found");
                    }
                } else
                    TransmitFileUsingHttpResponse(request, response, physicalFilePath, compressionType, file);

                return new HttpAsyncResult(callback, state, true, null, null);
            } catch (Exception x) {
                if (x is HttpException) {
                    var h = x as HttpException;
                    response.StatusCode = h.GetHttpCode();
                    Debug.WriteLine(h.Message);
                }
                return new HttpAsyncResult(callback, state, true, null, x);
            }
        }

        public virtual void EndProcessRequest(IAsyncResult result) {}

        private static bool DeliverFromCache(HttpContext context, HttpRequest request, HttpResponse response, string cacheKey, string physicalFilePath, ResponseCompressionType compressionType) {
            var cachedContent = context.Cache[cacheKey] as CachedContent;
            if (null == cachedContent)
                return false;

            var cachedBytes = cachedContent.ResponseBytes;

            ProduceResponseHeader(response, cachedBytes.Length, compressionType, physicalFilePath, cachedContent.LastModified);
            WriteResponse(response, cachedBytes);

            Debug.WriteLine("StaticFileHandler: Cached: " + request.FilePath);
            return true;
        }

        private static void CacheAndDeliver(HttpContext context, HttpRequest request, HttpResponse response, string physicalFilePath, ResponseCompressionType compressionType, string cacheKey, MemoryStream memoryStream, FileSystemInfo file) {
            var responseBytes = memoryStream.ToArray();
            context.Cache.Insert(cacheKey, new CachedContent(responseBytes, file.LastWriteTimeUtc), new CacheDependency(physicalFilePath), DateTime.Now.Add(_defaultCacheDuration), Cache.NoSlidingExpiration);

            ProduceResponseHeader(response, responseBytes.Length, compressionType, physicalFilePath, file.LastWriteTimeUtc);
            WriteResponse(response, responseBytes);

            Debug.WriteLine("StaticFileHandler: NonCached: " + request.FilePath);
        }

        private static void ReadFileData(ResponseCompressionType compressionType, FileInfo file, Stream memoryStream) {
            using (var outputStream = (compressionType == ResponseCompressionType.None ? memoryStream : (compressionType == ResponseCompressionType.GZip ? new GZipStream(memoryStream, CompressionMode.Compress, true) : (Stream) new DeflateStream(memoryStream, CompressionMode.Compress)))) {
                using (var fs = file.Open(FileMode.Open, FileAccess.Read, FileShare.Read)) {
                    var bufSize = Convert.ToInt32(Math.Min(file.Length, 8*1024));
                    var buffer = new byte[bufSize];

                    int bytesRead;
                    while ((bytesRead = fs.Read(buffer, 0, bufSize)) > 0)
                        outputStream.Write(buffer, 0, bytesRead);
                }

                outputStream.Flush();
            }
        }

        private static void EnsureProperRequest(HttpRequest httpRequest) {
            if (httpRequest.HttpMethod == "POST")
                throw new HttpException((int) HttpStatusCode.MethodNotAllowed, "Method not allowed");
            if (httpRequest.FilePath.EndsWith(".asp", StringComparison.InvariantCultureIgnoreCase))
                throw new HttpException((int) HttpStatusCode.Forbidden, "Path forbidden");
        }

        private static void TransmitFileUsingHttpResponse(HttpRequest request, HttpResponse response, string physicalFilePath, ResponseCompressionType compressionType, FileInfo file) {
            if (!file.Exists)
                throw new HttpException((int) HttpStatusCode.NotFound, request.FilePath + " Not Found");

            ProduceResponseHeader(response, Convert.ToInt32(file.Length), compressionType, physicalFilePath, file.LastWriteTimeUtc);
            response.TransmitFile(physicalFilePath);

            Debug.WriteLine("TransmitFile: " + request.FilePath);
        }

        private static void WriteResponse(HttpResponse response, byte[] bytes) {
            response.OutputStream.Write(bytes, 0, bytes.Length);
            response.OutputStream.Flush();
        }

        private static void ProduceResponseHeader(HttpResponse response, int count, ResponseCompressionType mode, string physicalFilePath, DateTime lastModified) {
            response.Buffer = false;
            response.BufferOutput = false;

            response.ContentType = MimeMapping.GetMimeMapping(physicalFilePath);
            if (mode != ResponseCompressionType.None)
                response.AppendHeader("Content-Encoding", mode.ToString().ToLower());
            response.AppendHeader("Content-Length", count.ToString(CultureInfo.InvariantCulture));

            response.Cache.SetCacheability(HttpCacheability.Public);
            response.Cache.AppendCacheExtension("must-revalidate, proxy-revalidate");
            response.Cache.SetMaxAge(_defaultCacheDuration);
            response.Cache.SetExpires(DateTime.Now.Add(_defaultCacheDuration));
            response.Cache.SetLastModified(lastModified);
        }

        private static ResponseCompressionType GetCompressionMode(HttpRequest request) {
            var acceptEncoding = request.Headers["Accept-Encoding"];
            if (string.IsNullOrEmpty(acceptEncoding))
                return ResponseCompressionType.None;

            acceptEncoding = acceptEncoding.ToUpperInvariant();

            if (acceptEncoding.Contains("GZIP"))
                return ResponseCompressionType.GZip;

            if (acceptEncoding.Contains("DEFLATE"))
                return ResponseCompressionType.Deflate;

            return ResponseCompressionType.None;
        }
    }
}