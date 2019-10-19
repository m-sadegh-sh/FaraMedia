namespace FaraMedia.Services.Querying.ContentManagement {
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.ContentManagement;
	using FaraMedia.Core.Domain.Security;
	using FaraMedia.Core.Operators;

	public sealed class PollVotingRecordQuery : EntityQueryBase<PollVotingRecord, PollVotingRecordQuery> {
		public PollVotingRecordQuery(IEnumerable<PollVotingRecord> entities) : base(entities) {}

		public PollVotingRecordQuery(IQueryable<PollVotingRecord> entities) : base(entities) {}

		public PollVotingRecordQuery WithPoll(Poll value = null,
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
					Entities = Entities.Where(pvr => pvr.SelectedItem.Choice.Poll == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(pvr => pvr.SelectedItem.Choice.Poll != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PollVotingRecordQuery WithPollId(long? value = null,
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
					Entities = Entities.Where(pvr => pvr.SelectedItem.Choice.Poll.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(pvr => pvr.SelectedItem.Choice.Poll.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(pvr => pvr.SelectedItem.Choice.Poll.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(pvr => pvr.SelectedItem.Choice.Poll.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(pvr => pvr.SelectedItem.Choice.Poll.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(pvr => pvr.SelectedItem.Choice.Poll.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PollVotingRecordQuery WithVoter(User value = null,
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
					Entities = Entities.Where(pvr => pvr.Voter == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(pvr => pvr.Voter != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PollVotingRecordQuery WithVoterId(long? value = null,
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
					Entities = Entities.Where(pvr => pvr.Voter.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(pvr => pvr.Voter.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(pvr => pvr.Voter.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(pvr => pvr.Voter.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(pvr => pvr.Voter.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(pvr => pvr.Voter.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PollVotingRecordQuery WithVoterIp(string value = null,
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
							Entities = Entities.Where(pvr => pvr.VoterIp == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(pvr => pvr.VoterIp.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(pvr => value.Contains(pvr.VoterIp));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(pvr => pvr.VoterIp.Contains(value) || value.Contains(pvr.VoterIp));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(pvr => pvr.VoterIp.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(pvr => value.StartsWith(pvr.VoterIp));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(pvr => pvr.VoterIp.StartsWith(value) || value.StartsWith(pvr.VoterIp));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(pvr => pvr.VoterIp.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(pvr => value.EndsWith(pvr.VoterIp));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(pvr => pvr.VoterIp.EndsWith(value) || value.EndsWith(pvr.VoterIp));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PollVotingRecordQuery WithVoteDateUtc(DateTime? value = null,
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
					Entities = Entities.Where(pvr => pvr.VoteDateUtc == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(pvr => pvr.VoteDateUtc != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(pvr => pvr.VoteDateUtc >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(pvr => pvr.VoteDateUtc > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(pvr => pvr.VoteDateUtc <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(pvr => pvr.VoteDateUtc < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PollVotingRecordQuery WithVoteDateUtcBetween(DateTime? from = null,
		                                                    ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                                    DateTime? to = null,
		                                                    ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                                    RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(pvr => pvr.VoteDateUtc >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(pvr => pvr.VoteDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(pvr => pvr.VoteDateUtc <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(pvr => pvr.VoteDateUtc == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(pvr => pvr.VoteDateUtc <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(pvr => pvr.VoteDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(pvr => pvr.VoteDateUtc >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(pvr => pvr.VoteDateUtc == to);
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

		public PollVotingRecordQuery WithSelectedItem(PollChoiceItem value = null,
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
					Entities = Entities.Where(pvr => pvr.SelectedItem == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(pvr => pvr.SelectedItem != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PollVotingRecordQuery WithSelectedItemId(long? value = null,
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
					Entities = Entities.Where(pvr => pvr.SelectedItem.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(pvr => pvr.SelectedItem.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(pvr => pvr.SelectedItem.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(pvr => pvr.SelectedItem.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(pvr => pvr.SelectedItem.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(pvr => pvr.SelectedItem.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}
	}
}