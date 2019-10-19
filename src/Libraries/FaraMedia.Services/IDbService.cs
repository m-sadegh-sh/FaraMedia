namespace FaraMedia.Services {
	using System;
	using System.Collections.Generic;

	using FaraMedia.Core.Data;
	using FaraMedia.Core.Domain;
	using FaraMedia.Services.Querying;

	public interface IDbService<TEntity, out TQuery> where TEntity : class, IEntity
	                                                 where TQuery : QueryBase<TEntity, TQuery> {
		TEntity GetById(long id,
		                bool load = false);

		TEntity Get(Action<TQuery> queryBuilder = null);

		IList<TEntity> GetAll(Action<TQuery> queryBuilder = null);

		IList<TEntity> GetAllPaged(Action<TQuery> queryBuilder = null,
		                           int page = 1,
		                           int size = DbConstants.MaxResultsCount);

		int QueryCount(Action<TQuery> queryBuilder = null);

		ServiceOperationResult Save(TEntity entity,
		                            bool validateChilds = false);

		ServiceOperationResult Delete(TEntity entity,
		                              bool onlyChangeFlag = false);
	}
}