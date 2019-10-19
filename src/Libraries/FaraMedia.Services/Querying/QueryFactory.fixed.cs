namespace FaraMedia.Services.Querying {
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core.Domain;

	public static class QueryFactory {
		public static TQuery CreateQuery<TEntity, TQuery>(this IEnumerable<TEntity> entities) where TQuery : QueryBase<TEntity, TQuery> where TEntity : IEntity {
			var query = Activator.CreateInstance(typeof (TQuery),
			                                     entities);

			return (TQuery) query;
		}

		public static TQuery CreateQuery<TEntity, TQuery>(this IQueryable<TEntity> entities) where TQuery : QueryBase<TEntity, TQuery> where TEntity : IEntity {
			var query = Activator.CreateInstance(typeof (TQuery),
			                                     entities);

			return (TQuery) query;
		}
	}
}