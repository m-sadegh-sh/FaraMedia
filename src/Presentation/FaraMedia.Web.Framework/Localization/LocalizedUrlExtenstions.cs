namespace FaraMedia.Web.Framework.Systematic {
    using System;

    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Data.Schemas.Systematic;

    public static class LocalizedUrlExtenstions {
        private static bool IsVirtualDirectory(this string applicationPath) {
            if (string.IsNullOrEmpty(applicationPath))
                throw new ArgumentException("Application path is not specified");

            return applicationPath != "/";
        }

        public static string RemoveApplicationPathFromRawUrl(this string rawUrl, string applicationPath) {
            if (string.IsNullOrEmpty(applicationPath))
                throw new ArgumentException("Application path is not specified");

            if (rawUrl.Length == applicationPath.Length)
                return "/";

            var result = rawUrl.Substring(applicationPath.Length);

            if (!result.StartsWith("/"))
                result = "/" + result;

            return result;
        }

        public static string GetLanguageSeoCodeFromUrl(this string url, string applicationPath, bool isRawPath) {
            if (!isRawPath)
                return url.Substring(2, LanguageConstants.Fields.IsoCode.Length);

            if (applicationPath.IsVirtualDirectory())
                url = url.RemoveApplicationPathFromRawUrl(applicationPath);

            return url.Substring(1, LanguageConstants.Fields.IsoCode.Length);
        }

        public static bool IsLocalizedUrl(this string url, string applicationPath, bool isRawPath) {
            if (string.IsNullOrEmpty(url))
                return false;
            if (isRawPath) {
                if (applicationPath.IsVirtualDirectory())
                    url = url.RemoveApplicationPathFromRawUrl(applicationPath);

                var length = url.Length;

                if (length < 1 + LanguageConstants.Fields.IsoCode.Length)
                    return false;

                if (length == 1 + LanguageConstants.Fields.IsoCode.Length)
                    return true;

                return (length > 1 + LanguageConstants.Fields.IsoCode.Length) && (url[1 + LanguageConstants.Fields.IsoCode.Length] == '/');
            } else {
                var length = url.Length;

                if (length < 2 + LanguageConstants.Fields.IsoCode.Length)
                    return false;

                if (length == 2 + LanguageConstants.Fields.IsoCode.Length)
                    return true;

                return (length > 2 + LanguageConstants.Fields.IsoCode.Length) && (url[2 + LanguageConstants.Fields.IsoCode.Length] == '/');
            }
        }

        public static string RemoveLocalizedPathFromRawUrl(this string url, string applicationPath) {
            if (string.IsNullOrEmpty(url))
                return url;

            string result;
            if (applicationPath.IsVirtualDirectory())
                url = url.RemoveApplicationPathFromRawUrl(applicationPath);

            var length = url.Length;

            if (length < LanguageConstants.Fields.IsoCode.Length + 1)
                result = url;
            else if (length == 1 + LanguageConstants.Fields.IsoCode.Length)
                result = url.Substring(0, 1);
            else
                result = url.Substring(LanguageConstants.Fields.IsoCode.Length + 1);

            if (applicationPath.IsVirtualDirectory())
                result = applicationPath + result;

            return result;
        }

        public static string AddLocalizedPathToRawUrl(this string url, string applicationPath, Language language) {
            if (language == null)
                throw new ArgumentNullException("language");

            var startIndex = 0;
            if (applicationPath.IsVirtualDirectory())
                startIndex = applicationPath.Length;

            url = url.Insert(startIndex, language.IsoCode);
            url = url.Insert(startIndex, "/");

            return url;
        }
    }
}