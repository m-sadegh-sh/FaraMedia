namespace FaraMedia.Services.Querying {
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain;
	using FaraMedia.Core.Operators;

	public abstract class EntityQueryBase<TEntity, TQuery> : QueryBase<TEntity, TQuery> where TEntity : class, IEntity
	                                                                                    where TQuery : EntityQueryBase<TEntity, TQuery> {
		protected EntityQueryBase(IEnumerable<TEntity> entities) : base(entities) {}

		protected EntityQueryBase(IQueryable<TEntity> entities) : base(entities) {}

		public TQuery WithId(long? value = null,
		                     ArgumentEvaluationMode mode = ArgumentEvaluationMode.IgnoreNeutral,
		                     IntegralOperator @operator = IntegralOperator.Equal) {
			switch (mode) {
				case ArgumentEvaluationMode.IgnoreNeutral:
					if (Neutrals.Is(value))
						return (TQuery) this;
					break;

				case ArgumentEvaluationMode.Explicit:
					break;

				default:
					throw new NotSupportedEnumException(mode);
			}

			switch (@operator) {
				case IntegralOperator.Equal:
					Entities = Entities.Where(e => e.Id == value);
					return (TQuery) this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(e => e.Id != value);
					return (TQuery) this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(e => e.Id >= value);
					return (TQuery) this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(e => e.Id > value);
					return (TQuery) this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(e => e.Id <= value);
					return (TQuery) this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(e => e.Id < value);
					return (TQuery) this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TQuery WithIdBetween(long? from = null,
		                            ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                            long? to = null,
		                            ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                            RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(e => e.Id >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(e => e.Id == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(e => e.Id <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(e => e.Id == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(e => e.Id <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(e => e.Id == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(e => e.Id >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(e => e.Id == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				default:
					throw new NotSupportedEnumException(@operator);
			}

			return (TQuery) this;
		}
	}
}