namespace FaraMedia.Services.Querying.FileManagement {
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.FileManagement;
	using FaraMedia.Core.Domain.Misc;
	using FaraMedia.Core.Operators;

	public sealed class DownloadQuery : UserContentQueryBase<Download, DownloadQuery> {
		public DownloadQuery(IEnumerable<Download> entities) : base(entities) {}

		public DownloadQuery(IQueryable<Download> entities) : base(entities) {}

		public DownloadQuery WithUseDownloadUrl(bool? value = null,
		                                        ArgumentEvaluationMode mode = ArgumentEvaluationMode.IgnoreNeutral,
		                                        BoolOperator @operator = BoolOperator.Equal) {
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
				case BoolOperator.Equal:
					Entities = Entities.Where(d => d.UseDownloadUrl == value);
					return this;

				case BoolOperator.NotEqual:
					Entities = Entities.Where(d => d.UseDownloadUrl != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public DownloadQuery WithFileName(string value = null,
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
							Entities = Entities.Where(d => d.FileName == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(d => d.FileName.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(d => value.Contains(d.FileName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(d => d.FileName.Contains(value) || value.Contains(d.FileName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(d => d.FileName.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(d => value.StartsWith(d.FileName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(d => d.FileName.StartsWith(value) || value.StartsWith(d.FileName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(d => d.FileName.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(d => value.EndsWith(d.FileName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(d => d.FileName.EndsWith(value) || value.EndsWith(d.FileName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public DownloadQuery WithContentType(string value = null,
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
							Entities = Entities.Where(d => d.ContentType == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(d => d.ContentType.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(d => value.Contains(d.ContentType));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(d => d.ContentType.Contains(value) || value.Contains(d.ContentType));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(d => d.ContentType.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(d => value.StartsWith(d.ContentType));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(d => d.ContentType.StartsWith(value) || value.StartsWith(d.ContentType));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(d => d.ContentType.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(d => value.EndsWith(d.ContentType));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(d => d.ContentType.EndsWith(value) || value.EndsWith(d.ContentType));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public DownloadQuery WithContentLength(long? value = null,
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
					Entities = Entities.Where(d => d.ContentLength == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(d => d.ContentLength != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(d => d.ContentLength >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(d => d.ContentLength > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(d => d.ContentLength <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(d => d.ContentLength < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public DownloadQuery WithContentLengthBetween(long? from = null,
		                                              ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                              long? to = null,
		                                              ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                              RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(d => d.ContentLength >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(d => d.ContentLength == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(d => d.ContentLength <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(d => d.ContentLength == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(d => d.ContentLength <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(d => d.ContentLength == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(d => d.ContentLength >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(d => d.ContentLength == to);
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

		public DownloadQuery WithChecksum(string value = null,
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
							Entities = Entities.Where(d => d.Checksum == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(d => d.Checksum.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(d => value.Contains(d.Checksum));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(d => d.Checksum.Contains(value) || value.Contains(d.Checksum));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(d => d.Checksum.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(d => value.StartsWith(d.Checksum));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(d => d.Checksum.StartsWith(value) || value.StartsWith(d.Checksum));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(d => d.Checksum.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(d => value.EndsWith(d.Checksum));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(d => d.Checksum.EndsWith(value) || value.EndsWith(d.Checksum));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public DownloadQuery WithDownloadUrl(Redirector value = null,
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
					Entities = Entities.Where(d => d.DownloadUrl == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(d => d.DownloadUrl != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public DownloadQuery WithDownloadUrlId(long? value = null,
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
					Entities = Entities.Where(d => d.DownloadUrl.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(d => d.DownloadUrl.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(d => d.DownloadUrl.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(d => d.DownloadUrl.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(d => d.DownloadUrl.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(d => d.DownloadUrl.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}
	}
}