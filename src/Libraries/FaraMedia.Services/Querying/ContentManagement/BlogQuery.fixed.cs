namespace FaraMedia.Services.Querying.ContentManagement {
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.ContentManagement;
	using FaraMedia.Core.Domain.Security;
	using FaraMedia.Core.Operators;

	public sealed class BlogQuery : UIElementQueryBase<Blog, BlogQuery> {
		public BlogQuery(IEnumerable<Blog> entities) : base(entities) {}

		public BlogQuery(IQueryable<Blog> entities) : base(entities) {}

		public BlogQuery WithTitle(string value = null,
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
							Entities = Entities.Where(b => b.Title == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(b => b.Title.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(b => value.Contains(b.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(b => b.Title.Contains(value) || value.Contains(b.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(b => b.Title.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(b => value.StartsWith(b.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(b => b.Title.StartsWith(value) || value.StartsWith(b.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(b => b.Title.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(b => value.EndsWith(b.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(b => b.Title.EndsWith(value) || value.EndsWith(b.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public BlogQuery WithDescription(string value = null,
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
							Entities = Entities.Where(b => b.Description == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(b => b.Description.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(b => value.Contains(b.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(b => b.Description.Contains(value) || value.Contains(b.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(b => b.Description.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(b => value.StartsWith(b.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(b => b.Description.StartsWith(value) || value.StartsWith(b.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(b => b.Description.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(b => value.EndsWith(b.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(b => b.Description.EndsWith(value) || value.EndsWith(b.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public BlogQuery WithAuthor(User value = null,
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
							Entities = Entities.Where(b => b.Authors.Any(u => u == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(b => b.Authors.All(u => u == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(b => b.Authors.Any(u => u != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(b => b.Authors.All(u => u != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public BlogQuery WithAuthorId(long? value = null,
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
							Entities = Entities.Where(b => b.Authors.Any(u => u.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(b => b.Authors.All(u => u.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(b => b.Authors.Any(u => u.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(b => b.Authors.All(u => u.Id != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public BlogQuery WithTag(Tag value = null,
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
							Entities = Entities.Where(b => b.Tags.Any(t => t == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(b => b.Tags.All(t => t == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(b => b.Tags.Any(t => t != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(b => b.Tags.All(t => t != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public BlogQuery WithTagId(long? value = null,
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
							Entities = Entities.Where(b => b.Tags.Any(t => t.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(b => b.Tags.All(t => t.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(b => b.Tags.Any(t => t.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(b => b.Tags.All(t => t.Id != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public BlogQuery WithPost(Post value = null,
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
							Entities = Entities.Where(b => b.Posts.Any(p => p == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(b => b.Posts.All(p => p == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(b => b.Posts.Any(p => p != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(b => b.Posts.All(p => p != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public BlogQuery WithPostId(long? value = null,
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
							Entities = Entities.Where(b => b.Posts.Any(p => p.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(b => b.Posts.All(p => p.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(b => b.Posts.Any(p => p.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(b => b.Posts.All(p => p.Id != value));
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