namespace FaraMedia.Services.Querying.Billing {
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.Billing;
	using FaraMedia.Core.Operators;

	public sealed class TransactionRequestQuery : EntityQueryBase<TransactionRequest, TransactionRequestQuery> {
		public TransactionRequestQuery(IEnumerable<TransactionRequest> entities) : base(entities) {}

		public TransactionRequestQuery(IQueryable<TransactionRequest> entities) : base(entities) {}

		public TransactionRequestQuery WithOrder(Order value = null,
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
					Entities = Entities.Where(tr => tr.Order == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(tr => tr.Order != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TransactionRequestQuery WithOrderId(long? value = null,
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
					Entities = Entities.Where(tr => tr.Order.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(tr => tr.Order.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(tr => tr.Order.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(tr => tr.Order.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(tr => tr.Order.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(tr => tr.Order.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TransactionRequestQuery WithOrderIdBetween(long? from = null,
		                                                  ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                                  long? to = null,
		                                                  ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                                  RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(tr => tr.Order.Id >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(tr => tr.Order.Id == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(tr => tr.Order.Id <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(tr => tr.Order.Id == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(tr => tr.Order.Id <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(tr => tr.Order.Id == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(tr => tr.Order.Id >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(tr => tr.Order.Id == to);
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

		public TransactionRequestQuery WithRequestDateUtc(DateTime? value = null,
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
					Entities = Entities.Where(tr => tr.RequestDateUtc == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(tr => tr.RequestDateUtc != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(tr => tr.RequestDateUtc >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(tr => tr.RequestDateUtc > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(tr => tr.RequestDateUtc <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(tr => tr.RequestDateUtc < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TransactionRequestQuery WithRequestDateUtcBetween(DateTime? from = null,
		                                                         ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                                         DateTime? to = null,
		                                                         ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                                         RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(tr => tr.RequestDateUtc >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(tr => tr.RequestDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(tr => tr.RequestDateUtc <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(tr => tr.RequestDateUtc == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(tr => tr.RequestDateUtc <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(tr => tr.RequestDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(tr => tr.RequestDateUtc >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(tr => tr.RequestDateUtc == to);
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

		public TransactionRequestQuery WithMerchantId(string value = null,
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
							Entities = Entities.Where(tr => tr.MerchantId == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(tr => tr.MerchantId.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(tr => value.Contains(tr.MerchantId));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(tr => tr.MerchantId.Contains(value) || value.Contains(tr.MerchantId));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(tr => tr.MerchantId.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(tr => value.StartsWith(tr.MerchantId));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(tr => tr.MerchantId.StartsWith(value) || value.StartsWith(tr.MerchantId));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(tr => tr.MerchantId.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(tr => value.EndsWith(tr.MerchantId));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(tr => tr.MerchantId.EndsWith(value) || value.EndsWith(tr.MerchantId));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TransactionRequestQuery WithTransactionKey(string value = null,
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
							Entities = Entities.Where(tr => tr.TransactionKey == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(tr => tr.TransactionKey.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(tr => value.Contains(tr.TransactionKey));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(tr => tr.TransactionKey.Contains(value) || value.Contains(tr.TransactionKey));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(tr => tr.TransactionKey.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(tr => value.StartsWith(tr.TransactionKey));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(tr => tr.TransactionKey.StartsWith(value) || value.StartsWith(tr.TransactionKey));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(tr => tr.TransactionKey.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(tr => value.EndsWith(tr.TransactionKey));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(tr => tr.TransactionKey.EndsWith(value) || value.EndsWith(tr.TransactionKey));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TransactionRequestQuery WithComputedHash(string value = null,
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
							Entities = Entities.Where(tr => tr.ComputedHash == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(tr => tr.ComputedHash.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(tr => value.Contains(tr.ComputedHash));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(tr => tr.ComputedHash.Contains(value) || value.Contains(tr.ComputedHash));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(tr => tr.ComputedHash.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(tr => value.StartsWith(tr.ComputedHash));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(tr => tr.ComputedHash.StartsWith(value) || value.StartsWith(tr.ComputedHash));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(tr => tr.ComputedHash.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(tr => value.EndsWith(tr.ComputedHash));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(tr => tr.ComputedHash.EndsWith(value) || value.EndsWith(tr.ComputedHash));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TransactionRequestQuery WithStatus(TransactionRequestStatus? value = null,
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
					Entities = Entities.Where(tr => tr.Status == value);
					return this;

				case EnumOperator.NotEqual:
					Entities = Entities.Where(tr => tr.Status != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TransactionRequestQuery WithResponse(TransactionResponse value = null,
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
							Entities = Entities.Where(tr => tr.Responses.Any(tr2 => tr2 == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(tr => tr.Responses.All(tr2 => tr2 == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(tr => tr.Responses.Any(tr2 => tr2 != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(tr => tr.Responses.All(tr2 => tr2 != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TransactionRequestQuery WithResponseId(long? value = null,
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
							Entities = Entities.Where(tr => tr.Responses.Any(tr2 => tr2.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(tr => tr.Responses.All(tr2 => tr2.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(tr => tr.Responses.Any(tr2 => tr2.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(tr => tr.Responses.All(tr2 => tr2.Id != value));
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