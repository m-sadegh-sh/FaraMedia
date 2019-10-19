namespace FaraMedia.Services.Querying.Systematic {
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.Systematic;
	using FaraMedia.Core.Operators;

	public sealed class EmailAccountQuery : AttributeQueryBase<EmailAccount, EmailAccountQuery> {
		public EmailAccountQuery(IEnumerable<EmailAccount> entities) : base(entities) {}

		public EmailAccountQuery(IQueryable<EmailAccount> entities) : base(entities) {}

		public EmailAccountQuery WithEmail(string value = null,
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
							Entities = Entities.Where(ea => ea.Email == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(ea => ea.Email.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(ea => value.Contains(ea.Email));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(ea => ea.Email.Contains(value) || value.Contains(ea.Email));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(ea => ea.Email.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(ea => value.StartsWith(ea.Email));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(ea => ea.Email.StartsWith(value) || value.StartsWith(ea.Email));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(ea => ea.Email.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(ea => value.EndsWith(ea.Email));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(ea => ea.Email.EndsWith(value) || value.EndsWith(ea.Email));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public EmailAccountQuery WithUserName(string value = null,
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
							Entities = Entities.Where(ea => ea.UserName == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(ea => ea.UserName.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(ea => value.Contains(ea.UserName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(ea => ea.UserName.Contains(value) || value.Contains(ea.UserName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(ea => ea.UserName.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(ea => value.StartsWith(ea.UserName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(ea => ea.UserName.StartsWith(value) || value.StartsWith(ea.UserName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(ea => ea.UserName.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(ea => value.EndsWith(ea.UserName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(ea => ea.UserName.EndsWith(value) || value.EndsWith(ea.UserName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public EmailAccountQuery WithPassword(string value = null,
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
							Entities = Entities.Where(ea => ea.Password == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(ea => ea.Password.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(ea => value.Contains(ea.Password));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(ea => ea.Password.Contains(value) || value.Contains(ea.Password));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(ea => ea.Password.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(ea => value.StartsWith(ea.Password));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(ea => ea.Password.StartsWith(value) || value.StartsWith(ea.Password));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(ea => ea.Password.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(ea => value.EndsWith(ea.Password));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(ea => ea.Password.EndsWith(value) || value.EndsWith(ea.Password));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public EmailAccountQuery WithHost(string value = null,
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
							Entities = Entities.Where(ea => ea.Host == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(ea => ea.Host.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(ea => value.Contains(ea.Host));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(ea => ea.Host.Contains(value) || value.Contains(ea.Host));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(ea => ea.Host.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(ea => value.StartsWith(ea.Host));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(ea => ea.Host.StartsWith(value) || value.StartsWith(ea.Host));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(ea => ea.Host.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(ea => value.EndsWith(ea.Host));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(ea => ea.Host.EndsWith(value) || value.EndsWith(ea.Host));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public EmailAccountQuery WithPort(int? value = null,
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
					Entities = Entities.Where(ea => ea.Port == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(ea => ea.Port != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(ea => ea.Port >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(ea => ea.Port > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(ea => ea.Port <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(ea => ea.Port < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public EmailAccountQuery WithPortBetween(int? from = null,
		                                         ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                         int? to = null,
		                                         ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                         RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(ea => ea.Port >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(ea => ea.Port == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(ea => ea.Port <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(ea => ea.Port == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(ea => ea.Port <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(ea => ea.Port == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(ea => ea.Port >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(ea => ea.Port == to);
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

		public EmailAccountQuery WithSslEnabled(bool? value = null,
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
					Entities = Entities.Where(ea => ea.SslEnabled == value);
					return this;

				case BoolOperator.NotEqual:
					Entities = Entities.Where(ea => ea.SslEnabled != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public EmailAccountQuery WithUseDefaultCredentials(bool? value = null,
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
					Entities = Entities.Where(ea => ea.UseDefaultCredentials == value);
					return this;

				case BoolOperator.NotEqual:
					Entities = Entities.Where(ea => ea.UseDefaultCredentials != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public EmailAccountQuery WithTemplate(MessageTemplate value = null,
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
							Entities = Entities.Where(ea => ea.Templates.Any(mt => mt == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(ea => ea.Templates.All(mt => mt == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(ea => ea.Templates.Any(mt => mt != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(ea => ea.Templates.All(mt => mt != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public EmailAccountQuery WithTemplateId(long? value = null,
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
							Entities = Entities.Where(ea => ea.Templates.Any(mt => mt.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(ea => ea.Templates.All(mt => mt.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(ea => ea.Templates.Any(mt => mt.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(ea => ea.Templates.All(mt => mt.Id != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public EmailAccountQuery WithEmail(QueuedEmail value = null,
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
							Entities = Entities.Where(ea => ea.Emails.Any(qe => qe == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(ea => ea.Emails.All(qe => qe == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(ea => ea.Emails.Any(qe => qe != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(ea => ea.Emails.All(qe => qe != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public EmailAccountQuery WithEmailId(long? value = null,
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
							Entities = Entities.Where(ea => ea.Emails.Any(qe => qe.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(ea => ea.Emails.All(qe => qe.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(ea => ea.Emails.Any(qe => qe.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(ea => ea.Emails.All(qe => qe.Id != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}
	}
}