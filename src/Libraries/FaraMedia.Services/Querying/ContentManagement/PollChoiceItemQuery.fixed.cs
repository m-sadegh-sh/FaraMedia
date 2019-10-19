namespace FaraMedia.Services.Querying.ContentManagement {
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.ContentManagement;
	using FaraMedia.Core.Operators;

	public sealed class PollChoiceItemQuery : EntityQueryBase<PollChoiceItem, PollChoiceItemQuery> {
		public PollChoiceItemQuery(IEnumerable<PollChoiceItem> entities) : base(entities) {}

		public PollChoiceItemQuery(IQueryable<PollChoiceItem> entities) : base(entities) {}

		public PollChoiceItemQuery WithText(string value = null,
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
							Entities = Entities.Where(pci => pci.Text == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(pci => pci.Text.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(pci => value.Contains(pci.Text));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(pci => pci.Text.Contains(value) || value.Contains(pci.Text));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(pci => pci.Text.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(pci => value.StartsWith(pci.Text));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(pci => pci.Text.StartsWith(value) || value.StartsWith(pci.Text));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(pci => pci.Text.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(pci => value.EndsWith(pci.Text));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(pci => pci.Text.EndsWith(value) || value.EndsWith(pci.Text));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PollChoiceItemQuery WithChoice(PollChoice value = null,
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
					Entities = Entities.Where(pci => pci.Choice == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(pci => pci.Choice != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PollChoiceItemQuery WithChoiceId(long? value = null,
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
					Entities = Entities.Where(pci => pci.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(pci => pci.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(pci => pci.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(pci => pci.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(pci => pci.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(pci => pci.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PollChoiceItemQuery WithVotingRecord(PollVotingRecord value = null,
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
							Entities = Entities.Where(pci => pci.VotingRecords.Any(pvr => pvr == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(pci => pci.VotingRecords.All(pvr => pvr == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(pci => pci.VotingRecords.Any(pvr => pvr != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(pci => pci.VotingRecords.All(pvr => pvr != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PollChoiceItemQuery WithVotingRecordId(long? value = null,
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
							Entities = Entities.Where(pci => pci.VotingRecords.Any(pvr => pvr.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(pci => pci.VotingRecords.All(pvr => pvr.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(pci => pci.VotingRecords.Any(pvr => pvr.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(pci => pci.VotingRecords.All(pvr => pvr.Id != value));
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