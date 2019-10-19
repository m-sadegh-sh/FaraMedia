namespace FaraMedia.Services.Querying.Billing {
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.Billing;
	using FaraMedia.Core.Operators;

	public sealed class TransactionResponseQuery : EntityQueryBase<TransactionResponse, TransactionResponseQuery> {
		public TransactionResponseQuery(IEnumerable<TransactionResponse> entities) : base(entities) {}

		public TransactionResponseQuery(IQueryable<TransactionResponse> entities) : base(entities) {}

		public TransactionResponseQuery WithRequest(TransactionRequest value = null,
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
					Entities = Entities.Where(tr => tr.Request == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(tr => tr.Request != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TransactionResponseQuery WithRequestId(long? value = null,
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
					Entities = Entities.Where(tr => tr.Request.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(tr => tr.Request.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(tr => tr.Request.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(tr => tr.Request.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(tr => tr.Request.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(tr => tr.Request.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TransactionResponseQuery WithRequestIdBetween(long? from = null,
		                                                     ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                                     long? to = null,
		                                                     ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                                     RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(tr => tr.Request.Id >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(tr => tr.Request.Id == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(tr => tr.Request.Id <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(tr => tr.Request.Id == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(tr => tr.Request.Id <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(tr => tr.Request.Id == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(tr => tr.Request.Id >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(tr => tr.Request.Id == to);
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

		public TransactionResponseQuery WithVerifyDateUtc(DateTime? value = null,
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
					Entities = Entities.Where(tr => tr.VerifyDateUtc == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(tr => tr.VerifyDateUtc != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(tr => tr.VerifyDateUtc >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(tr => tr.VerifyDateUtc > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(tr => tr.VerifyDateUtc <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(tr => tr.VerifyDateUtc < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TransactionResponseQuery WithVerifyDateUtcBetween(DateTime? from = null,
		                                                         ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                                         DateTime? to = null,
		                                                         ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                                         RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(tr => tr.VerifyDateUtc >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(tr => tr.VerifyDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(tr => tr.VerifyDateUtc <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(tr => tr.VerifyDateUtc == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(tr => tr.VerifyDateUtc <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(tr => tr.VerifyDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(tr => tr.VerifyDateUtc >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(tr => tr.VerifyDateUtc == to);
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

		public TransactionResponseQuery WithCode(string value = null,
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
							Entities = Entities.Where(tr => tr.Code == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(tr => tr.Code.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(tr => value.Contains(tr.Code));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(tr => tr.Code.Contains(value) || value.Contains(tr.Code));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(tr => tr.Code.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(tr => value.StartsWith(tr.Code));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(tr => tr.Code.StartsWith(value) || value.StartsWith(tr.Code));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(tr => tr.Code.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(tr => value.EndsWith(tr.Code));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(tr => tr.Code.EndsWith(value) || value.EndsWith(tr.Code));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TransactionResponseQuery WithSubCode(string value = null,
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
							Entities = Entities.Where(tr => tr.SubCode == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(tr => tr.SubCode.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(tr => value.Contains(tr.SubCode));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(tr => tr.SubCode.Contains(value) || value.Contains(tr.SubCode));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(tr => tr.SubCode.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(tr => value.StartsWith(tr.SubCode));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(tr => tr.SubCode.StartsWith(value) || value.StartsWith(tr.SubCode));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(tr => tr.SubCode.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(tr => value.EndsWith(tr.SubCode));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(tr => tr.SubCode.EndsWith(value) || value.EndsWith(tr.SubCode));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TransactionResponseQuery WithReasonCode(string value = null,
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
							Entities = Entities.Where(tr => tr.ReasonCode == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(tr => tr.ReasonCode.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(tr => value.Contains(tr.ReasonCode));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(tr => tr.ReasonCode.Contains(value) || value.Contains(tr.ReasonCode));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(tr => tr.ReasonCode.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(tr => value.StartsWith(tr.ReasonCode));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(tr => tr.ReasonCode.StartsWith(value) || value.StartsWith(tr.ReasonCode));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(tr => tr.ReasonCode.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(tr => value.EndsWith(tr.ReasonCode));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(tr => tr.ReasonCode.EndsWith(value) || value.EndsWith(tr.ReasonCode));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TransactionResponseQuery WithReasonDescription(string value = null,
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
							Entities = Entities.Where(tr => tr.ReasonDescription == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(tr => tr.ReasonDescription.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(tr => value.Contains(tr.ReasonDescription));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(tr => tr.ReasonDescription.Contains(value) || value.Contains(tr.ReasonDescription));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(tr => tr.ReasonDescription.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(tr => value.StartsWith(tr.ReasonDescription));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(tr => tr.ReasonDescription.StartsWith(value) || value.StartsWith(tr.ReasonDescription));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(tr => tr.ReasonDescription.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(tr => value.EndsWith(tr.ReasonDescription));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(tr => tr.ReasonDescription.EndsWith(value) || value.EndsWith(tr.ReasonDescription));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TransactionResponseQuery WithResult(TransactionResponseResult? value = null,
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
					Entities = Entities.Where(tr => tr.Result == value);
					return this;

				case EnumOperator.NotEqual:
					Entities = Entities.Where(tr => tr.Result != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}
	}
}