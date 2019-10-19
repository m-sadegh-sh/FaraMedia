namespace FaraMedia.AutoMapperIntegration.Resolvers {
    using System;

    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Services.Helpers;

    using FarsiLibrary.Utils;

    public sealed class DayMonthYearToUtcDateTimeResolver {
        private readonly int _year;
        private readonly int _month;
        private readonly int _day;
        private static IDateTimeHelper _dateTimeHelper;

        public DayMonthYearToUtcDateTimeResolver(int year, int month, int day) {
            _year = year;
            _month = month;
            _day = day;
        }

        public DateTime Resolve() {
            var persianDate = new PersianDate(_year, _month, _day);

            if (_dateTimeHelper == null)
                _dateTimeHelper = EngineContext.Current.Resolve<IDateTimeHelper>();

            var dateTime = _dateTimeHelper.TranslateToGregorian(persianDate);

            var destinationValue = _dateTimeHelper.ConvertToUtcTime(dateTime);

            return destinationValue;
        }
    }
}