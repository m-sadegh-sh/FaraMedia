namespace FaraMedia.Services.Querying.Systematic {
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain;
	using FaraMedia.Core.Domain.Systematic;
	using FaraMedia.Core.Operators;

	public sealed class QueuedEmailQuery : EntityQueryBase<QueuedEmail, QueuedEmailQuery> {
		public QueuedEmailQuery(IEnumerable<QueuedEmail> entities) : base(entities) {}

		public QueuedEmailQuery(IQueryable<QueuedEmail> entities) : base(entities) {}

		public QueuedEmailQuery WithFrom(string value = null,
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
							Entities = Entities.Where(qe => qe.From == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(qe => qe.From.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(qe => value.Contains(qe.From));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(qe => qe.From.Contains(value) || value.Contains(qe.From));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(qe => qe.From.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(qe => value.StartsWith(qe.From));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(qe => qe.From.StartsWith(value) || value.StartsWith(qe.From));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(qe => qe.From.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(qe => value.EndsWith(qe.From));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(qe => qe.From.EndsWith(value) || value.EndsWith(qe.From));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public QueuedEmailQuery WithFromName(string value = null,
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
							Entities = Entities.Where(qe => qe.FromName == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(qe => qe.FromName.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(qe => value.Contains(qe.FromName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(qe => qe.FromName.Contains(value) || value.Contains(qe.FromName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(qe => qe.FromName.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(qe => value.StartsWith(qe.FromName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(qe => qe.FromName.StartsWith(value) || value.StartsWith(qe.FromName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(qe => qe.FromName.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(qe => value.EndsWith(qe.FromName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(qe => qe.FromName.EndsWith(value) || value.EndsWith(qe.FromName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public QueuedEmailQuery WithTo(string value = null,
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
							Entities = Entities.Where(qe => qe.To == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(qe => qe.To.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(qe => value.Contains(qe.To));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(qe => qe.To.Contains(value) || value.Contains(qe.To));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(qe => qe.To.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(qe => value.StartsWith(qe.To));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(qe => qe.To.StartsWith(value) || value.StartsWith(qe.To));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(qe => qe.To.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(qe => value.EndsWith(qe.To));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(qe => qe.To.EndsWith(value) || value.EndsWith(qe.To));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public QueuedEmailQuery WithToName(string value = null,
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
							Entities = Entities.Where(qe => qe.ToName == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(qe => qe.ToName.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(qe => value.Contains(qe.ToName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(qe => qe.ToName.Contains(value) || value.Contains(qe.ToName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(qe => qe.ToName.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(qe => value.StartsWith(qe.ToName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(qe => qe.ToName.StartsWith(value) || value.StartsWith(qe.ToName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(qe => qe.ToName.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(qe => value.EndsWith(qe.ToName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(qe => qe.ToName.EndsWith(value) || value.EndsWith(qe.ToName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public QueuedEmailQuery WithCc(string value = null,
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
							Entities = Entities.Where(qe => qe.Cc.Any(cc => cc == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(qe => qe.Cc.All(cc => cc == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(qe => qe.Cc.Any(cc => cc != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(qe => qe.Cc.All(cc => cc != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public QueuedEmailQuery WithBcc(string value = null,
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
							Entities = Entities.Where(qe => qe.Bcc.Any(bcc => bcc == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(qe => qe.Bcc.All(bcc => bcc == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(qe => qe.Bcc.Any(bcc => bcc != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(qe => qe.Bcc.All(bcc => bcc != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public QueuedEmailQuery WithSubject(string value = null,
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
							Entities = Entities.Where(qe => qe.Subject == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(qe => qe.Subject.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(qe => value.Contains(qe.Subject));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(qe => qe.Subject.Contains(value) || value.Contains(qe.Subject));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(qe => qe.Subject.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(qe => value.StartsWith(qe.Subject));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(qe => qe.Subject.StartsWith(value) || value.StartsWith(qe.Subject));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(qe => qe.Subject.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(qe => value.EndsWith(qe.Subject));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(qe => qe.Subject.EndsWith(value) || value.EndsWith(qe.Subject));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public QueuedEmailQuery WithBody(string value = null,
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
							Entities = Entities.Where(qe => qe.Body == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(qe => qe.Body.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(qe => value.Contains(qe.Body));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(qe => qe.Body.Contains(value) || value.Contains(qe.Body));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(qe => qe.Body.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(qe => value.StartsWith(qe.Body));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(qe => qe.Body.StartsWith(value) || value.StartsWith(qe.Body));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(qe => qe.Body.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(qe => value.EndsWith(qe.Body));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(qe => qe.Body.EndsWith(value) || value.EndsWith(qe.Body));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public QueuedEmailQuery WithSendPriority(Priority? value = null,
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
					Entities = Entities.Where(qe => qe.SendPriority == value);
					return this;

				case EnumOperator.NotEqual:
					Entities = Entities.Where(qe => qe.SendPriority != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public QueuedEmailQuery WithSendingTries(int? value = null,
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
					Entities = Entities.Where(qe => qe.SendingTries == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(qe => qe.SendingTries != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(qe => qe.SendingTries >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(qe => qe.SendingTries > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(qe => qe.SendingTries <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(qe => qe.SendingTries < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public QueuedEmailQuery WithSendingTriesBetween(int? from = null,
		                                                ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                                int? to = null,
		                                                ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                                RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(qe => qe.SendingTries >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(qe => qe.SendingTries == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(qe => qe.SendingTries <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(qe => qe.SendingTries == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(qe => qe.SendingTries <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(qe => qe.SendingTries == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(qe => qe.SendingTries >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(qe => qe.SendingTries == to);
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

		public QueuedEmailQuery WithSentDateUtc(DateTime? value = null,
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
					Entities = Entities.Where(qe => qe.SentDateUtc == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(qe => qe.SentDateUtc != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(qe => qe.SentDateUtc >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(qe => qe.SentDateUtc > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(qe => qe.SentDateUtc <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(qe => qe.SentDateUtc < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public QueuedEmailQuery WithSentDateUtcBetween(DateTime? from = null,
		                                               ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                               DateTime? to = null,
		                                               ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                               RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(qe => qe.SentDateUtc >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(qe => qe.SentDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(qe => qe.SentDateUtc <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(qe => qe.SentDateUtc == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(qe => qe.SentDateUtc <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(qe => qe.SentDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(qe => qe.SentDateUtc >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(qe => qe.SentDateUtc == to);
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

		public QueuedEmailQuery WithAccount(EmailAccount value = null,
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
					Entities = Entities.Where(qe => qe.Account == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(qe => qe.Account != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public QueuedEmailQuery WithAccountId(long? value = null,
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
					Entities = Entities.Where(qe => qe.Account.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(qe => qe.Account.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(qe => qe.Account.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(qe => qe.Account.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(qe => qe.Account.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(qe => qe.Account.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public QueuedEmailQuery WithAccountIdBetween(long? from = null,
		                                             ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                             long? to = null,
		                                             ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                             RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(qe => qe.Account.Id >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(qe => qe.Account.Id == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(qe => qe.Account.Id <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(qe => qe.Account.Id == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(qe => qe.Account.Id <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(qe => qe.Account.Id == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(qe => qe.Account.Id >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(qe => qe.Account.Id == to);
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