namespace FaraMedia.Services.Querying.Systematic {
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.Systematic;
	using FaraMedia.Core.Operators;

	public sealed class NewsletterSubscriptionQuery : EntityQueryBase<NewsletterSubscription, NewsletterSubscriptionQuery> {
		public NewsletterSubscriptionQuery(IEnumerable<NewsletterSubscription> entities) : base(entities) {}

		public NewsletterSubscriptionQuery(IQueryable<NewsletterSubscription> entities) : base(entities) {}

		public NewsletterSubscriptionQuery WithEmail(string value = null,
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
							Entities = Entities.Where(ns => ns.Email == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(ns => ns.Email.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(ns => value.Contains(ns.Email));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(ns => ns.Email.Contains(value) || value.Contains(ns.Email));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(ns => ns.Email.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(ns => value.StartsWith(ns.Email));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(ns => ns.Email.StartsWith(value) || value.StartsWith(ns.Email));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(ns => ns.Email.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(ns => value.EndsWith(ns.Email));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(ns => ns.Email.EndsWith(value) || value.EndsWith(ns.Email));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public NewsletterSubscriptionQuery WithGuid(Guid? value = null,
		                                            ArgumentEvaluationMode mode = ArgumentEvaluationMode.IgnoreNeutral,
		                                            GuidOperator @operator = GuidOperator.Equal) {
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
				case GuidOperator.Equal:
					Entities = Entities.Where(ns => ns.Guid == value);
					return this;

				case GuidOperator.NotEqual:
					Entities = Entities.Where(ns => ns.Guid != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}
	}
}