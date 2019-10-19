namespace FaraMedia.Services.Querying.ContentManagement {
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.ContentManagement;
	using FaraMedia.Core.Operators;

	public sealed class CategoryQuery : EntityQueryBase<Category, CategoryQuery> {
		public CategoryQuery(IEnumerable<Category> entities) : base(entities) {}

		public CategoryQuery(IQueryable<Category> entities) : base(entities) {}

		public CategoryQuery WithTitle(string value = null,
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
							Entities = Entities.Where(c => c.Title == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(c => c.Title.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(c => value.Contains(c.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(c => c.Title.Contains(value) || value.Contains(c.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(c => c.Title.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(c => value.StartsWith(c.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(c => c.Title.StartsWith(value) || value.StartsWith(c.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(c => c.Title.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(c => value.EndsWith(c.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(c => c.Title.EndsWith(value) || value.EndsWith(c.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public CategoryQuery WithDescription(string value = null,
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
							Entities = Entities.Where(c => c.Description == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(c => c.Description.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(c => value.Contains(c.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(c => c.Description.Contains(value) || value.Contains(c.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(c => c.Description.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(c => value.StartsWith(c.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(c => c.Description.StartsWith(value) || value.StartsWith(c.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(c => c.Description.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(c => value.EndsWith(c.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(c => c.Description.EndsWith(value) || value.EndsWith(c.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public CategoryQuery WithMetadataTitle(string value = null,
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
							Entities = Entities.Where(c => c.Metadata.Title == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(c => c.Metadata.Title.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(c => value.Contains(c.Metadata.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(c => c.Metadata.Title.Contains(value) || value.Contains(c.Metadata.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(c => c.Metadata.Title.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(c => value.StartsWith(c.Metadata.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(c => c.Metadata.Title.StartsWith(value) || value.StartsWith(c.Metadata.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(c => c.Metadata.Title.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(c => value.EndsWith(c.Metadata.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(c => c.Metadata.Title.EndsWith(value) || value.EndsWith(c.Metadata.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public CategoryQuery WithMetadataSlug(string value = null,
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
							Entities = Entities.Where(c => c.Metadata.Slug == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(c => c.Metadata.Slug.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(c => value.Contains(c.Metadata.Slug));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(c => c.Metadata.Slug.Contains(value) || value.Contains(c.Metadata.Slug));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(c => c.Metadata.Slug.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(c => value.StartsWith(c.Metadata.Slug));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(c => c.Metadata.Slug.StartsWith(value) || value.StartsWith(c.Metadata.Slug));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(c => c.Metadata.Slug.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(c => value.EndsWith(c.Metadata.Slug));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(c => c.Metadata.Slug.EndsWith(value) || value.EndsWith(c.Metadata.Slug));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public CategoryQuery WithMetadataKeywords(string value = null,
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
							Entities = Entities.Where(c => c.Metadata.Keywords == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(c => c.Metadata.Keywords.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(c => value.Contains(c.Metadata.Keywords));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(c => c.Metadata.Keywords.Contains(value) || value.Contains(c.Metadata.Keywords));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(c => c.Metadata.Keywords.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(c => value.StartsWith(c.Metadata.Keywords));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(c => c.Metadata.Keywords.StartsWith(value) || value.StartsWith(c.Metadata.Keywords));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(c => c.Metadata.Keywords.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(c => value.EndsWith(c.Metadata.Keywords));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(c => c.Metadata.Keywords.EndsWith(value) || value.EndsWith(c.Metadata.Keywords));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public CategoryQuery WithMetadataDescription(string value = null,
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
							Entities = Entities.Where(c => c.Metadata.Description == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(c => c.Metadata.Description.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(c => value.Contains(c.Metadata.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(c => c.Metadata.Description.Contains(value) || value.Contains(c.Metadata.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(c => c.Metadata.Description.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(c => value.StartsWith(c.Metadata.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(c => c.Metadata.Description.StartsWith(value) || value.StartsWith(c.Metadata.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(c => c.Metadata.Description.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(c => value.EndsWith(c.Metadata.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(c => c.Metadata.Description.EndsWith(value) || value.EndsWith(c.Metadata.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public CategoryQuery WithParent(Category value = null,
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
					Entities = Entities.Where(c => c.Parent == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(c => c.Parent != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public CategoryQuery WithParentId(long? value = null,
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
					Entities = Entities.Where(c => c.Parent.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(c => c.Parent.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(c => c.Parent.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(c => c.Parent.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(c => c.Parent.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(c => c.Parent.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public CategoryQuery WithChild(Category value = null,
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
							Entities = Entities.Where(c => c.Children.Any(c2 => c2 == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(c => c.Children.All(c2 => c2 == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(c => c.Children.Any(c2 => c2 != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(c => c.Children.All(c2 => c2 != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public CategoryQuery WithChildId(long? value = null,
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
							Entities = Entities.Where(c => c.Children.Any(c2 => c2.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(c => c.Children.All(c2 => c2.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(c => c.Children.Any(c2 => c2.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(c => c.Children.All(c2 => c2.Id != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public CategoryQuery WithNews(News value = null,
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
							Entities = Entities.Where(c => c.News.Any(n => n == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(c => c.News.All(n => n == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(c => c.News.Any(n => n != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(c => c.News.All(n => n != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public CategoryQuery WithNewsId(long? value = null,
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
							Entities = Entities.Where(c => c.News.Any(n => n.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(c => c.News.All(n => n.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(c => c.News.Any(n => n.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(c => c.News.All(n => n.Id != value));
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