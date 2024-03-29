namespace FaraMedia.Core.Infrastructure.Extensions {
	using System.Collections.Generic;
	using System.Collections.Specialized;
	using System.Linq;

	using TB.ComponentModel;

	public static class NameValueCollectionExtensions {
		public static T Get<T>(this NameValueCollection source,
		                       string name,
		                       T defaultValue) {
			if (source[name].CanConvertTo<T>())
				return source[name].ConvertTo<T>();

			return defaultValue;
		}

		public static bool Contains(this NameValueCollection source,
		                            string value) {
			return source.Cast<string>().
			              Any(item => source[item] == value);
		}

		public static IDictionary<string, string> ToDictionary(this NameValueCollection source) {
			return source.Cast<string>().
			              ToDictionary(nameValue => nameValue,
			                           nameValue => source[nameValue]);
		}

		public static string ToQueryString(this NameValueCollection source) {
			return source.ToDictionary().
			              ToQueryString();
		}
	}
}