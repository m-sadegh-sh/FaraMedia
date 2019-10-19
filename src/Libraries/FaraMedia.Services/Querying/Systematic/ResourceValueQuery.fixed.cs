namespace FaraMedia.Services.Querying.Systematic {
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.Systematic;
	using FaraMedia.Core.Operators;

	public sealed class ResourceValueQuery : EntityQueryBase<ResourceValue, ResourceValueQuery> {
		public ResourceValueQuery(IEnumerable<ResourceValue> entities) : base(entities) {}

		public ResourceValueQuery(IQueryable<ResourceValue> entities) : base(entities) {}

		public ResourceValueQuery WithLanguage(Language value = null,
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
					Entities = Entities.Where(rv => rv.Language == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(rv => rv.Language != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ResourceValueQuery WithLanguageId(long? value = null,
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
					Entities = Entities.Where(rv => rv.Language.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(rv => rv.Language.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(rv => rv.Language.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(rv => rv.Language.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(rv => rv.Language.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(rv => rv.Language.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ResourceValueQuery WithLanguageIdBetween(long? from = null,
		                                                ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                                long? to = null,
		                                                ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                                RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(rv => rv.Language.Id >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(rv => rv.Language.Id == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(rv => rv.Language.Id <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(rv => rv.Language.Id == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(rv => rv.Language.Id <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(rv => rv.Language.Id == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(rv => rv.Language.Id >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(rv => rv.Language.Id == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				default:
					throw new NotSupportedEnumException(@operator);
			}

			return this;
		}

		public ResourceValueQuery WithLanguageCultureCode(string value = null,
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
							Entities = Entities.Where(rv => rv.Language.CultureCode == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(rv => rv.Language.CultureCode.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(rv => value.Contains(rv.Language.CultureCode));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(rv => rv.Language.CultureCode.Contains(value) || value.Contains(rv.Language.CultureCode));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(rv => rv.Language.CultureCode.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(rv => value.StartsWith(rv.Language.CultureCode));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(rv => rv.Language.CultureCode.StartsWith(value) || value.StartsWith(rv.Language.CultureCode));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(rv => rv.Language.CultureCode.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(rv => value.EndsWith(rv.Language.CultureCode));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(rv => rv.Language.CultureCode.EndsWith(value) || value.EndsWith(rv.Language.CultureCode));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ResourceValueQuery WithKey(ResourceKey value = null,
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
					Entities = Entities.Where(rv => rv.Key == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(rv => rv.Key != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ResourceValueQuery WithKeyId(long? value = null,
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
					Entities = Entities.Where(rv => rv.Key.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(rv => rv.Key.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(rv => rv.Key.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(rv => rv.Key.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(rv => rv.Key.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(rv => rv.Key.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ResourceValueQuery WithKeyIdBetween(long? from = null,
		                                           ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                           long? to = null,
		                                           ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                           RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(rv => rv.Key.Id >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(rv => rv.Key.Id == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(rv => rv.Key.Id <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(rv => rv.Key.Id == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(rv => rv.Key.Id <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(rv => rv.Key.Id == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(rv => rv.Key.Id >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(rv => rv.Key.Id == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				default:
					throw new NotSupportedEnumException(@operator);
			}

			return this;
		}

		public ResourceValueQuery WithKeyKey(string value = null,
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
							Entities = Entities.Where(rv => rv.Key.Key == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(rv => rv.Key.Key.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(rv => value.Contains(rv.Key.Key));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(rv => rv.Key.Key.Contains(value) || value.Contains(rv.Key.Key));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(rv => rv.Key.Key.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(rv => value.StartsWith(rv.Key.Key));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(rv => rv.Key.Key.StartsWith(value) || value.StartsWith(rv.Key.Key));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(rv => rv.Key.Key.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(rv => value.EndsWith(rv.Key.Key));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(rv => rv.Key.Key.EndsWith(value) || value.EndsWith(rv.Key.Key));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ResourceValueQuery WithValue(string value = null,
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
							Entities = Entities.Where(rv => rv.Value == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(rv => rv.Value.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(rv => value.Contains(rv.Value));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(rv => rv.Value.Contains(value) || value.Contains(rv.Value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(rv => rv.Value.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(rv => value.StartsWith(rv.Value));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(rv => rv.Value.StartsWith(value) || value.StartsWith(rv.Value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(rv => rv.Value.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(rv => value.EndsWith(rv.Value));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(rv => rv.Value.EndsWith(value) || value.EndsWith(rv.Value));
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