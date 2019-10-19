namespace FaraMedia.Core.Infrastructure.Extensions {
	using System;
	using System.Linq;
	using System.Text;

	public static class StringExtensions {
		public static string ToStringOrEmpty(this object value) {
			return (value ?? "").ToString();
		}

		public static string TrimOrEmpty(this string value) {
			return (value ?? "").Trim();
		}

		public static string ToFormattedString<T>(this T[] values,
		                                          string separator = "-") {
			var stringBuilder = new StringBuilder();

			foreach (var value in values) {
				stringBuilder.AppendFormat(string.Concat(value,
				                                         separator));
			}

			return stringBuilder.ToString();
		}

		public static string ReplaceAll(this string input,
		                                string oldValue,
		                                string newValue) {
			while (input.IndexOf(oldValue,
			                     StringComparison.Ordinal) > -1) {
				input = input.Replace(oldValue,
				                      newValue);
			}

			return input;
		}

		public static int IndexOfAny(this string source,
		                             params string[] values) {
			foreach (var index in values.Select(v => source.IndexOf(v,
			                                                        StringComparison.Ordinal)).
			                             Where(i => i > -1))
				return index;

			return -1;
		}
	}
}