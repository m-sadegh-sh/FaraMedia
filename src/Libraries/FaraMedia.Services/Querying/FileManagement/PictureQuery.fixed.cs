namespace FaraMedia.Services.Querying.FileManagement {
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.FileManagement;
	using FaraMedia.Core.Operators;

	public sealed class PictureQuery : UserContentQueryBase<Picture, PictureQuery> {
		public PictureQuery(IEnumerable<Picture> entities) : base(entities) {}

		public PictureQuery(IQueryable<Picture> entities) : base(entities) {}

		public PictureQuery WithFileName(string value = null,
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
							Entities = Entities.Where(p => p.FileName == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(p => p.FileName.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(p => value.Contains(p.FileName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(p => p.FileName.Contains(value) || value.Contains(p.FileName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(p => p.FileName.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(p => value.StartsWith(p.FileName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(p => p.FileName.StartsWith(value) || value.StartsWith(p.FileName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(p => p.FileName.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(p => value.EndsWith(p.FileName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(p => p.FileName.EndsWith(value) || value.EndsWith(p.FileName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PictureQuery WithMimeType(string value = null,
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
							Entities = Entities.Where(p => p.MimeType == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(p => p.MimeType.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(p => value.Contains(p.MimeType));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(p => p.MimeType.Contains(value) || value.Contains(p.MimeType));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(p => p.MimeType.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(p => value.StartsWith(p.MimeType));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(p => p.MimeType.StartsWith(value) || value.StartsWith(p.MimeType));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(p => p.MimeType.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(p => value.EndsWith(p.MimeType));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(p => p.MimeType.EndsWith(value) || value.EndsWith(p.MimeType));
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