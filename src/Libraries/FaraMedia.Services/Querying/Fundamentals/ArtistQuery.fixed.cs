namespace FaraMedia.Services.Querying.Fundamentals {
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.FileManagement;
	using FaraMedia.Core.Domain.Fundamentals;
	using FaraMedia.Core.Domain.Misc;
	using FaraMedia.Core.Operators;

	public sealed class ArtistQuery : UIElementQueryBase<Artist, ArtistQuery> {
		public ArtistQuery(IEnumerable<Artist> entities) : base(entities) {}

		public ArtistQuery(IQueryable<Artist> entities) : base(entities) {}

		public ArtistQuery WithFullName(string value = null,
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
							Entities = Entities.Where(a => a.FullName == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(a => a.FullName.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(a => value.Contains(a.FullName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(a => a.FullName.Contains(value) || value.Contains(a.FullName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(a => a.FullName.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(a => value.StartsWith(a.FullName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(a => a.FullName.StartsWith(value) || value.StartsWith(a.FullName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(a => a.FullName.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(a => value.EndsWith(a.FullName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(a => a.FullName.EndsWith(value) || value.EndsWith(a.FullName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ArtistQuery WithAlternativeName(string value = null,
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
							Entities = Entities.Where(a => a.AlternativeName == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(a => a.AlternativeName.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(a => value.Contains(a.AlternativeName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(a => a.AlternativeName.Contains(value) || value.Contains(a.AlternativeName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(a => a.AlternativeName.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(a => value.StartsWith(a.AlternativeName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(a => a.AlternativeName.StartsWith(value) || value.StartsWith(a.AlternativeName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(a => a.AlternativeName.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(a => value.EndsWith(a.AlternativeName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(a => a.AlternativeName.EndsWith(value) || value.EndsWith(a.AlternativeName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ArtistQuery WithHomeTown(string value = null,
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
							Entities = Entities.Where(a => a.HomeTown == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(a => a.HomeTown.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(a => value.Contains(a.HomeTown));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(a => a.HomeTown.Contains(value) || value.Contains(a.HomeTown));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(a => a.HomeTown.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(a => value.StartsWith(a.HomeTown));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(a => a.HomeTown.StartsWith(value) || value.StartsWith(a.HomeTown));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(a => a.HomeTown.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(a => value.EndsWith(a.HomeTown));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(a => a.HomeTown.EndsWith(value) || value.EndsWith(a.HomeTown));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ArtistQuery WithBiography(string value = null,
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
							Entities = Entities.Where(a => a.Biography == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(a => a.Biography.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(a => value.Contains(a.Biography));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(a => a.Biography.Contains(value) || value.Contains(a.Biography));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(a => a.Biography.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(a => value.StartsWith(a.Biography));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(a => a.Biography.StartsWith(value) || value.StartsWith(a.Biography));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(a => a.Biography.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(a => value.EndsWith(a.Biography));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(a => a.Biography.EndsWith(value) || value.EndsWith(a.Biography));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ArtistQuery WithBirthDateUtc(DateTime? value = null,
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
					Entities = Entities.Where(a => a.BirthDateUtc == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(a => a.BirthDateUtc != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(a => a.BirthDateUtc >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(a => a.BirthDateUtc > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(a => a.BirthDateUtc <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(a => a.BirthDateUtc < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ArtistQuery WithBirthDateUtcBetween(DateTime? from = null,
		                                           ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                           DateTime? to = null,
		                                           ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                           RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(a => a.BirthDateUtc >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(a => a.BirthDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(a => a.BirthDateUtc <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(a => a.BirthDateUtc == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(a => a.BirthDateUtc <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(a => a.BirthDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(a => a.BirthDateUtc >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(a => a.BirthDateUtc == to);
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

		public ArtistQuery WithFacebook(Redirector value = null,
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
					Entities = Entities.Where(a => a.Facebook == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(a => a.Facebook != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ArtistQuery WithFacebookId(long? value = null,
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
					Entities = Entities.Where(a => a.Facebook.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(a => a.Facebook.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(a => a.Facebook.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(a => a.Facebook.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(a => a.Facebook.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(a => a.Facebook.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ArtistQuery WithAvatar(Picture value = null,
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
					Entities = Entities.Where(a => a.Avatar == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(a => a.Avatar != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ArtistQuery WithAvatarId(long? value = null,
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
					Entities = Entities.Where(a => a.Avatar.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(a => a.Avatar.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(a => a.Avatar.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(a => a.Avatar.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(a => a.Avatar.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(a => a.Avatar.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ArtistQuery WithSingedTrack(Track value = null,
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
							Entities = Entities.Where(a => a.SingedTracks.Any(t => t == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(a => a.SingedTracks.All(t => t == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(a => a.SingedTracks.Any(t => t != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(a => a.SingedTracks.All(t => t != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ArtistQuery WithSingedTrackId(long? value = null,
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
							Entities = Entities.Where(a => a.SingedTracks.Any(t => t.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(a => a.SingedTracks.All(t => t.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(a => a.SingedTracks.Any(t => t.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(a => a.SingedTracks.All(t => t.Id != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ArtistQuery WithComposedTrack(Track value = null,
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
							Entities = Entities.Where(a => a.ComposedTracks.Any(t => t == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(a => a.ComposedTracks.All(t => t == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(a => a.ComposedTracks.Any(t => t != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(a => a.ComposedTracks.All(t => t != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ArtistQuery WithComposedTrackId(long? value = null,
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
							Entities = Entities.Where(a => a.ComposedTracks.Any(t => t.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(a => a.ComposedTracks.All(t => t.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(a => a.ComposedTracks.Any(t => t.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(a => a.ComposedTracks.All(t => t.Id != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ArtistQuery WithArrangedTrack(Track value = null,
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
							Entities = Entities.Where(a => a.ArrangedTracks.Any(t => t == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(a => a.ArrangedTracks.All(t => t == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(a => a.ArrangedTracks.Any(t => t != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(a => a.ArrangedTracks.All(t => t != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ArtistQuery WithArrangedTrackId(long? value = null,
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
							Entities = Entities.Where(a => a.ArrangedTracks.Any(t => t.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(a => a.ArrangedTracks.All(t => t.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(a => a.ArrangedTracks.Any(t => t.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(a => a.ArrangedTracks.All(t => t.Id != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ArtistQuery WithSongwrittenTrack(Track value = null,
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
							Entities = Entities.Where(a => a.SongwrittenTracks.Any(t => t == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(a => a.SongwrittenTracks.All(t => t == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(a => a.SongwrittenTracks.Any(t => t != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(a => a.SongwrittenTracks.All(t => t != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public ArtistQuery WithSongwrittenTrackId(long? value = null,
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
							Entities = Entities.Where(a => a.SongwrittenTracks.Any(t => t.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(a => a.SongwrittenTracks.All(t => t.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(a => a.SongwrittenTracks.Any(t => t.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(a => a.SongwrittenTracks.All(t => t.Id != value));
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