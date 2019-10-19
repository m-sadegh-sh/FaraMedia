namespace FaraMedia.Services.Querying {
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain;
	using FaraMedia.Core.Operators;

	public abstract class AttributeQueryBase<TEntity, TQuery> : EntityQueryBase<TEntity, TQuery> where TEntity : AttributeBase
	                                                                                             where TQuery : AttributeQueryBase<TEntity, TQuery> {
		protected AttributeQueryBase(IEnumerable<TEntity> entities) : base(entities) {}

		protected AttributeQueryBase(IQueryable<TEntity> entities) : base(entities) {}

		public TQuery WithSystemName(string value = null,
		                             ArgumentEvaluationMode mode = ArgumentEvaluationMode.IgnoreNeutral,
		                             StringOperator @operator = StringOperator.Exact,
		                             StringDirection direction = StringDirection.SourceToExpected) {
			switch (mode) {
				case ArgumentEvaluationMode.IgnoreNeutral:
					if (Neutrals.Is(value))
						return (TQuery) this;
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
							Entities = Entities.Where(a => a.SystemName == value);
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(a => a.SystemName.Contains(value));
							return (TQuery) this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(a => value.Contains(a.SystemName));
							return (TQuery) this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(a => a.SystemName.Contains(value) || value.Contains(a.SystemName));
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(a => a.SystemName.StartsWith(value));
							return (TQuery) this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(a => value.StartsWith(a.SystemName));
							return (TQuery) this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(a => a.SystemName.StartsWith(value) || value.StartsWith(a.SystemName));
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(a => a.SystemName.EndsWith(value));
							return (TQuery) this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(a => value.EndsWith(a.SystemName));
							return (TQuery) this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(a => a.SystemName.EndsWith(value) || value.EndsWith(a.SystemName));
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TQuery WithDisplayName(string value = null,
		                              ArgumentEvaluationMode mode = ArgumentEvaluationMode.IgnoreNeutral,
		                              StringOperator @operator = StringOperator.Exact,
		                              StringDirection direction = StringDirection.SourceToExpected) {
			switch (mode) {
				case ArgumentEvaluationMode.IgnoreNeutral:
					if (Neutrals.Is(value))
						return (TQuery) this;
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
							Entities = Entities.Where(a => a.DisplayName == value);
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(a => a.DisplayName.Contains(value));
							return (TQuery) this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(a => value.Contains(a.DisplayName));
							return (TQuery) this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(a => a.DisplayName.Contains(value) || value.Contains(a.DisplayName));
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(a => a.DisplayName.StartsWith(value));
							return (TQuery) this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(a => value.StartsWith(a.DisplayName));
							return (TQuery) this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(a => a.DisplayName.StartsWith(value) || value.StartsWith(a.DisplayName));
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(a => a.DisplayName.EndsWith(value));
							return (TQuery) this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(a => value.EndsWith(a.DisplayName));
							return (TQuery) this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(a => a.DisplayName.EndsWith(value) || value.EndsWith(a.DisplayName));
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TQuery WithDescription(string value = null,
		                              ArgumentEvaluationMode mode = ArgumentEvaluationMode.IgnoreNeutral,
		                              StringOperator @operator = StringOperator.Exact,
		                              StringDirection direction = StringDirection.SourceToExpected) {
			switch (mode) {
				case ArgumentEvaluationMode.IgnoreNeutral:
					if (Neutrals.Is(value))
						return (TQuery) this;
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
							Entities = Entities.Where(a => a.Description == value);
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(a => a.Description.Contains(value));
							return (TQuery) this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(a => value.Contains(a.Description));
							return (TQuery) this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(a => a.Description.Contains(value) || value.Contains(a.Description));
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(a => a.Description.StartsWith(value));
							return (TQuery) this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(a => value.StartsWith(a.Description));
							return (TQuery) this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(a => a.Description.StartsWith(value) || value.StartsWith(a.Description));
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(a => a.Description.EndsWith(value));
							return (TQuery) this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(a => value.EndsWith(a.Description));
							return (TQuery) this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(a => a.Description.EndsWith(value) || value.EndsWith(a.Description));
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}
	}
}