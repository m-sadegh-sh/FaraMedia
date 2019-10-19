namespace FaraMedia.Services.Querying.Security {
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.Security;
	using FaraMedia.Core.Operators;

	public sealed class FriendRequestQuery : EntityQueryBase<FriendRequest, FriendRequestQuery> {
		public FriendRequestQuery(IEnumerable<FriendRequest> entities) : base(entities) {}

		public FriendRequestQuery(IQueryable<FriendRequest> entities) : base(entities) {}

		public FriendRequestQuery WithFrom(User value = null,
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
					Entities = Entities.Where(fr => fr.From == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(fr => fr.From != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public FriendRequestQuery WithFromId(long? value = null,
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
					Entities = Entities.Where(fr => fr.From.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(fr => fr.From.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(fr => fr.From.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(fr => fr.From.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(fr => fr.From.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(fr => fr.From.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public FriendRequestQuery WithTo(User value = null,
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
					Entities = Entities.Where(fr => fr.To == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(fr => fr.To != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public FriendRequestQuery WithToId(long? value = null,
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
					Entities = Entities.Where(fr => fr.To.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(fr => fr.To.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(fr => fr.To.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(fr => fr.To.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(fr => fr.To.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(fr => fr.To.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public FriendRequestQuery WithSentDateUtc(DateTime? value = null,
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
					Entities = Entities.Where(fr => fr.SentDateUtc == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(fr => fr.SentDateUtc != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(fr => fr.SentDateUtc >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(fr => fr.SentDateUtc > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(fr => fr.SentDateUtc <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(fr => fr.SentDateUtc < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public FriendRequestQuery WithSentDateUtcBetween(DateTime? from = null,
		                                                 ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                                 DateTime? to = null,
		                                                 ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                                 RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(fr => fr.SentDateUtc >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(fr => fr.SentDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(fr => fr.SentDateUtc <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(fr => fr.SentDateUtc == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(fr => fr.SentDateUtc <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(fr => fr.SentDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(fr => fr.SentDateUtc >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(fr => fr.SentDateUtc == to);
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

		public FriendRequestQuery WithAccepted(bool? value = null,
		                                       ArgumentEvaluationMode mode = ArgumentEvaluationMode.IgnoreNeutral,
		                                       BoolOperator @operator = BoolOperator.Equal) {
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
				case BoolOperator.Equal:
					Entities = Entities.Where(fr => fr.Accepted == value);
					return this;

				case BoolOperator.NotEqual:
					Entities = Entities.Where(fr => fr.Accepted != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public FriendRequestQuery WithAcceptanceDateUtc(DateTime? value = null,
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
					Entities = Entities.Where(fr => fr.AcceptanceDateUtc == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(fr => fr.AcceptanceDateUtc != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(fr => fr.AcceptanceDateUtc >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(fr => fr.AcceptanceDateUtc > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(fr => fr.AcceptanceDateUtc <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(fr => fr.AcceptanceDateUtc < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public FriendRequestQuery WithAcceptanceDateUtcBetween(DateTime? from = null,
		                                                       ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                                       DateTime? to = null,
		                                                       ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                                       RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(fr => fr.AcceptanceDateUtc >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(fr => fr.AcceptanceDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(fr => fr.AcceptanceDateUtc <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(fr => fr.AcceptanceDateUtc == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(fr => fr.AcceptanceDateUtc <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(fr => fr.AcceptanceDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(fr => fr.AcceptanceDateUtc >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(fr => fr.AcceptanceDateUtc == to);
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

		public FriendRequestQuery WithBlockSubsequentRequests(bool? value = null,
		                                                      ArgumentEvaluationMode mode = ArgumentEvaluationMode.IgnoreNeutral,
		                                                      BoolOperator @operator = BoolOperator.Equal) {
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
				case BoolOperator.Equal:
					Entities = Entities.Where(fr => fr.BlockSubsequentRequests == value);
					return this;

				case BoolOperator.NotEqual:
					Entities = Entities.Where(fr => fr.BlockSubsequentRequests != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}
	}
}