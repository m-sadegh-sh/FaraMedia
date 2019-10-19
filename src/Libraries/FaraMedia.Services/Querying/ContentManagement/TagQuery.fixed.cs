namespace FaraMedia.Services.Querying.ContentManagement {
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.ContentManagement;
	using FaraMedia.Core.Operators;

	public sealed class TagQuery : EntityQueryBase<Tag, TagQuery> {
		public TagQuery(IEnumerable<Tag> entities) : base(entities) {}

		public TagQuery(IQueryable<Tag> entities) : base(entities) {}

		public TagQuery WithTitle(string value = null,
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
							Entities = Entities.Where(t => t.Title == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(t => t.Title.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(t => value.Contains(t.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(t => t.Title.Contains(value) || value.Contains(t.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(t => t.Title.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(t => value.StartsWith(t.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(t => t.Title.StartsWith(value) || value.StartsWith(t.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(t => t.Title.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(t => value.EndsWith(t.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(t => t.Title.EndsWith(value) || value.EndsWith(t.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TagQuery WithDescription(string value = null,
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
							Entities = Entities.Where(t => t.Description == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(t => t.Description.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(t => value.Contains(t.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(t => t.Description.Contains(value) || value.Contains(t.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(t => t.Description.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(t => value.StartsWith(t.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(t => t.Description.StartsWith(value) || value.StartsWith(t.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(t => t.Description.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(t => value.EndsWith(t.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(t => t.Description.EndsWith(value) || value.EndsWith(t.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TagQuery WithMetadataTitle(string value = null,
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
							Entities = Entities.Where(t => t.Metadata.Title == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(t => t.Metadata.Title.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(t => value.Contains(t.Metadata.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(t => t.Metadata.Title.Contains(value) || value.Contains(t.Metadata.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(t => t.Metadata.Title.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(t => value.StartsWith(t.Metadata.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(t => t.Metadata.Title.StartsWith(value) || value.StartsWith(t.Metadata.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(t => t.Metadata.Title.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(t => value.EndsWith(t.Metadata.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(t => t.Metadata.Title.EndsWith(value) || value.EndsWith(t.Metadata.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TagQuery WithMetadataSlug(string value = null,
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
							Entities = Entities.Where(t => t.Metadata.Slug == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(t => t.Metadata.Slug.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(t => value.Contains(t.Metadata.Slug));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(t => t.Metadata.Slug.Contains(value) || value.Contains(t.Metadata.Slug));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(t => t.Metadata.Slug.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(t => value.StartsWith(t.Metadata.Slug));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(t => t.Metadata.Slug.StartsWith(value) || value.StartsWith(t.Metadata.Slug));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(t => t.Metadata.Slug.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(t => value.EndsWith(t.Metadata.Slug));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(t => t.Metadata.Slug.EndsWith(value) || value.EndsWith(t.Metadata.Slug));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TagQuery WithMetadataKeywords(string value = null,
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
							Entities = Entities.Where(t => t.Metadata.Keywords == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(t => t.Metadata.Keywords.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(t => value.Contains(t.Metadata.Keywords));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(t => t.Metadata.Keywords.Contains(value) || value.Contains(t.Metadata.Keywords));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(t => t.Metadata.Keywords.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(t => value.StartsWith(t.Metadata.Keywords));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(t => t.Metadata.Keywords.StartsWith(value) || value.StartsWith(t.Metadata.Keywords));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(t => t.Metadata.Keywords.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(t => value.EndsWith(t.Metadata.Keywords));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(t => t.Metadata.Keywords.EndsWith(value) || value.EndsWith(t.Metadata.Keywords));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TagQuery WithMetadataDescription(string value = null,
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
							Entities = Entities.Where(t => t.Metadata.Description == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(t => t.Metadata.Description.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(t => value.Contains(t.Metadata.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(t => t.Metadata.Description.Contains(value) || value.Contains(t.Metadata.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(t => t.Metadata.Description.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(t => value.StartsWith(t.Metadata.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(t => t.Metadata.Description.StartsWith(value) || value.StartsWith(t.Metadata.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(t => t.Metadata.Description.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(t => value.EndsWith(t.Metadata.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(t => t.Metadata.Description.EndsWith(value) || value.EndsWith(t.Metadata.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TagQuery WithBlog(Blog value = null,
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
					Entities = Entities.Where(t => t.Blog == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(t => t.Blog != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TagQuery WithBlogId(long? value = null,
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
					Entities = Entities.Where(t => t.Blog.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(t => t.Blog.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(t => t.Blog.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(t => t.Blog.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(t => t.Blog.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(t => t.Blog.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TagQuery WithPost(Post value = null,
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
							Entities = Entities.Where(t => t.Posts.Any(p => p == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(t => t.Posts.All(p => p == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(t => t.Posts.Any(p => p != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(t => t.Posts.All(p => p != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TagQuery WithPostId(long? value = null,
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
							Entities = Entities.Where(t => t.Posts.Any(p => p.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(t => t.Posts.All(p => p.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(t => t.Posts.Any(p => p.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(t => t.Posts.All(p => p.Id != value));
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