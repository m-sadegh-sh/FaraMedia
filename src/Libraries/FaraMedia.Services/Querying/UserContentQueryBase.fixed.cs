namespace FaraMedia.Services.Querying {
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain;
	using FaraMedia.Core.Domain.Security;
	using FaraMedia.Core.Operators;

	public abstract class UserContentQueryBase<TEntity, TQuery> : EntityQueryBase<TEntity, TQuery> where TEntity : UserContentBase
	                                                                                               where TQuery : UserContentQueryBase<TEntity, TQuery> {
		protected UserContentQueryBase(IEnumerable<TEntity> entities) : base(entities) {}

		protected UserContentQueryBase(IQueryable<TEntity> entities) : base(entities) {}

		public TQuery WithCreator(User value = null,
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
					Entities = Entities.Where(uc => uc.CreationHistory.Invoker == value);
					return (TQuery) this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(uc => uc.CreationHistory.Invoker != value);
					return (TQuery) this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TQuery WithCreatorId(long? value = null,
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
					Entities = Entities.Where(uc => uc.CreationHistory.Invoker.Id == value);
					return (TQuery) this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(uc => uc.CreationHistory.Invoker.Id != value);
					return (TQuery) this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(uc => uc.CreationHistory.Invoker.Id >= value);
					return (TQuery) this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(uc => uc.CreationHistory.Invoker.Id > value);
					return (TQuery) this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(uc => uc.CreationHistory.Invoker.Id <= value);
					return (TQuery) this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(uc => uc.CreationHistory.Invoker.Id < value);
					return (TQuery) this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TQuery WithCreatorIdBetween(long? from = null,
		                                   ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                   long? to = null,
		                                   ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                   RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(uc => uc.CreationHistory.Invoker.Id >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(uc => uc.CreationHistory.Invoker.Id == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(uc => uc.CreationHistory.Invoker.Id <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(uc => uc.CreationHistory.Invoker.Id == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(uc => uc.CreationHistory.Invoker.Id <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(uc => uc.CreationHistory.Invoker.Id == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(uc => uc.CreationHistory.Invoker.Id >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(uc => uc.CreationHistory.Invoker.Id == to);
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

		public TQuery WithCreatorIp(string value = null,
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
							Entities = Entities.Where(uc => uc.CreationHistory.InvokerIp == value);
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(uc => uc.CreationHistory.InvokerIp.Contains(value));
							return (TQuery) this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(uc => value.Contains(uc.CreationHistory.InvokerIp));
							return (TQuery) this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(uc => uc.CreationHistory.InvokerIp.Contains(value) || value.Contains(uc.CreationHistory.InvokerIp));
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(uc => uc.CreationHistory.InvokerIp.StartsWith(value));
							return (TQuery) this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(uc => value.StartsWith(uc.CreationHistory.InvokerIp));
							return (TQuery) this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(uc => uc.CreationHistory.InvokerIp.StartsWith(value) || value.StartsWith(uc.CreationHistory.InvokerIp));
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(uc => uc.CreationHistory.InvokerIp.EndsWith(value));
							return (TQuery) this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(uc => value.EndsWith(uc.CreationHistory.InvokerIp));
							return (TQuery) this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(uc => uc.CreationHistory.InvokerIp.EndsWith(value) || value.EndsWith(uc.CreationHistory.InvokerIp));
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TQuery WithCreateDateUtc(DateTime? value = null,
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
					Entities = Entities.Where(uc => uc.CreationHistory.InvokeDateUtc == value);
					return (TQuery) this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(uc => uc.CreationHistory.InvokeDateUtc != value);
					return (TQuery) this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(uc => uc.CreationHistory.InvokeDateUtc >= value);
					return (TQuery) this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(uc => uc.CreationHistory.InvokeDateUtc > value);
					return (TQuery) this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(uc => uc.CreationHistory.InvokeDateUtc <= value);
					return (TQuery) this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(uc => uc.CreationHistory.InvokeDateUtc < value);
					return (TQuery) this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TQuery WithCreateDateUtcBetween(DateTime? from = null,
		                                       ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                       DateTime? to = null,
		                                       ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                       RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(uc => uc.CreationHistory.InvokeDateUtc >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(uc => uc.CreationHistory.InvokeDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(uc => uc.CreationHistory.InvokeDateUtc <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(uc => uc.CreationHistory.InvokeDateUtc == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(uc => uc.CreationHistory.InvokeDateUtc <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(uc => uc.CreationHistory.InvokeDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(uc => uc.CreationHistory.InvokeDateUtc >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(uc => uc.CreationHistory.InvokeDateUtc == to);
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

		public TQuery WithLastModifier(User value = null,
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
					Entities = Entities.Where(uc => uc.ModificationHistory.Invoker == value);
					return (TQuery) this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(uc => uc.ModificationHistory.Invoker != value);
					return (TQuery) this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TQuery WithLastModifierId(long? value = null,
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
					Entities = Entities.Where(uc => uc.ModificationHistory.Invoker.Id == value);
					return (TQuery) this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(uc => uc.ModificationHistory.Invoker.Id != value);
					return (TQuery) this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(uc => uc.ModificationHistory.Invoker.Id >= value);
					return (TQuery) this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(uc => uc.ModificationHistory.Invoker.Id > value);
					return (TQuery) this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(uc => uc.ModificationHistory.Invoker.Id <= value);
					return (TQuery) this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(uc => uc.CreationHistory.Invoker.Id < value);
					return (TQuery) this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TQuery WithLastModifierIdBetween(long? from = null,
		                                        ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                        long? to = null,
		                                        ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                        RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(uc => uc.ModificationHistory.Invoker.Id >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(uc => uc.ModificationHistory.Invoker.Id == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(uc => uc.ModificationHistory.Invoker.Id <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(uc => uc.ModificationHistory.Invoker.Id == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(uc => uc.ModificationHistory.Invoker.Id <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(uc => uc.ModificationHistory.Invoker.Id == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(uc => uc.ModificationHistory.Invoker.Id >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(uc => uc.ModificationHistory.Invoker.Id == to);
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

		public TQuery WithLastModifierIp(string value = null,
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
							Entities = Entities.Where(uc => uc.ModificationHistory.InvokerIp == value);
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(uc => uc.ModificationHistory.InvokerIp.Contains(value));
							return (TQuery) this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(uc => value.Contains(uc.ModificationHistory.InvokerIp));
							return (TQuery) this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(uc => uc.ModificationHistory.InvokerIp.Contains(value) || value.Contains(uc.ModificationHistory.InvokerIp));
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(uc => uc.ModificationHistory.InvokerIp.StartsWith(value));
							return (TQuery) this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(uc => value.StartsWith(uc.ModificationHistory.InvokerIp));
							return (TQuery) this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(uc => uc.ModificationHistory.InvokerIp.StartsWith(value) || value.StartsWith(uc.ModificationHistory.InvokerIp));
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(uc => uc.ModificationHistory.InvokerIp.EndsWith(value));
							return (TQuery) this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(uc => value.EndsWith(uc.ModificationHistory.InvokerIp));
							return (TQuery) this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(uc => uc.ModificationHistory.InvokerIp.EndsWith(value) || value.EndsWith(uc.ModificationHistory.InvokerIp));
							return (TQuery) this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TQuery WithLastModifyDateUtc(DateTime? value = null,
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
					Entities = Entities.Where(uc => uc.ModificationHistory.InvokeDateUtc == value);
					return (TQuery) this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(uc => uc.ModificationHistory.InvokeDateUtc != value);
					return (TQuery) this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(uc => uc.ModificationHistory.InvokeDateUtc >= value);
					return (TQuery) this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(uc => uc.ModificationHistory.InvokeDateUtc > value);
					return (TQuery) this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(uc => uc.ModificationHistory.InvokeDateUtc <= value);
					return (TQuery) this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(uc => uc.ModificationHistory.InvokeDateUtc < value);
					return (TQuery) this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TQuery WithLastModifyDateUtcBetween(DateTime? from = null,
		                                           ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                           DateTime? to = null,
		                                           ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                           RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(uc => uc.ModificationHistory.InvokeDateUtc >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(uc => uc.ModificationHistory.InvokeDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(uc => uc.ModificationHistory.InvokeDateUtc <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(uc => uc.ModificationHistory.InvokeDateUtc == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(uc => uc.ModificationHistory.InvokeDateUtc <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(uc => uc.ModificationHistory.InvokeDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(uc => uc.ModificationHistory.InvokeDateUtc >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(uc => uc.ModificationHistory.InvokeDateUtc == to);
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