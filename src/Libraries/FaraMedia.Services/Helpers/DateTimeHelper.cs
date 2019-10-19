namespace FaraMedia.Services.Helpers {
    using System;
    using System.Collections.ObjectModel;

    using FaraMedia.Core;
    using FaraMedia.Core.Domain.Configuration;
    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Core.Domain.Shared;
    using FaraMedia.Core.Infrastructure.Extensions;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Knowns.Security;
    using FaraMedia.Services.Extensions.Shared;
    using FaraMedia.Services.Querying.Shared;

    using FarsiLibrary.Utils;

    public sealed class DateTimeHelper : IDateTimeHelper {
        private readonly IDbService<EntityAttribute, EntityAttributeQuery> _entityAttributeService;
        private readonly IDbSettingsService<SystemSettings> _systemSettingsService;
        private readonly IWorkContext _workContext;
        private readonly SystemSettings _systemSettings;

        public DateTimeHelper(IDbService<EntityAttribute, EntityAttributeQuery> entityAttributeService, IDbSettingsService<SystemSettings> systemSettingsService, IWorkContext workContext, SystemSettings systemSettings) {
            _entityAttributeService = entityAttributeService;
            _systemSettingsService = systemSettingsService;
            _workContext = workContext;
            _systemSettings = systemSettings;
        }

        public TimeZoneInfo DefaultTimeZone {
            get {
                var timeZoneInfo = TimeZoneInfo.Local;

                if (!string.IsNullOrEmpty(_systemSettings.DefaultTimeZoneId) && CommonHelper.IsValidTimeZoneId(_systemSettings.DefaultTimeZoneId))
                    timeZoneInfo = FindTimeZoneById(_systemSettings.DefaultTimeZoneId);

                if (_systemSettings.DefaultTimeZoneId != timeZoneInfo.Id)
                    DefaultTimeZone = timeZoneInfo;

                return timeZoneInfo;
            }
            set {
                var defaultTimeZoneId = string.Empty;

                if (value != null)
                    defaultTimeZoneId = value.Id;

                _systemSettings.DefaultTimeZoneId = defaultTimeZoneId;
                _systemSettingsService.Save(_systemSettings);
            }
        }

        public TimeZoneInfo CurrentTimeZone {
            get { return GetUserTimeZone(_workContext.CurrentUser); }
            set {
                if (!_systemSettings.AllowUsersToSetTimeZone)
                    return;

                var timeZoneId = string.Empty;

                if (value != null)
                    timeZoneId = value.Id;

                var user = _workContext.CurrentUser;

                if (user == null)
                    return;

                _entityAttributeService.Save(user.Id, UserAttributeNames.TimeZoneId, timeZoneId);
            }
        }

        public TimeZoneInfo FindTimeZoneById(string id) {
            return TimeZoneInfo.FindSystemTimeZoneById(id);
        }

        public ReadOnlyCollection<TimeZoneInfo> GetSystemTimeZones() {
            return TimeZoneInfo.GetSystemTimeZones();
        }

        public DateTime ConvertToUserTime(DateTime dateTime) {
            dateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);

            var currentUserTimeZoneInfo = CurrentTimeZone;

            return TimeZoneInfo.ConvertTime(dateTime, currentUserTimeZoneInfo);
        }

        public DateTime ConvertToUserTime(DateTime dateTime, TimeZoneInfo sourceTimeZone) {
            var currentUserTimeZoneInfo = CurrentTimeZone;

            return ConvertToUserTime(dateTime, sourceTimeZone, currentUserTimeZoneInfo);
        }

        public DateTime ConvertToUserTime(DateTime dateTime, TimeZoneInfo sourceTimeZone, TimeZoneInfo destinationTimeZone) {
            return TimeZoneInfo.ConvertTime(dateTime, sourceTimeZone, destinationTimeZone);
        }

        public DateTime ConvertToUtcTime(DateTime dateTime) {
            return ConvertToUtcTime(dateTime, dateTime.Kind);
        }

        public DateTime ConvertToUtcTime(DateTime dateTime, DateTimeKind sourceDateTimeKind) {
            dateTime = DateTime.SpecifyKind(dateTime, sourceDateTimeKind);

            return TimeZoneInfo.ConvertTimeToUtc(dateTime);
        }

        public DateTime ConvertToUtcTime(DateTime dateTime, TimeZoneInfo sourceTimeZone) {
            if (sourceTimeZone.IsInvalidTime(dateTime))
                return dateTime;

            return TimeZoneInfo.ConvertTimeToUtc(dateTime, sourceTimeZone);
        }

        public TimeZoneInfo GetUserTimeZone(User user) {
            TimeZoneInfo timeZoneInfo = null;

            if (_systemSettings.AllowUsersToSetTimeZone) {
                var timeZoneId = string.Empty;
                if (user != null)
                    timeZoneId = _entityAttributeService.GetValueByOwnerIdAndKey(user.Id, UserAttributeNames.TimeZoneId, "");

                if (!string.IsNullOrEmpty(timeZoneId) && CommonHelper.IsValidTimeZoneId(timeZoneId))
                    timeZoneInfo = FindTimeZoneById(timeZoneId);
            }

            return timeZoneInfo ?? DefaultTimeZone;
        }

        public PersianDate TranslateToPersian(DateTime dateTime) {
            return dateTime.ToPersianDate();
        }

        public DateTime TranslateToGregorian(PersianDate persianDate) {
            return persianDate.ToGeorgianDate();
        }

        public void FormatizeToPersian(ref int? beginYearOffset, ref int? endYearOffset, ref int? selectedYear, ref int? selectedMonth, ref int? selectedDay, out int beginYear, out int endYear) {
            var nowUserDateTime = ConvertToUserTime(DateTime.UtcNow);
            var nowPersianDate = TranslateToPersian(nowUserDateTime);

            if (beginYearOffset == null || beginYearOffset > 0 || nowPersianDate.Year - beginYearOffset < 1000)
                beginYearOffset = -100;

            beginYear = (int) (nowPersianDate.Year + beginYearOffset);

            if (endYearOffset == null || endYearOffset < 0 || nowPersianDate.Year + endYearOffset > 9999)
                endYearOffset = 0;

            endYear = (int) (nowPersianDate.Year + endYearOffset);

            if (selectedYear == null || selectedYear < 1000 || selectedYear > 9999)
                selectedYear = nowPersianDate.Year;

            if (selectedMonth == null || selectedMonth < 1 || selectedMonth > 12)
                selectedMonth = nowPersianDate.Month;

            if (selectedDay == null || selectedDay < 1 || selectedDay > 31)
                selectedDay = nowPersianDate.Day;
        }
    }
}