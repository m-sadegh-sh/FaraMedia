namespace FaraMedia.Services.Querying.Fundamentals {
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.Fundamentals;
	using FaraMedia.Core.Operators;

	public sealed class PhotoAlbumQuery : UIElementQueryBase<PhotoAlbum, PhotoAlbumQuery> {
		public PhotoAlbumQuery(IEnumerable<PhotoAlbum> entities) : base(entities) {}

		public PhotoAlbumQuery(IQueryable<PhotoAlbum> entities) : base(entities) {}

		public PhotoAlbumQuery WithTitle(string value = null,
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
							Entities = Entities.Where(pa => pa.Title == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(pa => pa.Title.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(pa => value.Contains(pa.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(pa => pa.Title.Contains(value) || value.Contains(pa.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(pa => pa.Title.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(pa => value.StartsWith(pa.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(pa => pa.Title.StartsWith(value) || value.StartsWith(pa.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(pa => pa.Title.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(pa => value.EndsWith(pa.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(pa => pa.Title.EndsWith(value) || value.EndsWith(pa.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PhotoAlbumQuery WithDescription(string value = null,
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
							Entities = Entities.Where(pa => pa.Description == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(pa => pa.Description.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(pa => value.Contains(pa.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(pa => pa.Description.Contains(value) || value.Contains(pa.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(pa => pa.Description.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(pa => value.StartsWith(pa.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(pa => pa.Description.StartsWith(value) || value.StartsWith(pa.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(pa => pa.Description.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(pa => value.EndsWith(pa.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(pa => pa.Description.EndsWith(value) || value.EndsWith(pa.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PhotoAlbumQuery WithArtist(Artist value = null,
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
					Entities = Entities.Where(pa => pa.Artist == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(pa => pa.Artist != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PhotoAlbumQuery WithArtistId(long? value = null,
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
					Entities = Entities.Where(pa => pa.Artist.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(pa => pa.Artist.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(pa => pa.Artist.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(pa => pa.Artist.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(pa => pa.Artist.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(pa => pa.Artist.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PhotoAlbumQuery WithPhoto(Photo value = null,
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
							Entities = Entities.Where(pa => pa.Photos.Any(p => p == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(pa => pa.Photos.All(p => p == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(pa => pa.Photos.Any(p => p != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(pa => pa.Photos.All(p => p != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PhotoAlbumQuery WithPhotoId(long? value = null,
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
							Entities = Entities.Where(pa => pa.Photos.Any(p => p.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(pa => pa.Photos.All(p => p.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(pa => pa.Photos.Any(p => p.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(pa => pa.Photos.All(p => p.Id != value));
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