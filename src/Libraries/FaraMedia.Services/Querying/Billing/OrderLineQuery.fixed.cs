namespace FaraMedia.Services.Querying.Billing {
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.Billing;
	using FaraMedia.Core.Domain.FileManagement;
	using FaraMedia.Core.Operators;

	public sealed class OrderLineQuery : EntityQueryBase<OrderLine, OrderLineQuery> {
		public OrderLineQuery(IEnumerable<OrderLine> entities) : base(entities) {}

		public OrderLineQuery(IQueryable<OrderLine> entities) : base(entities) {}

		public OrderLineQuery WithType(ItemType? value = null,
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
					Entities = Entities.Where(ol => ol.Type == value);
					return this;

				case EnumOperator.NotEqual:
					Entities = Entities.Where(ol => ol.Type != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public OrderLineQuery WithItemId(long? value = null,
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
					Entities = Entities.Where(ol => ol.ItemId == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(ol => ol.ItemId != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(ol => ol.ItemId >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(ol => ol.ItemId > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(ol => ol.ItemId <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(ol => ol.ItemId < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public OrderLineQuery WithItemIdBetween(long? from = null,
		                                        ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                        long? to = null,
		                                        ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                        RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(ol => ol.ItemId >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(ol => ol.ItemId == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(ol => ol.ItemId <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(ol => ol.ItemId == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(ol => ol.ItemId <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(ol => ol.ItemId == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(ol => ol.ItemId >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(ol => ol.ItemId == to);
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

		public OrderLineQuery WithItemTitle(string value = null,
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
							Entities = Entities.Where(ol => ol.ItemTitle == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(ol => ol.ItemTitle.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(ol => value.Contains(ol.ItemTitle));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(ol => ol.ItemTitle.Contains(value) || value.Contains(ol.ItemTitle));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(ol => ol.ItemTitle.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(ol => value.StartsWith(ol.ItemTitle));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(ol => ol.ItemTitle.StartsWith(value) || value.StartsWith(ol.ItemTitle));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(ol => ol.ItemTitle.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(ol => value.EndsWith(ol.ItemTitle));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(ol => ol.ItemTitle.EndsWith(value) || value.EndsWith(ol.ItemTitle));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public OrderLineQuery WithQuantity(int? value = null,
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
					Entities = Entities.Where(ol => ol.Quantity == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(ol => ol.Quantity != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(ol => ol.Quantity >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(ol => ol.Quantity > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(ol => ol.Quantity <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(ol => ol.Quantity < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public OrderLineQuery WithQuantityBetween(int? from = null,
		                                          ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                          int? to = null,
		                                          ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                          RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(ol => ol.Quantity >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(ol => ol.Quantity == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(ol => ol.Quantity <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(ol => ol.Quantity == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(ol => ol.Quantity <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(ol => ol.Quantity == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(ol => ol.Quantity >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(ol => ol.Quantity == to);
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

		public OrderLineQuery WithDiscount(int? value = null,
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
					Entities = Entities.Where(ol => ol.Discount == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(ol => ol.Discount != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(ol => ol.Discount >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(ol => ol.Discount > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(ol => ol.Discount <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(ol => ol.Discount < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public OrderLineQuery WithDiscountBetween(int? from = null,
		                                          ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                          int? to = null,
		                                          ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                          RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(ol => ol.Discount >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(ol => ol.Discount == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(ol => ol.Discount <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(ol => ol.Discount == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(ol => ol.Discount <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(ol => ol.Discount == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(ol => ol.Discount >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(ol => ol.Discount == to);
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

		public OrderLineQuery WithPrice(int? value = null,
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
					Entities = Entities.Where(ol => ol.Price == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(ol => ol.Price != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(ol => ol.Price >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(ol => ol.Price > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(ol => ol.Price <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(ol => ol.Price < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public OrderLineQuery WithPriceBetween(int? from = null,
		                                       ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                       int? to = null,
		                                       ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                       RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(ol => ol.Price >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(ol => ol.Price == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(ol => ol.Price <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(ol => ol.Price == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(ol => ol.Price <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(ol => ol.Price == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(ol => ol.Price >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(ol => ol.Price == to);
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

		public OrderLineQuery WithOrder(Order value = null,
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
					Entities = Entities.Where(ol => ol.Order == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(ol => ol.Order != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public OrderLineQuery WithOrderId(long? value = null,
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
					Entities = Entities.Where(ol => ol.Order.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(ol => ol.Order.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(ol => ol.Order.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(ol => ol.Order.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(ol => ol.Order.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(ol => ol.Order.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public OrderLineQuery WithOrderIdBetween(long? from = null,
		                                         ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                         long? to = null,
		                                         ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                         RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(ol => ol.Order.Id >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(ol => ol.Order.Id == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(ol => ol.Order.Id <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(ol => ol.Order.Id == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(ol => ol.Order.Id <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(ol => ol.Order.Id == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(ol => ol.Order.Id >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(ol => ol.Order.Id == to);
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

		public OrderLineQuery WithDownload(Download value = null,
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
					Entities = Entities.Where(ol => ol.Download == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(ol => ol.Download != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public OrderLineQuery WithDownloadId(long? value = null,
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
					Entities = Entities.Where(ol => ol.Order.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(ol => ol.Order.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(ol => ol.Order.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(ol => ol.Order.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(ol => ol.Order.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(ol => ol.Order.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public OrderLineQuery WithDownloadIdBetween(long? from = null,
		                                            ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                            long? to = null,
		                                            ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                            RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(ol => ol.Download.Id >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(ol => ol.Download.Id == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(ol => ol.Download.Id <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(ol => ol.Download.Id == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(ol => ol.Download.Id <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(ol => ol.Download.Id == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(ol => ol.Download.Id >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(ol => ol.Download.Id == to);
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

		public OrderLineQuery WithAccessTries(short? value = null,
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
					Entities = Entities.Where(ol => ol.AccessTries == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(ol => ol.AccessTries != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(ol => ol.AccessTries >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(ol => ol.AccessTries > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(ol => ol.AccessTries <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(ol => ol.AccessTries < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public OrderLineQuery WithAccessTriesBetween(short? from = null,
		                                             ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                             short? to = null,
		                                             ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                             RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(ol => ol.AccessTries >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(ol => ol.AccessTries == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(ol => ol.AccessTries <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(ol => ol.AccessTries == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(ol => ol.AccessTries <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(ol => ol.AccessTries == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(ol => ol.AccessTries >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(ol => ol.AccessTries == to);
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