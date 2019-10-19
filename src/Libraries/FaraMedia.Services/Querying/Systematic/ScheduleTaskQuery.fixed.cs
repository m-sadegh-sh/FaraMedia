namespace FaraMedia.Services.Querying.Systematic {
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain;
	using FaraMedia.Core.Domain.Systematic;
	using FaraMedia.Core.Operators;

	public sealed class ScheduleTaskQuery : AttributeQueryBase<ScheduleTask, ScheduleTaskQuery> {
		public ScheduleTaskQuery(IEnumerable<ScheduleTask> entities) : base(entities) {}

		public ScheduleTaskQuery(IQueryable<ScheduleTask> entities) : base(entities) {}

		public ScheduleTaskQuery WithTypeName(string value = null,
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
							Entities = Entities.Where(st => st.TypeName == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(st => st.TypeName.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(st => value.Contains(st.TypeName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(st => st.TypeName.Contains(value) || value.Contains(st.TypeName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(st => st.TypeName.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(st => value.StartsWith(st.TypeName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(st => st.TypeName.StartsWith(value) || value.StartsWith(st.TypeName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(st => st.TypeName.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(st => value.EndsWith(st.TypeName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(st => st.TypeName.EndsWith(value) || value.EndsWith(st.TypeName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ScheduleTaskQuery WithIsActive(bool? value = null,
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
					Entities = Entities.Where(st => st.IsActive == value);
					return this;

				case BoolOperator.NotEqual:
					Entities = Entities.Where(st => st.IsActive != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ScheduleTaskQuery WithExecutionPriority(Priority? value = null,
		                                               ArgumentEvaluationMode mode = ArgumentEvaluationMode.IgnoreNeutral,
		                                               EnumOperator @operator = EnumOperator.Equal) {
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
				case EnumOperator.Equal:
					Entities = Entities.Where(st => st.ExecutionPriority == value);
					return this;

				case EnumOperator.NotEqual:
					Entities = Entities.Where(st => st.ExecutionPriority != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ScheduleTaskQuery WithStopOnError(bool? value = null,
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
					Entities = Entities.Where(st => st.StopOnError == value);
					return this;

				case BoolOperator.NotEqual:
					Entities = Entities.Where(st => st.StopOnError != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ScheduleTaskQuery WithMaximumRunningSeconds(int? value = null,
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
					Entities = Entities.Where(st => st.MaximumRunningSeconds == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(st => st.MaximumRunningSeconds != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(st => st.MaximumRunningSeconds >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(st => st.MaximumRunningSeconds > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(st => st.MaximumRunningSeconds <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(st => st.MaximumRunningSeconds < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ScheduleTaskQuery WithMaximumRunningSecondsBetween(int? from = null,
		                                                          ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                                          int? to = null,
		                                                          ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                                          RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(st => st.MaximumRunningSeconds >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(st => st.MaximumRunningSeconds == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(st => st.MaximumRunningSeconds <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(st => st.MaximumRunningSeconds == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(st => st.MaximumRunningSeconds <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(st => st.MaximumRunningSeconds == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(st => st.MaximumRunningSeconds >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(st => st.MaximumRunningSeconds == to);
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