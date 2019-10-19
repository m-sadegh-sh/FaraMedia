namespace FaraMedia.Services.Querying.ContentManagement {
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.ContentManagement;
	using FaraMedia.Core.Operators;

	public sealed class NewsQuery : UIElementQueryBase<News, NewsQuery> {
		public NewsQuery(IEnumerable<News> entities) : base(entities) {}

		public NewsQuery(IQueryable<News> entities) : base(entities) {}

		public NewsQuery WithTitle(string value = null,
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
							Entities = Entities.Where(n => n.Title == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(n => n.Title.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(n => value.Contains(n.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(n => n.Title.Contains(value) || value.Contains(n.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(n => n.Title.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(n => value.StartsWith(n.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(n => n.Title.StartsWith(value) || value.StartsWith(n.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(n => n.Title.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(n => value.EndsWith(n.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(n => n.Title.EndsWith(value) || value.EndsWith(n.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public NewsQuery WithShort(string value = null,
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
							Entities = Entities.Where(n => n.Short == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(n => n.Short.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(n => value.Contains(n.Short));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(n => n.Short.Contains(value) || value.Contains(n.Short));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(n => n.Short.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(n => value.StartsWith(n.Short));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(n => n.Short.StartsWith(value) || value.StartsWith(n.Short));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(n => n.Short.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(n => value.EndsWith(n.Short));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(n => n.Short.EndsWith(value) || value.EndsWith(n.Short));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public NewsQuery WithFull(string value = null,
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
							Entities = Entities.Where(n => n.Full == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(n => n.Full.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(n => value.Contains(n.Full));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(n => n.Full.Contains(value) || value.Contains(n.Full));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(n => n.Full.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(n => value.StartsWith(n.Full));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(n => n.Full.StartsWith(value) || value.StartsWith(n.Full));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(n => n.Full.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(n => value.EndsWith(n.Full));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(n => n.Full.EndsWith(value) || value.EndsWith(n.Full));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public NewsQuery WithCategory(Category value = null,
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
					Entities = Entities.Where(n => n.Category == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(n => n.Category != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public NewsQuery WithCategoryId(long? value = null,
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
					Entities = Entities.Where(n => n.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(n => n.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(n => n.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(n => n.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(n => n.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(n => n.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}
	}
}