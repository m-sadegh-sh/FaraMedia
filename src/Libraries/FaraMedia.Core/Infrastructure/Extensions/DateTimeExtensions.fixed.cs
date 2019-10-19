namespace FaraMedia.Core.Infrastructure.Extensions {
	using System;

	using FarsiLibrary.Utils;

	public static class DateTimeExtensions {
		public static string GetTimestamp(this DateTime value) {
			return value.ToString("yyMMddHHmmssff");
		}

		public static string ToPersianDateString(this DateTime value,
		                                         bool toWritten = true) {
			return toWritten ? PersianDateConverter.ToPersianDate(value).
			                                        ToWritten() : PersianDateConverter.ToPersianDate(value).
			                                                                           ToString();
		}

		public static PersianDate ToPersianDate(this DateTime value) {
			return PersianDateConverter.ToPersianDate(value);
		}

		public static DateTime ToGeorgianDate(this PersianDate value) {
			return PersianDateConverter.ToGregorianDateTime(value);
		}
	}
}