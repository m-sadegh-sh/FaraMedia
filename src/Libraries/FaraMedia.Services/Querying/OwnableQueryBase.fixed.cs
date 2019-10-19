namespace FaraMedia.Services.Querying {
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain;
	using FaraMedia.Core.Operators;

	public abstract class OwnableQueryBase<TEntity, TQuery> : EntityQueryBase<TEntity, TQuery> where TEntity : OwnableBase
	                                                                                           where TQuery : OwnableQueryBase<TEntity, TQuery> {
		protected OwnableQueryBase(IEnumerable<TEntity> entities) : base(entities) {}

		protected OwnableQueryBase(IQueryable<TEntity> entities) : base(entities) {}

		public TQuery WithOwnerId(long? value = null,
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
					Entities = Entities.Where(o => o.OwnerId == value);
					return (TQuery) this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(o => o.OwnerId != value);
					return (TQuery) this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(o => o.OwnerId >= value);
					return (TQuery) this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(o => o.OwnerId > value);
					return (TQuery) this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(o => o.OwnerId <= value);
					return (TQuery) this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(o => o.OwnerId < value);
					return (TQuery) this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TQuery WithOwnerIdBetween(long? from = null,
		                                 ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                 long? to = null,
		                                 ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                 RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(o => o.OwnerId >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(o => o.OwnerId == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(o => o.OwnerId <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(o => o.OwnerId == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(o => o.OwnerId <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(o => o.OwnerId == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(o => o.OwnerId >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(o => o.OwnerId == to);
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