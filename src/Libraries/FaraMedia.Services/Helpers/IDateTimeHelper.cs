namespace FaraMedia.Services.Helpers {
    using System;
    using System.Collections.ObjectModel;

    using FaraMedia.Core.Domain.Security;

    using FarsiLibrary.Utils;

    public interface IDateTimeHelper {
        TimeZoneInfo DefaultTimeZone { get; set; }
        TimeZoneInfo CurrentTimeZone { get; set; }
        TimeZoneInfo FindTimeZoneById(string id);
        ReadOnlyCollection<TimeZoneInfo> GetSystemTimeZones();
        DateTime ConvertToUserTime(DateTime dateTime);
        DateTime ConvertToUserTime(DateTime dateTime, TimeZoneInfo sourceTimeZone);
        DateTime ConvertToUserTime(DateTime dateTime, TimeZoneInfo sourceTimeZone, TimeZoneInfo destinationTimeZone);
        DateTime ConvertToUtcTime(DateTime dateTime);
        DateTime ConvertToUtcTime(DateTime dateTime, DateTimeKind sourceDateTimeKind);
        DateTime ConvertToUtcTime(DateTime dateTime, TimeZoneInfo sourceTimeZone);
        TimeZoneInfo GetUserTimeZone(User user);
        PersianDate TranslateToPersian(DateTime dateTime);
        DateTime TranslateToGregorian(PersianDate persianDate);
        void FormatizeToPersian(ref int? beginYearOffset, ref int? endYearOffset, ref int? selectedYear, ref int? selectedMonth, ref int? selectedDay, out int beginYear, out int endYear);
    }
}