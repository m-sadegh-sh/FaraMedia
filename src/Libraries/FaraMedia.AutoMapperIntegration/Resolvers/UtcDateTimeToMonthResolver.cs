namespace FaraMedia.AutoMapperIntegration.Resolvers {
    using System;

    using AutoMapper;

    public sealed class UtcDateTimeToMonthResolver : UtcDateTimeToDateTimeResolver {
        public override ResolutionResult Resolve(ResolutionResult source) {
            var dateTime = (DateTime) base.Resolve(source).Value;

            var persianDate = DateTimeHelper.TranslateToPersian(dateTime);

            return source.New(persianDate.Month);
        }
    }
}