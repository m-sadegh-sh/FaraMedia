namespace FaraMedia.Services.Querying.Billing {
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.Billing;
	using FaraMedia.Core.Operators;

	public sealed class OrderStatusQuery : AttributeQueryBase<OrderStatus, OrderStatusQuery> {
		public OrderStatusQuery(IEnumerable<OrderStatus> entities) : base(entities) {}

		public OrderStatusQuery(IQueryable<OrderStatus> entities) : base(entities) {}

		public OrderStatusQuery WithOrder(Order value = null,
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
							Entities = Entities.Where(os => os.Orders.Any(o => o == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(os => os.Orders.All(o => o == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(os => os.Orders.Any(o => o != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(os => os.Orders.All(o => o != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public OrderStatusQuery WithOrderId(long? value = null,
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
							Entities = Entities.Where(os => os.Orders.Any(o => o.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(os => os.Orders.All(o => o.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(os => os.Orders.Any(o => o.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(os => os.Orders.All(o => o.Id != value));
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