namespace FaraMedia.Core {
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using System.Net;
	using System.Security;
	using System.Security.Cryptography;
	using System.Text;
	using System.Text.RegularExpressions;
	using System.Web;

	using FaraMedia.Core.Infrastructure.Extensions;
	using FaraMedia.Core.Sanitization;

	using Utilities.DataTypes.ExtensionMethods;

	public static class CommonHelper {
		private const string OK_CHARS = "abcdefghijklmnopqrstuvwxyz01123456789";
		private const string EMAIL_PATTERN = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{2}|com|org|net|edu|gov|mil|biz|info|mobi|name|aero|asia|jobs|museum)\b";
		private const string URL_PATTERN = @"(http|https|ftp)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
		private const string PHONE_NUMBER_PATTERN = @"^(0[1-9][0-9]{9,10})$";
		private const string MOBILE_NUMBER_PATTERN = @"^(09[1-9][0-9]{8})$";
		private static AspNetHostingPermissionLevel? _trustLevel;

		public static bool IsValidIp(string value) {
			if (value == null)
				return true;

			IPAddress ip;
			if (IPAddress.TryParse(value,
			                       out ip))
				return true;

			return false;
		}

		public static bool IsValidEmail(string value) {
			if (string.IsNullOrEmpty(value))
				return false;

			return Regex.IsMatch(value.Trim(),
			                     EMAIL_PATTERN);
		}

		public static bool IsValidUrl(string value) {
			if (string.IsNullOrEmpty(value))
				return false;

			return Regex.IsMatch(value.Trim(),
			                     URL_PATTERN);
		}

		public static bool IsValidPhoneNumber(string value) {
			if (string.IsNullOrEmpty(value))
				return false;

			return Regex.IsMatch(value.Trim(),
			                     PHONE_NUMBER_PATTERN);
		}

		public static bool IsValidMobileNumber(string value) {
			if (string.IsNullOrEmpty(value))
				return false;

			return Regex.IsMatch(value.Trim(),
			                     MOBILE_NUMBER_PATTERN);
		}

		public static bool IsValidPath(string value) {
			if (string.IsNullOrEmpty(value))
				return false;

			return value.Any(ch => Path.GetInvalidPathChars().
			                            Any(ipc => ipc == ch));
		}

		public static bool IsValidTimeZoneId(string timeZoneId) {
			try {
				TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
				return true;
			} catch (TimeZoneNotFoundException) {
				return false;
			}
		}

		public static string BuildUrlFromRouteName(string routeName,
		                                           bool ignoreDuplication = true,
		                                           bool pluralize = false,
		                                           bool sanitize = false,
		                                           params string[] nonPluralizableTokens) {
			if (string.IsNullOrWhiteSpace(routeName))
				return string.Empty;

			var segments = new List<string>();

			var startIndex = -1;
			var endIndex = -1;
			var forceToAdd = false;
			var skipOnce = false;
			var insideExpression = false;

			for (var i = 0; i < routeName.Length; i++) {
				var @char = routeName[i];

				if (i == routeName.Length - 1) {
					forceToAdd = true;
					endIndex = i;
				} else if (@char == '*')
					skipOnce = true;
				else if (!insideExpression && char.IsUpper(@char)) {
					if (startIndex == -1)
						startIndex = i;
					else
						forceToAdd = true;
				} else {
					switch (@char) {
						case '{':
							insideExpression = true;
							if (startIndex == -1)
								startIndex = i;
							else
								forceToAdd = true;
							break;
						case '}':
							insideExpression = false;
							endIndex = i;
							break;
						default:
							endIndex = i;
							break;
					}
				}

				if (forceToAdd) {
					if (skipOnce) {
						skipOnce = false;
						forceToAdd = false;
						continue;
					}

					var segment = routeName.Substring(startIndex,
					                                  endIndex - startIndex + 1).
					                        ReplaceAll("*",
					                                   "");

					if (!string.IsNullOrWhiteSpace(segment) && !(ignoreDuplication && segments.Contains(segment)))
						segments.Add(segment);

					startIndex = i;
					forceToAdd = false;
				}
			}

			var url = new StringBuilder();

			var nonPluralizableTokensProvided = nonPluralizableTokens != null && nonPluralizableTokens.Any();

			for (var i = 0; i < segments.Count; i++) {
				if (i > 0)
					url.Append("/");

				var segment = segments[i];

				var isExpression = segment.StartsWith("{") && segment.EndsWith("}");

				if (!isExpression) {
					if (pluralize && nonPluralizableTokensProvided && !nonPluralizableTokens.Contains(segment))
						segment = segment.Pluralize();

					if (sanitize)
						segment = segment.Sanitize();
				}

				url.Append(segment);
			}

			return url.ToString().
			           ToLower(CultureInfo.CurrentCulture);
		}

		public static string GenerateRandomDigitCode(int length) {
			var random = new Random();
			var stringBuilder = new StringBuilder(length);

			for (var i = 0; i < length; i++)
				stringBuilder.Append(random.Next(10));

			return stringBuilder.ToString();
		}

		public static string GenerateRandomMixedString(int length) {
			var random = new Random();
			var stringBuilder = new StringBuilder(length);

			for (var i = 0; i < length; i++) {
				stringBuilder.Append(OK_CHARS[random.Next(0,
				                                          OK_CHARS.Length)]);
			}

			return stringBuilder.ToString();
		}

		public static int GenerateRandomInteger(int min = 0,
		                                        int max = Int32.MaxValue) {
			var buffer = new byte[10];
			new RNGCryptoServiceProvider().GetBytes(buffer);

			return new Random(BitConverter.ToInt32(buffer,
			                                       0)).Next(min,
			                                                max);
		}

		public static string EnsureNotNull(string value) {
			return value ?? string.Empty;
		}

		public static string EnsureMaxLength(string value,
		                                     int maxLength) {
			if (string.IsNullOrEmpty(value))
				return string.Empty;

			if (value.Length > maxLength) {
				value = value.Substring(0,
				                        maxLength);
			}

			return value;
		}

		public static bool AreNullOrEmpty(params string[] stringsToValidate) {
			var result = false;

			Array.ForEach(stringsToValidate,
			              value => {
				              if (string.IsNullOrEmpty(value))
					              result = true;
			              });

			return result;
		}

		public static AspNetHostingPermissionLevel GetTrustLevel() {
			if (!_trustLevel.HasValue) {
				_trustLevel = AspNetHostingPermissionLevel.None;

				foreach (var trustLevel in
						new[] {AspNetHostingPermissionLevel.Unrestricted, AspNetHostingPermissionLevel.High, AspNetHostingPermissionLevel.Medium, AspNetHostingPermissionLevel.Low, AspNetHostingPermissionLevel.Minimal}) {
					try {
						new AspNetHostingPermission(trustLevel).Demand();
						_trustLevel = trustLevel;
						break;
					} catch (SecurityException) {}
				}
			}
			return _trustLevel.Value;
		}

		public static string ConvertEnum(string value) {
			var chars = value.ToCharArray();
			var result = new StringBuilder();

			foreach (var @char in chars) {
				if (@char != char.ToLower(@char)) {
					result.AppendFormat(" {0}",
					                    @char);
				} else
					result.Append(@char);
			}

			return result.ToString();
		}
	}
}