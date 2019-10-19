namespace FaraMedia.Services.Querying.Misc {
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.Misc;
	using FaraMedia.Core.Operators;

	public sealed class ToDoStatusQuery : AttributeQueryBase<ToDoStatus, ToDoStatusQuery> {
		public ToDoStatusQuery(IEnumerable<ToDoStatus> entities) : base(entities) {}

		public ToDoStatusQuery(IQueryable<ToDoStatus> entities) : base(entities) {}

		public ToDoStatusQuery WithToDo(ToDo value = null,
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
							Entities = Entities.Where(tds => tds.ToDos.Any(td => td == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(tds => tds.ToDos.All(td => td == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(tds => tds.ToDos.Any(td => td != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(tds => tds.ToDos.All(td => td != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ToDoStatusQuery WithToDoId(long? value = null,
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
							Entities = Entities.Where(tds => tds.ToDos.Any(td => td.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(tds => tds.ToDos.All(td => td.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(tds => tds.ToDos.Any(td => td.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(tds => tds.ToDos.All(td => td.Id != value));
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