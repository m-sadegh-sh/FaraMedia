namespace FaraMedia.Services.Querying.Configuration {
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.Configuration;
	using FaraMedia.Core.Operators;

	public sealed class SettingQuery : EntityQueryBase<Setting, SettingQuery> {
		public SettingQuery(IEnumerable<Setting> entities) : base(entities) {}

		public SettingQuery(IQueryable<Setting> entities) : base(entities) {}

		public SettingQuery WithKey(string value = null,
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
							Entities = Entities.Where(s => s.Key == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(s => s.Key.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(s => value.Contains(s.Key));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(s => s.Key.Contains(value) || value.Contains(s.Key));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(s => s.Key.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(s => value.StartsWith(s.Key));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(s => s.Key.StartsWith(value) || value.StartsWith(s.Key));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(s => s.Key.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(s => value.EndsWith(s.Key));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(s => s.Key.EndsWith(value) || value.EndsWith(s.Key));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public SettingQuery WithValue(string value = null,
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
							Entities = Entities.Where(s => s.Value == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(s => s.Value.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(s => value.Contains(s.Value));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(s => s.Value.Contains(value) || value.Contains(s.Value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(s => s.Value.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(s => value.StartsWith(s.Value));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(s => s.Value.StartsWith(value) || value.StartsWith(s.Value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(s => s.Value.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(s => value.EndsWith(s.Value));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(s => s.Value.EndsWith(value) || value.EndsWith(s.Value));
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