namespace FaraMedia.Services.Querying.Fundamentals {
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.FileManagement;
	using FaraMedia.Core.Domain.Fundamentals;
	using FaraMedia.Core.Operators;

	public sealed class PhotoQuery : UIElementQueryBase<Photo, PhotoQuery> {
		public PhotoQuery(IEnumerable<Photo> entities) : base(entities) {}

		public PhotoQuery(IQueryable<Photo> entities) : base(entities) {}

		public PhotoQuery WithTitle(string value = null,
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
							Entities = Entities.Where(p => p.Title == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(p => p.Title.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(p => value.Contains(p.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(p => p.Title.Contains(value) || value.Contains(p.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(p => p.Title.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(p => value.StartsWith(p.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(p => p.Title.StartsWith(value) || value.StartsWith(p.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(p => p.Title.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(p => value.EndsWith(p.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(p => p.Title.EndsWith(value) || value.EndsWith(p.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PhotoQuery WithDescription(string value = null,
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
							Entities = Entities.Where(p => p.Description == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(p => p.Description.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(p => value.Contains(p.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(p => p.Description.Contains(value) || value.Contains(p.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(p => p.Description.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(p => value.StartsWith(p.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(p => p.Description.StartsWith(value) || value.StartsWith(p.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(p => p.Description.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(p => value.EndsWith(p.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(p => p.Description.EndsWith(value) || value.EndsWith(p.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PhotoQuery WithAlbum(Album value = null,
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
					Entities = Entities.Where(p => p.Album == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(p => p.Album != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PhotoQuery WithAlbumId(long? value = null,
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
					Entities = Entities.Where(p => p.Album.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(p => p.Album.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(p => p.Album.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(p => p.Album.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(p => p.Album.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(p => p.Album.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PhotoQuery WithPicture(Picture value = null,
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
					Entities = Entities.Where(p => p.Picture == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(p => p.Picture != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PhotoQuery WithPictureId(long? value = null,
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
					Entities = Entities.Where(p => p.Picture.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(p => p.Picture.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(p => p.Picture.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(p => p.Picture.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(p => p.Picture.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(p => p.Picture.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}
	}
}