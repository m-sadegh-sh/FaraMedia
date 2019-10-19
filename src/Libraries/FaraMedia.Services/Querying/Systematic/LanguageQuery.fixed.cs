namespace FaraMedia.Services.Querying.Systematic {
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.Systematic;
	using FaraMedia.Core.Operators;

	public sealed class LanguageQuery : AttributeQueryBase<Language, LanguageQuery> {
		public LanguageQuery(IEnumerable<Language> entities) : base(entities) {}

		public LanguageQuery(IQueryable<Language> entities) : base(entities) {}

		public LanguageQuery WithNativeName(string value = null,
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
							Entities = Entities.Where(l => l.NativeName == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(l => l.NativeName.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(l => value.Contains(l.NativeName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(l => l.NativeName.Contains(value) || value.Contains(l.NativeName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(l => l.NativeName.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(l => value.StartsWith(l.NativeName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(l => l.NativeName.StartsWith(value) || value.StartsWith(l.NativeName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(l => l.NativeName.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(l => value.EndsWith(l.NativeName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(l => l.NativeName.EndsWith(value) || value.EndsWith(l.NativeName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public LanguageQuery WithCultureCode(string value = null,
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
							Entities = Entities.Where(l => l.CultureCode == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(l => l.CultureCode.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(l => value.Contains(l.CultureCode));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(l => l.CultureCode.Contains(value) || value.Contains(l.CultureCode));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(l => l.CultureCode.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(l => value.StartsWith(l.CultureCode));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(l => l.CultureCode.StartsWith(value) || value.StartsWith(l.CultureCode));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(l => l.CultureCode.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(l => value.EndsWith(l.CultureCode));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(l => l.CultureCode.EndsWith(value) || value.EndsWith(l.CultureCode));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public LanguageQuery WithValue(ResourceValue value = null,
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
							Entities = Entities.Where(l => l.Values.Any(rv => rv == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(l => l.Values.All(rv => rv == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(l => l.Values.Any(rv => rv != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(l => l.Values.All(rv => rv != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public LanguageQuery WithValueId(long? value = null,
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
							Entities = Entities.Where(l => l.Values.Any(rv => rv.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(l => l.Values.All(rv => rv.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(l => l.Values.Any(rv => rv.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(l => l.Values.All(rv => rv.Id != value));
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