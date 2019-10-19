namespace FaraMedia.Services.Querying.Fundamentals {
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.FileManagement;
	using FaraMedia.Core.Domain.Fundamentals;
	using FaraMedia.Core.Domain.Misc;
	using FaraMedia.Core.Operators;

	public sealed class PublisherQuery : UIElementQueryBase<Publisher, PublisherQuery> {
		public PublisherQuery(IEnumerable<Publisher> entities) : base(entities) {}

		public PublisherQuery(IQueryable<Publisher> entities) : base(entities) {}

		public PublisherQuery WithName(string value = null,
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
							Entities = Entities.Where(p => p.Name == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(p => p.Name.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(p => value.Contains(p.Name));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(p => p.Name.Contains(value) || value.Contains(p.Name));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(p => p.Name.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(p => value.StartsWith(p.Name));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(p => p.Name.StartsWith(value) || value.StartsWith(p.Name));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(p => p.Name.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(p => value.EndsWith(p.Name));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(p => p.Name.EndsWith(value) || value.EndsWith(p.Name));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PublisherQuery WithCeo(string value = null,
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
							Entities = Entities.Where(p => p.Ceo == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(p => p.Ceo.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(p => value.Contains(p.Ceo));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(p => p.Ceo.Contains(value) || value.Contains(p.Ceo));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(p => p.Ceo.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(p => value.StartsWith(p.Ceo));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(p => p.Ceo.StartsWith(value) || value.StartsWith(p.Ceo));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(p => p.Ceo.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(p => value.EndsWith(p.Ceo));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(p => p.Ceo.EndsWith(value) || value.EndsWith(p.Ceo));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PublisherQuery WithRegisterationNumber(string value = null,
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
							Entities = Entities.Where(p => p.RegisterationNumber == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(p => p.RegisterationNumber.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(p => value.Contains(p.RegisterationNumber));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(p => p.RegisterationNumber.Contains(value) || value.Contains(p.RegisterationNumber));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(p => p.RegisterationNumber.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(p => value.StartsWith(p.RegisterationNumber));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(p => p.RegisterationNumber.StartsWith(value) || value.StartsWith(p.RegisterationNumber));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(p => p.RegisterationNumber.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(p => value.EndsWith(p.RegisterationNumber));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(p => p.RegisterationNumber.EndsWith(value) || value.EndsWith(p.RegisterationNumber));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PublisherQuery WithEmail(string value = null,
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
							Entities = Entities.Where(p => p.Email == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(p => p.Email.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(p => value.Contains(p.Email));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(p => p.Email.Contains(value) || value.Contains(p.Email));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(p => p.Email.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(p => value.StartsWith(p.Email));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(p => p.Email.StartsWith(value) || value.StartsWith(p.Email));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(p => p.Email.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(p => value.EndsWith(p.Email));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(p => p.Email.EndsWith(value) || value.EndsWith(p.Email));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PublisherQuery WithBriefHistory(string value = null,
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
							Entities = Entities.Where(p => p.BriefHistory == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(p => p.BriefHistory.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(p => value.Contains(p.BriefHistory));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(p => p.BriefHistory.Contains(value) || value.Contains(p.BriefHistory));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(p => p.BriefHistory.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(p => value.StartsWith(p.BriefHistory));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(p => p.BriefHistory.StartsWith(value) || value.StartsWith(p.BriefHistory));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(p => p.BriefHistory.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(p => value.EndsWith(p.BriefHistory));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(p => p.BriefHistory.EndsWith(value) || value.EndsWith(p.BriefHistory));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PublisherQuery WithWebsite(Redirector value = null,
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
					Entities = Entities.Where(p => p.Website == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(p => p.Website != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PublisherQuery WithWebsiteId(long? value = null,
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
					Entities = Entities.Where(p => p.Website.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(p => p.Website.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(p => p.Website.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(p => p.Website.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(p => p.Website.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(p => p.Website.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PublisherQuery WithLogo(Picture value = null,
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
					Entities = Entities.Where(p => p.Logo == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(p => p.Logo != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PublisherQuery WithLogoId(long? value = null,
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
					Entities = Entities.Where(p => p.Logo.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(p => p.Logo.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(p => p.Logo.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(p => p.Logo.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(p => p.Logo.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(p => p.Logo.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PublisherQuery WithTrack(Track value = null,
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
							Entities = Entities.Where(p => p.Tracks.Any(t => t == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(p => p.Tracks.All(t => t == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(p => p.Tracks.Any(t => t != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(p => p.Tracks.All(t => t != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PublisherQuery WithTrackId(long? value = null,
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
							Entities = Entities.Where(p => p.Tracks.Any(t => t.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(p => p.Tracks.All(t => t.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(p => p.Tracks.Any(t => t.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(p => p.Tracks.All(t => t.Id != value));
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