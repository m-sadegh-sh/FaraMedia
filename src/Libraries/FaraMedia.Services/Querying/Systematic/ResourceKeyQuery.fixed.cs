namespace FaraMedia.Services.Querying.Systematic {
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.Systematic;
	using FaraMedia.Core.Operators;

	public sealed class ResourceKeyQuery : EntityQueryBase<ResourceKey, ResourceKeyQuery> {
		public ResourceKeyQuery(IEnumerable<ResourceKey> entities) : base(entities) {}

		public ResourceKeyQuery(IQueryable<ResourceKey> entities) : base(entities) {}

		public ResourceKeyQuery WithKey(string value = null,
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
							Entities = Entities.Where(rk => rk.Key == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(rk => rk.Key.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(rk => value.Contains(rk.Key));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(rk => rk.Key.Contains(value) || value.Contains(rk.Key));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(rk => rk.Key.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(rk => value.StartsWith(rk.Key));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(rk => rk.Key.StartsWith(value) || value.StartsWith(rk.Key));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(rk => rk.Key.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(rk => value.EndsWith(rk.Key));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(rk => rk.Key.EndsWith(value) || value.EndsWith(rk.Key));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ResourceKeyQuery WithDisplayName(string value = null,
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
							Entities = Entities.Where(rk => rk.DisplayName == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(rk => rk.DisplayName.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(rk => value.Contains(rk.DisplayName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(rk => rk.DisplayName.Contains(value) || value.Contains(rk.DisplayName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(rk => rk.DisplayName.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(rk => value.StartsWith(rk.DisplayName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(rk => rk.DisplayName.StartsWith(value) || value.StartsWith(rk.DisplayName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(rk => rk.DisplayName.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(rk => value.EndsWith(rk.DisplayName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(rk => rk.DisplayName.EndsWith(value) || value.EndsWith(rk.DisplayName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ResourceKeyQuery WithDescription(string value = null,
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
							Entities = Entities.Where(rk => rk.Description == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(rk => rk.Description.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(rk => value.Contains(rk.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(rk => rk.Description.Contains(value) || value.Contains(rk.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(rk => rk.Description.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(rk => value.StartsWith(rk.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(rk => rk.Description.StartsWith(value) || value.StartsWith(rk.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(rk => rk.Description.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(rk => value.EndsWith(rk.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(rk => rk.Description.EndsWith(value) || value.EndsWith(rk.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ResourceKeyQuery WithValue(ResourceValue value = null,
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
							Entities = Entities.Where(rk => rk.Values.Any(rv => rv == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(rk => rk.Values.All(rv => rv == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(rk => rk.Values.Any(rv => rv != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(rk => rk.Values.All(rv => rv != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ResourceKeyQuery WithValueId(long? value = null,
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
							Entities = Entities.Where(rk => rk.Values.Any(rv => rv.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(rk => rk.Values.All(rv => rv.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(rk => rk.Values.Any(rv => rv.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(rk => rk.Values.All(rv => rv.Id != value));
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