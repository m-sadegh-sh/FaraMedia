namespace FaraMedia.Services.Querying.Misc {
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.Misc;
	using FaraMedia.Core.Operators;

	public sealed class TicketDepartmentQuery : AttributeQueryBase<TicketDepartment, TicketDepartmentQuery> {
		public TicketDepartmentQuery(IEnumerable<TicketDepartment> entities) : base(entities) {}

		public TicketDepartmentQuery(IQueryable<TicketDepartment> entities) : base(entities) {}

		public TicketDepartmentQuery WithTicket(Ticket value = null,
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
							Entities = Entities.Where(td => td.Tickets.Any(t => t == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(td => td.Tickets.All(t => t == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(td => td.Tickets.Any(t => t != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(td => td.Tickets.All(t => t != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TicketDepartmentQuery WithTicketId(long? value = null,
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
							Entities = Entities.Where(td => td.Tickets.Any(t => t.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(td => td.Tickets.All(t => t.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(td => td.Tickets.Any(t => t.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(td => td.Tickets.All(t => t.Id != value));
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