namespace FaraMedia.Services.Querying.ContentManagement {
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.ContentManagement;
	using FaraMedia.Core.Operators;

	public sealed class PollChoiceQuery : EntityQueryBase<PollChoice, PollChoiceQuery> {
		public PollChoiceQuery(IEnumerable<PollChoice> entities) : base(entities) {}

		public PollChoiceQuery(IQueryable<PollChoice> entities) : base(entities) {}

		public PollChoiceQuery WithTitle(string value = null,
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
							Entities = Entities.Where(pc => pc.Title == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(pc => pc.Title.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(pc => value.Contains(pc.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(pc => pc.Title.Contains(value) || value.Contains(pc.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(pc => pc.Title.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(pc => value.StartsWith(pc.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(pc => pc.Title.StartsWith(value) || value.StartsWith(pc.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(pc => pc.Title.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(pc => value.EndsWith(pc.Title));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(pc => pc.Title.EndsWith(value) || value.EndsWith(pc.Title));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PollChoiceQuery WithDescription(string value = null,
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
							Entities = Entities.Where(pc => pc.Description == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(pc => pc.Description.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(pc => value.Contains(pc.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(pc => pc.Description.Contains(value) || value.Contains(pc.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(pc => pc.Description.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(pc => value.StartsWith(pc.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(pc => pc.Description.StartsWith(value) || value.StartsWith(pc.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(pc => pc.Description.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(pc => value.EndsWith(pc.Description));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(pc => pc.Description.EndsWith(value) || value.EndsWith(pc.Description));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PollChoiceQuery WithIsMultiSelection(bool? value = null,
		                                            ArgumentEvaluationMode mode = ArgumentEvaluationMode.IgnoreNeutral,
		                                            BoolOperator @operator = BoolOperator.Equal) {
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
				case BoolOperator.Equal:
					Entities = Entities.Where(pc => pc.IsMultiSelection == value);
					return this;

				case BoolOperator.NotEqual:
					Entities = Entities.Where(pc => pc.IsMultiSelection != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PollChoiceQuery WithPoll(Poll value = null,
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
					Entities = Entities.Where(pc => pc.Poll == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(pc => pc.Poll != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PollChoiceQuery WithPollId(long? value = null,
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
					Entities = Entities.Where(pc => pc.Poll.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(pc => pc.Poll.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(pc => pc.Poll.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(pc => pc.Poll.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(pc => pc.Poll.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(pc => pc.Poll.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PollChoiceQuery WithItem(PollChoiceItem value = null,
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
							Entities = Entities.Where(pc => pc.Items.Any(pci => pci == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(pc => pc.Items.All(pci => pci == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(pc => pc.Items.Any(pci => pci != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(pc => pc.Items.All(pci => pci != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public PollChoiceQuery WithItemId(long? value = null,
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
							Entities = Entities.Where(pc => pc.Items.Any(pci => pci.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(pc => pc.Items.All(pci => pci.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(pc => pc.Items.Any(pci => pci.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(pc => pc.Items.All(pci => pci.Id != value));
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