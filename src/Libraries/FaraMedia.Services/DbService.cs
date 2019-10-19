namespace FaraMedia.Services {
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Data;
	using FaraMedia.Core.Domain;
	using FaraMedia.Core.Infrastructure;
	using FaraMedia.Services.Querying;

	using NHibernate;
	using NHibernate.Linq;

	public class DbService<TEntity, TQuery> : IDbService<TEntity, TQuery> where TEntity : class, IEntity
	                                                                      where TQuery : QueryBase<TEntity, TQuery>, new() {
		private readonly ISession _session;
		private readonly IQueryable<TEntity> _entities;
		private readonly ValidationProvider<TEntity> _validationProvider;

		public DbService(ISession session,
		                 ValidationProvider<TEntity> validationProvider) {
			_session = session;
			_entities = _session.Query<TEntity>();
			_validationProvider = validationProvider;
		}

		public virtual TEntity GetById(long id,
		                               bool load = false) {
			if (Neutrals.Is(id))
				return null;

			TEntity entity;

			if (load)
				entity = _session.Load<TEntity>(id);
			else
				entity = _session.Get<TEntity>(id);

			return entity;
		}

		public TEntity Get(Action<TQuery> queryBuilder) {
			var entities = _entities;

			queryBuilder(entities.CreateQuery<TEntity, TQuery>());

			return entities.FirstOrDefault();
		}

		public virtual IList<TEntity> GetAll(Action<TQuery> queryBuilder = null) {
			var entities = _entities;

			if (queryBuilder != null)
				queryBuilder(entities.CreateQuery<TEntity, TQuery>());

			return entities.ToList();
		}

		public virtual IList<TEntity> GetAllPaged(Action<TQuery> queryBuilder = null,
		                                          int page = 1,
		                                          int size = DbConstants.MaxResultsCount) {
			var entities = _entities;

			if (queryBuilder != null)
				queryBuilder(entities.CreateQuery<TEntity, TQuery>());

			if (!Neutrals.Is(page))
				entities = entities.Skip(page);

			if (!Neutrals.Is(size))
				entities = entities.Take(size);

			return entities.ToList();
		}

		public virtual int QueryCount(Action<TQuery> queryBuilder = null) {
			return GetAll(queryBuilder).
					Count;
		}

		public virtual ServiceOperationResult Save(TEntity entity,
		                                           bool validateChilds = false) {
			var result = EngineContext.Current.Resolve<ServiceOperationResult>();

			if (entity == null) {
				result.AddResourceError(CommonConstants.Messages.NullEntity);
				return result;
			}

			if (entity.Id != default(long) && GetById(entity.Id) == null) {
				result.AddResourceError(CommonConstants.Messages.UnknownEntity);
				return result;
			}

			if (!_validationProvider.Validate(entity,
			                                  result))
				return result;

			try {
				_session.SaveOrUpdate(entity);
			} catch (Exception exception) {
				return result;
			}

			return result;
		}

		public virtual ServiceOperationResult Delete(TEntity entity,
		                                             bool onlyChangeFlag = false) {
			var result = EngineContext.Current.Resolve<ServiceOperationResult>();

			if (entity == null) {
				result.AddResourceError(CommonConstants.Messages.NullEntity);
				return result;
			}

			if (GetById(entity.Id) == null) {
				result.AddResourceError(CommonConstants.Messages.UnknownEntity);
				return result;
			}

			try {
				_session.Delete(entity);
			} catch (Exception exception) {
				return result;
			}

			return result;
		}
	}
}