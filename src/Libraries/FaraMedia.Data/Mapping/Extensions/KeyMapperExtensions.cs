namespace FaraMedia.Data.Mapping.Extensions {
	using System;
	using System.Linq.Expressions;

	using NHibernate.Mapping.ByCode;

	using Utilities.Reflection.ExtensionMethods;

	public static class KeyMapperExtensions {
		public static void Column<TEntity, TOther>(this IKeyMapper<TEntity> mapper,
		                                           Expression<Func<TOther, object>> expression) where TEntity : class where TOther : class {
			mapper.Column(expression.GetPropertyName());
		}
	}
}