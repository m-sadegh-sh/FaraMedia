namespace FaraMedia.Web.Framework.Modules {
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Web;

    using FaraMedia.Web.Framework.Configuration;
    using FaraMedia.Web.Framework.Parsers;

    public sealed class FixFarsiCharsModule : HttpModuleBase {
        private const char ARABIC_YEH = (char) 0x064A;
        private const char ARABIC_KEH = (char) 0x0643;
        private const char FARSI_YEH = (char) 0x06CC;
        private const char FARSI_KEH = (char) 0x06A9;

        private static List<FixData> _fixDataList;
        private static List<string> _prefixExceptionList;
        private static List<string> _idExceptionList;
        private static bool _applyToJson;
        private static bool _applyToForm;
        private static bool _applyToQueryString;
        private static bool _applyToCookie;
        private static readonly PropertyInfo _isReadOnly = typeof (NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);

        public FixFarsiCharsModule() {
            var configSection =
                (FixFarsiCharsConfigurationSection) ConfigurationManager.GetSection("fixFarsiChars") ?? new FixFarsiCharsConfigurationSection();

            _applyToJson = configSection.ApplyToJson;
            _applyToForm = configSection.ApplyToForm;
            _applyToQueryString = configSection.ApplyToQueryString;
            _applyToCookie = configSection.ApplyToCookie;

            _prefixExceptionList = new List<string>(configSection.Exceptions.Count);
            _idExceptionList = new List<string>(configSection.Exceptions.Count);

            foreach (ExceptionElement element in configSection.Exceptions) {
                if (!string.IsNullOrEmpty(element.Prefix))
                    _prefixExceptionList.Add(element.Prefix);
                else if (!string.IsNullOrEmpty(element.Id))
                    _idExceptionList.Add(element.Id);
            }

            _fixDataList = new List<FixData>(configSection.Replacements.Count + 2);
            var isArabicYehDefined = false;
            var isArabicKehDefined = false;

            foreach (ReplacementElement element in configSection.Replacements) {
                var fix = new FixData {
                    Original = ConvertToChar(element.Original),
                    Replacement = ConvertToChar(element.Replacement)
                };

                _fixDataList.Add(fix);
                isArabicYehDefined |= fix.Original == ARABIC_YEH;
                isArabicKehDefined |= fix.Original == ARABIC_KEH;
            }

            if (!isArabicYehDefined) {
                _fixDataList.Add(new FixData {
                    Original = ARABIC_YEH,
                    Replacement = FARSI_YEH
                });
            }

            if (!isArabicKehDefined) {
                _fixDataList.Add(new FixData {
                    Original = ARABIC_KEH,
                    Replacement = FARSI_KEH
                });
            }
        }

        protected override void OnBeginRequest(HttpContextBase context) {
            var request = HttpContext.Current.Request;

            var isJsonRequest = request.ContentType.StartsWith("application/json", StringComparison.InvariantCultureIgnoreCase);
            if (_applyToJson && isJsonRequest)
                FixCharsInInputStream(request.InputStream);

            if (_applyToForm && !isJsonRequest)
                FixCharsInNameValueCollection(request.Form);

            if (_applyToQueryString)
                FixCharsInNameValueCollection(request.QueryString);

            if (_applyToCookie)
                FixCharsInCookieCollection(request.Cookies);
        }

        public static bool ShouldFixField(string key) {
            if (key == null)
                return false;

            if (_prefixExceptionList.Count != 0 || _idExceptionList.Count != 0) {
                var indexOfDollarSign = key.LastIndexOf('$');
                var id = indexOfDollarSign == -1 ? key : key.Substring(indexOfDollarSign + 1);
                if (_idExceptionList.Any(idException => id.Equals(idException, StringComparison.InvariantCultureIgnoreCase)))
                    return false;

                return _prefixExceptionList.All(prefixException => !id.StartsWith(prefixException, StringComparison.InvariantCultureIgnoreCase));
            }

            return true;
        }

        public static string FixValue(string value) {
            var fixedValue = new StringBuilder(value);

            fixedValue = _fixDataList.Aggregate(fixedValue, (current, fix) => current.Replace(fix.Original, fix.Replacement));

            return fixedValue.ToString();
        }

        public static char FixValue(char value) {
            foreach (var fix in _fixDataList) {
                if (value == fix.Original)
                    return fix.Replacement;
            }

            return value;
        }

        private static char ConvertToChar(string s) {
            char ch;
            if (char.TryParse(s, out ch))
                return ch;

            int code;
            if (int.TryParse(s, out code))
                return (char) code;

            throw new FormatException(s);
        }

        private static void FixCharsInInputStream(Stream stream) {
            var httpRawUploadedContent = GetNonPublicFieldValue(stream, "_data");
            var values = (byte[]) GetNonPublicFieldValue(httpRawUploadedContent, "_data");
            var fixedString = JsonParser.FixJsonString(Encoding.UTF8.GetString(values));

            if (fixedString != null)
                Encoding.UTF8.GetBytes(fixedString).CopyTo(values, 0);
        }

        private static object GetNonPublicFieldValue(object obj, string name) {
            var fieldInfo = obj.GetType().GetField(name, BindingFlags.Instance | BindingFlags.NonPublic);

            if (fieldInfo != null)
                return fieldInfo.GetValue(obj);

            return null;
        }

        private static void FixCharsInCookieCollection(HttpCookieCollection httpCookieCollection) {
            foreach (var key in httpCookieCollection.AllKeys) {
                if (ShouldFixField(key)) {
                    var cookie = httpCookieCollection[key];
                    if (cookie != null) {
                        foreach (var cookieKey in cookie.Values.AllKeys)
                            cookie.Values[cookieKey] = FixValue(cookie.Values[cookieKey]);
                    }
                }
            }
        }

        private static void FixCharsInNameValueCollection(NameValueCollection nameValueCollection) {
            _isReadOnly.SetValue(nameValueCollection, false, null);

            foreach (var key in nameValueCollection.AllKeys) {
                if (ShouldFixField(key))
                    nameValueCollection[key] = FixValue(nameValueCollection[key]);
            }

            _isReadOnly.SetValue(nameValueCollection, true, null);
        }
    }
}