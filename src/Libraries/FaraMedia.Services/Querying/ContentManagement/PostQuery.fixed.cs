namespace FaraMedia.Services.Querying.ContentManagement {
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.ContentManagement;
	using FaraMedia.Core.Operators;

	public sealed class PostQuery : EntityQueryBase<Post, PostQuery> {
		public PostQuery(IEnumerable<Post> entities) : base(entities) {}

		public PostQuery(IQueryable<Post> entities) : base(entities) {}

		public PostQuery WithTitle(string value = null,
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
							Entities = Entities.Where(p => p.Title == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(p => p.Title.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(p => value.Contains(p.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(p => p.Title.Contains(value) || value.Contains(p.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(p => p.Title.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(p => value.StartsWith(p.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(p => p.Title.StartsWith(value) || value.StartsWith(p.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(p => p.Title.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(p => value.EndsWith(p.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(p => p.Title.EndsWith(value) || value.EndsWith(p.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PostQuery WithBody(string value = null,
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
							Entities = Entities.Where(p => p.Body == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(p => p.Body.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(p => value.Contains(p.Body));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(p => p.Body.Contains(value) || value.Contains(p.Body));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(p => p.Body.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(p => value.StartsWith(p.Body));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(p => p.Body.StartsWith(value) || value.StartsWith(p.Body));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(p => p.Body.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(p => value.EndsWith(p.Body));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(p => p.Body.EndsWith(value) || value.EndsWith(p.Body));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PostQuery WithBlog(Blog value = null,
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
					Entities = Entities.Where(p => p.Blog == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(p => p.Blog != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PostQuery WithBlogId(long? value = null,
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
					Entities = Entities.Where(p => p.Blog.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(p => p.Blog.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(p => p.Blog.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(p => p.Blog.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(p => p.Blog.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(p => p.Blog.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PostQuery WithTag(Tag value = null,
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
							Entities = Entities.Where(p => p.Tags.Any(t => t == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(p => p.Tags.All(t => t == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(p => p.Tags.Any(t => t != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(p => p.Tags.All(t => t != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PostQuery WithTagId(long? value = null,
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
							Entities = Entities.Where(p => p.Tags.Any(t => t.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(p => p.Tags.All(t => t.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(p => p.Tags.Any(t => t.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(p => p.Tags.All(t => t.Id != value));
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