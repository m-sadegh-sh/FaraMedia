namespace FaraMedia.Services.Querying {
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain;
	using FaraMedia.Core.Domain.Security;
	using FaraMedia.Core.Operators;

	public abstract class UIElementQueryBase<TEntity, TQuery> : UserContentQueryBase<TEntity, TQuery> where TEntity : UIElementBase
	                                                                                                  where TQuery : UIElementQueryBase<TEntity, TQuery> {
		protected UIElementQueryBase(IEnumerable<TEntity> entities) : base(entities) {}

		protected UIElementQueryBase(IQueryable<TEntity> entities) : base(entities) {}

		public TQuery WithDisplayOrder(short? value = null,
		                               ArgumentEvaluationMode mode = ArgumentEvaluationMode.IgnoreNeutral,
		                               IntegralOperator @operator = IntegralOperator.Equal) {
			switch (mode) {
				case ArgumentEvaluationMode.IgnoreNeutral:
					if (Neutrals.Is(value))
						return (TQuery) this;
					break;

				case ArgumentEvaluationMode.Explicit:
					break;

				default:
					throw new NotSupportedEnumException(mode);
			}

			switch (@operator) {
				case IntegralOperator.Equal:
					Entities = Entities.Where(uie => uie.DisplayOrder == value);
					return (TQuery) this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(uie => uie.DisplayOrder != value);
					return (TQuery) this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(uie => uie.DisplayOrder >= value);
					return (TQuery) this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(uie => uie.DisplayOrder > value);
					return (TQuery) this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(uie => uie.DisplayOrder <= value);
					return (TQuery) this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(uie => uie.DisplayOrder < value);
					return (TQuery) this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TQuery WithDisplayOrderBetween(short? from = null,
		                                      ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                      short? to = null,
		                                      ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                      RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(uie => uie.DisplayOrder >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(uie => uie.DisplayOrder == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(uie => uie.DisplayOrder <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(uie => uie.DisplayOrder == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(uie => uie.DisplayOrder <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(uie => uie.DisplayOrder == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(uie => uie.DisplayOrder >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(uie => uie.DisplayOrder == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				default:
					throw new NotSupportedEnumException(@operator);
			}

			return (TQuery) this;
		}

		public TQuery WithOwner(Role value = null,
		                        ArgumentEvaluationMode mode = ArgumentEvaluationMode.IgnoreNeutral,
		                        EntityOperator @operator = EntityOperator.Equal) {
			switch (mode) {
				case ArgumentEvaluationMode.IgnoreNeutral:
					if (Neutrals.Is(value))
						return (TQuery) this;
					break;

				case ArgumentEvaluationMode.Explicit:
					break;

				default:
					throw new NotSupportedEnumException(mode);
			}

			switch (@operator) {
				case EntityOperator.Equal:
					Entities = Entities.Where(uie => uie.Owner == value);
					return (TQuery) this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(uie => uie.Owner != value);
					return (TQuery) this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TQuery WithOwnerId(long? value = null,
		                          ArgumentEvaluationMode mode = ArgumentEvaluationMode.IgnoreNeutral,
		                          IntegralOperator @operator = IntegralOperator.Equal) {
			switch (mode) {
				case ArgumentEvaluationMode.IgnoreNeutral:
					if (Neutrals.Is(value))
						return (TQuery) this;
					break;

				case ArgumentEvaluationMode.Explicit:
					break;

				default:
					throw new NotSupportedEnumException(mode);
			}

			switch (@operator) {
				case IntegralOperator.Equal:
					Entities = Entities.Where(uie => uie.Owner.Id == value);
					return (TQuery) this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(uie => uie.Owner.Id != value);
					return (TQuery) this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(uie => uie.Owner.Id >= value);
					return (TQuery) this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(uie => uie.Owner.Id > value);
					return (TQuery) this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(uie => uie.Owner.Id <= value);
					return (TQuery) this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(uie => uie.Owner.Id < value);
					return (TQuery) this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TQuery WithOwnerIdBetween(long? from = null,
		                                 ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                 long? to = null,
		                                 ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                 RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(uie => uie.Owner.Id >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(uie => uie.Owner.Id == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(uie => uie.Owner.Id <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(uie => uie.Owner.Id == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(uie => uie.Owner.Id <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(uie => uie.Owner.Id == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(uie => uie.Owner.Id >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(uie => uie.Owner.Id == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				default:
					throw new NotSupportedEnumException(@operator);
			}

			return (TQuery) this;
		}

		public TQuery WithMetadataTitle(string value = null,
		                                ArgumentEvaluationMode mode = ArgumentEvaluationMode.IgnoreNeutral,
		                                StringOperator @operator = StringOperator.Exact,
		                                StringDirection direction = StringDirection.SourceToExpected) {
			switch (mode) {
				case ArgumentEvaluationMode.IgnoreNeutral:
					if (Neutrals.Is(value))
						return (TQuery) this;
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
							Entities = Entities.Where(uie => uie.Metadata.Title == value);
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(uie => uie.Metadata.Title.Contains(value));
							return (TQuery) this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(uie => value.Contains(uie.Metadata.Title));
							return (TQuery) this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(uie => uie.Metadata.Title.Contains(value) || value.Contains(uie.Metadata.Title));
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(uie => uie.Metadata.Title.StartsWith(value));
							return (TQuery) this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(uie => value.StartsWith(uie.Metadata.Title));
							return (TQuery) this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(uie => uie.Metadata.Title.StartsWith(value) || value.StartsWith(uie.Metadata.Title));
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(uie => uie.Metadata.Title.EndsWith(value));
							return (TQuery) this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(uie => value.EndsWith(uie.Metadata.Title));
							return (TQuery) this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(uie => uie.Metadata.Title.EndsWith(value) || value.EndsWith(uie.Metadata.Title));
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TQuery WithMetadataSlug(string value = null,
		                               ArgumentEvaluationMode mode = ArgumentEvaluationMode.IgnoreNeutral,
		                               StringOperator @operator = StringOperator.Exact,
		                               StringDirection direction = StringDirection.SourceToExpected) {
			switch (mode) {
				case ArgumentEvaluationMode.IgnoreNeutral:
					if (Neutrals.Is(value))
						return (TQuery) this;
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
							Entities = Entities.Where(uie => uie.Metadata.Slug == value);
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(uie => uie.Metadata.Slug.Contains(value));
							return (TQuery) this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(uie => value.Contains(uie.Metadata.Slug));
							return (TQuery) this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(uie => uie.Metadata.Slug.Contains(value) || value.Contains(uie.Metadata.Slug));
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(uie => uie.Metadata.Slug.StartsWith(value));
							return (TQuery) this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(uie => value.StartsWith(uie.Metadata.Slug));
							return (TQuery) this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(uie => uie.Metadata.Slug.StartsWith(value) || value.StartsWith(uie.Metadata.Slug));
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(uie => uie.Metadata.Slug.EndsWith(value));
							return (TQuery) this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(uie => value.EndsWith(uie.Metadata.Slug));
							return (TQuery) this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(uie => uie.Metadata.Slug.EndsWith(value) || value.EndsWith(uie.Metadata.Slug));
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TQuery WithMetadataKeywords(string value = null,
		                                   ArgumentEvaluationMode mode = ArgumentEvaluationMode.IgnoreNeutral,
		                                   StringOperator @operator = StringOperator.Exact,
		                                   StringDirection direction = StringDirection.SourceToExpected) {
			switch (mode) {
				case ArgumentEvaluationMode.IgnoreNeutral:
					if (Neutrals.Is(value))
						return (TQuery) this;
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
							Entities = Entities.Where(uie => uie.Metadata.Keywords == value);
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(uie => uie.Metadata.Keywords.Contains(value));
							return (TQuery) this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(uie => value.Contains(uie.Metadata.Keywords));
							return (TQuery) this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(uie => uie.Metadata.Keywords.Contains(value) || value.Contains(uie.Metadata.Keywords));
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(uie => uie.Metadata.Keywords.StartsWith(value));
							return (TQuery) this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(uie => value.StartsWith(uie.Metadata.Keywords));
							return (TQuery) this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(uie => uie.Metadata.Keywords.StartsWith(value) || value.StartsWith(uie.Metadata.Keywords));
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(uie => uie.Metadata.Keywords.EndsWith(value));
							return (TQuery) this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(uie => value.EndsWith(uie.Metadata.Keywords));
							return (TQuery) this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(uie => uie.Metadata.Keywords.EndsWith(value) || value.EndsWith(uie.Metadata.Keywords));
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TQuery WithMetadataDescription(string value = null,
		                                      ArgumentEvaluationMode mode = ArgumentEvaluationMode.IgnoreNeutral,
		                                      StringOperator @operator = StringOperator.Exact,
		                                      StringDirection direction = StringDirection.SourceToExpected) {
			switch (mode) {
				case ArgumentEvaluationMode.IgnoreNeutral:
					if (Neutrals.Is(value))
						return (TQuery) this;
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
							Entities = Entities.Where(uie => uie.Metadata.Description == value);
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(uie => uie.Metadata.Description.Contains(value));
							return (TQuery) this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(uie => value.Contains(uie.Metadata.Description));
							return (TQuery) this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(uie => uie.Metadata.Description.Contains(value) || value.Contains(uie.Metadata.Description));
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(uie => uie.Metadata.Description.StartsWith(value));
							return (TQuery) this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(uie => value.StartsWith(uie.Metadata.Description));
							return (TQuery) this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(uie => uie.Metadata.Description.StartsWith(value) || value.StartsWith(uie.Metadata.Description));
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(uie => uie.Metadata.Description.EndsWith(value));
							return (TQuery) this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(uie => value.EndsWith(uie.Metadata.Description));
							return (TQuery) this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(uie => uie.Metadata.Description.EndsWith(value) || value.EndsWith(uie.Metadata.Description));
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TQuery WithDeleter(User value = null,
		                          ArgumentEvaluationMode mode = ArgumentEvaluationMode.IgnoreNeutral,
		                          EntityOperator @operator = EntityOperator.Equal) {
			switch (mode) {
				case ArgumentEvaluationMode.IgnoreNeutral:
					if (Neutrals.Is(value))
						return (TQuery) this;
					break;

				case ArgumentEvaluationMode.Explicit:
					break;

				default:
					throw new NotSupportedEnumException(mode);
			}

			switch (@operator) {
				case EntityOperator.Equal:
					Entities = Entities.Where(uie => uie.DeletionHistory.Invoker == value);
					return (TQuery) this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(uie => uie.DeletionHistory.Invoker != value);
					return (TQuery) this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TQuery WithDeleterId(long? value = null,
		                            ArgumentEvaluationMode mode = ArgumentEvaluationMode.IgnoreNeutral,
		                            IntegralOperator @operator = IntegralOperator.Equal) {
			switch (mode) {
				case ArgumentEvaluationMode.IgnoreNeutral:
					if (Neutrals.Is(value))
						return (TQuery) this;
					break;

				case ArgumentEvaluationMode.Explicit:
					break;

				default:
					throw new NotSupportedEnumException(mode);
			}

			switch (@operator) {
				case IntegralOperator.Equal:
					Entities = Entities.Where(uie => uie.DeletionHistory.Invoker.Id == value);
					return (TQuery) this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(uie => uie.DeletionHistory.Invoker.Id != value);
					return (TQuery) this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(uie => uie.DeletionHistory.Invoker.Id >= value);
					return (TQuery) this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(uie => uie.DeletionHistory.Invoker.Id > value);
					return (TQuery) this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(uie => uie.DeletionHistory.Invoker.Id <= value);
					return (TQuery) this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(uie => uie.DeletionHistory.Invoker.Id < value);
					return (TQuery) this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TQuery WithDeleterIdBetween(long? from = null,
		                                   ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                   long? to = null,
		                                   ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                   RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(uie => uie.DeletionHistory.Invoker.Id >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(uie => uie.DeletionHistory.Invoker.Id == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(uie => uie.DeletionHistory.Invoker.Id <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(uie => uie.DeletionHistory.Invoker.Id == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(uie => uie.DeletionHistory.Invoker.Id <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(uie => uie.DeletionHistory.Invoker.Id == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(uie => uie.DeletionHistory.Invoker.Id >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(uie => uie.DeletionHistory.Invoker.Id == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				default:
					throw new NotSupportedEnumException(@operator);
			}

			return (TQuery) this;
		}

		public TQuery WithDeleterIp(string value = null,
		                            ArgumentEvaluationMode mode = ArgumentEvaluationMode.IgnoreNeutral,
		                            StringOperator @operator = StringOperator.Exact,
		                            StringDirection direction = StringDirection.SourceToExpected) {
			switch (mode) {
				case ArgumentEvaluationMode.IgnoreNeutral:
					if (Neutrals.Is(value))
						return (TQuery) this;
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
							Entities = Entities.Where(uie => uie.DeletionHistory.InvokerIp == value);
							return (TQuery) this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(uie => uie.DeletionHistory.InvokerIp == value);
							return (TQuery) this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(uie => uie.DeletionHistory.InvokerIp == value);
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(uie => uie.DeletionHistory.InvokerIp.Contains(value));
							return (TQuery) this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(uie => value.Contains(uie.DeletionHistory.InvokerIp));
							return (TQuery) this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(uie => uie.DeletionHistory.InvokerIp.Contains(value) || value.Contains(uie.DeletionHistory.InvokerIp));
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(uie => uie.DeletionHistory.InvokerIp.StartsWith(value));
							return (TQuery) this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(uie => value.StartsWith(uie.DeletionHistory.InvokerIp));
							return (TQuery) this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(uie => uie.DeletionHistory.InvokerIp.StartsWith(value) || value.StartsWith(uie.DeletionHistory.InvokerIp));
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(uie => uie.DeletionHistory.InvokerIp.EndsWith(value));
							return (TQuery) this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(uie => value.EndsWith(uie.DeletionHistory.InvokerIp));
							return (TQuery) this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(uie => uie.DeletionHistory.InvokerIp.EndsWith(value) || value.EndsWith(uie.DeletionHistory.InvokerIp));
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TQuery WithDeleteDateUtc(DateTime? value = null,
		                                ArgumentEvaluationMode mode = ArgumentEvaluationMode.IgnoreNeutral,
		                                IntegralOperator @operator = IntegralOperator.Equal) {
			switch (mode) {
				case ArgumentEvaluationMode.IgnoreNeutral:
					if (Neutrals.Is(value))
						return (TQuery) this;
					break;

				case ArgumentEvaluationMode.Explicit:
					break;

				default:
					throw new NotSupportedEnumException(mode);
			}

			switch (@operator) {
				case IntegralOperator.Equal:
					Entities = Entities.Where(uie => uie.DeletionHistory.InvokeDateUtc == value);
					return (TQuery) this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(uie => uie.DeletionHistory.InvokeDateUtc != value);
					return (TQuery) this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(uie => uie.DeletionHistory.InvokeDateUtc >= value);
					return (TQuery) this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(uie => uie.DeletionHistory.InvokeDateUtc > value);
					return (TQuery) this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(uie => uie.DeletionHistory.InvokeDateUtc <= value);
					return (TQuery) this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(uie => uie.DeletionHistory.InvokeDateUtc < value);
					return (TQuery) this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TQuery WithDeleteDateUtcBetween(DateTime? from = null,
		                                       ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                       DateTime? to = null,
		                                       ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                       RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(uie => uie.DeletionHistory.InvokeDateUtc >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(uie => uie.DeletionHistory.InvokeDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(uie => uie.DeletionHistory.InvokeDateUtc <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(uie => uie.DeletionHistory.InvokeDateUtc == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(uie => uie.DeletionHistory.InvokeDateUtc <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(uie => uie.DeletionHistory.InvokeDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(uie => uie.DeletionHistory.InvokeDateUtc >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(uie => uie.DeletionHistory.InvokeDateUtc == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				default:
					throw new NotSupportedEnumException(@operator);
			}

			return (TQuery) this;
		}
	}
}