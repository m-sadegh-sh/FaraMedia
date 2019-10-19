namespace FaraMedia.Services.Querying.Systematic {
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.Systematic;
	using FaraMedia.Core.Operators;

	public sealed class ActivityTypeQuery : AttributeQueryBase<ActivityType, ActivityTypeQuery> {
		public ActivityTypeQuery(IEnumerable<ActivityType> entities) : base(entities) {}

		public ActivityTypeQuery(IQueryable<ActivityType> entities) : base(entities) {}

		public ActivityTypeQuery WithActivity(Activity value = null,
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
							Entities = Entities.Where(at => at.Activities.Any(a => a == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(at => at.Activities.All(a => a == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(at => at.Activities.Any(a => a != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(at => at.Activities.All(a => a != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ActivityTypeQuery WithActivityId(long? value = null,
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
							Entities = Entities.Where(at => at.Activities.Any(a => a.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(at => at.Activities.All(a => a.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(at => at.Activities.Any(a => a.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(at => at.Activities.All(a => a.Id != value));
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