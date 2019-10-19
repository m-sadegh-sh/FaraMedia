namespace FaraMedia.Services.Querying.Misc {
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.Misc;
	using FaraMedia.Core.Operators;

	public sealed class TicketStatusQuery : AttributeQueryBase<TicketStatus, TicketStatusQuery> {
		public TicketStatusQuery(IEnumerable<TicketStatus> entities) : base(entities) {}

		public TicketStatusQuery(IQueryable<TicketStatus> entities) : base(entities) {}

		public TicketStatusQuery WithTicket(Ticket value = null,
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
							Entities = Entities.Where(ts => ts.Tickets.Any(t => t == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(ts => ts.Tickets.All(t => t == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(ts => ts.Tickets.Any(t => t != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(ts => ts.Tickets.All(t => t != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TicketStatusQuery WithTicketId(long? value = null,
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
					Entities = Entities.Where(ts => ts.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(ts => ts.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(ts => ts.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(ts => ts.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(ts => ts.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(ts => ts.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}
	}
}