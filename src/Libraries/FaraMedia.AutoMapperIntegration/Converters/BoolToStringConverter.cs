namespace FaraMedia.AutoMapperIntegration.Converters {
    using AutoMapper;

    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Data.Schemas.Layout;
    using FaraMedia.Services.Systematic;

    public sealed class BoolToStringConverter : ITypeConverter<bool, string> {
        private static IStringResourceService _stringResourceService;

        public string Convert(ResolutionContext context) {
            var sourceValue = (bool) context.SourceValue;

            if (_stringResourceService == null)
                _stringResourceService = EngineContext.Current.Resolve<IStringResourceService>();

            if (sourceValue)
                return _stringResourceService.GetResourceValue(MappingConstants.Texts.True);

            return _stringResourceService.GetResourceValue(MappingConstants.Texts.False);
        }
    }
}