namespace FaraMedia.AutoMapperIntegration.Converters {
    using System;

    using AutoMapper;

    using FaraMedia.Core.Globalization;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Core.Infrastructure.Extensions;
    using FaraMedia.Services.Helpers;

    public class NullableDateTimeToMultiFormatDateTimeConverter : ITypeConverter<DateTime?, MultiFormatDateTime> {
        private static IDateTimeHelper _dateTimeHelper;

        public MultiFormatDateTime Convert(ResolutionContext context) {
            var sourceValue = (DateTime?) context.SourceValue;

            if (_dateTimeHelper == null)
                _dateTimeHelper = EngineContext.Current.Resolve<IDateTimeHelper>();

            if (!sourceValue.HasValue)
                return new MultiFormatDateTime();

            var userDateTime = _dateTimeHelper.ConvertToUserTime(sourceValue.Value);

            return new MultiFormatDateTime {
                HasValue = true,
                OriginalValue = userDateTime,
                PersianDate = userDateTime.ToPersianDate(),
                StringRepresentation = userDateTime.ToPersianDateString()
            };
        }
    }
}