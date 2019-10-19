namespace FaraMedia.Services.Querying.Misc {
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.FileManagement;
	using FaraMedia.Core.Domain.Fundamentals;
	using FaraMedia.Core.Domain.Misc;
	using FaraMedia.Core.Operators;

	public sealed class RedirectorQuery : EntityQueryBase<Redirector, RedirectorQuery> {
		public RedirectorQuery(IEnumerable<Redirector> entities) : base(entities) {}

		public RedirectorQuery(IQueryable<Redirector> entities) : base(entities) {}

		public RedirectorQuery WithTargetUrl(string value = null,
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
							Entities = Entities.Where(r => r.TargetUrl == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(r => r.TargetUrl.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(r => value.Contains(r.TargetUrl));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(r => r.TargetUrl.Contains(value) || value.Contains(r.TargetUrl));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(r => r.TargetUrl.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(r => value.StartsWith(r.TargetUrl));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(r => r.TargetUrl.StartsWith(value) || value.StartsWith(r.TargetUrl));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(r => r.TargetUrl.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(r => value.EndsWith(r.TargetUrl));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(r => r.TargetUrl.EndsWith(value) || value.EndsWith(r.TargetUrl));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public RedirectorQuery WithShortHash(string value = null,
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
							Entities = Entities.Where(r => r.ShortHash == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(r => r.ShortHash.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(r => value.Contains(r.ShortHash));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(r => r.ShortHash.Contains(value) || value.Contains(r.ShortHash));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(r => r.ShortHash.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(r => value.StartsWith(r.ShortHash));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(r => r.ShortHash.StartsWith(value) || value.StartsWith(r.ShortHash));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(r => r.ShortHash.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(r => value.EndsWith(r.ShortHash));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(r => r.ShortHash.EndsWith(value) || value.EndsWith(r.ShortHash));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public RedirectorQuery WithUrlName(string value = null,
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
							Entities = Entities.Where(r => r.UrlName == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(r => r.UrlName.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(r => value.Contains(r.UrlName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(r => r.UrlName.Contains(value) || value.Contains(r.UrlName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(r => r.UrlName.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(r => value.StartsWith(r.UrlName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(r => r.UrlName.StartsWith(value) || value.StartsWith(r.UrlName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(r => r.UrlName.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(r => value.EndsWith(r.UrlName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(r => r.UrlName.EndsWith(value) || value.EndsWith(r.UrlName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public RedirectorQuery WithDescription(string value = null,
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
							Entities = Entities.Where(r => r.Description == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(r => r.Description.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(r => value.Contains(r.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(r => r.Description.Contains(value) || value.Contains(r.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(r => r.Description.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(r => value.StartsWith(r.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(r => r.Description.StartsWith(value) || value.StartsWith(r.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(r => r.Description.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(r => value.EndsWith(r.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(r => r.Description.EndsWith(value) || value.EndsWith(r.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public RedirectorQuery WithUsageTimes(int? value = null,
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
					Entities = Entities.Where(r => r.UsageTimes == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(r => r.UsageTimes != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(r => r.UsageTimes >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(r => r.UsageTimes > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(r => r.UsageTimes <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(r => r.UsageTimes < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public RedirectorQuery WithUsageTimesBetween(int? from = null,
		                                             ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                             int? to = null,
		                                             ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                             RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(r => r.UsageTimes >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(r => r.UsageTimes == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(r => r.UsageTimes <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(r => r.UsageTimes == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(r => r.UsageTimes <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(r => r.UsageTimes == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(r => r.UsageTimes >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(r => r.UsageTimes == to);
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

		public RedirectorQuery WithDownload(Download value = null,
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
							Entities = Entities.Where(r => r.Downloads.Any(d => d == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(r => r.Downloads.All(d => d == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(r => r.Downloads.Any(d => d != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(r => r.Downloads.All(d => d != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public RedirectorQuery WithDownloadId(long? value = null,
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
							Entities = Entities.Where(r => r.Downloads.Any(d => d.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(r => r.Downloads.All(d => d.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(r => r.Downloads.Any(d => d.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(r => r.Downloads.All(d => d.Id != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public RedirectorQuery WithArtist(Artist value = null,
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
							Entities = Entities.Where(r => r.Artists.Any(a => a == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(r => r.Artists.All(a => a == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(r => r.Artists.Any(a => a != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(r => r.Artists.All(a => a != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public RedirectorQuery WithArtistId(long? value = null,
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
							Entities = Entities.Where(r => r.Artists.Any(a => a.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(r => r.Artists.All(a => a.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(r => r.Artists.Any(a => a.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(r => r.Artists.All(a => a.Id != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public RedirectorQuery WithPublisher(Publisher value = null,
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
							Entities = Entities.Where(r => r.Publishers.Any(p => p == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(r => r.Publishers.All(p => p == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(r => r.Publishers.Any(p => p != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(r => r.Publishers.All(p => p != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public RedirectorQuery WithPublisherId(long? value = null,
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
							Entities = Entities.Where(r => r.Publishers.Any(p => p.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(r => r.Publishers.All(p => p.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(r => r.Publishers.Any(p => p.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(r => r.Publishers.All(p => p.Id != value));
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