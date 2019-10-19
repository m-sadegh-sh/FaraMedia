namespace FaraMedia.Services.Querying.Misc {
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.Misc;
	using FaraMedia.Core.Domain.Security;
	using FaraMedia.Core.Operators;

	public sealed class TicketResponseQuery : EntityQueryBase<TicketResponse, TicketResponseQuery> {
		public TicketResponseQuery(IEnumerable<TicketResponse> entities) : base(entities) {}

		public TicketResponseQuery(IQueryable<TicketResponse> entities) : base(entities) {}

		public TicketResponseQuery WithResponder(User value = null,
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
					Entities = Entities.Where(tr => tr.Responder == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(tr => tr.Responder != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TicketResponseQuery WithResponderId(long? value = null,
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
					Entities = Entities.Where(tr => tr.Responder.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(tr => tr.Responder.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(tr => tr.Responder.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(tr => tr.Responder.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(tr => tr.Responder.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(tr => tr.Responder.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TicketResponseQuery WithInResponseTo(Ticket value = null,
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
					Entities = Entities.Where(tr => tr.InResponseTo == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(tr => tr.InResponseTo != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TicketResponseQuery WithInResponseToId(long? value = null,
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
					Entities = Entities.Where(tr => tr.InResponseTo.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(tr => tr.InResponseTo.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(tr => tr.InResponseTo.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(tr => tr.InResponseTo.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(tr => tr.InResponseTo.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(tr => tr.InResponseTo.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TicketResponseQuery WithResponseDateUtc(DateTime? value = null,
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
					Entities = Entities.Where(tr => tr.ResponseDateUtc == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(tr => tr.ResponseDateUtc != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(tr => tr.ResponseDateUtc >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(tr => tr.ResponseDateUtc > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(tr => tr.ResponseDateUtc <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(tr => tr.ResponseDateUtc < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TicketResponseQuery WithResponseDateUtcBetween(DateTime? from = null,
		                                                      ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                                      DateTime? to = null,
		                                                      ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                                      RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(tr => tr.ResponseDateUtc >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(tr => tr.ResponseDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(tr => tr.ResponseDateUtc <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(tr => tr.ResponseDateUtc == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(tr => tr.ResponseDateUtc <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(tr => tr.ResponseDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(tr => tr.ResponseDateUtc >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(tr => tr.ResponseDateUtc == to);
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

		public TicketResponseQuery WithSubject(string value = null,
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
							Entities = Entities.Where(tr => tr.Subject == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(tr => tr.Subject.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(tr => value.Contains(tr.Subject));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(tr => tr.Subject.Contains(value) || value.Contains(tr.Subject));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(tr => tr.Subject.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(tr => value.StartsWith(tr.Subject));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(tr => tr.Subject.StartsWith(value) || value.StartsWith(tr.Subject));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(tr => tr.Subject.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(tr => value.EndsWith(tr.Subject));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(tr => tr.Subject.EndsWith(value) || value.EndsWith(tr.Subject));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public TicketResponseQuery WithBody(string value = null,
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
							Entities = Entities.Where(tr => tr.Body == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(tr => tr.Body.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(tr => value.Contains(tr.Body));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(tr => tr.Body.Contains(value) || value.Contains(tr.Body));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(tr => tr.Body.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(tr => value.StartsWith(tr.Body));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(tr => tr.Body.StartsWith(value) || value.StartsWith(tr.Body));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(tr => tr.Body.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(tr => value.EndsWith(tr.Body));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(tr => tr.Body.EndsWith(value) || value.EndsWith(tr.Body));
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