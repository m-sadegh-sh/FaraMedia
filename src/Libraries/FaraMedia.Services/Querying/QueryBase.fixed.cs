namespace FaraMedia.Services.Querying {
	using System.Collections.Generic;
	using System.Linq;

	public class QueryBase<TEntity, TQuery> where TEntity : class
	                                        where TQuery : QueryBase<TEntity, TQuery> {
		public QueryBase(IEnumerable<TEntity> entities) : this(entities.AsQueryable()) {}

		public QueryBase(IQueryable<TEntity> entities) {
			Entities = entities;
		}

		protected IQueryable<TEntity> Entities { get; set; }
	}
}