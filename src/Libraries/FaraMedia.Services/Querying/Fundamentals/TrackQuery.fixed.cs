namespace FaraMedia.Services.Querying.Fundamentals {
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.FileManagement;
	using FaraMedia.Core.Domain.Fundamentals;
	using FaraMedia.Core.Operators;

	public sealed class TrackQuery : UIElementQueryBase<Track, TrackQuery> {
		public TrackQuery(IEnumerable<Track> entities) : base(entities) {}

		public TrackQuery(IQueryable<Track> entities) : base(entities) {}

		public TrackQuery WithTitle(string value = null,
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
							Entities = Entities.Where(t => t.Title == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(t => t.Title.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(t => value.Contains(t.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(t => t.Title.Contains(value) || value.Contains(t.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(t => t.Title.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(t => value.StartsWith(t.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(t => t.Title.StartsWith(value) || value.StartsWith(t.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(t => t.Title.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(t => value.EndsWith(t.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(t => t.Title.EndsWith(value) || value.EndsWith(t.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TrackQuery WithDescription(string value = null,
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
							Entities = Entities.Where(t => t.Description == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(t => t.Description.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(t => value.Contains(t.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(t => t.Description.Contains(value) || value.Contains(t.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(t => t.Description.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(t => value.StartsWith(t.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(t => t.Description.StartsWith(value) || value.StartsWith(t.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(t => t.Description.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(t => value.EndsWith(t.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(t => t.Description.EndsWith(value) || value.EndsWith(t.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TrackQuery WithIsVideo(bool? value = null,
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
					Entities = Entities.Where(t => t.IsVideo == value);
					return this;

				case BoolOperator.NotEqual:
					Entities = Entities.Where(t => t.IsVideo != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TrackQuery WithTrackNumber(int? value = null,
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
					Entities = Entities.Where(t => t.TrackNumber == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(t => t.TrackNumber != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(t => t.TrackNumber >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(t => t.TrackNumber > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(t => t.TrackNumber <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(t => t.TrackNumber < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TrackQuery WithTrackNumberBetween(int? from = null,
		                                         ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                         int? to = null,
		                                         ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                         RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(t => t.TrackNumber >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(t => t.TrackNumber == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(t => t.TrackNumber <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(t => t.TrackNumber == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(t => t.TrackNumber <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(t => t.TrackNumber == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(t => t.TrackNumber >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(t => t.TrackNumber == to);
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

		public TrackQuery WithReleaseDateUtc(DateTime? value = null,
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
					Entities = Entities.Where(t => t.ReleaseDateUtc == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(t => t.ReleaseDateUtc != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(t => t.ReleaseDateUtc >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(t => t.ReleaseDateUtc > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(t => t.ReleaseDateUtc <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(t => t.ReleaseDateUtc < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TrackQuery WithReleaseDateUtcBetween(DateTime? from = null,
		                                            ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                            DateTime? to = null,
		                                            ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                            RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(t => t.ReleaseDateUtc >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(t => t.ReleaseDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(t => t.ReleaseDateUtc <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(t => t.ReleaseDateUtc == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(t => t.ReleaseDateUtc <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(t => t.ReleaseDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(t => t.ReleaseDateUtc >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(t => t.ReleaseDateUtc == to);
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

		public TrackQuery WithGenre(Genre value = null,
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
					Entities = Entities.Where(t => t.Genre == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(t => t.Genre != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TrackQuery WithGenreId(long? value = null,
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
					Entities = Entities.Where(t => t.Genre.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(t => t.Genre.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(t => t.Genre.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(t => t.Genre.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(t => t.Genre.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(t => t.Genre.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TrackQuery WithAlbum(Album value = null,
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
					Entities = Entities.Where(t => t.Album == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(t => t.Album != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TrackQuery WithAlbumId(long? value = null,
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
					Entities = Entities.Where(t => t.Album.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(t => t.Album.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(t => t.Album.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(t => t.Album.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(t => t.Album.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(t => t.Album.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TrackQuery WithPublisher(Publisher value = null,
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
					Entities = Entities.Where(t => t.Publisher == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(t => t.Publisher != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TrackQuery WithPublisherId(long? value = null,
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
					Entities = Entities.Where(t => t.Publisher.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(t => t.Publisher.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(t => t.Publisher.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(t => t.Publisher.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(t => t.Publisher.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(t => t.Publisher.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TrackQuery WithCover(Picture value = null,
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
							Entities = Entities.Where(t => t.Covers.Any(p => p == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(t => t.Covers.All(p => p == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(t => t.Covers.Any(p => p != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(t => t.Covers.All(p => p != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TrackQuery WithCoverId(long? value = null,
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
							Entities = Entities.Where(t => t.Covers.Any(p => p.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(t => t.Covers.All(p => p.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(t => t.Covers.Any(p => p.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(t => t.Covers.All(p => p.Id != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TrackQuery WithDownload(Download value = null,
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
							Entities = Entities.Where(t => t.Downloads.Any(d => d == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(t => t.Downloads.All(d => d == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(t => t.Downloads.Any(d => d != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(t => t.Downloads.All(d => d != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TrackQuery WithDownloadId(long? value = null,
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
							Entities = Entities.Where(t => t.Downloads.Any(d => d.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(t => t.Downloads.All(d => d.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(t => t.Downloads.Any(d => d.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(t => t.Downloads.All(d => d.Id != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TrackQuery WithSinger(Artist value = null,
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
							Entities = Entities.Where(t => t.Singers.Any(a => a == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(t => t.Singers.All(a => a == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(t => t.Singers.Any(a => a != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(t => t.Singers.All(a => a != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TrackQuery WithSingerId(long? value = null,
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
							Entities = Entities.Where(t => t.Singers.Any(a => a.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(t => t.Singers.All(a => a.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(t => t.Singers.Any(a => a.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(t => t.Singers.All(a => a.Id != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TrackQuery WithComposer(Artist value = null,
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
							Entities = Entities.Where(t => t.Composers.Any(a => a == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(t => t.Composers.All(a => a == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(t => t.Composers.Any(a => a != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(t => t.Composers.All(a => a != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TrackQuery WithComposerId(long? value = null,
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
							Entities = Entities.Where(t => t.Composers.Any(a => a.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(t => t.Composers.All(a => a.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(t => t.Composers.Any(a => a.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(t => t.Composers.All(a => a.Id != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TrackQuery WithArrangementer(Artist value = null,
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
							Entities = Entities.Where(t => t.Arrangementers.Any(a => a == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(t => t.Arrangementers.All(a => a == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(t => t.Arrangementers.Any(a => a != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(t => t.Arrangementers.All(a => a != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TrackQuery WithArrangementerId(long? value = null,
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
							Entities = Entities.Where(t => t.Arrangementers.Any(a => a.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(t => t.Arrangementers.All(a => a.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(t => t.Arrangementers.Any(a => a.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(t => t.Arrangementers.All(a => a.Id != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TrackQuery WithSongwriter(Artist value = null,
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
							Entities = Entities.Where(t => t.Songwriters.Any(a => a == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(t => t.Songwriters.All(a => a == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(t => t.Songwriters.Any(a => a != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(t => t.Songwriters.All(a => a != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TrackQuery WithSongwriterId(long? value = null,
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
							Entities = Entities.Where(t => t.Songwriters.Any(a => a.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(t => t.Songwriters.All(a => a.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(t => t.Songwriters.Any(a => a.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(t => t.Songwriters.All(a => a.Id != value));
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