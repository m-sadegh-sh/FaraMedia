namespace FaraMedia.Services.Querying.Misc {
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain;
	using FaraMedia.Core.Domain.Misc;
	using FaraMedia.Core.Domain.Security;
	using FaraMedia.Core.Operators;

	public sealed class TicketQuery : EntityQueryBase<Ticket, TicketQuery> {
		public TicketQuery(IEnumerable<Ticket> entities) : base(entities) {}

		public TicketQuery(IQueryable<Ticket> entities) : base(entities) {}

		public TicketQuery WithOpener(User value = null,
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
					Entities = Entities.Where(t => t.Opener == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(t => t.Opener != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TicketQuery WithOpenerId(long? value = null,
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
					Entities = Entities.Where(t => t.Opener.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(t => t.Opener.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(t => t.Opener.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(t => t.Opener.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(t => t.Opener.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(t => t.Opener.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TicketQuery WithOpenDateUtc(DateTime? value = null,
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
					Entities = Entities.Where(t => t.OpenDateUtc == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(t => t.OpenDateUtc != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(t => t.OpenDateUtc >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(t => t.OpenDateUtc > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(t => t.OpenDateUtc <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(t => t.OpenDateUtc < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TicketQuery WithOpenDateUtcBetween(DateTime? from = null,
		                                          ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                          DateTime? to = null,
		                                          ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                          RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(t => t.OpenDateUtc >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(t => t.OpenDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(t => t.OpenDateUtc <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(t => t.OpenDateUtc == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(t => t.OpenDateUtc <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(t => t.OpenDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(t => t.OpenDateUtc >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(t => t.OpenDateUtc == to);
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

		public TicketQuery WithSubject(string value = null,
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
							Entities = Entities.Where(t => t.Subject == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(t => t.Subject.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(t => value.Contains(t.Subject));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(t => t.Subject.Contains(value) || value.Contains(t.Subject));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(t => t.Subject.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(t => value.StartsWith(t.Subject));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(t => t.Subject.StartsWith(value) || value.StartsWith(t.Subject));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(t => t.Subject.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(t => value.EndsWith(t.Subject));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(t => t.Subject.EndsWith(value) || value.EndsWith(t.Subject));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TicketQuery WithBody(string value = null,
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
							Entities = Entities.Where(t => t.Body == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(t => t.Body.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(t => value.Contains(t.Body));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(t => t.Body.Contains(value) || value.Contains(t.Body));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(t => t.Body.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(t => value.StartsWith(t.Body));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(t => t.Body.StartsWith(value) || value.StartsWith(t.Body));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(t => t.Body.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(t => value.EndsWith(t.Body));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(t => t.Body.EndsWith(value) || value.EndsWith(t.Body));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TicketQuery WithDepartment(TicketDepartment value = null,
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
					Entities = Entities.Where(t => t.Department == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(t => t.Department != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TicketQuery WithDepartmentId(long? value = null,
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
					Entities = Entities.Where(t => t.Department.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(t => t.Department.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(t => t.Department.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(t => t.Department.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(t => t.Department.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(t => t.Department.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TicketQuery WithCheckPriority(Priority? value = null,
		                                     ArgumentEvaluationMode mode = ArgumentEvaluationMode.IgnoreNeutral,
		                                     EnumOperator @operator = EnumOperator.Equal) {
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
				case EnumOperator.Equal:
					Entities = Entities.Where(t => t.CheckPriority == value);
					return this;

				case EnumOperator.NotEqual:
					Entities = Entities.Where(t => t.CheckPriority != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TicketQuery WithStatus(TicketStatus value = null,
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
					Entities = Entities.Where(t => t.Status == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(t => t.Status != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TicketQuery WithStatusId(long? value = null,
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
					Entities = Entities.Where(t => t.Status.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(t => t.Status.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(t => t.Status.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(t => t.Status.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(t => t.Status.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(t => t.Status.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TicketQuery WithResponse(TicketResponse value = null,
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
							Entities = Entities.Where(t => t.Responses.Any(tr => tr == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(t => t.Responses.All(tr => tr == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(t => t.Responses.Any(tr => tr != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(t => t.Responses.All(tr => tr != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TicketQuery WithResponseId(long? value = null,
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
							Entities = Entities.Where(t => t.Responses.Any(tr => tr.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(t => t.Responses.All(tr => tr.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(t => t.Responses.Any(tr => tr.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(t => t.Responses.All(tr => tr.Id != value));
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