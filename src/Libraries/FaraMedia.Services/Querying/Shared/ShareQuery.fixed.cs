namespace FaraMedia.Services.Querying.Shared {
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.Security;
	using FaraMedia.Core.Domain.Shared;
	using FaraMedia.Core.Operators;

	public sealed class ShareQuery : OwnableQueryBase<Share, ShareQuery> {
		public ShareQuery(IEnumerable<Share> entities) : base(entities) {}

		public ShareQuery(IQueryable<Share> entities) : base(entities) {}

		public ShareQuery WithSharer(User value = null,
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
					Entities = Entities.Where(s => s.Sharer == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(s => s.Sharer != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ShareQuery WithSharerId(long? value = null,
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
					Entities = Entities.Where(s => s.Sharer.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(s => s.Sharer.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(s => s.Sharer.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(s => s.Sharer.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(s => s.Sharer.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(s => s.Sharer.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ShareQuery WithShareDateUtc(DateTime? value = null,
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
					Entities = Entities.Where(s => s.ShareDateUtc == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(s => s.ShareDateUtc != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(s => s.ShareDateUtc >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(s => s.ShareDateUtc > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(s => s.ShareDateUtc <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(s => s.ShareDateUtc < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ShareQuery WithShareDateUtcBetween(DateTime? from = null,
		                                          ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                          DateTime? to = null,
		                                          ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                          RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(s => s.ShareDateUtc >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(s => s.ShareDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(s => s.ShareDateUtc <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(s => s.ShareDateUtc == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(s => s.ShareDateUtc <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(s => s.ShareDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(s => s.ShareDateUtc >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(s => s.ShareDateUtc == to);
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