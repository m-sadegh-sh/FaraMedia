namespace FaraMedia.Web.Framework.Helpers {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Web;

    using FaraMedia.Core;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Core.Infrastructure.Extensions;

    public static class UrlConstructor {
        private static readonly IWebHelper _webHelper;

        static UrlConstructor() {
            _webHelper = EngineContext.Current.Resolve<IWebHelper>();
        }

        public static Uri ToStandartUri(this Uri nonStandardUri) {
            if (nonStandardUri == null)
                return null;

            var originNameValues = HttpUtility.ParseQueryString(nonStandardUri.Query);

            var nameValues = new Dictionary<string, string>();

            foreach (var value in from string nameValue in originNameValues
                                  where !nameValues.Keys.Contains(nameValue.ToStringOrEmpty())
                                  select nameValue.ToStringOrEmpty())
                nameValues.Add(value, originNameValues[value]);

            var emptyKeys = nameValues.Keys.Where(key => string.IsNullOrEmpty(nameValues[key])).ToList();
            foreach (var key in emptyKeys)
                nameValues.Remove(key);

            var sb = new StringBuilder();

            sb.Append(nonStandardUri.Scheme);
            sb.Append(Uri.SchemeDelimiter);
            sb.Append(nonStandardUri.Host);
            if ((nonStandardUri.Port != 80 && nonStandardUri.ToString().IsHttp()) || (nonStandardUri.Port != 443 && nonStandardUri.ToString().IsHttps()))
                sb.Append(":" + nonStandardUri.Port);
            sb.Append(EnsureTrailingSlash(nonStandardUri.AbsolutePath));
            sb = new StringBuilder(sb.ToString().ToLower());
            if (nameValues.Count > (0))
                sb.Append(nameValues.ToQueryString());
            else if (!sb.ToString().EndsWith("/") && !Regex.IsMatch(sb.ToString(), @"\.[A-Za-z]*$"))
                sb.Append("/");

            return new Uri(sb.ToString());
        }

        public static string ToStandartUrl(this Uri nonStandardUri) {
            return nonStandardUri.ToStandartUri().ToStringOrEmpty();
        }

        public static string ToStandardUrl(this Uri standardUri) {
            return standardUri == null ? string.Empty : standardUri.ToString().ToStandardUrl(false);
        }

        public static string ToStandardUrl(this string nonStandardUrl) {
            var isHttps = nonStandardUrl.IsHttps();

            return nonStandardUrl.ToStandardUrl(_webHelper.GetLocation ref isHttps, false);
        }

        public static string ToStandardUrl(this string nonStandardUrl, bool compression) {
            return nonStandardUrl.ToStandardUrl(_webHelper.GetLocation compression);
        }

        public static string ToStandardRelativeUrl(this string nonStandardUrl) {
            return nonStandardUrl.ToStandardUrl(null, false);
        }

        public static string ToRelativeUrl(this string absoluteUrl) {
            if (string.IsNullOrEmpty(absoluteUrl))
                return string.Empty;

            return absoluteUrl.Remove(0, absoluteUrl.IndexOfThirdSlash());
        }

        public static int IndexOfThirdSlash(this string absoluteUrl) {
            var index = absoluteUrl.Count(ch => ch == '/') >= 3 ? -1 : 1;
            for (var i = 0; i < absoluteUrl.Length; i++) {
                if (absoluteUrl[i] == '/')
                    index++;
                if (index == 2)
                    return i + 1;
            }
            return -1;
        }

        public static string ToStandardUrl(this string nonStandardUrl, string baseUrl, bool compression) {
            var temp = nonStandardUrl.IsHttps();
            return nonStandardUrl.ToStandardUrl(baseUrl, ref temp, compression);
        }

        public static string ToStandardUrl(this string nonStandardUrl, string baseUrl, ref bool isHttps, bool compression) {
            if (string.IsNullOrEmpty(nonStandardUrl))
                return string.Empty;

            var standard = nonStandardUrl.UrlDecode();

            standard = standard.Replace("https://127.0.0.1/", "https://localhost/");

            var shouldBeRelative = false;
            if (string.IsNullOrEmpty(baseUrl)) {
                baseUrl = _webHelper.GetLocation
                shouldBeRelative = true;
            }

            bool isValid;
            Uri temp;
            baseUrl = InsertScheme(baseUrl, false);
            if (baseUrl == null) {
                standard = InsertScheme(standard, isHttps);
                isValid = Uri.TryCreate(standard, UriKind.RelativeOrAbsolute, out temp);
            } else
                isValid = Uri.TryCreate(new Uri(baseUrl), standard, out temp);

            if (isValid) {
                if (temp.Port == -1)
                    return string.Empty;

                standard = temp.ToStandartUri().ToString();

                isHttps = standard.IsHttps();

                var indexOfHash = standard.IndexOf("#", StringComparison.Ordinal);
                if (indexOfHash > -1)
                    standard = standard.Remove(indexOfHash);
                if (compression) {
                    standard = standard.Replace(isHttps ? "https://" : "http://", string.Empty);
                    standard = standard.Replace("www.", string.Empty);
                    standard = Regex.Replace(standard, "//", "/");
                }

                return shouldBeRelative ? standard.ToRelativeUrl().UrlPathEncode() : standard.UrlPathEncode();
            }
            return string.Empty;
        }

        private static string InsertScheme(this string url, bool isHttps) {
            if (string.IsNullOrEmpty(url))
                return string.Empty;

            if (url.StartsWith("https://") || url.StartsWith("http://"))
                return url;

            if (isHttps && !url.StartsWith("https://"))
                return string.Concat(Uri.UriSchemeHttps, Uri.SchemeDelimiter, url);

            if (!url.StartsWith("http://"))
                return string.Concat(Uri.UriSchemeHttp, Uri.SchemeDelimiter, url);

            return string.Empty;
        }

        internal static string RemoveScheme(this string url) {
            if (string.IsNullOrEmpty(url))
                return string.Empty;

            if (url.StartsWith("https://"))
                return url.Remove(0, "https://".Length);

            if (url.StartsWith("http://"))
                return url.Remove(0, "http://".Length);

            return string.Empty;
        }

        public static string UrlEncode(this string value) {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            return HttpUtility.UrlEncode(value);
        }

        public static string UrlPathEncode(this string value) {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            return HttpUtility.UrlPathEncode(value);
        }

        public static string UrlDecode(this string value) {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            return HttpUtility.UrlDecode(value);
        }

        public static string AttributeEncode(this string value) {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            return HttpUtility.HtmlAttributeEncode(value);
        }

        public static string HtmlEncode(this string value) {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            return HttpUtility.HtmlEncode(value);
        }

        public static string HtmlDecode(this string value) {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            return HttpUtility.HtmlDecode(value);
        }

        public static bool HasNotTrailingSlash(this string value) {
            if (string.IsNullOrEmpty(value))
                return false;

            return value.HasNotExtension() && !value.EndsWith("/") && value.HasNoQueryString();
        }

        public static bool HasNoQueryString(this string value) {
            if (string.IsNullOrEmpty(value))
                return false;

            return value.IndexOf("?", StringComparison.Ordinal) == (-1);
        }

        public static bool HasNotExtension(this string value) {
            if (string.IsNullOrEmpty(value))
                return false;

            return value.IndexOf(".", StringComparison.Ordinal) == (-1);
        }

        public static bool IsHttps(this string url) {
            return !string.IsNullOrEmpty(url) && url.StartsWith("https://");
        }

        public static bool IsHttp(this string url) {
            return !string.IsNullOrEmpty(url) && url.StartsWith("http://");
        }

        public static string EnsureTrailingSlash(this string value) {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            return value.HasNotTrailingSlash() ? value + "/" : value;
        }

        public static string EnsureIsHttps(this string value) {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            if (!value.IsHttps())
                return "https://" + value.Replace("http://", string.Empty);
            return value;
        }

        public static string EnsureIsHttp(this string value) {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            if (value.IsHttps())
                return "http://" + value.Replace("https://", null);
            return value;
        }
    }
}