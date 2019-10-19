namespace FaraMedia.AutoMapperIntegration.Extensions {
    using System.Linq;

    using AutoMapper;

    public static class MappingExpressionExtensions {
        public static IMappingExpression<TSource, TDestination> IgnoreAllNonExisting<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression) {
            var sourceType = typeof (TSource);
            var destinationType = typeof (TDestination);

            var existingMaps = Mapper.GetAllTypeMaps().First(tm => tm.SourceType == sourceType && tm.DestinationType == destinationType);

            foreach (var property in existingMaps.GetUnmappedPropertyNames())
                expression.ForMember(property, mce => mce.Ignore());

            return expression;
        }
    }
}