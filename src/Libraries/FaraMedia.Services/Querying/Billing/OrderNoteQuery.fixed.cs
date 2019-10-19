namespace FaraMedia.Services.Querying.Billing {
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.Billing;
	using FaraMedia.Core.Operators;

	public sealed class OrderNoteQuery : EntityQueryBase<OrderNote, OrderNoteQuery> {
		public OrderNoteQuery(IEnumerable<OrderNote> entities) : base(entities) {}

		public OrderNoteQuery(IQueryable<OrderNote> entities) : base(entities) {}

		public OrderNoteQuery WithNote(string value = null,
		                               ArgumentEvaluationMode mode = ArgumentEvaluationMode.IgnoreNeutral,
		                               StringOperator @operator = StringOperator.Exact,
		                               StringDirection direction = StringDirection.SourceToExpected) {
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
				case StringOperator.Exact:
					switch (direction) {
						case StringDirection.SourceToExpected:
						case StringDirection.ExpectedToSource:
						case StringDirection.TwoWay:
							Entities = Entities.Where(on => on.Note == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(on => on.Note.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(on => value.Contains(on.Note));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(on => on.Note.Contains(value) || value.Contains(on.Note));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(on => on.Note.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(on => value.StartsWith(on.Note));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(on => on.Note.StartsWith(value) || value.StartsWith(on.Note));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(on => on.Note.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(on => value.EndsWith(on.Note));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(on => on.Note.EndsWith(value) || value.EndsWith(on.Note));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public OrderNoteQuery WithIsPublic(bool? value = null,
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
					Entities = Entities.Where(on => on.IsPublic == value);
					return this;

				case BoolOperator.NotEqual:
					Entities = Entities.Where(on => on.IsPublic != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public OrderNoteQuery WithOrder(Order value = null,
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
					Entities = Entities.Where(on => on.Order == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(on => on.Order != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public OrderNoteQuery WithOrderId(long? value = null,
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
					Entities = Entities.Where(on => on.Order.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(on => on.Order.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(on => on.Order.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(on => on.Order.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(on => on.Order.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(on => on.Order.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public OrderNoteQuery WithOrderIdBetween(long? from = null,
		                                         ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                         long? to = null,
		                                         ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                         RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(on => on.Order.Id >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(on => on.Order.Id == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(on => on.Order.Id <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(on => on.Order.Id == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(on => on.Order.Id <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(on => on.Order.Id == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(on => on.Order.Id >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(on => on.Order.Id == to);
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