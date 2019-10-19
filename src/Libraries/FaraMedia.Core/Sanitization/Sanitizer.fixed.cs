namespace FaraMedia.Core.Sanitization {
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Text.RegularExpressions;

	using FaraMedia.Core.Infrastructure.Extensions;

	public static class Sanitizer {
		private static readonly SanitizeConfig _config;

		static Sanitizer() {
			_config = SanitizeConfig.Current;
		}

		public static bool IsSanitized(this string input) {
			return string.CompareOrdinal(input,
			                             Sanitize(input)) == 0;
		}

		public static string Sanitize(this Enum value) {
			return Sanitize(value.ToStringOrEmpty(),
			                replacements: null);
		}

		public static string Sanitize(this Enum value,
		                              IDictionary<string, string> replacements) {
			return Sanitize(value.ToStringOrEmpty(),
			                replacements);
		}

		public static string Sanitize(this Enum value,
		                              SanitizeConfig config) {
			return Sanitize(value.ToStringOrEmpty(),
			                config);
		}

		public static string Sanitize(this Enum value,
		                              IDictionary<string, string> replacements,
		                              SanitizeConfig config) {
			return ToSanitizedValue(value.ToStringOrEmpty(),
			                        replacements,
			                        config);
		}

		public static string Sanitize(this string value) {
			return Sanitize(value,
			                replacements: null);
		}

		public static string Sanitize(this string value,
		                              IDictionary<string, string> replacements) {
			return Sanitize(value,
			                replacements,
			                _config);
		}

		public static string Sanitize(this string value,
		                              SanitizeConfig config) {
			return Sanitize(value,
			                null,
			                config);
		}

		public static string Sanitize(this string value,
		                              IDictionary<string, string> replacements,
		                              SanitizeConfig config) {
			return ToSanitizedValue(value,
			                        replacements,
			                        config);
		}

		private static string ToSanitizedValue(this string value,
		                                       ICollection<KeyValuePair<string, string>> replacements,
		                                       SanitizeConfig config) {
			if (string.IsNullOrEmpty(value))
				return string.Empty;

			value = AppendSeparator(value,
			                        config);

			if (config.UseLowerCase)
				value = value.ToLower();

			if (replacements != null && replacements.Count > 0) {
				value = replacements.Aggregate(value,
				                               (current,
				                                replacement) => current.ReplaceAll(replacement.Key,
				                                                                   replacement.Value));
			}

			value = Regex.Replace(value,
			                      @"&\w+;",
			                      string.Empty);

			if (config.RemoveNonWesternCharacters) {
				value = Regex.Replace(value,
				                      @"[^a-z0-9\-\u0600-\u06FF\s]",
				                      config.Separator);
			} else {
				value = Regex.Replace(value,
				                      @"[^a-z0-9\-\s]",
				                      config.Separator);
			}

			if (!string.IsNullOrEmpty(config.Separator)) {
				if (config.Separator != " ") {
					value = Regex.Replace(value,
					                      " ",
					                      config.Separator);
				}

				if (config.TrimMultipleSeparators) {
					value = Regex.Replace(value,
					                      string.Concat(config.Separator,
					                                    "{2,}"),
					                      config.Separator);
				}

				var separatorArray = config.Separator.ToCharArray();

				value = value.TrimStart(separatorArray);
				value = value.TrimEnd(separatorArray);
			}

			return value;
		}

		private static string AppendSeparator(string input,
		                                      SanitizeConfig config) {
			var result = new StringBuilder();
			var alreadyAppnded = false;

			foreach (var @char in input) {
				if (char.IsUpper(@char)) {
					if (!alreadyAppnded) {
						result.AppendFormat(string.Concat(config.Separator,
						                                  char.ToLower(@char)));
						alreadyAppnded = true;
					} else
						result.Append(char.ToLower(@char));
				} else {
					result.Append(@char);
					alreadyAppnded = false;
				}
			}

			return result.ToString();
		}
	}
}