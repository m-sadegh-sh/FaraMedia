namespace FaraMedia.Services.Querying.Misc {
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.Misc;
	using FaraMedia.Core.Domain.Security;
	using FaraMedia.Core.Operators;

	public sealed class ToDoQuery : EntityQueryBase<ToDo, ToDoQuery> {
		public ToDoQuery(IEnumerable<ToDo> entities) : base(entities) {}

		public ToDoQuery(IQueryable<ToDo> entities) : base(entities) {}

		public ToDoQuery WithTitle(string value = null,
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
							Entities = Entities.Where(td => td.Title == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(td => td.Title.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(td => value.Contains(td.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(td => td.Title.Contains(value) || value.Contains(td.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(td => td.Title.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(td => value.StartsWith(td.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(td => td.Title.StartsWith(value) || value.StartsWith(td.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(td => td.Title.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(td => value.EndsWith(td.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(td => td.Title.EndsWith(value) || value.EndsWith(td.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ToDoQuery WithDescription(string value = null,
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
							Entities = Entities.Where(td => td.Description == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(td => td.Description.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(td => value.Contains(td.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(td => td.Description.Contains(value) || value.Contains(td.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(td => td.Description.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(td => value.StartsWith(td.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(td => td.Description.StartsWith(value) || value.StartsWith(td.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(td => td.Description.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(td => value.EndsWith(td.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(td => td.Description.EndsWith(value) || value.EndsWith(td.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ToDoQuery WithPerformer(User value = null,
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
					Entities = Entities.Where(td => td.Performer == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(td => td.Performer != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ToDoQuery WithPerformerId(long? value = null,
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
					Entities = Entities.Where(td => td.Performer.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(td => td.Performer.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(td => td.Performer.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(td => td.Performer.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(td => td.Performer.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(td => td.Performer.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ToDoQuery WithStatus(ToDoStatus value = null,
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
					Entities = Entities.Where(td => td.Status == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(td => td.Status != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ToDoQuery WithStatusId(long? value = null,
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
					Entities = Entities.Where(td => td.Status.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(td => td.Status.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(td => td.Status.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(td => td.Status.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(td => td.Status.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(td => td.Status.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ToDoQuery WithDueDateUtc(DateTime? value = null,
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
					Entities = Entities.Where(td => td.DueDateUtc == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(td => td.DueDateUtc != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(td => td.DueDateUtc >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(td => td.DueDateUtc > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(td => td.DueDateUtc <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(td => td.DueDateUtc < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ToDoQuery WithDueDateUtcBetween(DateTime? from = null,
		                                       ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                       DateTime? to = null,
		                                       ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                       RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(td => td.DueDateUtc >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(td => td.DueDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(td => td.DueDateUtc <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(td => td.DueDateUtc == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(td => td.DueDateUtc <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(td => td.DueDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(td => td.DueDateUtc >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(td => td.DueDateUtc == to);
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