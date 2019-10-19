namespace FaraMedia.AutoMapperIntegration.Converters {
    using AutoMapper;

    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Core.Infrastructure.Extensions;
    using FaraMedia.Data.Schemas.Layout;
    using FaraMedia.Services.Systematic;

    public sealed class NullOrEmptyStringToStringConverter : ITypeConverter<string, string> {
        private static IStringResourceService _stringResourceService;

        public string Convert(ResolutionContext context) {
            var sourceValue = context.SourceValue.ToStringOrEmpty();

            if (!string.IsNullOrEmpty(sourceValue))
                return sourceValue;

            if (context.Parent != null && (context.Parent.SourceType.Name.StartsWith("Editable") || context.Parent.DestinationType.Name.StartsWith("Editable")))
                return null;

            if (_stringResourceService == null)
                _stringResourceService = EngineContext.Current.Resolve<IStringResourceService>();

            var result = _stringResourceService.GetResourceValue(MappingConstants.Texts.Empty);

            return result;
        }
    }
}