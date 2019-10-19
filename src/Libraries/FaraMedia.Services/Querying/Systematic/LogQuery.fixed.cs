namespace FaraMedia.Services.Querying.Systematic {
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.Security;
	using FaraMedia.Core.Domain.Systematic;
	using FaraMedia.Core.Operators;

	public sealed class LogQuery : EntityQueryBase<Log, LogQuery> {
		public LogQuery(IEnumerable<Log> entities) : base(entities) {}

		public LogQuery(IQueryable<Log> entities) : base(entities) {}

		public LogQuery WithShortMessage(string value = null,
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
							Entities = Entities.Where(l => l.ShortMessage == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(l => l.ShortMessage.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(l => value.Contains(l.ShortMessage));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(l => l.ShortMessage.Contains(value) || value.Contains(l.ShortMessage));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(l => l.ShortMessage.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(l => value.StartsWith(l.ShortMessage));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(l => l.ShortMessage.StartsWith(value) || value.StartsWith(l.ShortMessage));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(l => l.ShortMessage.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(l => value.EndsWith(l.ShortMessage));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(l => l.ShortMessage.EndsWith(value) || value.EndsWith(l.ShortMessage));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public LogQuery WithFullMessage(string value = null,
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
							Entities = Entities.Where(l => l.FullMessage == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(l => l.FullMessage.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(l => value.Contains(l.FullMessage));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(l => l.FullMessage.Contains(value) || value.Contains(l.FullMessage));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(l => l.FullMessage.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(l => value.StartsWith(l.FullMessage));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(l => l.FullMessage.StartsWith(value) || value.StartsWith(l.FullMessage));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(l => l.FullMessage.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(l => value.EndsWith(l.FullMessage));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(l => l.FullMessage.EndsWith(value) || value.EndsWith(l.FullMessage));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public LogQuery WithRequestedUrl(string value = null,
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
							Entities = Entities.Where(l => l.RequestedUrl == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(l => l.RequestedUrl.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(l => value.Contains(l.RequestedUrl));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(l => l.RequestedUrl.Contains(value) || value.Contains(l.RequestedUrl));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(l => l.RequestedUrl.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(l => value.StartsWith(l.RequestedUrl));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(l => l.RequestedUrl.StartsWith(value) || value.StartsWith(l.RequestedUrl));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(l => l.RequestedUrl.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(l => value.EndsWith(l.RequestedUrl));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(l => l.RequestedUrl.EndsWith(value) || value.EndsWith(l.RequestedUrl));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public LogQuery WithReferrerUrl(string value = null,
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
							Entities = Entities.Where(l => l.ReferrerUrl == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(l => l.ReferrerUrl.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(l => value.Contains(l.ReferrerUrl));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(l => l.ReferrerUrl.Contains(value) || value.Contains(l.ReferrerUrl));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(l => l.ReferrerUrl.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(l => value.StartsWith(l.ReferrerUrl));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(l => l.ReferrerUrl.StartsWith(value) || value.StartsWith(l.ReferrerUrl));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(l => l.ReferrerUrl.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(l => value.EndsWith(l.ReferrerUrl));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(l => l.ReferrerUrl.EndsWith(value) || value.EndsWith(l.ReferrerUrl));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public LogQuery WithLevel(LogLevel? value = null,
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
					Entities = Entities.Where(l => l.Level == value);
					return this;

				case EnumOperator.NotEqual:
					Entities = Entities.Where(l => l.Level != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public LogQuery WithLogDateUtc(DateTime? value = null,
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
					Entities = Entities.Where(l => l.LogDateUtc == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(l => l.LogDateUtc != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(l => l.LogDateUtc >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(l => l.LogDateUtc > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(l => l.LogDateUtc <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(l => l.LogDateUtc < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public LogQuery WithLogDateUtcBetween(DateTime? from = null,
		                                      ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                      DateTime? to = null,
		                                      ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                      RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(l => l.LogDateUtc >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(l => l.LogDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(l => l.LogDateUtc <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(l => l.LogDateUtc == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(l => l.LogDateUtc <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(l => l.LogDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(l => l.LogDateUtc >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(l => l.LogDateUtc == to);
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

		public LogQuery WithInvoker(User value = null,
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
					Entities = Entities.Where(l => l.Invoker == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(l => l.Invoker != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public LogQuery WithInvokerId(long? value = null,
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
					Entities = Entities.Where(l => l.Invoker.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(l => l.Invoker.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(l => l.Invoker.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(l => l.Invoker.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(l => l.Invoker.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(l => l.Invoker.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public LogQuery WithInvokerIdBetween(long? from = null,
		                                     ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                     long? to = null,
		                                     ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                     RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(l => l.Invoker.Id >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(l => l.Invoker.Id == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(l => l.Invoker.Id <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(l => l.Invoker.Id == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(l => l.Invoker.Id <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(l => l.Invoker.Id == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(l => l.Invoker.Id >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(l => l.Invoker.Id == to);
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

		public LogQuery WithInvokerIp(string value = null,
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
							Entities = Entities.Where(l => l.InvokerIp == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(l => l.InvokerIp.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(l => value.Contains(l.InvokerIp));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(l => l.InvokerIp.Contains(value) || value.Contains(l.InvokerIp));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(l => l.InvokerIp.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(l => value.StartsWith(l.InvokerIp));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(l => l.InvokerIp.StartsWith(value) || value.StartsWith(l.InvokerIp));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(l => l.InvokerIp.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(l => value.EndsWith(l.InvokerIp));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(l => l.InvokerIp.EndsWith(value) || value.EndsWith(l.InvokerIp));
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