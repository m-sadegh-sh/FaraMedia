namespace FaraMedia.Services.Querying.ContentManagement {
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.ContentManagement;
	using FaraMedia.Core.Operators;

	public sealed class GroupQuery : EntityQueryBase<Group, GroupQuery> {
		public GroupQuery(IEnumerable<Group> entities) : base(entities) {}

		public GroupQuery(IQueryable<Group> entities) : base(entities) {}

		public GroupQuery WithTitle(string value = null,
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
							Entities = Entities.Where(g => g.Title == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(g => g.Title.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(g => value.Contains(g.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(g => g.Title.Contains(value) || value.Contains(g.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(g => g.Title.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(g => value.StartsWith(g.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(g => g.Title.StartsWith(value) || value.StartsWith(g.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(g => g.Title.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(g => value.EndsWith(g.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(g => g.Title.EndsWith(value) || value.EndsWith(g.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public GroupQuery WithDescription(string value = null,
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
							Entities = Entities.Where(g => g.Description == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(g => g.Description.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(g => value.Contains(g.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(g => g.Description.Contains(value) || value.Contains(g.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(g => g.Description.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(g => value.StartsWith(g.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(g => g.Description.StartsWith(value) || value.StartsWith(g.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(g => g.Description.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(g => value.EndsWith(g.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(g => g.Description.EndsWith(value) || value.EndsWith(g.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public GroupQuery WithMetadataTitle(string value = null,
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
							Entities = Entities.Where(g => g.Metadata.Title == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(g => g.Metadata.Title.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(g => value.Contains(g.Metadata.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(g => g.Metadata.Title.Contains(value) || value.Contains(g.Metadata.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(g => g.Metadata.Title.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(g => value.StartsWith(g.Metadata.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(g => g.Metadata.Title.StartsWith(value) || value.StartsWith(g.Metadata.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(g => g.Metadata.Title.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(g => value.EndsWith(g.Metadata.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(g => g.Metadata.Title.EndsWith(value) || value.EndsWith(g.Metadata.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public GroupQuery WithMetadataSlug(string value = null,
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
							Entities = Entities.Where(g => g.Metadata.Slug == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(g => g.Metadata.Slug.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(g => value.Contains(g.Metadata.Slug));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(g => g.Metadata.Slug.Contains(value) || value.Contains(g.Metadata.Slug));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(g => g.Metadata.Slug.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(g => value.StartsWith(g.Metadata.Slug));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(g => g.Metadata.Slug.StartsWith(value) || value.StartsWith(g.Metadata.Slug));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(g => g.Metadata.Slug.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(g => value.EndsWith(g.Metadata.Slug));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(g => g.Metadata.Slug.EndsWith(value) || value.EndsWith(g.Metadata.Slug));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public GroupQuery WithMetadataKeywords(string value = null,
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
							Entities = Entities.Where(g => g.Metadata.Keywords == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(g => g.Metadata.Keywords.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(g => value.Contains(g.Metadata.Keywords));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(g => g.Metadata.Keywords.Contains(value) || value.Contains(g.Metadata.Keywords));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(g => g.Metadata.Keywords.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(g => value.StartsWith(g.Metadata.Keywords));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(g => g.Metadata.Keywords.StartsWith(value) || value.StartsWith(g.Metadata.Keywords));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(g => g.Metadata.Keywords.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(g => value.EndsWith(g.Metadata.Keywords));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(g => g.Metadata.Keywords.EndsWith(value) || value.EndsWith(g.Metadata.Keywords));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public GroupQuery WithMetadataDescription(string value = null,
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
							Entities = Entities.Where(g => g.Metadata.Description == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(g => g.Metadata.Description.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(g => value.Contains(g.Metadata.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(g => g.Metadata.Description.Contains(value) || value.Contains(g.Metadata.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(g => g.Metadata.Description.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(g => value.StartsWith(g.Metadata.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(g => g.Metadata.Description.StartsWith(value) || value.StartsWith(g.Metadata.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(g => g.Metadata.Description.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(g => value.EndsWith(g.Metadata.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(g => g.Metadata.Description.EndsWith(value) || value.EndsWith(g.Metadata.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public GroupQuery WithParent(Group value = null,
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
					Entities = Entities.Where(g => g.Parent == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(g => g.Parent != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public GroupQuery WithParentId(long? value = null,
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
					Entities = Entities.Where(g => g.Parent.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(g => g.Parent.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(g => g.Parent.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(g => g.Parent.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(g => g.Parent.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(g => g.Parent.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public GroupQuery WithPage(Page value = null,
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
							Entities = Entities.Where(g => g.Pages.Any(p => p == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(g => g.Pages.All(p => p == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(g => g.Pages.Any(p => p != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(g => g.Pages.All(p => p != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public GroupQuery WithPageId(long? value = null,
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
							Entities = Entities.Where(g => g.Pages.Any(p => p.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(g => g.Pages.All(p => p.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(g => g.Pages.Any(p => p.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(g => g.Pages.All(p => p.Id != value));
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