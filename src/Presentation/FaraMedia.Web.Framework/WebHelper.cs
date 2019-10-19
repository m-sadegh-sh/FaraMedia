namespace FaraMedia.Web.Framework {
	using System;
	using System.IO;
	using System.Text.RegularExpressions;
	using System.Web;
	using System.Web.Hosting;

	using CuttingEdge.Conditions;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.Configuration;
	using FaraMedia.Core.SafeCode;

	public sealed class WebHelper : IWebHelper {
		private readonly HttpContextBase _httpContext;
		private readonly SecuritySettings _securitySettings;

		public WebHelper(HttpContextBase httpContext,
		                 SecuritySettings securitySettings) {
			_httpContext = httpContext;
			_securitySettings = securitySettings;
		}

		public string GetHost() {
			var useSsl = IsCurrentConnectionSecured();

			return GetHost(useSsl);
		}

		public string GetHost(bool useSsl) {
			var appHost = ServerVariables("HTTP_HOST");

			if (string.IsNullOrEmpty(appHost))
				appHost = "localhost";

			string result;

			if (useSsl || _securitySettings.UseSsl) {
				result = string.Concat("https://",
				                       appHost);
			} else {
				result = string.Concat("http://",
				                       appHost);
			}

			if (!result.EndsWith("/"))
				result += "/";

			return result.ToLowerInvariant();
		}

		public string GetIpAddress() {
			if (_httpContext.IsReady() && _httpContext.Request.UserHostAddress != null)
				return _httpContext.Request.UserHostAddress;

			return string.Empty;
		}

		public string GetLocation() {
			var useSsl = IsCurrentConnectionSecured();

			return GetLocation(useSsl);
		}

		public string GetLocation(bool useSsl) {
			var result = GetHost(useSsl);

			if (result.EndsWith("/")) {
				result = result.Substring(0,
				                          result.Length - 1);
			}

			if (_httpContext.IsReady())
				result = result + _httpContext.Request.ApplicationPath;

			if (!result.EndsWith("/"))
				result += "/";

			return result.ToLowerInvariant();
		}

		public string GetUrl(bool absoluteUrl,
		                     bool includeQueryString) {
			var useSsl = IsCurrentConnectionSecured();

			return GetUrl(absoluteUrl,
			              includeQueryString,
			              useSsl);
		}

		public string GetUrl(bool absoluteUrl,
		                     bool includeQueryString,
		                     bool useSsl) {
			var url = string.Empty;

			if (!_httpContext.IsReady())
				return url;

			if (includeQueryString) {
				var appHost = GetHost(useSsl);
				if (appHost.EndsWith("/")) {
					appHost = appHost.Substring(0,
					                            appHost.Length - 1);
				}
				url = appHost + _httpContext.Request.RawUrl;
			} else if (_httpContext.Request.Url != null)
				url = _httpContext.Request.Url.GetLeftPart(UriPartial.Path);

			if (!absoluteUrl && _httpContext.Request.Url != null) {
				url = url.Replace(_httpContext.Request.Url.GetLeftPart(UriPartial.Authority),
				                  "");
			}

			url = url.ToLowerInvariant();

			return url;
		}

		public string GetReferrer() {
			if (_httpContext.IsReady() && _httpContext.Request.UrlReferrer != null)
				return _httpContext.Request.UrlReferrer.ToString();

			return string.Empty;
		}

		public string MapPath(string path) {
			if (HostingEnvironment.IsHosted)
				return HostingEnvironment.MapPath(path);

			var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
			path = path.Replace("~/",
			                    string.Empty).
			            TrimStart('/').
			            Replace('/',
			                    '\\');
			var combinedPath = Path.Combine(baseDirectory,
			                                path);

			return combinedPath;
		}

		public bool IsCurrentConnectionSecured() {
			if (_httpContext.IsReady()) {
				return SafeExecuter.Execute(() => _httpContext.Request.IsSecureConnection).
				                    Result;
			}

			return false;
		}

		public string ServerVariables(string name) {
			if (_httpContext.IsReady())
				return _httpContext.Request.ServerVariables[name] ?? "";

			return string.Empty;
		}

		public T QueryString<T>(string name,
		                        T defaultValue = default(T)) {
			if (!_httpContext.IsReady())
				return defaultValue;

			var value = _httpContext.Request.QueryString[name];

			if (!string.IsNullOrEmpty(value)) {
				return ConvertUtility.To(value,
				                         defaultValue);
			}

			return defaultValue;
		}

		public bool RestartAppDomain() {
			if (CommonHelper.GetTrustLevel() > AspNetHostingPermissionLevel.Medium) {
				HttpRuntime.UnloadAppDomain();

				return TryWriteGlobalAsax();
			}

			if (TryWriteWebConfig())
				return true;

			if (TryWriteGlobalAsax())
				return true;

			return false;
		}

		public bool IsStaticResource(HttpRequestBase request) {
			Condition.Requires(request,
			                   "request").
			          IsNotNull();

			var extension = VirtualPathUtility.GetExtension(request.Path);

			if (extension == null)
				return false;

			switch (extension.ToLower()) {
				case ".axd":
				case ".ashx":
				case ".bmp":
				case ".css":
				case ".gif":
				case ".ico":
				case ".jpeg":
				case ".jpg":
				case ".js":
				case ".png":
				case ".rar":
				case ".zip":
					return true;
			}

			return false;
		}

		public bool IsSearchEngine(HttpRequestBase request) {
			if (request == null)
				return false;

			if (request.Browser != null && request.Browser.Crawler)
				return true;

			if (request.UserAgent != null) {
				var regex = new Regex("Twiceler|BaiDuSpider|Slurp|Ask|Teoma|Yahoo",
				                      RegexOptions.IgnoreCase);
				return regex.Match(request.UserAgent).
				             Success;
			}

			return false;
		}

		private bool TryWriteWebConfig() {
			try {
				File.SetLastWriteTimeUtc(MapPath("~/Web.config"),
				                         DateTime.UtcNow);

				return true;
			} catch {
				return false;
			}
		}

		private bool TryWriteGlobalAsax() {
			try {
				File.SetLastWriteTimeUtc(MapPath("~/Global.asax"),
				                         DateTime.UtcNow);

				return true;
			} catch {
				return false;
			}
		}
	}
}