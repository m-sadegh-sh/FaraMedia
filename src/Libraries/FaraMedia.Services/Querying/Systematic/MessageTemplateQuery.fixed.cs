namespace FaraMedia.Services.Querying.Systematic {
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.Systematic;
	using FaraMedia.Core.Operators;

	public sealed class MessageTemplateQuery : EntityQueryBase<MessageTemplate, MessageTemplateQuery> {
		public MessageTemplateQuery(IEnumerable<MessageTemplate> entities) : base(entities) {}

		public MessageTemplateQuery(IQueryable<MessageTemplate> entities) : base(entities) {}

		public MessageTemplateQuery WithBccEmailAddresses(string value = null,
		                                                  ArgumentEvaluationMode mode = ArgumentEvaluationMode.IgnoreNeutral,
		                                                  CollectionOperator @operator = CollectionOperator.Equal,
		                                                  CollectionDirection direction = CollectionDirection.Any) {
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
				case CollectionOperator.Equal:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(mt => mt.BccEmailAddresses.Any(bea => bea == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(mt => mt.BccEmailAddresses.All(bea => bea == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(mt => mt.BccEmailAddresses.Any(bea => bea != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(mt => mt.BccEmailAddresses.All(bea => bea != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public MessageTemplateQuery WithSubject(string value = null,
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
							Entities = Entities.Where(mt => mt.Subject == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(mt => mt.Subject.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(mt => value.Contains(mt.Subject));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(mt => mt.Subject.Contains(value) || value.Contains(mt.Subject));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(mt => mt.Subject.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(mt => value.StartsWith(mt.Subject));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(mt => mt.Subject.StartsWith(value) || value.StartsWith(mt.Subject));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(mt => mt.Subject.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(mt => value.EndsWith(mt.Subject));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(mt => mt.Subject.EndsWith(value) || value.EndsWith(mt.Subject));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public MessageTemplateQuery WithBody(string value = null,
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
							Entities = Entities.Where(mt => mt.Body == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(mt => mt.Body.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(mt => value.Contains(mt.Body));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(mt => mt.Body.Contains(value) || value.Contains(mt.Body));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(mt => mt.Body.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(mt => value.StartsWith(mt.Body));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(mt => mt.Body.StartsWith(value) || value.StartsWith(mt.Body));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(mt => mt.Body.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(mt => value.EndsWith(mt.Body));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(mt => mt.Body.EndsWith(value) || value.EndsWith(mt.Body));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public MessageTemplateQuery WithAccount(EmailAccount value = null,
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
					Entities = Entities.Where(mt => mt.Account == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(mt => mt.Account != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public MessageTemplateQuery WithAccountId(long? value = null,
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
					Entities = Entities.Where(mt => mt.Account.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(mt => mt.Account.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(mt => mt.Account.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(mt => mt.Account.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(mt => mt.Account.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(mt => mt.Account.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public MessageTemplateQuery WithAccountIdBetween(long? from = null,
		                                                 ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                                 long? to = null,
		                                                 ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                                 RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(mt => mt.Account.Id >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(mt => mt.Account.Id == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(mt => mt.Account.Id <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(mt => mt.Account.Id == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(mt => mt.Account.Id <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(mt => mt.Account.Id == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(mt => mt.Account.Id >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(mt => mt.Account.Id == to);
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