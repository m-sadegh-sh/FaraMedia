namespace FaraMedia.AutoMapperIntegration.Resolvers {
    using System;

    using AutoMapper;

    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Services.Helpers;

    public class UtcDateTimeToDateTimeResolver : IValueResolver {
        protected static IDateTimeHelper DateTimeHelper;

        public virtual ResolutionResult Resolve(ResolutionResult source) {
            var utcDateTime = (DateTime) source.Value;

            if (DateTimeHelper == null)
                DateTimeHelper = EngineContext.Current.Resolve<IDateTimeHelper>();

            var destinationValue = DateTimeHelper.ConvertToUserTime(utcDateTime);

            return source.New(destinationValue);
        }
    }
}