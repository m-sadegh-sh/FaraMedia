namespace FaraMedia.Services.Querying.Shared {
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.Security;
	using FaraMedia.Core.Domain.Shared;
	using FaraMedia.Core.Operators;

	public sealed class LikeQuery : OwnableQueryBase<Like, LikeQuery> {
		public LikeQuery(IEnumerable<Like> entities) : base(entities) {}

		public LikeQuery(IQueryable<Like> entities) : base(entities) {}

		public LikeQuery WithLiker(User value = null,
		                           ArgumentEvaluationMode mode = ArgumentEvaluationMode.IgnoreNeutral,
		                           EntityOperator @operator = EntityOperator.Equal) {
			switch (mode) {
				case ArgumentEvaluationMode.IgnoreNeutral:
					if (Neutrals.Is(value))
						return this;
					break;

				case ArgumentEvaluationMode.Explicit:
					break;

				default:
					throw new NotSupportedEnumException(mode);
			}

			switch (@operator) {
				case EntityOperator.Equal:
					Entities = Entities.Where(l => l.Liker == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(l => l.Liker != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public LikeQuery WithLikerId(long? value = null,
		                             ArgumentEvaluationMode mode = ArgumentEvaluationMode.IgnoreNeutral,
		                             IntegralOperator @operator = IntegralOperator.Equal) {
			switch (mode) {
				case ArgumentEvaluationMode.IgnoreNeutral:
					if (Neutrals.Is(value))
						return this;
					break;

				case ArgumentEvaluationMode.Explicit:
					break;

				default:
					throw new NotSupportedEnumException(mode);
			}

			switch (@operator) {
				case IntegralOperator.Equal:
					Entities = Entities.Where(l => l.Liker.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(l => l.Liker.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(l => l.Liker.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(l => l.Liker.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(l => l.Liker.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(l => l.Liker.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public LikeQuery WithLikeDateUtc(DateTime? value = null,
		                                 ArgumentEvaluationMode mode = ArgumentEvaluationMode.IgnoreNeutral,
		                                 IntegralOperator @operator = IntegralOperator.Equal) {
			switch (mode) {
				case ArgumentEvaluationMode.IgnoreNeutral:
					if (Neutrals.Is(value))
						return this;
					break;

				case ArgumentEvaluationMode.Explicit:
					break;

				default:
					throw new NotSupportedEnumException(mode);
			}

			switch (@operator) {
				case IntegralOperator.Equal:
					Entities = Entities.Where(l => l.LikeDateUtc == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(l => l.LikeDateUtc != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(l => l.LikeDateUtc >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(l => l.LikeDateUtc > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(l => l.LikeDateUtc <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(l => l.LikeDateUtc < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public LikeQuery WithLikeDateUtcBetween(DateTime? from = null,
		                                        ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                        DateTime? to = null,
		                                        ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                        RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(l => l.LikeDateUtc >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(l => l.LikeDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(l => l.LikeDateUtc <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(l => l.LikeDateUtc == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(l => l.LikeDateUtc <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(l => l.LikeDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(l => l.LikeDateUtc >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(l => l.LikeDateUtc == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				default:
					throw new NotSupportedEnumException(@operator);
			}

			return this;
		}
	}
}