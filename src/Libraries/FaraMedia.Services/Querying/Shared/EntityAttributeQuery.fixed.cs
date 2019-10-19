namespace FaraMedia.Services.Querying.Shared {
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.Shared;
	using FaraMedia.Core.Operators;

	public sealed class EntityAttributeQuery : OwnableQueryBase<EntityAttribute, EntityAttributeQuery> {
		public EntityAttributeQuery(IEnumerable<EntityAttribute> entities) : base(entities) {}

		public EntityAttributeQuery(IQueryable<EntityAttribute> entities) : base(entities) {}

		public EntityAttributeQuery WithKey(string value = null,
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
							Entities = Entities.Where(ea => ea.Key == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(ea => ea.Key.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(ea => value.Contains(ea.Key));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(ea => ea.Key.Contains(value) || value.Contains(ea.Key));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(ea => ea.Key.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(ea => value.StartsWith(ea.Key));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(ea => ea.Key.StartsWith(value) || value.StartsWith(ea.Key));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(ea => ea.Key.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(ea => value.EndsWith(ea.Key));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(ea => ea.Key.EndsWith(value) || value.EndsWith(ea.Key));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public EntityAttributeQuery WithDisplayName(string value = null,
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
							Entities = Entities.Where(ea => ea.DisplayName == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(ea => ea.DisplayName.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(ea => value.Contains(ea.DisplayName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(ea => ea.DisplayName.Contains(value) || value.Contains(ea.DisplayName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(ea => ea.DisplayName.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(ea => value.StartsWith(ea.DisplayName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(ea => ea.DisplayName.StartsWith(value) || value.StartsWith(ea.DisplayName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(ea => ea.DisplayName.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(ea => value.EndsWith(ea.DisplayName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(ea => ea.DisplayName.EndsWith(value) || value.EndsWith(ea.DisplayName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public EntityAttributeQuery WithValue(string value = null,
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
							Entities = Entities.Where(ea => ea.Value == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(ea => ea.Value.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(ea => value.Contains(ea.Value));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(ea => ea.Value.Contains(value) || value.Contains(ea.Value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(ea => ea.Value.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(ea => value.StartsWith(ea.Value));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(ea => ea.Value.StartsWith(value) || value.StartsWith(ea.Value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(ea => ea.Value.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(ea => value.EndsWith(ea.Value));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(ea => ea.Value.EndsWith(value) || value.EndsWith(ea.Value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public EntityAttributeQuery WithDescription(string value = null,
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
							Entities = Entities.Where(ea => ea.Description == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(ea => ea.Description.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(ea => value.Contains(ea.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(ea => ea.Description.Contains(value) || value.Contains(ea.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(ea => ea.Description.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(ea => value.StartsWith(ea.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(ea => ea.Description.StartsWith(value) || value.StartsWith(ea.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(ea => ea.Description.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(ea => value.EndsWith(ea.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(ea => ea.Description.EndsWith(value) || value.EndsWith(ea.Description));
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