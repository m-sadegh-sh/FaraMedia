namespace FaraMedia.Services.Querying.Shared {
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.Shared;
	using FaraMedia.Core.Operators;

	public sealed class CommentQuery : UserContentQueryBase<Comment, CommentQuery> {
		public CommentQuery(IEnumerable<Comment> entities) : base(entities) {}

		public CommentQuery(IQueryable<Comment> entities) : base(entities) {}

		public CommentQuery WithOwnerId(long? value = null,
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
					Entities = Entities.Where(c => c.OwnerId == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(c => c.OwnerId != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(c => c.OwnerId >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(c => c.OwnerId > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(c => c.OwnerId <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(c => c.OwnerId < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public CommentQuery WithEmail(string value = null,
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
							Entities = Entities.Where(c => c.Email == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(c => c.Email.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(c => value.Contains(c.Email));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(c => c.Email.Contains(value) || value.Contains(c.Email));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(c => c.Email.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(c => value.StartsWith(c.Email));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(c => c.Email.StartsWith(value) || value.StartsWith(c.Email));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(c => c.Email.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(c => value.EndsWith(c.Email));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(c => c.Email.EndsWith(value) || value.EndsWith(c.Email));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public CommentQuery WithTitle(string value = null,
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

		public CommentQuery WithBody(string value = null,
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
							Entities = Entities.Where(c => c.Body == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(c => c.Body.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(c => value.Contains(c.Body));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(c => c.Body.Contains(value) || value.Contains(c.Body));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(c => c.Body.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(c => value.StartsWith(c.Body));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(c => c.Body.StartsWith(value) || value.StartsWith(c.Body));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(c => c.Body.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(c => value.EndsWith(c.Body));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(c => c.Body.EndsWith(value) || value.EndsWith(c.Body));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public CommentQuery WithInReplyTo(Comment value = null,
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
					Entities = Entities.Where(c => c.InReplyTo == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(c => c.InReplyTo != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public CommentQuery WithInReplyToId(long? value = null,
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
					Entities = Entities.Where(c => c.InReplyTo.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(c => c.InReplyTo.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(c => c.InReplyTo.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(c => c.InReplyTo.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(c => c.InReplyTo.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(c => c.InReplyTo.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public CommentQuery WithReply(Comment value = null,
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
							Entities = Entities.Where(c => c.Replies.Any(c2 => c2 == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(c => c.Replies.All(c2 => c2 == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(c => c.Replies.Any(c2 => c2 != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(c => c.Replies.All(c2 => c2 != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public CommentQuery WithReplyId(long? value = null,
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
							Entities = Entities.Where(c => c.Replies.Any(c2 => c2.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(c => c.Replies.All(c2 => c2.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(c => c.Replies.Any(c2 => c2.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(c => c.Replies.All(c2 => c2.Id != value));
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