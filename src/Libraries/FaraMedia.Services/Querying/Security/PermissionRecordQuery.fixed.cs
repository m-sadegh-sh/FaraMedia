namespace FaraMedia.Services.Querying.Security {
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.Security;
	using FaraMedia.Core.Operators;

	public sealed class PermissionRecordQuery : AttributeQueryBase<PermissionRecord, PermissionRecordQuery> {
		public PermissionRecordQuery(IEnumerable<PermissionRecord> entities) : base(entities) {}

		public PermissionRecordQuery(IQueryable<PermissionRecord> entities) : base(entities) {}

		public PermissionRecordQuery WithCategory(string value = null,
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
							Entities = Entities.Where(pr => pr.Category == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(pr => pr.Category.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(pr => value.Contains(pr.Category));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(pr => pr.Category.Contains(value) || value.Contains(pr.Category));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(pr => pr.Category.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(pr => value.StartsWith(pr.Category));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(pr => pr.Category.StartsWith(value) || value.StartsWith(pr.Category));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(pr => pr.Category.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(pr => value.EndsWith(pr.Category));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(pr => pr.Category.EndsWith(value) || value.EndsWith(pr.Category));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PermissionRecordQuery WithRole(Role value = null,
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
							Entities = Entities.Where(pr => pr.Roles.Any(r => r == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(pr => pr.Roles.All(r => r == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(pr => pr.Roles.Any(r => r != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(pr => pr.Roles.All(r => r != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PermissionRecordQuery WithRoleId(long? value = null,
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
							Entities = Entities.Where(pr => pr.Roles.Any(r => r.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(pr => pr.Roles.All(r => r.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(pr => pr.Roles.Any(r => r.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(pr => pr.Roles.All(r => r.Id != value));
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